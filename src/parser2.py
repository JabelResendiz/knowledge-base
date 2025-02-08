import gzip
import re
from response import HTTPResponse
from utils import readline, CaseInsensitiveDict

class BadUrlError(Exception):
    pass

def parse_http_url(url):
    # Expresión regular para parsear la URL
    regex = r'^(http://)?([^:/\s]+)(?::(\d+))?(/[^?\s]*)?(\?[^#\s]*)?$'
    match = re.match(regex, url)
    
    if not match:
        raise BadUrlError(f"Invalid URL: {url}")
    
    scheme = match.group(1) or "http://"  # Si no tiene esquema, asignamos "http://"
    host = match.group(2)
    port = match.group(3) or 80  # Si no tiene puerto, asignamos el puerto por defecto 80
    path = match.group(4) or "/"  # Si no tiene path, asignamos "/"
    query = match.group(5) or ""  # Si no tiene query, dejamos como cadena vacía
    
    #Convertir el puerto a entero
    
    port = int(port)
    
    return (host,port,path,query)


def parse_response(method, conn):
    buffer, index = readline(conn)
    version, code, reason = map(str.strip, buffer.decode().split(" ", 2))
    # ignore \n
    index += 1
    
    buffer, index = readline(conn, index)
    headers = CaseInsensitiveDict()
    while buffer != b'\r':
        header, value = map(str.strip, buffer.decode().split(":", 1))
        headers[header] = value
        index += 1
        buffer, index = readline(conn, index)
    # ignore \r
    index += 1

    body = b''
    if "Content-Length" in headers:
        cl = int(headers.get("Content-Length", 0))
        while len(body) < cl and method != "HEAD":
            body += conn.recv(cl - len(body))
    elif headers.get("Transfer-Encoding") == "chunked":
        size, index = readline(conn, index)
        size = int(size, base=16) + 2 # size in hex + carrier return + \n
        body += conn.recv(size)
        index += size
        while size - 2:
            size, index = readline(conn, index)
            size = int(size, base=16) + 2 # size in hex + carrier return
            body += conn.recv(size)
            index += size

    # decode if needed
    # only gzip and identity are supported
    if headers.get("Content-Encoding") == "gzip":
        body = gzip.decompress(body)

    return HTTPResponse(
        version=version,
        code=code,
        reason=reason,
        headers=headers,
        body=body
    )
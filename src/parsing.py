import gzip
import re
from http_response import HTTPResponse
from exceptions import UrlIncorrect
from collections import defaultdict


class CaseInsensitiveDict(defaultdict):
    def __setitem__(self, key, value):
        super().__setitem__(key.lower(), value)

    def __getitem__(self, key):
        return super().__getitem__(key.lower())

    def __delitem__(self, key):
        super().__delitem__(key.lower())


class Http_Response:
    
    def __init__(self):
        self.url = url

def parse_http_url(url):
    # Expresión regular para parsear la URL
    regex = r'^(http://)?([^:/\s]+)(?::(\d+))?(/[^?\s]*)?(\?[^#\s]*)?$'
    match = re.match(regex, url)
    
    if not match:
        raise UrlIncorrect(f"Invalid URL: {url}")
    
    scheme = match.group(1) or "http://"  # Si no tiene esquema, asignamos "http://"
    host = match.group(2)
    port = match.group(3) or 80  # Si no tiene puerto, asignamos el puerto por defecto 80
    path = match.group(4) or "/"  # Si no tiene path, asignamos "/"
    query = match.group(5) or ""  # Si no tiene query, dejamos como cadena vacía
    
    #Convertir el puerto a entero
    
    port = int(port)
    
    return (host,port,path,query)



def _readline(connection,index=0):
    """Lee una línea de datos del socket sin usar un índice."""
    buffer = bytearray()
    while True:
        char = connection.recv(1)
        if char == b"\n":
            break
        buffer.extend(char)
        index +=1
    return bytes(buffer).strip(),index



def parse_http_response(method, conn):
    
    # Leer las primeras lineas
    buffer, index = _readline(conn)
    version, code, reason = map(str.strip, buffer.decode().split(" ", 2))
    # ignore \n
    index += 1
    
    # Leer encabezados
    buffer, index = _readline(conn, index)
    headers = CaseInsensitiveDict()
    
    while buffer != b'\r':
        header, value = map(str.strip, buffer.decode().split(":", 1))
        headers[header] = value
        index += 1
        buffer, index = _readline(conn, index)
    # ignore \r
    index += 1
    
    # leer el cuerpo de la respuesta
    body = b''
    if "Content-Length" in headers:
        cl = int(headers.get("Content-Length", 0))
        while len(body) < cl and method != "HEAD":
            body += conn.recv(cl - len(body))
    elif headers.get("Transfer-Encoding") == "chunked":
        size, index = _readline(conn, index)
        size = int(size, base=16) + 2 # size in hex + carrier return + \n
        body += conn.recv(size)
        index += size
        while size - 2:
            size, index = _readline(conn, index)
            size = int(size, base=16) + 2 # size in hex + carrier return
            body += conn.recv(size)
            index += size

    # descompresion si es necesario
    if headers.get("Content-Encoding") == "gzip":
        body = gzip.decompress(body)

    
    # devolver la respuesta HTTP
    return HTTPResponse(
        version=version,
        code=code,
        reason=reason,
        headers=headers,
        body=body
    )
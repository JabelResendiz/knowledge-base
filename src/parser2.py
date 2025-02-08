# import re
# import gzip
# from response import HTTPResponse
# from collections import defaultdict




# def read_line(conn):
#     """ Lee una línea completa desde el socket. """
#     line = b""
#     while True:
#         chunk = conn.recv(1)
#         if not chunk or chunk == b"\n":
#             break
#         line += chunk
#     return line.strip()  # Eliminamos espacios y retornos de línea

# def read_headers(conn):
#     """ Lee los encabezados HTTP y los devuelve en un diccionario. """
#     headers = defaultdict(str)
#     while True:
#         line = read_line(conn)
#         if not line:
#             break  # Fin de los encabezados
#         try:
#             key, value = line.decode().split(":", 1)
#             headers[key.strip()] = value.strip()
#         except ValueError:
#             #logger.warning("Encabezado HTTP mal formado: %s", line)
#     return headers

# def read_body(conn, headers, method):
#     """ Lee el cuerpo de la respuesta según Content-Length o Transfer-Encoding. """
#     body = b""

#    # Leer cuerpo basado en Content-Length
#     if "Content-Length" in headers:
#         length = int(headers["Content-Length"])
#         while len(body) < length:
#             body += conn.recv(length - len(body))
    
#     #Leer cuerpo basado en Transfer-Encoding: chunked
#     elif headers.get("Transfer-Encoding") == "chunked":
#         while True:
#             size_line = read_line(conn)
#             if not size_line:
#                 break
#             try:
#                 chunk_size = int(size_line, 16)  # Convertir de hexadecimal a entero
#             except ValueError:
#                 logger.warning("Error al leer chunk size: %s", size_line)
#                 break
            
#             if chunk_size == 0:
#                 break  # Fin de los chunks
            
#             chunk_data = conn.recv(chunk_size)
#             body += chunk_data
#             read_line(conn)  # Consumir la línea vacía después del chunk

#     #Descomprimir si está en gzip
#     if headers.get("Content-Encoding") == "gzip":
#         try:
#             body = gzip.decompress(body)
#         except gzip.BadGzipFile:
#             logger.warning("Error al descomprimir GZIP")

#     return body

# def parse_response(method, conn):
#     """ Parsea la respuesta HTTP del servidor. """
#    # Leer línea de estado HTTP
#     status_line = read_line(conn).decode()
#     try:
#         version, code, reason = status_line.split(" ", 2)
#     except ValueError:
#         logger.error("Línea de estado mal formada: %s", status_line)
#         return None

#     headers = read_headers(conn)
#     body = read_body(conn, headers, method) if method != "HEAD" else b""

#     return HTTPResponse(version, code, reason, headers, body)

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
        # sometimes it sends an incomplete response
        # it will hang if c-l is wrong
        # NOTE HEAD request returns c-l as if it were a
        # GET so it will hang as well
        # https://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.13
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
import gzip
import re
from http_response import HTTPResponse
from exceptions import UrlIncorrect

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



def _readline(connection, index=0):
    # inicializar un buffer vacio
    buffer = b''
    
    while True:
        c = connection.recv(1) # recibe un byte
        
        if c == b'\n': # si es un slato de linea
            break
        
        buffer +=c
        index +=1
        
    return buffer, index


def categorize_args(args):
    final_args = []
    merged_headers = []
    merged_data = []
    header_index = False
    data_index = False
    for i in args:
        if i == "-h":
            if data_index:
                final_args.append(" ".join(merged_data))
                merged_data = []
            data_index = False
            header_index = True
            final_args.append(i)
            continue
        elif i == "-d":
            if header_index:
                final_args.append(" ".join(merged_headers))
                merged_data = []
            data_index = True
            header_index = False
            final_args.append(i)
            continue


        if header_index:
            merged_headers.append(i)
        elif data_index:
            merged_data.append(i)
        else:
            final_args.append(i)

    if header_index:
        final_args.append(" ".join(merged_headers))
    elif data_index:
        final_args.append(" ".join(merged_data))
        
    return final_args

def parse_http_response(method, conn):
    
    # Leer las primeras lineas
    buffer, index = _readline(conn)
    version, code, reason = map(str.strip, buffer.decode().split(" ", 2))
    
    index += 1
    
    # Leer encabezados
    buffer, index = _readline(conn, index)
    headers = {}
    
    while buffer != b'\r':
        # Decodificar y dividir el encabezado y su valor
        header, value = map(str.strip, buffer.decode().split(":", 1))
        
         # Convertir tanto la clave (header) como el valor (value) a minúsculas
        header= header.lower()
        value = value.lower()
        headers[header] = value
        
        # Leer la siguiente línea del socket
        index += 1
        buffer, index = _readline(conn, index)
    index += 1
    
    # leer el cuerpo de la respuesta
    body = b''
    
    if "content-length" in headers:
        lg = int(headers.get("content-length", 0))
        while len(body) < lg and method != "HEAD":
            body += conn.recv(lg - len(body))
            
    elif headers.get("transfer-encoding") == "chunked":
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
    if headers.get("content-encoding") == "gzip":
        body = gzip.decompress(body)

    
    # devolver la respuesta HTTP
    return HTTPResponse(
        version=version,
        code=code,
        reason=reason,
        headers=headers,
        body=body
    )
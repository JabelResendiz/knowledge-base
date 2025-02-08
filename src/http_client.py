import socket
import re
import gzip
import logging
from collections import defaultdict
from response import HTTPResponse
from parser2 import parse_http_url,parse_response

# GLOBAL VARIABLES
_versionHttp = 'HTTP/1.1'
default_port = 80

logging.basicConfig(
    level=logging.WARNING,
    format='%(asctime)s - %(levelname)s - %(message)s'
)


class HttpClient:
    
    def __init__(self,host: "IP", port :int, timeout=socket._GLOBAL_DEFAULT_TIMEOUT, blocksize = 8192):
        
        self.host = host
        self.port = port
        self.timeout = timeout
        
        self.mySocket = None
        self.blocksize = blocksize
    
    # se hace uso del protocolo TCP/IP
    def connect (self):
       self.mySocket = socket.create_connection((self.host,self.port),self.timeout)
       #logger.info("INFO - conexión a %s:%s ha sido exitosa" , self.host, self.port) 
    
    def request(self,method,url,body="", headers= None):
        
        headers = headers or {}
        headers["Host"]= headers.get("Host",self.host)
        headers["Content-Length"] = str(len(body))
        headers["Accept-Encodding"] =headers.get("Accept-Encoding", "identity") # sin compresion
        headers["Connection"] = "close" # se cierra la conexion despues de recibir la respuesta

        # construir la solicitud HTTP
        
        request= f"{method.upper()} {url} {_versionHttp}\r\n"
        
        # agregar los encabezados
        
        for header, value in headers.items():
            request += f"{header}: {value}\r\n"
        
        if body:
            request+= f"\r\n{body}\r\n"
        
        request += "\r\n"
        
        # converite la solicitud a bytes porque socket trabaja con binarios
        self.send(request.encode())
        
    
    def send(self,data):
        if not self.mySocket:
            raise Exception()

        logging.info("INFO - sending\n%s", data)
        
        self.mySocket.sendall(data)
    
    def close(self):
        if self.mySocket: # si el socket esta abierto
            self.mySocket.close()
            self.mySocket = None

    def receive(self,count= 1024):
        # recibir hasta count bytes del servidor
        return self.mySocket.recv(count)
  
  
def request (method="GET",url="/",headers = None,body =""):
    host,port,path,query = parse_http_url(url)
    
    conn = HttpClient(host,port)
    
    res= None
    data = None
    
    try:
        conn.connect()
        conn.request(method,path+query, headers=headers,body=body)
        data= parse_response (method,conn.mySocket)
    
    finally:
        conn.close()
    
    logging.debug("%s %s %s", data, data.body, data.headers)
    
    return data
    

if __name__ == "__main__":
    #URL = "http://httpbin.org/"
    URL = "http://www.cubadebate.cu/"
    #URL = "http://127.0.0.1:8000"
    #URL = "http://anglesharp.azurewebsites.net/Chunked" # chunk
    #URL = "http://www.whatsmyip.org/

    # r
    res = request("GET", URL, headers={"Accept-Encoding": "gzip"})
    print(res)
    #res.visualise()

    URL = "http://anglesharp.azurewebsites.net/Chunked" # chunk
    res = request("GET", URL)
    print(res)
    #res.visualise()

    URL = "http://httpbin.org/"
    res = request("GET", URL, headers={"User-Agent": "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36"})
    print(res)
    #res.visualise()

    res = request("HEAD", URL)
    print(res, res.headers)
    res = request("OPTIONS", URL)
    print(res, res.headers)

    URL = "http://httpbin.org/status/100"
    res = request("DELETE", URL)
    print(res, res.headers, res.reason, res.body)

    URL = "http://httpbin.org/anything"
    res = request("POST", URL, body="blob doko")
    print(res, res.headers, res.reason, res.body)
    res = request("PATCH", URL, body="skipped all the text")
    print(res, res.headers, res.reason, res.body)
    res = request("PUT", URL, body="dodo")
    print(res, res.headers, res.reason, res.body)
    URL = "http://47.251.122.81:8888"
    res = request("CONNECT", URL, body="dodo")
    print(res, res.headers, res.reason, res.body)

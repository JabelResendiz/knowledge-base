import socket
from threading import Thread
import gzip
import datetime
from termcolor import colored

# Configuración del servidor
HOST = '0.0.0.0'  # Escucha en todas las interfaces
PORT = 8000        # Puerto del servidor
VERSION = 'HTTP/1.1'  #Version

class HTTPServer:
    def __init__(self, host, port):
        self.host = host
        self.port = port

    def start(self):
        """Inicia el servidor y acepta conexiones entrantes en hilos separados."""
        server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)  # Permite reutilizar el puerto
        server_socket.bind((self.host, self.port))
        server_socket.listen(5)

        print(colored(f"Servidor HTTP en {self.host}:{self.port}"))

        while True:
            client_socket, client_address = server_socket.accept()
            print(colored(f"Conexión entrante desde {client_address}"))
            thread = Thread(target=self.handle_client, args=(client_socket,))
            thread.start()

    def handle_client(self, client_socket):
        """Maneja una conexión entrante procesando la solicitud HTTP y enviando una respuesta."""
        try:
            request_data = client_socket.recv(1024).decode()
            if not request_data:
                client_socket.close()
                return

            response = self.handle_request(request_data)
            client_socket.sendall(response.encode())

        except Exception as e:
            print(colored(f"Error al procesar la solicitud: {e}"))

        finally:
            client_socket.close()

    def handle_request(self, request):
        """Procesa la solicitud HTTP y genera la respuesta adecuada."""
        try:
            lines = request.split("\r\n")
            request_line = lines[0].split(" ")
            method, path, _ = request_line

            headers = self.parse_headers(lines[1:])
            body = ""

            if "Content-Length" in headers:
                body_length = int(headers["Content-Length"])
                body = request[-body_length:]  # Extraer el cuerpo del mensaje si existe

            return self.build_response(method, path, headers, body)

        except Exception:
            return self.http_response(400, "Bad Request", "Invalid request format.")

    def parse_headers(self, header_lines):
        """Convierte líneas de encabezados HTTP en un diccionario."""
        headers = {}
        for line in header_lines:
            if ": " in line:
                key, value = line.split(": ", 1)
                headers[key] = value
        return headers

    def build_response(self, method, path, headers, body):
        """Genera respuestas HTTP según el método y la ruta solicitada."""
        if method == "GET":
            return self.http_response(200, "OK", "Hello, GET!")

        elif method == "POST":
            return self.http_response(200, "OK", f"Received POST: {body}")

        elif method == "HEAD":
            return self.http_response(200, "OK", "", include_body=False)

        elif method == "PUT":
            return self.http_response(200, "OK", "PUT request successful!")

        elif method == "DELETE":
            return self.http_response(200, "OK", "DELETE request successful!")

        elif method == "OPTIONS":
            return self.http_response(200, "OK", "", headers={"Allow": "OPTIONS, GET, POST, HEAD, PUT, DELETE, TRACE, CONNECT"})

        elif method == "TRACE":
            return self.http_response(200, "OK", f"TRACE received:\n{headers}")

        else:
            return self.http_response(405, "Method Not Allowed", "This method is not supported.")

    def http_response(self, status_code, reason, body, headers=None, include_body=True):
        """Construye una respuesta HTTP válida con headers y cuerpo."""
        headers = headers or {}
        headers["Server"] = "CustomHTTPServer/1.0"
        headers["Date"] = datetime.datetime.now(datetime.timezone.utc).strftime("%a, %d %b %Y %H:%M:%S GMT")

        # Verificar si el cliente acepta gzip
        accepts_gzip = "accept-encoding" in headers and "gzip" in headers["accept-encoding"]

        if include_body:
            body_bytes = body.encode()
            
            if accepts_gzip:  # Si el cliente acepta gzip, comprimir la respuesta
                body_bytes = gzip.compress(body_bytes)
                headers["Content-Encoding"] = "gzip"  # Informar que está comprimido

            headers["Content-Length"] = str(len(body_bytes))
        else:
            body_bytes = b""

        response = f"{VERSION} {status_code} {reason}\r\n"
        for key, value in headers.items():
            response += f"{key}: {value}\r\n"
        response += "\r\n"

        print(colored(response + body_bytes.decode()))
        return response + body_bytes.decode()

# Ejecutar el servidor
if __name__ == "__main__":
    server = HTTPServer(HOST, PORT)
    server.start()



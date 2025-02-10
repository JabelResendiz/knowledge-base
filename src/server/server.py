import socket

HOST = "0.0.0.0"  # Acepta conexiones de cualquier IP
PORT = 8080  # Puerto en el que escuchará el servidor

def handle_request(request):
    """Maneja una solicitud HTTP y devuelve una respuesta adecuada."""
    lines = request.split("\r\n")
    request_line = lines[0]  # Primera línea contiene el método y la ruta
    method, path, _ = request_line.split(" ")

    if method == "GET" and path == "/":
        response_body = '{"status": 200, "body": "Welcome to the server!"}'
        response_headers = "HTTP/1.1 200 OK\r\nContent-Type: application/json\r\n\r\n"
        return response_headers + response_body

    elif method == "POST" and path == "/":
        response_body = '{"status": 200, "body": "POST request successful"}'
        response_headers = "HTTP/1.1 200 OK\r\nContent-Type: application/json\r\n\r\n"
        return response_headers + response_body

    elif method == "HEAD" and path == "/":
        return "HTTP/1.1 200 OK\r\n\r\n"

    elif method == "PUT" and path == "/resource":
        response_body = '{"status": 200, "body": "PUT request successful!"}'
        response_headers = "HTTP/1.1 200 OK\r\nContent-Type: application/json\r\n\r\n"
        return response_headers + response_body

    elif method == "DELETE" and path == "/resource":
        response_body = '{"status": 200, "body": "DELETE request successful!"}'
        response_headers = "HTTP/1.1 200 OK\r\nContent-Type: application/json\r\n\r\n"
        return response_headers + response_body

    else:
        return "HTTP/1.1 404 Not Found\r\nContent-Type: text/plain\r\n\r\nPage not found"

# Configurar el socket del servidor
server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server_socket.bind((HOST, PORT))
server_socket.listen(5)  # Permite hasta 5 conexiones en cola

print(f"Servidor corriendo en http://{HOST}:{PORT}/")

while True:
    
    # espera una conexion entrante
    client_socket, client_address = server_socket.accept()
    print(f"Conexión establecida con {client_address}")

    # lee la solicitud HTTP del cliente (hasta 1024 bytes)
    request_data = client_socket.recv(1024).decode()
    print(f"Solicitud recibida:\n{request_data}")

    
    # llama a la funcion handle_request
    if request_data:
        response = handle_request(request_data)
        client_socket.sendall(response.encode())

    client_socket.close()

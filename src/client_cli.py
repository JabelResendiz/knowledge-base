import argparse
import json
import sys
from http_client import  final_request
from http_response import HTTPResponse
from parsing import categorize_args

# def fix(args):
#     final_args = []
#     merged_headers = []
#     merged_data = []
#     header_index = False
#     data_index = False
#     for i in args:
#         if i == "-h":
#             if data_index:
#                 final_args.append(" ".join(merged_data))
#                 merged_data = []
#             data_index = False
#             header_index = True
#             final_args.append(i)
#             continue
#         elif i == "-d":
#             if header_index:
#                 final_args.append(" ".join(merged_headers))
#                 merged_data = []
#             data_index = True
#             header_index = False
#             final_args.append(i)
#             continue


#         if header_index:
#             merged_headers.append(i)
#         elif data_index:
#             merged_data.append(i)
#         else:
#             final_args.append(i)

#     if header_index:
#         final_args.append(" ".join(merged_headers))
#     elif data_index:
#         final_args.append(" ".join(merged_data))
        
#     return final_args


def main(sys_args):
    # Set up argument parser
    # print(sys_args)
    
    #  = categorize_args(sys_args)
    # print(t)
    # sys_args = fix(sys_args)
    # print(sys_args)
    
    parser = argparse.ArgumentParser(description="HTTP Client CLI", add_help=False)
    parser.add_argument("-m", "--method", required=True, help="HTTP method (e.g., GET, POST)")
    parser.add_argument("-u", "--url", required=True, help="Request URL")
    parser.add_argument("-h", "--header", type=str, default="{}", help="Request headers in JSON format (e.g., '{\"User-Agent\": \"device\"}')")
    parser.add_argument("-d", "--data", type=str, default="", help="Request body data")

    # Parse arguments
    args = parser.parse_args(categorize_args(sys_args))

    # Prepare headers from JSON string
    try:
        headers = json.loads(args.header)
    except json.JSONDecodeError:
        print("Invalid header format. Please provide valid JSON.")
        sys.exit(1)

    # Make the HTTP request
    response: HTTPResponse = final_request(method=args.method, url=args.url, headers=headers, body=args.data)

    # Prepare output JSON format
    output = {
        "status": response.code,
        "body": response.get_body_bytes().decode('utf-8')  # Assuming body is in bytes and needs to be decoded
    }

     # Print output as JSON
    print(json.dumps(output, indent=2))

if __name__ == "__main__":
    main(sys.argv[1:])


# import argparse
# import json
# import sys
# from http_client import request
# from http_response import HTTPResponse

# def clean_args(args):
#     """
#     Reorganiza los argumentos de la línea de comandos para evitar problemas con encabezados (-h) y datos (-d).
#     """
#     final_args = []
#     current_key = None
#     merged_values = []

#     for arg in args:
#         if arg in ("-h", "-d"):  
#             if current_key:  # Si ya había una clave activa, agregamos su valor acumulado
#                 final_args.append(" ".join(merged_values))
#             current_key = arg
#             merged_values = [arg]  # Reiniciamos con la clave actual
#         else:
#             merged_values.append(arg)

#     if merged_values:  # Añadir último conjunto de valores
#         final_args.append(" ".join(merged_values))

#     return final_args


# def parse_arguments(sys_args_clean):
#     """
#     Maneja la entrada de argumentos desde la línea de comandos.
#     """
#     parser = argparse.ArgumentParser(description="HTTP Client CLI",add_help=False)

#     parser.add_argument("-m", "--method", required=True, help="Método HTTP (e.g., GET, POST)")
#     parser.add_argument("-u", "--url", required=True, help="URL de la solicitud")
#     parser.add_argument("-h", "--header", type=str, default="{}", help="Encabezados en JSON (e.g., '{\"User-Agent\": \"my-app\"}')")
#     parser.add_argument("-d", "--data", type=str, default="", help="Cuerpo de la solicitud")

#     return parser.parse_args(sys_args_clean)


# def parse_headers(header_str):
#     """
#     Convierte la cadena de encabezados en un diccionario JSON válido.
#     """
#     try:
#         return json.loads(header_str)
#     except json.JSONDecodeError:
#         print("❌ Error: Formato de encabezado inválido. Debe ser JSON válido.")
#         sys.exit(1)


# def make_request(args):
#     """
#     Ejecuta la solicitud HTTP y devuelve la respuesta.
#     """
#     headers = parse_headers(args.header)

#     response: HTTPResponse = request(
#         method=args.method,
#         url=args.url,
#         headers=headers,
#         body=args.data
#     )

#     return {
#         "status": response.code,
#         "body": response.get_body_bytes().decode('utf-8')
#     }


# def main(sys_args):
#     """
#     Controla el flujo principal del script.
#     """
#     sys_args_clean= clean_args(sys_args)
#     args = parse_arguments(sys_args_clean)
#     output = make_request(args)
#     print(json.dumps(output, indent=2))


# if __name__ == "__main__":
#     main(sys.argv[1:])

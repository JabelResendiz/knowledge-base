# Clean Architecture Template

```c#
dotnet new webapi -n DownTrack.Api

dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.0

dotnet add package Microsoft.EntityFrameworkCore --version 8.0.0

dotnet add package Pomelo.EntityFrameworkCore.MySql --version 8.0.0

```

## que son los endpoints?

son puntos de accesos especificos en una API que permite la comunicacion entre diferentes sistemas de la app. En este caso los endpoints son URLs a los clientes que pueden hacer solicitudes HTTP para realizar operaciones especificas u obtener datos.

Caracteristicas clave de los endpoints:

1. URL especifica : Cada endpoint tiene una URL única que lo identifica.
2. Método HTTP: Se asocia con un método HTTP específico (GET, POST, PUT, DELETE, etc.) que indica la acción a realizar.
3. Funcionalidad definida: Cada endpoint realiza una tarea específica, como obtener datos, crear un nuevo recurso, actualizar información existente, etc.
4. Parámetros: Pueden aceptar parámetros en la URL, en el cuerpo de la solicitud, o como parámetros de consulta.
5. Respuesta: Devuelven una respuesta, generalmente en un formato como JSON, con los datos solicitados o una confirmación de la acción realizada.

Por ejemplo, si tu aplicación se está ejecutando en `https://tudominio.com`, un cliente podría hacer una solicitud GET a `https://tudominio.com/api/Productos` para obtener la lista de todos los productos.


## Que es IActionResult?

es una interfaz en ASP.NET Core que representa el resultado de una accion en un controlador . Permite devolver diferentes tipos de respuestas HTTP desde los metodos de los controladores.


es una forma de decirle a tu appp web que tipo de respuesta debe enviar de vuelta.es como una caja de herramientas que tiene diferentes tipos de respuestas que puede usar. por ejemplo:

1. OK(): Es como decir “¡Todo está bien!” y enviar los datos que el usuario pidió.
2. NotFound(): Es como decir “No encontré lo que buscabas” y enviar un mensaje de error.
3. BadRequest(): Es como decir “La solicitud que hiciste está mal” y enviar un mensaje de error.
4. NoContent(): es como decir "no tengo nada que enviar de vuelta"
5. Redirect("{url de la pagina }"): redirige al user a otra pagina

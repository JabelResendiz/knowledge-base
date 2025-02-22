## Capa de Transporte

La capa de red provee una entrega de paquete punto a punto mediante el uso de datagramas o circuitos virtuales. La capa de trasnporte se basa en la capa de red para proveer transporte de datos de un proveso en una maquina de origen a un proceso en una maquina de destino, con un nivel deseado de confiabilidad que es independiente de las redes fisicas que se utilizan en la actualidad. Ofrece las abstracciones que necesitan las aplicaciones para usar la red. Sin esta capa, todo
el concepto de protocolos por capas tendría muy poco sentido.

### Servicios que se proporcionan a las capas superiores

La capa de transporte se encarga de proporcionar un servicio de transmision eficiente , confiable y economico. Existen dos tipos de servicio en la capa de transporte: orientado a conexion (como TCP) y sin conexion (como UDP).

La `capa de transporte` es esencial porque proporciona un servicio más confiable que la capa de red, la cual puede estar fuera del control de los usuarios (los enrutadores son operados por proveedores de red). Esta capa también aísla las aplicaciones de las imperfecciones y variabilidad de las redes, lo que permite que los programas funcionen en diversas redes sin preocuparse por las diferencias en las interfaces de red o el nivel de fiabilidad.

Finalmente, se resalta la distinción entre las capas inferiores (1-4), que son proveedoras del servicio de transporte, y las capas superiores (por encima de la capa 4), que son las que usan este servicio. La capa de transporte actúa como **límite principal** entre el proveedor de servicio (la red) y el usuario del servicio (las aplicaciones).

#### Primitias del servicio de transporte

`Primitivas del servicio de transporte ` son operaciones que permiten a los programas de aplicacion acceder al servicio de transporte de la capa correspondiente. Estas primitivas son esenciales para establecer, usar y liberar conexiones de manera confiable entre procesos, ocultando las imperfecciones de la red.

Se introducen las  **primitivas básicas de un servicio de transporte orientado a conexión** , que incluyen:

1. **LISTEN** : El servidor espera a que un cliente se conecte.
2. **CONNECT** : El cliente intenta establecer una conexión con el servidor.
3. **SEND** : Envía datos a través de la conexión.
4. **RECEIVE** : Recibe datos de la conexión.
5. **DISCONNECT** : Libera la conexión cuando ya no es necesaria

El **servicio de transporte** es una capa crítica que ofrece a las aplicaciones un medio para intercambiar datos de manera confiable, aunque la red subyacente (capa de red) pueda ser inestable o no confiable. A diferencia del servicio de red, que a menudo está expuesto a la pérdida de paquetes o fallos en los enrutadores, la capa de transporte asegura que los datos lleguen correctamente al destino, gestionando retransmisiones y reconexiones si es necesario.

Así, los segmentos (intercambiados por la capa de transporte) están contenidos en paquetes (intercambiados por la capa de red). A su vez, estos paquetes están contenidos en tramas (intercambiadas por la
capa de enlace de datos). Cuando llega una trama, la capa de enlace de datos procesa el encabezado de
la trama y, si la dirección de destino coincide para la entrega local, pasa el contenido del campo de carga
útil de la trama a la entidad de red. Esta última procesa de manera similar el encabezado del paquete y
después pasa el contenido de la carga útil del paquete a la entidad de transporte

#### Sockets de Berkeley

Otro conjunto de primitivas de trasnporte : las primitivas de socket que se utilizan para TCP.

un `socket` es un punto final de comunicacion en una red. La API de sockets proporciona un conjunto de primitivas para crear, gestionar y cerrar conexiones de red.

Las principales primitivas de socket para TCP son:

* **SOCKET** : Crea un nuevo socket.
* **BIND** : Asocia una dirección (IP y puerto) al socket.
* **LISTEN** : Marca el socket como listo para aceptar conexiones.
* **ACCEPT** : Acepta conexiones entrantes.
* **CONNECT** : Inicia una conexión activa con un servidor.
* **SEND** / **RECEIVE** : Envía y recibe datos.
* **CLOSE** : Cierra la conexión.

> 💡 **NOTA**: cualquier numero entre 1024 y 65535 funcionara como puerto; los puertos por debajo de 1023 estan reservados para los usuarios privilegiados
>
> Pro ejemplo:
>
> * **80** : HTTP (navegación web)
> * **443** : HTTPS (navegación web segura)
> * **21** : FTP (protocolo de transferencia de archivos)
> * **25** : SMTP (envío de correo)
>
> `Puerto` se usa para identificar un servicio o aplicacion especfica en una maquina dentro de una red. Los puertos permiten que diferentes aplicaciones en una misma maquina se comuniquen con otras maquina a traves de una reed, sin que haya conflicto entre ellas.

> 💡  **Siguiente es un posible escenario para una conexion de transporte:**
>
> 1. Un proceso servidor de correo se enlaza con el TSAP(ptunto termjnal que identifica un proceso de app en la capa de transporte) 1522 en el host 2 para esperar una llamada entrante. La manera en que un proceso se enlaza con un TSAP está fuera del modelo de red y depende por completo
>    del sistema operativo local. Por ejemplo, se podría usar una llamada como nuestra LISTEN.
>
> * Un **proceso de aplicación en un cliente** se enlaza con otro TSAP (puerto) y solicita una conexión a un **servidor de correo** especificando la dirección de destino (TSAP).
> * Después de establecer la conexión, los datos (como el mensaje de correo) se transmiten entre ambos procesos.

El desafio es como un proceso de app en un host (por ejemplo,un cliente) sabe la direccion TSAP de un servicio :

- Para ello se establecen direcciones TSAP estables, donde los servidores conocidosse asignan a puertos fijos
- Para servicios desconocidos se utiliza un asignador de puertos. El asignador de puertos actúa como un **"directorio"** que devuelve la dirección correcta del TSAP asociado a un servicio solicitado.
- En lugar de tener cada servicio escuchando en su propio TSAP durante todo el día, se utiliza un servidor especial como **inetd** (en sistemas UNIX).

### Resumen del funcionamiento:

1. El **cliente** envía una solicitud al asignador de puertos (portmapper) para obtener la dirección TSAP del servicio que busca.
2. El asignador de puertos devuelve la dirección TSAP del servicio solicitado.
3. El cliente establece una conexión con el servidor especificado a través del TSAP proporcionado.
4. El servidor gestiona la conexión para procesar la solicitud del cliente.

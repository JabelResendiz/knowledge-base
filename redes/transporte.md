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

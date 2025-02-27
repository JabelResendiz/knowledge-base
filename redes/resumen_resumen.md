# Pautas del resumen de redes

## Capa de enlace de datos

- Funciones de la capa de enlace
- Servicios proporcionados a la capa de red
- Entramado (Tecnicas de Delimitacion de Tramas)
- Control de errores
- Protocolos elementales
- Resumen

### Funciones de la capa de enlace

* **Proveer de una interfaz bien definida de servicios para la capa de red**: Esta capa actúa como intermediario entre la capa de red y la capa física, facilitando la comunicación entre dispositivos en una red. Transforma los bits de datos de la capa de red en tramas que pueden ser transmitidas a través de la capa física .
* **Delimitar la secuencias de bytes en frames bien definidos**: La capa de enlace de datos se encarga de encapsular los datos en tramas, que son bloques de datos con una estructura específica que incluye información como la dirección de origen y destino (dirección MAC), la longitud de los datos y un campo de verificación de errores (CRC). Esto permite que los datos sean transmitidos de manera organizada y eficiente .
* **Detectar y corregir errores de transmisión**: Utiliza el campo de verificación de errores (CRC) para detectar si los datos han sido alterados durante la transmisión. Si se detecta un error, la trama puede ser retransmitida o descartada, dependiendo de la política de manejo de errores implementada .
* **Regular en flujo de los datos de forma tal que remitentes rápidos no ahogen a receptores lentos**: La capa de enlace de datos implementa mecanismos de control de flujo para evitar que un transmisor muy rápido sature a un receptor lento. Esto se logra mediante el uso de señales de control que indican al receptor cuántos datos puede aceptar en un momento dado, permitiendo así una comunicación equilibrada y eficiente .

### Servicios proporcionados

* Servicio sin conexion ni confirmación de recepción
  * Se envian tramas independientes a la maquina de destino sin que esta confirme la recepcion
  * No se comunican los frames recibidos
  * No se establece algún tipo de comunicación lógica
  * Tráfico en tiempo real. Voz y video.
  * Ejemplo: Ethernet
* Servicio sin conexion con confirmacion de recepcion
  * Medio no confiable con alto índice de errores
  * Se comunican los frames recibidos
  * No se establece algún tipo de comunicación lógica
  * Genera un costo adicional
* Servicio con conexion y confirmacion de recepcion
  * Cualquier Medio
  * Se comunican los frames recibidos
  * Se establece una comunicación antes de realizar el envío
  * Cada frame enviado se verifica
  * Cada frame se recibe una vez y en el orden correcto

### Entramados (Tecnicas de Delimitacion De Tramas)

- **Conteo de Bytes**
  - Los frames tienen bytes iniciales que representan la longitud en bytes del frames
  - Es malo para reconocer perdida o solapado con otros frames
- **Bytes banderas con relleno de bytes** :
  - Insertar por parte del emisor de un bytes para indicar el inicio y fin del frame
  - Puede haber bytes en la parte de los datos para ciertos datos como canciones o fotos (esto se resuelve con bytes ESC)
  - Frames mas grandes
- **Bits banderas con relleno de bytes** :
  - Frames de menor tamanno
  - Funciona igual que el anterior
  - Aprovechan el ancho de banda por tanto
  - Se aplica la idea de poner un bit 0 por cada 5 bit 1s
- **Violaciones de codificacion de la capa fisica** :
  - Estrategia implica no seguir las reglas de codificacion de la capa fisica para delimitar frames
  - Ignorar estas reglas pueden permitir una mayor flexibilidad en la trasmision pero errores de interpretacion e incompatibilidad

### Correccion de Errores

- **Codigo de Hamming** :
  - agrega bits de redundancia mediante los bits de paridad
  - Se agregan bits de paridad en posicones potencias de 2 y se calculan mediante operaciones sucesivas entre los bits que esten en posiciones con 1s en dicha representacion
  - permite corregir el error si el frame llega con problema
  - para corregir errores en varios bits , se ejecuta la operacion misma en orden inverso y se construye al cadena donde por cada bit de paridad bien se pone un 1 y un 0 en caso contrario. Al finalizar la cadena representa el bits a arreglar
- **Codigo convolucionales binarios**:
  - Utiliza una secuencia de bits conocidos como polinomio generador para generar bits de control
  - Pueden corregir errores de un solo bit
- **Codigo Reed-Solomon** :
  - Son especialmeten utiles en aplicaciones donde se requiere una alta tasa de correciones de errores
  - Utilizan polinomios para generar bits de control y son capaces de corregir errores mutiples bits
- **Codigo de baja densidad con respecto a la paridad**:
  - En un código LDPC,cada bit de salida se forma sólo a partir de una fracción de los bits de entrada
  - Las palabras codificadas recibidas se decodifican con un algoritmo de aproximación que mejora de manera reiterativacon base en el mejor ajuste de los datos recibidos con una palabra codificadaválida. Esto corrige los errores
  - Los códigos LDPCson prácticos para tamaños grandes de bloques y tienen excelentes habilidadesde corrección de errores que superan a las de muchos otros códigos

### Deteccion de errores

- **Paridad**:
  - Verificar si el numero total de 1s en los datos recibidos es par o impar dependiendo del tipo de paridad utilizados
  - Para ello el emisor cuenta el numero de bits 1 en los datos, y de acuerdo a la paridad utilizaada le agrega al final de los datos un `0` o `1`
  - Solo detectan errores simples, si hay numero par de bits afectados, falla
  - Una mejora es tomar varios datos, ponerlos en forma matricial,calcular el bit de paridad por cada columna y fila y enviar los datos de forma horizontal de arriba a abajo .
- **Checksum**:
  - Detectar errores mediante la suma de segmentos de datos y envios del complemento
  - Se suman los segmentos de datos y si ocurre overflow se agrega como carry y se continua
  - A la suma final se le hace complemento y se envian entonces los segmentos mas el checksum
  - El receptor hace la misma operacion, suma de la msima manera los valores, si el complemneto del resultado final es 0 etnonces es correcto sino envia un ack al emisor
- **CRC**:
  - Ambas partes conocen un polinomio previamente (todos coeficientes 0 y 1)
  - El emisor a los datos les agrega al final el numero de bits 0 como grado sea del polinomio
  - Se realiza la division y el resto se le suma al valor de los datos , se envia
  - Si el receptor divide y el resto es 0 entonces es corrector sino es error

### Protocolos Elementales

- **Protocolo simplex utopico**:
  - Sin control de flujo ni correcion de errores
  - Es basico, solo lleva la informacion desde y hasta las capas de enlace y fisica, agregando o eliminando parte de la info del frame
- **Protocolo simplex de parada y espera para un canal libre**:
  - Lidia con el problema del control del flujo estableciendo evento
- **Protocolo simpelx de parada y espera para un canal ruidoso**:
  - Lidis con le control de flujo y resuelve el problema de tramas perdidas o dannadas
  - Involucra temporizadores por cada trama despues de la cual se debe volver a enviar en el lado del receptor
  - El receptor envia un frame de respuesta ACK o de NCK para actualizar al emisor del estado del frame
- **Superposicion**:
  - En vez de utilizar enlaces separados para enviar datos en ambas direcciones se usa un unico enlace para trasnmitir datos y ACK
  - Para ellos se establece una politica de espera y timepo para envio de ACK y datos y evitar choques
  - Aprovecha el ancho de banda  reduce la sobrecarga de procesamientos
  - El desafio es justamente averiguar cuando enviar nuevo paquete antes de enviar un ACk independiente
- **ventana desplazante**:
  - Cada trama se identifica con un numero de secuencia unico
  - Se declaran una ventana de ambos lados para representar el conjunto de tramas que el emisor o receptor puede enviar o reciibir pero que no han sido confirmadas o que puede aceptar
  - Las ventanas se deslizan y dinamicas.
- **Protocolos retroceso N**:
  - En vez de bloquear el canal por trama , se envian arias tramas de forma continua y desoues se bloquea
  - GoBackN se usa cunado la ventana es de tamanno 1. EL emisro puede enviar varias tramas pero el receptor solo recibe 1 sola a la vez. Cuando la trama recibida es correcta, se envia una confirmacion de recepcion para esa trama
  - Si el receptor detecta que una trama esta dannada  no envia ningun ACK para esa trama, pero todas las tramas siguientes tmb quedan descartadas
  - Esto provoca que el emisor deba emitir tramas de nuevo desde que fallo
- **Repeticion selectiva**:
  - Es mas eficiente, ya que permite aceptar y almacenar tramas correctas , incluso si alguna de las tramas anteriores esta dannada
  - Como las tramas deben ser enviadas a la capa de red en orden etnonces se espera que el emisor envie la trama dannada de nuevo para proceder a vaciar el buffer que se tenia almacenando tramas correctas posteriores
- **Protocolo punto a punto**:
  - Estandar ampliamente utilizado para la transmision de datos a trves d enlaces de comunicacion punto a punto
  - Areas de area amplia (WAN) para conectar dispositivos como enrutadores , computadoras y modems a traves de distintos tipos de enlaces como fibra, ADSL, SONET
  - Presenta un metodo de entradamas que delinea sin ambiguedad el final de trama; un protocolo de control de enlace para activar lienas, probarlas , negociar opaciones y desactivarlas; un mecanismo para negociar opciones de capa de red con independencia del protocolo
  - Internet utiliza PPP como el protocolo de enlace de datos principal sobre líneas punto a punto. Provee
    un servicio sin conexión ni confirmación de recepción mediante el uso de bytes bandera para delimitar las
    tramas, junto con una CRC para detección de errores

## Subcapa de control de acceso al medio

- Problema de asignacion del canal
- Protocolos de Acceso Multiple
- Protocolos de Acceso Mutiple con deteccion de portadora
- Protcolos libres de colisiones
- Protocolos de Contencion limitada
- Protocolos de LAN inalambricas
- Dispositivos

### Problemas de asignacion del canal

El problema de asignacion de canales consiste en que solo existe un medio compartido por n usuarios y el uso compartido por parte de todos ellos de forma inadecuada interfiere con el resto de los usuarios.

Para ello las soluciones son:

- Asignacion estatica de canal:
  - FDM : divide el ancho de banda disponible en multiples subcanales y cad ausuario recibe un subcanal.Este enfoque no aprovecha todo el ancho de banda desperdiciando recursos
  - TDM : divide el espacio de tiempo en segmentos que cada usuario puee utilizar, sucede lo mismo, si no se utiliza por parte de un usuario de su ranura de tiempo entonces se desperdicia
- Asignacion dinamica de canales:
  - Pemite que multiples estaciones de comunicacion compartan el mismo canal, gestionando el acceso al medio para evitar colisiones
  - Trafico independiente
  - COlisiones observables
  - Tiempo continuo o ranurado
  - Deteccion de portadora o sin deteccion de portadora

### Protocolos de Acceso Multiples

- **Aloha** :
  - Sistema simple de acceso multiple
  - Siempre que las estaciones tenga datos para transmitir usan el canal
  - Eso conlleva a problemas de colisiones constantes, donde ambas estaciones involucradas deben volver a enviar sus datos
  - Un 18% de exito
  - El trafico por los suarios sigue ditrbucon de Poisson
- **Aloha ranurado** :
  - Divide el tiempo en intervalos discretos o ranuras .
  - Cada ranura corresponde a una trama y las estaciones deben esperar al inicio de un ranura para transmitir
  - Produce una sincronizacion en las transmisiioesn y reduce el perido vulnerable
  - 38% de exito

#### Protocolos de acceso mutiples con deteccion de portadora

portadora se le dice a escuchar la transmision de datos en el canal. Los protocolos en los que las estaciones escuchan una portadora y actuan de manera acorde se llama protocolos de deteccion de portadora.

- **1-persistent CSMA** :
  - Cuando uns estacion quiere transmitir , escucha primero el canal para ver si esta libre u ocupado
  - Si esta libre , trasnmite sus datos de inmmediato. Se le llama entonces "persistente-1"
  - Si esta ocupado , la estacion espera a que se libere el canal. Una vez libre se transmite
  - Siguen existiendo colisiones , pero despues de una colision cada estacion espera un tiempo aleatorio antes de volver de intentar transmitir (backoff aleatorio)
- **CSMA no persistente:**
  - Se introduce para reducir la probabilidad de colisiones
  - Al igual que en el anterior , cuando una estacion tiene dato debe escuchar primero el canal
  - SI esta libre transmite
  - SI esta ocupado , la estacion no intentar trasnmitir de inmmediato sino que espera un tiempo aleatorio antes de volver a escuchar al canal
  - Desventajaa: mayor retardo y eficiencia se ve reducida en cargas altas
- **CSMA persistente-p**:
  - Cuando una estacion esta lista para transmitir escucha el canal
  - Si esta libre , no transmite innediatamente sino que lo hace con un probabilidad p . Con una probabilidad q= 1-p la estacion decide posponer la transmision hasta la siguiente ranura
  - Si esta ocupado ,la estacion espera hasta la siguiente ranura y luego aplica de nuevo el proceso anterior
  - Si ocurre una colisión espera un intervalo de tiempo aleatorio y comienza de nuevo
- **CSMA/CD**:
  - Mejora signifiativa a los protocolos CSMA persitnet y no persistente
  - AL igual que los otros , escucha primero el canal cuando quiere trasnmitir .
  - Si esta libre trasnmite
  - Si dos sennales colisionan las estaciones pueden detectar que esta colisionando en el canal y decdir parar de transmitir de inmedianto para no ocupar el canal (eso ocurre porque una estacion se entera primero que la otra que ha ocurrido una colision entonces se detiene )
  - depues de abortar debe esperar un tiempo aleatorio y luego intentar trasnmitir de nuevo
  - no recomendada para redes inalambricas por su gran dificultad debido a la diferncia de potencia entre las sennales

#### Protocolos libres de colisiones

- **Protocolo de mapa de bit**:
  - Hay N estaciones conectadas al canal , enumerada de 0 a N-1
  - El tiempo se ranura en N espacios de contencion , una por estacion
  - Durante la j-esima ranura solo puede transmitir la j-esima estacion, si tiene algo que transmitir entonces transmite 1 , snio un 0
  - Deepues de eso todas las estaciones saben cuales quieren trasnmitir y cuales no,
  - Se repite el ciclo entonces donde cada estacion que puso un 1 envia sus datos
- **Paso de token**
  - Tecnica para organiza el canal de comunicaciones de forma ordenada y sin colisiones. \
  - Usa un token que es un mensaje especial, que se pasa de esacion en estacion
  - Si una estacion tiene una trama en cola para transmitir , cuando recibe el token , puede enviar esa trama antes de pasar el token a la siguietn estacion
- **Conteo ascendente binario**
  - resuelve la contencion por el canal en redes con multiples estaciones
  - Selecciona una estacion gaadora de manera eficiente , utilizadno direcciones binarias y un cnal que combinar trasnmisiones de las estaciones (OR booleano)
  - Para ello el numero de mayor direccion binaria envia por ser el ganador

#### Contencion Limitada

- **Protocolo de recorrido de arbol adaptable**:
  - mejora el acceso al canal en redes dedifusión al dividir las estaciones en subgrupos organizados en un árbol binario
  - Cada nodo del árbol corresponde a una ranura de contención , y las estaciones compitenpor el canal según su ubicación en el árbol
  - Si hay una colisión , se examinan los nodos inferiores recursivamente para identificar qué estaciones están listas paratransmitir. La búsqueda comienza más abajo en el árbol cuando hay una alta carga enel sistema, optimizando la contención

#### Protocolos de LAN inalambrica

* **MACA**:
  * Se usa para evitar colisiones en redes inalambricas (WIFI por ejemplo) donde las estacioens comparten el smimo canal de comunicacion
  * resulev que Si una estacion A esta enviando datos a un estacion B y otra C esta fuera del alcance de A pero cerca de B, C podria empezar a transmitir sin saber que A ya esta evniadno datos a B Esto causa colision
  * resuelve que Si una estacion C esta cerca de B pero no de A, podria escuchar que B esta transmitiendo y decidir no enviar los datos a D, auqnue no haya interferencias entre Cy D
  * Para ellos si A quiere comunicarse con B envai un sennal RTS para decirle que quiere mandarle datos. B recibe y envia otra aceptando. Todas las estaciones que esuchan la RTS de A y la CTS de B saben que no deben transmitir mientras A esta enviadno datos a B
  * Las que solo escuchan el RTS puede transmitir siempre que no interfiera con la senna de B
  * Si dos estaciones intentar enviar la RTS al mismo tiempo, habra una colision. Depues de eso ambas estaciones esperan un tiempo aleatorio

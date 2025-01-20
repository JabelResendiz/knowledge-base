## Modelos:

* modelo cliente-servidor: servidor y clientes
* modelo peer-to-peer : no hay division de quien es cliente y quien es servidor (redes sociales)-

existen dos tipos de tecnología de transmisión que se emplean mucho en la actualidad:

- los enlaces de difusión (broadcast) : Por el contrario, en una red de difusión todas las máquinas en la red comparten el canal de comunicación; los paquetes que envía una máquina son recibidos por todas las demás. Un campo de dirección
  dentro de cada paquete especifica a quién se dirige. Cuando una máquina recibe un paquete, verifica el
  campo de dirección. Si el paquete está destinado a la máquina receptora, ésta procesa el paquete; si el paquete está destinado para otra máquina, sólo lo ignora
- los enlaces de punto a punto: Los enlaces de punto a punto conectan pares individuales de máquinas.

## Redes de area personal (PAN)

permiten a los dispositivos comunicarse dentro del rango de una persona. Un ejemplo común es una red inalámbrica que conecta a una computadora con sus periféricos. Casi todas las computadoras tienen conectado un monitor,
un teclado, un ratón y una impresora. Apenas de 1m de distancia, ejemplo es la red de Bluetooth.

### Bluetooth:

utilizan el paradigma maestro-esclavo de la figura .
La unidad del sistema (la PC), por lo general es el maestro que trata con el ratón, el teclado, etc., como
sus esclavos. El maestro dice a los esclavos qué direcciones usar, cuándo pueden transmitir información,
durante cuánto tiempo pueden transmitir, qué frecuencias usar, etcéter

## Redes de area local

Generalmente llamadas LAN (Local Area Networks), son redes de propiedad
privada que operan dentro de un solo edificio, como una casa, oficina o fábrica. Las redes LAN se utilizan
ampliamente para conectar computadoras personales y electrodomésticos con el fin de compartir recursos
(por ejemplo, impresoras) e intercambiar información. Cuando las empresas utilizan redes LAN se les
conoce como redes empresariales.

En la mayoría de los casos, cada computadora se comunica con un dispositivo en el techo, como
se muestra en la figura 1-8(a). A este dispositivo se le denomina AP (Punto de Acceso, del inglés Access
Point), enrutador inalámbrico o estación base; transmite paquetes entre las computadoras inalámbricas
y también entre éstas e Internet. El AP es como el niño popular de la escuela, ya que todos quieren hablar
con él. Pero si hay otras computadoras que estén lo bastante cerca una de otra, se pueden comunicar directamente entre sí en una configuración de igual a igual.

hay un estandar para las redes LAN inalambricas llamadas IEEE 802.11 conocido como WiFi. Las redes LAN alámbricas utilizan distintas tecnologías de transmisión. La mayoría utilizan cables de
cobre, pero algunas usan fibra óptica. Las redes LAN tienen restricciones en cuanto a su tamaño, lo cual
significa que el tiempo de transmisión en el peor de los casos es limitado y se sabe de antemano.

La topología de muchas redes LAN alámbricas está basada en los enlaces de punto a punto. El estándar IEEE 802.3, comúnmente conocido como Ethernet, es hasta ahora el tipo más común de LAN
alámbrica. La figura 1-8(b) muestra un ejemplo de topología de Ethernet conmutada. Cada computadora
se comunica mediante el protocolo Ethernet y se conecta a una caja conocida como switch con un enlace
de punto a punto. De aquí que tenga ese nombre. Un switch tiene varios puertos, cada uno de los cuales
se puede conectar a una computadora. El trabajo del switch es transmitir paquetes entre las computadoras conectadas a él, y utiliza la dirección en cada paquete para determinar a qué computadora se lo
debe enviar.

## Redes de area metropolitana(MAN)

Cubre toda una ciudad. El ejemplo más popular de una MAN es el de las redes de televisión por cable disponibles en muchas ciudades.
Estos sistemas surgieron a partir de los primeros sistemas de antenas comunitarias que se utilizaban en
áreas donde la recepción de televisión por aire era mala. En esos primeros sistemas se colocaba una gran
antena encima de una colina cercana y después se canalizaba una señal a las casas de los suscriptores.

## Redes de areas amplias (WAN)

abarca una extensa área geográfica, por lo general un país o continente. Empezaremos nuestra discusión con las redes WAN alámbricas y usaremos el
ejemplo de una empresa con sucursales en distintas ciudades.

## Jerarquia de protocolos

Para reducir la complejidad de su u diseño, la mayoría de las redes se organizan como una pila de capas o
niveles, cada una construida a partir de la que está abajo. El número de capas, su nombre, el contenido
de cada una y su función difieren de una red a otra. El propósito de cada capa es ofrecer ciertos servicios
a las capas superiores, mientras les oculta los detalles relacionados con la forma en que se implementan
los servicios ofrecidos. Es decir, cada capa es un tipo de máquina virtual que ofrece ciertos servicios a la
capa que está encima de ella.

Cuando la capa n en una máquina lleva a cabo una conversación con la capa n en otra máquina, a las
reglas y convenciones utilizadas en esta conversación se les conoce como el protocolo de la capa n. En esencia,
un protocolo es un acuerdo entre las partes que se comunican para establecer la forma en que se llevará a
cabo esa comunicación.

Entre cada par de capas adyacentes hay una interfaz. Ésta define las operaciones y servicios primitivos que pone la capa más baja a disposición de la capa superior inmediata. Cuando los diseñadores de
redes deciden cuántas capas incluir en una red y qué debe hacer cada una, la consideración más importante es definir interfaces limpias entre las capa.

### Aspectos de diseño para las capas

La confiabilidad es el aspecto de diseño enfocado en verificar que una red opere correctamente, aun
cuando esté formada por una colección de componentes que sean, por sí mismos, poco confiables. Piense
en los bits de un paquete que viajan a través de la red. Existe la posibilidad de que algunas de estas piezas
se reciban dañadas (invertidas) debido al ruido eléctrico, a las señales aleatorias inalámbricas, a fallas en
el hardware, a errores del software, etc.

Un mecanismo para detectar errores en la información recibida utiliza códigos de **detección de errores.** Así, la información que se recibe de manera incorrecta puede retransmitirse hasta que se reciba de
manera correcta. Los códigos más poderosos cuentan con **corrección de errores**, en donde el mensaje
correcto se recupera a partir de los bits posiblemente incorrectos que se recibieron originalmente. Ambos
mecanismos funcionan añadiendo información redundante. Se utilizan en capas bajas para proteger los
paquetes que se envían a través de enlaces individuales, y en capas altas para verificar que el contenido
correcto fue recibido

Otro aspecto de la confiabilidad consiste en encontrar una ruta funcional a través de una red. A menudo
hay múltiples rutas entre origen y destino, y en una red extensa puede haber algunos enlaces o enrutadores descompuestos. Suponga que la red está caída en Alemania. Los paquetes que se envían de Londres
a Roma a través de Alemania no podrán pasar, pero para evitar esto, podríamos enviar los paquetes de
Londres a Roma vía París. La red debería tomar esta decisión de manera automática. A este tema se le
conoce como **enrutamiento**.

### Comparación entre servicio orientado a conexión

Las capas pueden ofrecer dos tipos distintos de servicio a las capas superiores: orientado a conexión y sin
conexión:

- orentado a conexion: está modelado a partir del sistema telefónico. Para hablar con alguien levantamos el auricular, marcamos el número, hablamos y después colgamos. De manera similar,
  para usar un servicio de red orientado a conexión, el usuario del servicio establece primero una conexión,
  la utiliza y después la libera. El aspecto esencial de una conexión es que funciona como un tubo: el emisor
  mete objetos (bits) en un extremo y el receptor los toma en el otro extremo. En la mayoría de los casos se
  conserva el orden de manera que los bits llegan en el orden en el que se enviaron.
- En contraste al servicio orientado a la conexión, el servicio sin conexión está modelado a partir del
  sistema postal. Cada mensaje (carta) lleva la dirección de destino completa, y cada uno es enrutado hacia los nodos intermedios dentro del sistema, en forma independiente a todos los mensajes subsecuentes. Hay
  distintos nombres para los mensajes en diferentes contextos: un paquete es un mensaje en la capa de red.
  Cuando los nodos intermedios reciben un mensaje completo antes de enviarlo al siguiente nodo, se le
  llama conmutación de almacenamiento y envío

### La relacion entre servicios y protocolos

Los servicios y los protocolos son conceptos distintos. Esta distinción es tan importante que la enfatizaremos una vez más. Un servicio es un conjunto de primitivas (operaciones) que una capa proporciona a
la capa que está encima de ella. El servicio define qué operaciones puede realizar la capa en beneficio de
sus usuarios, pero no dice nada sobre cómo se implementan estas operaciones. Un servicio se relaciona
con una interfaz entre dos capas, en donde la capa inferior es el proveedor del servicio y la capa superior
es el usuario

En contraste, un protocolo es un conjunto de reglas que rigen el formato y el significado de los paquetes o mensajes que intercambian las entidades iguales en una capa. Las entidades utilizan protocolos para
implementar sus definiciones de servicios. Pueden cambiar sus protocolos a voluntad, siempre y cuando
no cambien el servicio visible para sus usuarios. De esta manera, el servicio y el protocolo no dependen
uno del otro. Éste es un concepto clave que cualquier diseñador de red debe comprender bien.

## Capa fisica

### Serie de Fourier

- serie de Fourier: cualquier funcion periodica de comportamiento razonable , g(t) con un periodo T , se puede construir como la suma de unicos numeros (posiblemente infinitos ) de senos y cosenos :

$$
g(T)= \frac{1}{2} c + \sum_{n=1}^{\infin}{a_{n}}\sin(2\pi nft) + \sum_{n=1}^{\infin}{b_{n}}\cos(2\pi nft)
$$

en donde $f =\frac{1}{T}$ es la frecuencia fundamental , $a_{n}$ y $b_{n}$ son las amplitudes de seno y coseno del n-esimo armonico y c es una cste.

Es posible manejar una señal de datos con una duración finita (todas la tienen) con sólo imaginar que el patrón completo se repite una y otra vez de manera indefinida (es decir, el intervalo de T a 2T es el mismo que de 0 a T, etcétera).

Podemos calcular las amplitudes de $a_n$ para cualquier g(t) si multiplicamos ambos lados de la ecuación por sen(2πk ft) y después integramos de 0 a T. Dado que

$$
\int_{0}^{T} \sin(2\pi kft) \sin(2\pi nft) dt = \begin{cases} 0 & \text{para } k ≠ n \\ T/2 & \text{para } k = n \end{cases}
$$

(propiedad de la ortogonalidad de las funciones seno y coseno)

$$
a_{n} = \frac{2}{T} \int_{0}^{T} g(t)\sin(2\pi nft)dt
$$

$$
b_{n} = \frac{2}{T} \int_{0}^{T} g(t)\cos(2\pi nft)dt
$$

$$
c = \frac{2}{T} \int_{0}^{T} g(t)dt
$$

### Conceptos

- ancho de banda: se refire a la capacidad maxima de transmision de datos a traves de una conexion en un period de tiempo determinada. (bps, Mbps, Gbps)

* [ **Ancho de Banda vs. Velocidad** : El ancho de banda es la cantidad de datos que se pueden transmitir por segundo, mientras que la velocidad es cuán rápido se transmiten esos datos](https://espanol.verizon.com/articles/internet-essentials/bandwidth-definition/).
* [ **Ancho de Banda vs. Latencia** : La latencia es el tiempo que tarda un paquete de datos en viajar desde el origen hasta el destino, mientras que el ancho de banda es la cantidad de datos que se pueden enviar en ese tiempo](https://espanol.verizon.com/articles/internet-essentials/bandwidth-definition/).

### Medios de transmision

- medios magneticos: a traves de una cinta magentica o medios removibles  (DVD regrabables), transporte fisico.
- Par trenzado: Un par trenzado consta de dos cables de cobre aislados, por lo general de 1 mm de grosor. Los cables están trenzados en forma helicoidal, justo igual que una molécula
  de ADN. El trenzado se debe a que dos cables paralelos constituyen una antena simple. Cuando se trenzan los cables, las ondas de distintos trenzados se cancelan y el cable irradia con menos efectividad. Por lo general una señal se transmite como la diferencia en el voltaje entre los dos cables en el par. Esto ofrece
  una mejor inmunidad al ruido externo, ya que éste tiende a afectar ambos cables en la misma proporción y en consecuencia, el diferencial queda sin modificación. La aplicacion mas comun es el sistema telefonico
- cable coaxial: El cable coaxial es otro medio de transmisión común (conocido simplemente como “coax”). Este cable tiene
  mejor blindaje y mayor ancho de banda que los pares trenzados sin blindaje, por lo que puede abarcar mayores distancias a velocidades más altas.
- lineas electricas: Hay otro tipo más común de cableado: las líneas de energía eléctrica.
  Estas líneas transportan energía eléctrica a las casas, y el cableado eléctrico dentro de las casas distribuye
  la energía a las tomas de corriente.
  El uso de las líneas eléctricas para la comunicación de datos es una idea antigua. Las compañías de
  electricidad han utilizado las líneas eléctricas para la comunicación de baja velocidad durante varios años
  (por ejemplo, la medición remota), así como también en el hogar para controlar dispositivos (por ejemplo,
  el estándar X10). En años recientes surgió un interés renovado por la comunicación de alta velocidad a
  través de estas líneas, tanto dentro del hogar con una LAN como fuera de éste para el acceso a Internet
  de banda ancha. Nos concentraremos en el escenario más común: el uso de los cables eléctricos dentro del
  hogar.
- fibra optica: La fibra óptica se utiliza para la transmisión de larga distancia en las redes troncales, las redes LAN
  de alta velocidad (aunque hasta ahora el cobre siempre ha logrado ponerse a la par) y el acceso a Internet
  de alta velocidad como FTTH (Fibra para el Hogar, del inglés Fiber To The Home). Un sistema de transmisión óptico tiene tres componentes clave: la fuente de luz, el medio de transmisión y el detector. Por
  convención, un pulso de luz indica un bit 1 y la ausencia de luz indica un bit 0. El medio de transmisión
  es una fibra de vidrio ultradelgada. El detector genera un pulso eléctrico cuando la luz incide en él. Al
  conectar una fuente de luz a un extremo de una fibra óptica y un detector al otro extremo, tenemos un
  sistema de transmisión de datos unidireccional que acepta una señal eléctrica, la convierte y la transmite
  mediante pulsos de luz, y después reconvierte la salida a una señal eléctrica en el extremo receptor. Hay muchos rayos rebotando cada uno con un angulo de reflexion distinto( a este tipo de fibra se le llama fibra multimodal). Pero si el diámetro de la fibra se reduce a unas cuantas longitudes de onda de luz, la fibra actúa como
  una guía de ondas y la luz se puede propagar sólo en línea recta, sin rebotar, con lo que se obtiene una fibra
  monomodo. Estas fibras son más costosas pero se utilizan mucho para distancias más largas. Las fibras monomodo disponibles en la actualidad pueden transmitir datos a 100 Gbps por 100 km sin necesidad de amplificación. Incluso se han logrado tasas de datos más altas en el laboratorio, para distancias más cortas.

### Atenuacion

Se refiere a la perdidad de potecnia de una sennal a medida que se propaga a traves de un medio de transmisicion como un cable , el aire o el agua. Este fenomeno puede afectar a sennales acusticas, electricas u opticas.

## Satelites de comunicacion

Podemos considerar un satélite de comunicaciones como
un enorme repetidor de microondas en el cielo que contiene varios transpondedores, cada uno de los
cuales escucha en cierta porción del espectro, amplifica la señal entrante y después la retransmite en otra
frecuencia para evitar interferencia con la señal entrante. Este modo de operación se llama tubo doblado.
Se puede agregar un procesamiento digital para manipular o redirigir por separado los flujos de datos en
toda la banda, o el satélite puede recibir información digital y retransmitirla. Esta forma de regeneración
de señales mejora el desempeño si se le compara con un tubo doblado, ya que el satélite no amplifica el
ruido en la señal que va hacia arriba. Los haces que descienden pueden ser amplios y cubrir una fracción
considerable de la superficie de la Tierra, o pueden ser estrechos y cubrir un área de unos cuantos cientos
de kilómetros de diámetro.

**Amplificacion: significa aumentar la intensidad o la potencia de una señal, ya sea una señal eléctrica, de radiofrecuencia, de audio, o cualquier otra forma de transmisión. En el contexto de comunicaciones y satélites, amplificar una señal se refiere a hacerla más fuerte o clara para que pueda ser transmitida con mayor eficacia a largas distancias o después de haber perdido fuerza debido a la atenuación**

**Satelites de Orbita Media (MEO) :**

* entre los dos cinturones de Van Allen
* menor altura que los satélites GEO, producen una huella más
  pequeña en la Tierra y requieren transmisores menos poderosos para comunicarse
* En la actualidad se utilizan para sistemas de navegación en vez de las telecomunicaciones
* La constelación de alrededor de 30 satélites GPS (Sistema de Posicionamiento Global, del
  inglés Global Positioning System) que giran a una distancia aproximada de 20 200 km son ejemplos de
  satélites MEO

**Satelite de Orbita Terrestre Baja (LEO)**

* se encuentran a una altitud
  todavía más baja
* Debido a su rápido movimiento, se necesita un gran número de ellos para un sistema completo
* las estaciones terrestres no
  necesitan mucha potencia y el retardo de viaje redondo es de sólo unos cuantos milisegundos
* El costo
  de lanzamiento es más económico

**COnmutacion: es decidir que camino tomara la informacion para ir de un lugar a otro. Es como organizar el tráfico en una ciudad para que los mensajes, llamadas o datos lleguen a su destino.**

La conmutación decide la mejor manera de mover información según el tipo de comunicación:

* **Circuitos** : Rápido y directo, pero costoso si no se usa todo el tiempo.
* **Paquetes** : Más flexible y eficiente, ideal para redes modernas como internet.

En resumen, la conmutación es cómo las redes organizan y manejan el tráfico para que la información llegue rápida y correctamente.

### Transmision en Banda Base

es un método para enviar señales directamente en su forma original, sin modificar la frecuencia. En este tipo de transmisión, toda la energía de la señal ocupa el rango completo del canal de comunicación disponible, sin necesidad de ser modulada a otra frecuencia.

### Características principales:

1. **Sin modulación de frecuencia** :

* Las señales se transmiten tal como son, en su rango de frecuencia original.
* No se superponen con otras señales porque ocupan todo el canal de transmisión.

1. **Uso típico en redes locales (LAN)** :

* Por ejemplo, Ethernet utiliza transmisión en banda base para enviar datos directamente a través de cables de red.

1. **Limitada en alcance** :

* Debido a la falta de modulación, las señales en banda base tienden a degradarse rápidamente con la distancia.
* Son más adecuadas para distancias cortas, como dentro de un edificio o campus.

### Ventajas:

* **Simplicidad** : Es más fácil implementar y no requiere un equipo complicado para modular la señal.
* **Eficiencia** : Toda la capacidad del canal se usa para una sola señal.

### Desventajas:

* **Distancia limitada** : La señal puede sufrir atenuación y distorsión si viaja largas distancias.
* **Un solo usuario por canal** : Solo se puede transmitir una señal por canal en un momento dado, lo que limita su uso en sistemas compartidos.

### Ejemplo cotidiano:

Piensa en un cable Ethernet que conecta tu computadora al router. La información viaja directamente desde la computadora al router usando la transmisión en banda base, sin modificar la frecuencia.

En resumen, la transmisión en banda base es un método sencillo y eficiente para enviar señales sin cambios en su frecuencia, ideal para redes locales y comunicaciones de corto alcedios fisicos de capa fisica

## Medios de capa fisica

- modems : realiza conversiones entre un flujo de bits digitales y una señal analógica (Hay muchas variedades de módems: telefónicos, DSL, de cable, inalámbricos etc. El módem puede estar integrado en la computadora (lo cual es ahora común para los módems telefónicos) o puede ser una caja separada (algo común para los módems DSL y de cable))

# Enlace de datos

La capa de enlace de datos utiliza los servicios de la capa física para enviar y recibir bits a través de los
canales de comunicación. Tiene varias funciones específicas, entre las que se incluyen:

1. Proporcionar a la capa de red una interfaz de servicio bien definida
2. Manejar los errores de transmisión.
3. Regular el flujo de datos para que los emisores rápidos no saturen a los receptores lentos.

Para cumplir con estas metas, la capa de enlace de datos toma los paquetes que obtiene de la capa de red
y los encapsula en tramas para transmitirlos. Cada trama contiene un encabezado, un campo de carga útil
(payload) para almacenar el paquete y un terminador. El manejo de las
tramas es la tarea más importante de la capa de enlace de datos.

### Servicios proporcionados a la capa de red

La función de la capa de enlace de datos es proveer servicios a la capa de red. El servicio principal
es la transferencia de datos de la capa de red en la máquina de origen, a la capa de red en la máquina de destino. En la capa de red de la máquina de origen está una entidad, llamada proceso, que entrega
algunos bits a la capa de enlace de datos para que los transmita al destino. La tarea de la capa de enlace de
datos es transmitir los bits a la máquina de destino, de modo que se puedan entregar a la capa de red de esa
máquina.

La capa de enlace de datos puede diseñarse para ofrecer varios servicios. Los servicios reales ofrecidos
varían de un protocolo a otro. Tres posibilidades razonables que normalmente se proporcionan son:

1. **Servicio sin conexión ni confirmación de recepción** : El servicio sin conexión ni confirmación de recepción consiste en hacer que la máquina de origen envíe
   tramas independientes a la máquina de destino sin que ésta confirme la recepción. Ethernet es un buen
   ejemplo de una capa de enlace de datos que provee esta clase de servicio. No se establece una conexión
   lógica de antemano ni se libera después. Si se pierde una trama debido a ruido en la línea, en la capa
   de datos no se realiza ningún intento por detectar la pérdida o recuperarse de ella. Esta clase de servicio es apropiada cuando la tasa de error es muy baja, de modo que la recuperación se deja a las capas
   superiores. También es apropiada para el tráfico en tiempo real, como el de voz, en donde es peor tener
   retraso en los datos que errores en ellos
2. **Servicio sin conexión con confirmación de recepción**: El siguiente paso en términos de confiabilidad es el servicio sin conexión con confirmación de recepción.
   Cuando se ofrece este servicio tampoco se utilizan conexiones lógicas, pero se confirma de manera individual
   la recepción de cada trama enviada. De esta manera, el emisor sabe si la trama llegó bien o se perdió. Si no ha
   llegado en un intervalo especificado, se puede enviar de nuevo. Este servicio es útil en canales no confiables,
   como los de los sistemas inalámbricos. 802.11 (WiFi) es un buen ejemplo de esta clase de servicio
3. **Servicio orientado a conexión con confirmación de recepción**: el servicio más sofisticado que puede proveer la capa de enlace de datos a la capa de red
   es el servicio orientado a conexión. Con este servicio, las máquinas de origen y de destino establecen una
   conexión antes de transferir datos. Cada trama enviada a través de la conexión está numerada, y la capa de
   enlace de datos garantiza que cada trama enviada llegará a su destino. Es más, garantiza que cada trama
   se recibirá exactamente una vez y que todas las tramas se recibirán en el orden correcto. Así, el servicio
   orientado a conexión ofrece a los procesos de la capa de red el equivalente a un flujo de bits confiable.
   Es apropiado usarlo en enlaces largos y no confiables, como un canal de satélite o un circuito telefónico
   de larga distancia. Si se utilizara el servicio no orientado a conexión con confirmación de recepción, es
   posible que las confirmaciones de recepción perdidas ocasionaran que una trama se enviara y recibiera
   varias veces, desperdiciando ancho de banda.

### Entramado

Para proveer servicio a la capa de red, la capa de enlace de datos debe usar el servicio que la capa física le
proporciona. Lo que hace la capa física es aceptar un flujo de bits puros y tratar de entregarlo al destino.
Si el canal es ruidoso, como en la mayoría de los enlaces inalámbricos y en algunos alámbricos, la capa
física agregará cierta redundancia a sus señales para reducir la tasa de error de bits a un nivel tolerable. Sin
embargo, no se garantiza que el flujo de bits recibido por la capa de enlace de datos esté libre de errores.
Algunos bits pueden tener distintos valores y la cantidad de bits recibidos puede ser menor, igual o mayor
que la cantidad de bits transmitidos. Es responsabilidad de la capa de enlace de datos detectar y, de ser
necesario, corregir los errores.
El método común es que la capa de enlace de datos divida el flujo de bits en tramas discretas, calcule
un token corto conocido como suma de verificación para cada trama, e incluya esa suma de verificación
en la trama al momento de transmitirla. . Cuando una trama llega al destino, se recalcula la suma de verificación. Si la nueva suma
de verificación calculada es distinta de la contenida en la trama, la capa de enlace de datos sabe que ha
ocurrido un error y toma las medidas necesarias para manejarlo (por ejemplo, desecha la trama errónea y
es posible que también devuelva un informe de error).

Es más difícil dividir el flujo de bits en tramas de lo que parece a simple vista. Un buen diseño debe
facilitar a un receptor el proceso de encontrar el inicio de las nuevas tramas al tiempo que utiliza una pequeña parte del ancho de banda del canal. cuatro métodos de entramado son:

1. **Conteo de bytes** : se vale de un campo en el encabezado para especificar el número de bytes
   en la trama. Cuando la capa de enlace de datos del destino ve el conteo de bytes, sabe cuántos bytes siguen
   y, por lo tanto, dónde concluye la trama. El problema con este algoritmo es que el conteo se puede alterar debido a un error de transmisión. , el destino perderá la sincronía y entonces será incapaz de localizar el inicio correcto
   de la siguiente trama. Incluso si el destino sabe que la trama está mal puesto que la suma de verificación es
   incorrecta, no tiene forma de saber dónde comienza la siguiente trama. Tampoco es útil enviar una trama
   de vuelta a la fuente para solicitar una retransmisión, ya que el destino no sabe cuántos bytes tiene que
   saltar para llegar al inicio de la retransmisión. Por esta razón raras veces se utiliza el método de conteo
   de bytes por sí solo
2. **Bytes banderas con relleno de bytes** : evita el problema de volver a sincronizar nuevamente después de
   un error al hacer que cada trama inicie y termine con bytes especiales. Con frecuencia se utiliza el mismo
   byte, denominado byte bandera, como delimitador inicial y final. . Dos bytes bandera consecutivos señalan el final de una trama y el inicio de la siguiente. De
   esta forma, si el receptor pierde alguna vez la sincronización, todo lo que tiene que hacer es buscar dos
   bytes bandera para encontrar el fin de la trama actual y el inicio de la siguiente. Se puede dar el caso de que el byte
   bandera aparezca en los datos, en especial cuando se transmiten datos binarios como fotografías o canciones. Esta situación interferiría con el entramado. Una forma de resolver este problema es hacer que
   la capa de enlace de datos del emisor inserte un byte de escape especial (ESC) justo antes de cada byte
   bandera “accidental” en los datos. De esta forma es posible diferenciar un byte bandera del entramado
   de uno en los datos mediante la ausencia o presencia de un byte de escape antes del byte bandera. La
   capa de enlace de datos del lado receptor quita el byte de escape antes de entregar los datos a la capa de
   red. Esta técnica se llama relleno de bytes.
3. **Bits bandera con relleno de bits**: resuelve una desventaja del relleno de bytes: que está
   obligado a usar bytes de 8 bits. También se puede realizar el entramado a nivel de bit, de modo que las
   tramas puedan contener un número arbitrario de bits compuesto por unidades de cualquier tamaño. Cada trama empieza y termina con un patrón
   de bits especial, 01111110 o 0x7E en hexadecimal. Este patrón es un byte bandera. Cada vez que la capa de
   enlace de datos del emisor encuentra cinco bits 1 consecutivos en los datos, inserta automáticamente un 0
   como relleno en el flujo de bits de salida. Este relleno de bits es análogo al relleno de bytes, en el cual se
   inserta un byte de escape en el flujo de caracteres de salida antes de un byte bandera en los datos. Además
   asegura una densidad mínima de transiciones que ayudan a la capa física a mantener la sincronización.
   La tecnología USB (Bus Serie Universal, del inglés Universal Serial Bus) usa relleno de bits por esta
   razón.
4. **Violaciones de codificación de la capa física** : es utilizar un atajo desde la capa física. Esta redundancia
   significa que algunas señales no ocurrirán en los datos regulares. Por ejemplo, en el código de línea 4B/5B
   se asignan 4 bits de datos a 5 bits de señal para asegurar suficientes transiciones de bits. Esto significa que
   no se utilizan 16 de las 32 posibles señales. Podemos usar algunas señales reservadas para indicar el inicio
   y el fin de las tramas. En efecto, estamos usando “violaciones de código” para delimitar tramas. La belleza
   de este esquema es que, como hay señales reservadas, es fácil encontrar el inicio y final de las tramas y no
   hay necesidad de rellenar los datos.

### Control de errores

Una vez resuelto el problema de marcar el inicio y el fin de cada trama, llegamos al siguiente dilema:
cómo asegurar que todas las tramas realmente se entreguen en el orden apropiado a la capa de red del
destino. Suponga por un momento que el receptor puede saber si una trama que recibe contiene la
información correcta o errónea. Para un servicio sin conexión ni confirmación de recepción sería ideal
si el emisor siguiera enviando tramas sin importarle si llegan en forma adecuada. Pero para un servicio
confiable orientado a conexión no sería nada bueno

### **Problemas en la capa de enlace de datos:**

1. **Tramas perdidas o con errores:**
   * Una trama puede llegar con errores o no llegar debido a fallos en el hardware, ruido en el canal o interferencias.
   * Sin retroalimentación, el emisor no sabe si la transmisión fue exitosa.
2. **Retransmisiones:**
   * Si una trama se retransmite debido a pérdida o errores, existe el riesgo de que el receptor acepte la misma trama más de una vez.
3. **Confirmaciones perdidas:**
   * Si una confirmación de recepción (positiva o negativa) no llega al emisor, este no puede determinar cómo proceder.

---

### **Soluciones propuestas:**

#### **1. Retroalimentación con confirmaciones:**

* **Tramas de control especiales** :
* Confirmación positiva (ACK): Indica que una trama llegó correctamente.
* Confirmación negativa (NAK): Indica que una trama llegó con errores y debe retransmitirse.
* Este mecanismo garantiza que el emisor sepa si debe reenviar o continuar con la siguiente trama.

#### **2. Temporizadores:**

* Al enviar una trama, el emisor inicia un  **temporizador** .
* Si la confirmación no llega antes de que el temporizador expire, el emisor retransmite la trama.
* Esto evita esperas indefinidas en caso de pérdida de la trama o de la confirmación.

#### **3. Números de secuencia:**

* Las tramas llevan un **número de secuencia** único.
* El receptor utiliza este número para distinguir entre:
  * Tramas nuevas.
  * Retransmisiones de tramas ya recibidas.
* Esto garantiza que cada trama sea procesada una sola vez por la capa de red.

---

### **Objetivo final:**

* **Transmisión confiable:** Asegurar que todas las tramas lleguen al destino en el orden correcto, sin duplicados ni omisiones.
* **Detección de errores:** Identificar tramas erróneas o perdidas y corregirlas mediante retransmisiones.
* **Eficiencia:** Evitar esperas innecesarias y minimizar las retransmisiones

Una **NIC** ( **Network Interface Card** , por sus siglas en inglés) o **tarjeta de interfaz de red** es un componente de hardware que conecta un dispositivo (como una computadora, servidor o impresora) a una red. La NIC permite que el dispositivo envíe y reciba datos a través de la red, ya sea mediante medios cableados o inalámbricos. Pertenece a la capa de enlace.

## Deteccion y correcion de errores

Los diseñadores de redes han desarrollado dos estrategias básicas para manejar los errores. Ambas
añaden información redundante a los datos que se envían. Una es incluir suficiente información redundante
para que el receptor pueda deducir cuáles debieron ser los datos transmitidos. La otra estrategia es incluir
sólo suficiente redundancia para permitir que el receptor sepa que ha ocurrido un error (pero no qué error)
y entonces solicite una retransmisión. La primera estrategia utiliza códigos de corrección de errores; la
segunda usa códigos de detección de errores

### Codigo de correcion de errores

1. Códigos de Hamming
2. Códigos convolucionales binarios :  En un código convolucional, un codificador procesa una secuencia de bits de entrada y genera una secuencia de bits de salida. No hay un tamaño de mensaje natural, o
   límite de codificación, como en un código de bloque. La salida depende de los bits de entrada actual y previa.
   Es decir, el codificador tiene memoria. El número de bits previos de los que depende la salida se denomina
   longitud de restricción del código. Los códigos convolucionales se especifican en términos de su tasa de
   transmisión y su longitud de restricción.
3. **Códigos de Reed-Solomon**: Al igual que los códigos de Hamming, los códigos de Reed-Solomon son códigos de bloques lineales y
   con frecuencia también son sistemáticos. A diferencia de los códigos de Hamming, que operan sobre bits
   individuales, los códigos de Reed-Solomon operan sobre símbolos de m bits.
4. **Códigos de verificación de paridad de baja densidad** : En un código LDPC, cada bit de salida se forma sólo a partir de una fracción de los bits de entrada.
   Esto conduce a una representación matricial del código con una densidad baja de 1s, razón por la cual tiene ese nombre. Las palabras codificadas recibidas se decodifican con un algoritmo de aproximación que
   mejora de manera reiterativa con base en el mejor ajuste de los datos recibidos con una palabra codificada
   válida. Esto corrige los errores. álida. Esto corrige los errores.
   Los códigos LDPC son prácticos para tamaños grandes de bloques y tienen excelentes habilidades
   de corrección de errores que superan a las de muchos otros códigos (incluyendo los que vimos antes) en
   la práctica. Por esta razón se están incluyendo rápidamente en los nuevos protocolos. Forman parte del
   estándar para la difusión de video digital, la Ethernet de 10 Gbps, las redes de líneas eléctricas y la versión
   más reciente de 802.11

Todos estos códigos agregan redundancia a la información que se envía. Una trama consiste en m bits de
datos (mensaje) y r bits redundantes (verificación). En un código de bloque, los r bits de verificación se
calculan únicamente en función de los m bits de datos con los que se asocian, como si los m bits se buscaran en una gran tabla para encontrar sus correspondientes r bits de verificación

#### Codigo de Hamming

Se agrega información redundante (bits de paridad) a los datos originales para que el receptor pueda detectar y corregir errores. Los bits de paridad se calculan usando relaciones lógicas (XOR) entre bits específicos de los datos. En el receptor, los bits de paridad se recalculan y comparan con los recibidos. Si hay una discrepancia, se identifica la posición del bit erróneo y se corrige.

##### Calculo del codigo

###### Paso 1: Determinar la cantiad de bits de paridad (r):

Se necesitan rr**r** bits de paridad para proteger mm**m** bits de datos, donde:

$$
2^r \geq m+r+1
$$

Ejemplo para proteger 4 bits de datos (m=4) se necesitan r=3 ya que : $8\geq $$4+3+1$

###### Paso2 : Posicionar los bits de paridad:

Los bits de paridad se colocan en posiciones que son potencias de 2 (1,2,4,8,…)

Ejemplo:

- Datos : D1,D2,D3,D4
- Estructura final : P1,P2, D1, P4 ,D2, D3, D4

**Paso 3: Calcular los bits de paridad:**

* Cada bit de paridad cubre un grupo específico de bits según su posición.
* Los grupos se determinan por las posiciones cuyos números binarios tienen un 11**1** en la posición correspondiente.

**Ejemplo para P1:**

* P1 verifica las posiciones 1, 3, 5, 7.
* P1=D1⊕D2⊕D4

### Codigo de deteccion de errores

Los códigos de corrección de errores se utilizan de manera amplia en los enlaces inalámbricos, que son
notoriamente más ruidosos y propensos a errores si se les compara con la fibra óptica. Sin los códigos de
corrección de errores sería difícil hacer pasar cualquier cosa. Sin embargo, a través de la fibra óptica o del
cable de cobre de alta calidad, la tasa de error es mucho más baja, por lo que la detección de errores y la
retransmisión por lo general son más eficientes para manejar un error ocasional.

Tres códigos de detección de errores distintos. Todos son códigos de
bloques sistemáticos lineales:

1. Paridad
2. Sumas de verificación
3. Pruebas de Redundancia Cíclica (CRC)

### **1. Método de Paridad**

El método de **paridad** es uno de los más simples para la  **detección de errores** .

#### **Funcionamiento:**

* **Objetivo:** Verificar si el número total de bits **1** en los datos recibidos es par o impar, dependiendo del tipo de paridad utilizado.
* **Proceso:**
  1. **En el transmisor:**
     * Se calcula el número de bits **1** en el mensaje.
     * Si se usa  **paridad par** , se agrega un bit adicional para que el número total de **1** sea par.
     * Si se usa  **paridad impar** , se agrega un bit adicional para que el número total de **1** sea impar.
  2. **En el receptor:**
     * Se recalcula la paridad del mensaje recibido.
     * Si la paridad no coincide con lo esperado, se detecta un error.
* **Limitación:** Solo detecta errores simples (un número impar de bits alterados). Si hay un número par de bits alterados, no se detecta.

#### **Ejemplo:**

* Datos originales: **110101**
* **Paridad par:**
  * Número de **1**: **4** (par).
  * Bit de paridad: **0** (para mantenerlo par).
  * Datos enviados: **1101010**.
* **Paridad impar:**
  * Número de **1**: **4** (par).
  * Bit de paridad: **1** (para hacerlo impar).
  * Datos enviados: **1101011**.

---

### **2. Método de Suma de Verificación (Checksum)**

#### **Funcionamiento:**

* **Objetivo:** Detectar errores mediante la suma de segmentos de datos y el envío del complemento de la suma como verificación.
* **Proceso:**
  1. **En el transmisor:**
     * Los datos se dividen en bloques de longitud fija.
     * Se calculan las sumas de estos bloques.
     * Si la suma excede la capacidad del bloque (overflow), se envuelve el exceso (carry-around sum).
     * Se toma el complemento de la suma y se envía como el  **checksum** .
  2. **En el receptor:**
     * Se realizan los mismos pasos para calcular la suma de los datos recibidos, incluido el checksum.
     * Si la suma resultante es 00**0**, los datos son correctos. De lo contrario, hay un error.
* **Limitación:** Es menos robusto que otros métodos como CRC para detectar errores más complejos.

#### **Ejemplo:**

* Bloques de datos (en binario): **1101**,**1010**,**0111**
* Suma binaria: 1111
* Complemento: **0000** (checksum enviado).
* En el receptor, la suma de los bloques y el checksum debe dar **0000**.

---

### **3. Método CRC (Cyclic Redundancy Check)**

El CRC es un método más avanzado que utiliza divisiones polinomiales para detectar errores. Es ampliamente usado en redes y almacenamiento.

#### **Funcionamiento:**

1. **Representación de datos:**
   * Los datos a transmitir se representan como un polinomio en binario.
   * Por ejemplo, el mensaje **1101** se representa como x^**3**+x^**2**+1
2. **División polinómica:**
   * Se elige un polinomio generador **G**(**x**), que es conocido por el emisor y receptor.
   * Los datos se expanden agregando ceros al final (según el grado de **G**(**x**)).
   * Se realiza una división binaria (XOR) entre los datos expandidos y **G**(**x**).
   * El residuo de la división (R) se agrega al mensaje original.
3. **Envío de datos:**
   * El mensaje transmitido es: **M**+**R** (datos originales más el residuo).
4. **En el receptor:**
   * Se realiza la misma división con el polinomio generador **G**(**x**).
   * Si el residuo resultante es **0**, los datos están correctos. De lo contrario, hay un error.

#### **Ejemplo:**

* Datos originales: **1101**.
* Generador **G**(**x**)): **1011** (polinomio de grado 3).
* Datos expandidos: **1101000** (se agregan 3 ceros).
* División:
  * **1101000**÷**1011**=**1001** (cociente), residuo: **111**.
* Datos transmitidos: **1101111** (datos originales + residuo **111**).
* En el receptor:
  * **1101111**÷**1011**. Si el residuo es **0**, no hay errores.

## Protocolos Elementales

### Protocolo simplex utopico

Para este algoritmo asumiremos que:

1. El envio y la recepcion son procesos independientes
2. La comunicacion es unidireccional
3. Los equipos y medios son confiable

Sin control de flujo ni corrección de errores

```C
void sender(void){
    frame s;
    packet buffer;
    while (true){
        from_network_layer(&buffer);
        s.info = buffer;
        to_physical_layer(&s);
    }
}

void receiver(void){
    frame r;
    event_type event;
    while (true){
        wait_for_event(&event);
        from_physical_layer(&r);
        to_network_layer(&r.info)
    }
}
```

### Protocolo simplex de parada y espera para un canal libre de errores

Ahora debemos lidiar con el problema principal de evitar que el emisor sature al receptor enviando tramas
a una mayor velocidad de la que este último puede procesarlas

Control de flujo sin corrección de errores

```C
void sender(void){
    frame s;
    packet buffer;
    event_type event;
    while (true){
        from_network_layer(&buffer);
        s.info = buffer;
        to_physical_layer(&s);
        wait_for_event(&event);
    }
}

void receiver(void){
    frame r, s;
    event_type event;
    while (true){
        wait_for_event(&event);
        from_physical_layer(&r);
        to_network_layer(&r.info)
        to_physical_layer(&s);
    }
}
```

### Protocolo simplex de parada y espera para un canal ruidoso

A pesar de que se puede advertir ya la deteccion de tramas dannadas o perdidas o detectadas correctamente mediante un frame que devuelve al emisor . Sin embargo es necesario advertir un temporizador para retransmitir la trama nuevamente y ademas evitar tramas enviadas duplicadas en caso de perderse por el camino el frame de confirmacion. Para ello el receptor debe manejar por el numero de secuencia que la trama que llega para ver si es una trama nueva o un duplicado que puede descartarse.

Los protocolos en los que el emisor espera una confirmacion de recepcion positiva antes de avanzar al siguiente elemento de datos se llaman **ARQ** (Solicitud Automatica de Repeticion) o **PAR** (Confirmacion de Recepcion Positiva con Retransmision)

```c
void sender(void) {
    seq_nr next_frame_to_send;  // Número de secuencia del próximo marco a enviar.
    frame s;                   // Marco a enviar.
    packet buffer;             // Paquete desde la capa de red.
    event_type event;          // Tipo de evento (como llegada de un ACK).

    next_frame_to_send = 0;    // Inicializa el número de secuencia.
    from_network_layer(&buffer); // Obtiene el primer paquete de la capa de red.
    while (true) {
        s.info = buffer;           // Coloca el paquete en el marco.
        s.seq = next_frame_to_send; // Asigna el número de secuencia al marco.
        to_physical_layer(&s);     // Envía el marco por el canal físico.
        start_timer(s.seq);        // Inicia el temporizador para la retransmisión.
        wait_for_event(&event);    // Espera un evento, como un ACK o un temporizador vencido.
        if (event == frame_arrival) {  // Si llega un marco del receptor...
            from_physical_layer(&s);  // Extrae el marco del canal físico.
            if (s.ack == next_frame_to_send) { // Si el ACK coincide con el marco enviado...
                stop_timer(s.ack);           // Detiene el temporizador.
                from_network_layer(&buffer); // Obtiene el siguiente paquete de la capa de red.
                next_frame_to_send++;        // Incrementa el número de secuencia.
            }
        }
    }
}





void receiver(void) {
    seq_nr frame_expected;   // Número de secuencia esperado.
    frame r, s;              // `r`: Marco recibido, `s`: ACK a enviar.
    event_type event;        // Tipo de evento (como llegada de un marco).

    frame_expected = 0;      // Inicializa el número de secuencia esperado.
    while (true) {
        wait_for_event(&event);        // Espera un evento, como la llegada de un marco.
        if (event == frame_arrival) { // Si llega un marco...
            from_physical_layer(&r);   // Extrae el marco del canal físico.
            if (r.seq == frame_expected) { // Si el número de secuencia coincide con el esperado...
                to_network_layer(&r.info); // Pasa los datos del marco a la capa de red.
                frame_expected++;         // Incrementa el número de secuencia esperado.
            }
            s.ack = 1 - frame_expected;  // Prepara un ACK para el marco procesado.
            to_physical_layer(&s);      // Envía el ACK al emisor.
        }
    }
}

```

## Superposición (Piggybacking)

1. **Transmisión Full-Dúplex:**
   * En lugar de usar enlaces separados para enviar datos en ambas direcciones, se utiliza un único enlace para transmitir datos y confirmaciones (ACK).
   * Las tramas de datos y las confirmaciones se diferencian mediante el campo `kind` en el encabezado.
2. **Superposición (Piggybacking):**
   * Permite incluir la confirmación (ACK) en las tramas de datos de salida, evitando tramas de control independientes.
   * **Ventajas:**
     * Ahorra ancho de banda.
     * Reduce la sobrecarga de procesamiento.
   * **Desafío:** Determinar cuánto tiempo esperar un nuevo paquete antes de enviar un ACK independiente. Se puede usar un tiempo fijo para decidir.

## Ventana Desplazantes

* **Número de Secuencia:**

  * Cada trama enviada se identifica con un número de secuencia único.
  * Estos números se asignan cíclicamente entre `0` y un valor máximo (por lo general `2^n - 1`, donde `n` es el número de bits usados para representar el número de secuencia).
* **Ventanas:**

  * **Ventana del emisor:** Es el conjunto de tramas que el emisor puede enviar pero que aún no han sido confirmadas.
  * **Ventana del receptor:** Es el conjunto de tramas que el receptor puede aceptar.

  Estas ventanas son dinámicas y se "deslizan" conforme se envían y reciben tramas.
* **Tamaño de Ventana:**

  * Define cuántas tramas pueden estar "en vuelo" sin confirmación.
  * Ejemplo:
    * Si el tamaño de la ventana del emisor es 3, puede enviar hasta 3 tramas sin esperar confirmaciones.
    * Si el tamaño de la ventana del receptor es 1, solo aceptará la siguiente trama esperada en orden.

### Funcionamiento Básico

1. **Ventana del Emisor:**

   * Contiene tramas que han sido enviadas pero no confirmadas (ACK no recibido).
   * Cada vez que se recibe una confirmación (ACK) de una trama, el extremo inferior de la ventana avanza.
   * Si llega un paquete nuevo desde la capa de red, se asigna el siguiente número de secuencia y la ventana se desliza.

   Ejemplo: Si la ventana del emisor es `[3, 4, 5]` y se confirma la trama `3`, la ventana pasa a `[4, 5, 6]`.
2. **Ventana del Receptor:**

   * Contiene los números de secuencia de las tramas que puede aceptar.
   * Si recibe una trama dentro de la ventana, la guarda y genera una confirmación.
   * Si recibe una trama fuera de la ventana (por ejemplo, ya confirmada o fuera de orden), la descarta.

   Ejemplo: Si la ventana del receptor es `[3, 4, 5]` y recibe la trama `3`, la ventana se desliza a `[4, 5, 6]`.

#### Protocolo de ventana deslizante de 1 bit

```c
void protocol4 (void)
{

seq_nr next_frame_to_send; /* sólo 0 o 1 */

seq_nr frame_expected; /* sólo 0 o 1 */

frame r, s; /* variables de trabajo */

packet buffer; /* paquete actual que se envía */

event_type event;

next_frame_to_send = 0; /* siguiente trama del flujo de salida */

frame_expected = 0; /* próxima trama esperada */

from_network_layer(&buffer); /* obtiene un paquete de la capa de red */

s.info = buffer; /* se prepara para enviar la trama inicial */

s.seq = next_frame_to_send; /* inserta el número de secuencia en la trama */

s.ack = 1 – frame_expected; /* confirmación de recepción superpuesta */

to_physical_layer(&s); /* transmite la trama */

start_timer(s.seq); /* inicia el temporizador */

while (true){
 	wait_for_event(&event); /* 				       frame_arrival, cksum_err o timeout */
 	if (event == frame_arrival){ /* ha llegado una trama sin daño. */
 	    from_physical_layer(&r); /* la obtiene */
 	    if(r.seq == frame_expected) { /* maneja flujo de tramas de entrada. */
 	        to_network_layer(&r.info); /* pasa el paquete a la capa de red */
 	        inc(frame_expected); /* invierte el siguiente número de secuencia esperado */
            }

            if(r.ack == next_frame_to_send){ /* maneja flujo de tramas de salida. */
                 stop_timer(r.ack); /* desactiva el temporizador */
                 from_network_layer(&buffer); /* obtiene un nuevo paquete de la capa de red */
                 inc(next_frame_to_send); /* invierte el número de secuencia del emisor */

            }

         }
         s.info = buffer; /* construye trama de salida */
   	 s.seq = next_frame_to_send; /* le inserta el número de secuencia */
 	 s.ack = 1 – frame_expected; /* número de secuencia de la última trama recibida */
 	 to_physical_layer(&s); /* transmite una trama */
 	 start_timer(s.seq); /* inicia el temporizador */
}
}
```

El problema con este protocolo es cuando la comunicacion inicia simultaneamente, se cruzan sus tramas.

### Protocolo que utiliza retroceso N

En vez de mantener y bloquear el receptor por trama, se envian varaias tramas por el canal de forma continua para luego bloquearlo. Esta estrategia mejora significativamente el tiempo de espera y se aprovecha el ancho de banda. Esta tecnica de mantener varias tramas en movimineot es un ejemplo de canalizacion (pipeling).

La canalización de tramas a través de un canal de comunicación no confiable presenta problemas serios.
Primero, ¿qué ocurre si una trama a la mitad de un flujo extenso se daña o pierde? Llegarán grandes cantidades de tramas sucesivas al receptor antes de que el emisor se entere de que algo anda mal. Cuando llega
una trama dañada al receptor es obvio que debe descartarse pero, ¿qué debe hacer el receptor con todas
las tramas correctas que le siguen? Recuerde que la capa de enlace de datos del receptor está obligada a
entregar paquetes a la capa de red en secuencia.

Para ellos hay dos metodos , ambos tienen como objetivo garantizar que las tramas se reciban correctamente y, en caso de error, volver a enviarlas de manera eficiente.

- Retroceso n:
- Repeticion selectiva:

El protocolo **Go-Back-N** se utiliza para manejar errores en la transmisión de tramas cuando la ventana de recepción del receptor es de tamaño 1. Es decir, el receptor sólo puede aceptar la trama esperada, y todas las tramas siguientes se descartan si una trama intermedia se pierde o se recibe con error.

**Funcionamiento:**

1. El emisor puede enviar múltiples tramas (hasta el tamaño de su ventana), pero el receptor sólo puede aceptar una trama a la vez. Cuando recibe una trama correcta, la pasa a la capa superior y envía una confirmación de recepción (ACK) para esa trama.
2. Si el receptor detecta una trama dañada o perdida (por ejemplo, debido a un error de verificación), no envía ningún ACK para esa trama. Todas las tramas siguientes que haya recibido también se descartan, ya que deben llegar en el orden correcto.
3. El emisor, al no recibir un ACK para una trama, la reenvía junto con las tramas siguientes, incluso si algunas de ellas se recibieron correctamente.

La **repetición selectiva** es más eficiente que el retroceso N, ya que permite al receptor aceptar y almacenar tramas correctas que recibe, incluso si alguna de las tramas anteriores está dañada o perdida.

**Funcionamiento:**

1. El emisor también puede enviar múltiples tramas, pero a diferencia de  **Go-Back-N** , el receptor no descarta las tramas correctas que llegan después de una trama perdida. El receptor puede almacenar estas tramas correctamente recibidas en un búfer.
2. Si una trama se pierde o se recibe con error, el receptor no envía un ACK para esa trama. Sin embargo, cuando el emisor recibe un ACK o una confirmación de recepción negativa (NAK) para la trama perdida, sólo retransmite esa trama.
3. El receptor puede entonces entregar las tramas en orden cuando la trama perdida se haya retransmitido y recibido correctamente, permitiendo que las tramas almacenadas en el búfer se entreguen a la capa superior en el orden correcto.

### Protocolo Punto a Punto (PPP)

es un estándar ampliamente utilizado para la transmisión de datos a través de enlaces de comunicación punto a punto. Es comúnmente implementado en redes de área amplia (WAN) para conectar dispositivos como enrutadores, computadoras y módems a través de distintos tipos de enlaces, tales como **fibra óptica SONET** y **ADSL.** Constituye una mejora del protocolo mas simple conocido como SLIP (Protocolo de Linea Serial de Internet).

Se utiliza para manejar la configuración de detección
de errores en los enlaces, soporta múltiples protocolos, permite la autentificación y tiene muchas otras funciones. Con un amplio conjunto de opciones, PPP provee tres características principales:

1. Un método de entramado que delinea sin ambigüedades el final de una trama y el inicio de la
   siguiente. El formato de trama también maneja la detección de errores.
2. Un protocolo de control de enlace para activar líneas, probarlas, negociar opciones y desactivarlas
   en forma ordenada cuando ya no son necesarias. Este protocolo se llama LCP (Protocolo de
   Control de Enlace, del inglés Link Control Protocol).
3. Un mecanismo para negociar opciones de capa de red con independencia del protocolo de red que
   se vaya a utilizar. El método elegido debe tener un NCP (Protocolo de Control de Red, del inglés
   Network Control Protocol) distinto para cada capa de red soportada.

Esta orientado a bytes, de fomra que el relleo de bytes y las tramas tienen numero entero de bytes.

**ADSL** es una tecnología que se utiliza en redes de acceso de última milla, permitiendo conexiones de banda ancha a Internet mediante la infraestructura de la red telefónica. ADSL proporciona un canal de transmisión asimétrico, donde la velocidad de descarga (desde Internet hacia el usuario) es mucho mayor que la velocidad de subida (desde el usuario hacia Internet).

**PPP** (protocolo de la capa de enlace de datos)

Su funcionalidad incluye:

* **Encapsulación de paquetes de red:** PPP puede encapsular diversos protocolos de red, lo que lo hace adecuado para ser utilizado en diferentes tipos de enlaces de comunicación (como SONET o ADSL).
* **Control de errores y detección de fallos:** PPP incluye mecanismos para detectar y corregir errores en la transmisión de datos, lo que asegura la fiabilidad de la comunicación.
* **Autenticación:** PPP soporta autenticación, lo que permite verificar la identidad de los dispositivos que se comunican a través de los enlaces.
* **Compresión:** El protocolo puede usar compresión de datos para mejorar la eficiencia en el uso del ancho de banda.

# Subcapa de control de acceso al medio

Los protocolos que se utilizan para determinar quién sigue en un canal multiacceso pertenecen a una subcapa de la capa de enlace de datos llamada subcapa MAC (Control de Acceso
al Medio, del inglés Medium Access Control). La subcapa MAC tiene especial importancia
en las LAN, en especial las inalámbricas puesto que el canal inalámbrico es de difusión por
naturaleza. En contraste, las WAN usan enlaces punto a punto, excepto en las redes satelitales. Es la parte inferior de la capa de enlace de datos.

## Problema de asignacion del canal

El problema de asignacion de canales consiste en que solo existe un medio compartido por n usuarios y el uso compartido por parte de todos ellos de forma inadecuada interfiere con el resto de los usuarios.

### Asignacion estatica del canal

Se tienen en cuenta dos metodos tradicionales de multiplexacion:

- **FDM (Multiplexión por División de Frecuencia): En FDM, el ancho de banda disponible de un canal se divide en múltiples subcanales, y cada usuario recibe un subcanal para transmitir o recibir datos. Este enfoque es adecuado cuando el número de usuarios es pequeño y constante, o cuando el tráfico es estable y predecible. Sin embargo, presenta varios problemas cuando, el numero de usuarios es gradne y variable ; trafico de rafagas**
- **TDM (Multiplexión por División de Tiempo): En TDM, el canal se divide en segmentos de tiempo, y a cada usuario se le asigna una ranura de tiempo. Si un usuario no utiliza su ranura asignada, el tiempo se desperdicia, lo que también resulta en una asignación ineficiente cuando el tráfico es variable. Si se utilizara un conjunto de redes de 10 Mbps en lugar de una de 100 Mbps y se asignara una red a cada usuario, el retardo promedio se incrementaría.**

La asignación estática (ya sea por FDM o TDM) es ineficiente en redes donde el tráfico es  **variable o en ráfagas** . Cuando los usuarios no usan su canal de forma constante, ya sea por inactividad o por picos de tráfico, el ancho de banda se desperdicia. Este enfoque no se adapta bien a las necesidades dinámicas de la mayoría de los sistemas de cómputo modernos, donde las cargas de tráfico varían enormemente.

### Supuestos para la asignacion dinamica de canales

Se establece supuestos claves que subyacen en los protoclos de accesos mutliples para la asignacion de canales de comunicacion. Estos protocolos permiten que multiples estaciones de comunicacion compartan un unico canal, gestionando el acceso al medio para evitar colisiones y maximizar la eficiencia de transmision:

- Trafico independiente
- Canal Unico
- Colisiones observables
- Tiempo continuo o ranurado
- Deteccion de portadora o sin deteccion de portadora

## Protocolos de Acceso Multiple

### Aloha puro

El **sistema ALOHA** es un protocolo simple para el acceso múltiple a un canal compartido. Permite que los usuarios transmitan cuando tengan datos, pero debido a la naturaleza de acceso no coordinado, las transmisiones pueden superponerse y causar  **colisiones** , lo que lleva a la pérdida de las tramas involucradas.

El **sistema ALOHA** es un protocolo simple para el acceso múltiple a un canal compartido. Permite que los usuarios transmitan cuando tengan datos, pero debido a la naturaleza de acceso no coordinado, las transmisiones pueden superponerse y causar  **colisiones** , lo que lleva a la pérdida de las tramas involucradas. Aquí están los puntos clave de este protocolo:

#### 1. **Proceso de transmisión:**

* Las estaciones transmiten tramas a la computadora central.
* Si una estación recibe una confirmación de que su trama llegó correctamente, continúa. Si la trama sufrió una colisión, la estación debe retransmitirla.
* El tiempo de retransmisión es **aleatorio** para evitar que las tramas se colisionen repetidamente en sincronía.

#### 2. **Sistema de Contención:**

* ALOHA es un sistema de  **contención** , donde varios usuarios comparten un canal común y pueden transmitir al mismo tiempo, lo que puede generar colisiones.

#### 3. **Colisiones:**

* Cuando dos tramas se transmiten simultáneamente, se colisionan. Esto ocurre si el primer bit de una trama se traslapa con el último bit de otra.
* Ambas tramas son destruidas, y las estaciones involucradas deben retransmitir sus tramas.

#### 4. **Eficiencia del Canal ALOHA:**

* La **eficiencia** de ALOHA se refiere a qué fracción de las tramas transmitidas escapan a las colisiones.
* El sistema tiene **limitada eficiencia** debido a la naturaleza aleatoria de las transmisiones y las colisiones.

#### 5. **Modelo de Tráfico:**

* El tráfico generado por los usuarios sigue una **distribución de Poisson** con una media de  **N tramas por tiempo de trama** .
* Si N > 1, el canal está sobrecargado, y la mayoría de las tramas colisionarán. Si N < 1, hay menos colisiones y el rendimiento mejora.

#### 6. **Retransmisiones:**

* Además de las nuevas tramas, las estaciones retransmiten tramas previamente colisionadas. Las tramas nuevas y las retransmisiones combinadas siguen una distribución de Poisson con media  **G tramas por tiempo de trama** .

#### 7. **Probabilidad de Éxito (P₀):**

* La probabilidad de que una trama se transmita sin colisiones, es decir, la probabilidad de éxito, se calcula como  **P₀ = e^(-2G)** , donde **G** es la carga de tráfico (la tasa de tramas generadas).
* La **velocidad real de transmisión (S)** se calcula como  **S = G * P₀ = G * e^(-2G)** .

#### 8. **Máxima Eficiencia:**

* La **máxima eficiencia** se alcanza cuando  **G = 0.5** , lo que da una tasa de  **S ≈ 0.184** . Esto significa que solo aproximadamente **18%** de las tramas transmitidas tienen éxito, ya que el canal está sobrecargado debido a las colisiones.

### Aloha ranurado

El **ALOHA ranurado** es una variante del protocolo ALOHA que mejora la eficiencia de acceso al canal compartido al dividir el tiempo en intervalos discretos o  **ranuras** . Cada ranura corresponde a una trama, y las estaciones deben esperar al inicio de una ranura para transmitir, en lugar de hacerlo de manera continua como en el ALOHA puro. Esto introduce una sincronización en las transmisiones y reduce el **periodo vulnerable** (el tiempo durante el cual las tramas pueden colisionar). A continuación, se detallan los aspectos clave del ALOHA ranurado:

#### 1. **Principio de Funcionamiento:**

* **División del tiempo en ranuras:** En lugar de transmitir en cualquier momento, las estaciones esperan al inicio de una ranura para enviar su trama.
* **Reducción del periodo vulnerable:** Al esperar a que comience una nueva ranura, las colisiones ocurren solo dentro de esa ranura, lo que reduce el tiempo durante el cual pueden ocurrir colisiones. Esto hace que la probabilidad de colisión se reduzca comparada con ALOHA puro.

#### 2. **Eficiencia del Canal:**

* **Probabilidad de éxito:** La probabilidad de que una transmisión no choque con otra durante una ranura es  **e^(-G)** , donde **G** es la carga del canal, es decir, el número de tramas generadas por las estaciones por ranura de tiempo.
* La **velocidad real de transmisión (S)** en ALOHA ranurado es  **S = G * e^(-G)** . Esto alcanza su máxima eficiencia cuando  **G = 1** , con una velocidad de transmisión de  **S ≈ 1/e ≈ 0.368** , que es **el doble** de la eficiencia del ALOHA puro, que tenía un rendimiento máximo de  **0.184** .

#### 3. **Distribución de Tráfico:**

* **Distribución de Poisson:** Las tramas generadas siguen una distribución de Poisson, con una media de **G** tramas por ranura de tiempo.
* **Probabilidad de ranura vacía y colisiones:**
  * Cuando el sistema opera a  **G = 1** , alrededor del **37%** de las ranuras estarán vacías, **37%** tendrá éxito, y **26%** sufrirá colisiones.
  * Si **G** aumenta, el número de **ranuras vacías** disminuye, pero las  **colisiones aumentan exponencialmente** .

#### 4. **Colisiones y Retransmisiones:**

* **Probabilidad de colisión:** La probabilidad de colisión en una ranura es  **1 − e^(-2G)** . Si una transmisión choca, se requiere un nuevo intento.
* El número esperado de transmisiones para una línea (considerando colisiones y retransmisiones) está relacionado con  **G** . A medida que **G** aumenta, el rendimiento se degrada rápidamente debido a un mayor número de colisiones.

#### 5. **Aplicaciones Modernas:**

* El ALOHA ranurado fue utilizado inicialmente en los primeros sistemas experimentales en la década de 1970, pero fue en gran parte olvidado hasta que problemas modernos de acceso compartido en redes, como el **Internet a través de cable** y la  **comunicación entre etiquetas RFID y lectores** , lo revivieron.
* Su capacidad para resolver problemas de asignación de canales compartidos ha sido redescubierta en aplicaciones actuales, demostrando que protocolos aparentemente obsoletos pueden encontrar nuevas utilidades.

#### 6. **Impacto de Carga Alta (G alto):**

* A medida que **G** aumenta, se reduce la eficiencia del sistema debido a un  **aumento exponencial de las colisiones** , lo que implica que un mayor tráfico en el canal provoca un peor rendimiento.

### Protocolos de acceso múltiple con detección de portadora

Con el ALOHA ranurado, el mejor aprovechamiento de canal que se puede lograr es 1/e. Este resultado
tan bajo no es muy sorprendente pues, con estaciones que transmiten a voluntad propia, sin prestar atención a lo que están haciendo las demás estaciones, es inevitable que haya muchas colisiones. Sin embargo,
en las redes LAN es posible que las estaciones detecten lo que están haciendo las demás estaciones y
adapten su comportamiento con base en ello. Estas redes pueden lograr una utilización mucho mejor que
1/e.

Los protocolos en los que las estaciones escuchan una portadora (es decir, una transmisión) y actúan
de manera acorde se llaman protocolos de detección de portadora.

#### 1-persistent CSMA

* **Escuchar el canal:**
  * Cuando una estación quiere transmitir, **escucha** primero el canal para ver si está ocupado o libre.
* **Si el canal está libre:**
  * Si el canal está **inactivo** (sin transmisiones en curso), la estación **transmite** sus datos de inmediato. Esto es lo que se llama "persistente-1", porque la estación actúa con **probabilidad 1** de transmitir si el canal está libre.
* **Si el canal está ocupado:**
  * Si el canal está **ocupado** (otra estación está transmitiendo), la estación **espera** a que se libere el canal. Una vez libre, la estación transmite.
* **Colisiones:**
  * Si dos estaciones intentan transmitir al mismo tiempo, se  **produce una colisión** .
  * Después de la colisión, cada estación espera un tiempo aleatorio antes de volver a intentar transmitir, lo que se conoce como  **backoff aleatorio** .

#### CSMA no persistente

El protocolo **CSMA no persistente** es una variación del protocolo  **CSMA persistente-1** , y se introduce para reducir la probabilidad de colisiones al hacer que las estaciones sean menos "impulsivas" y más "pacientes". Aquí están los detalles clave:

##### **Funcionamiento del CSMA no persistente:**

1. **Escuchar el canal:**
   * Al igual que en  **CSMA persistente-1** , cuando una estación tiene datos para transmitir, **escucha primero el canal** para ver si está libre.
2. **Si el canal está libre:**
   * Si el canal está **inactivo** (sin transmisión en curso), la estación **transmite** los datos de inmediato, como en CSMA persistente.
3. **Si el canal está ocupado:**
   * Si el canal está  **ocupado** , la estación no intentará transmitir de inmediato (como en CSMA persistente-1), sino que **espera un tiempo aleatorio** antes de volver a intentar escuchar el canal.
4. **Reintentos:**
   * Después de esperar, la estación vuelve a escuchar el canal y repite el proceso. Si el canal sigue ocupado, espera nuevamente y repite el algoritmo, siempre eligiendo un tiempo de espera aleatorio cada vez.

##### **Ventajas sobre CSMA persistente-1:**

* **Menos colisiones:**
  * El **CSMA no persistente** reduce la probabilidad de colisiones simultáneas. Como las estaciones no transmiten inmediatamente cuando el canal se libera, hay menos posibilidades de que varias estaciones comiencen a transmitir al mismo tiempo.
* **Mejor uso del canal:**
  * Al esperar aleatoriamente, se **distribuyen** mejor las transmisiones a lo largo del tiempo, lo que **optimiza** el uso del canal y evita que las estaciones se "pongan en fila" para transmitir inmediatamente.

##### **Desventajas:**

* **Mayor retardo:**
  * Como las estaciones esperan un tiempo aleatorio para retransmitir cuando el canal está ocupado, este protocolo introduce **mayores retardos** en comparación con el  **CSMA persistente-1** , donde las estaciones transmiten inmediatamente si el canal está libre.
* **Eficiencia reducida en cargas altas:**
  * Aunque el CSMA no persistente ayuda a evitar las colisiones simultáneas, los **retrasos adicionales** pueden hacer que el canal se use de forma menos eficiente en comparación con otros protocolos como el **ALOHA ranurado** o incluso el **CSMA persistente** en cargas bajas.

#### CSMA persistente-p

##### **Funcionamiento del CSMA persistente-p:**

1. **Escuchar el canal:**
   * Cuando una estación está lista para transmitir, primero **escucha el canal** para ver si está libre.
2. **Si el canal está libre:**
   * Si el canal está  **inactivo** , la estación no transmite inmediatamente, sino que lo hace con una  **probabilidad p** . Con una probabilidad  **q = 1 - p** , la estación decide **posponer la transmisión** hasta la siguiente ranura.
3. **Si el canal está ocupado:**
   * Si el canal está ocupado, la estación **espera hasta la siguiente ranura** y luego aplica el mismo proceso de probabilidades **p** (transmitir) y **q** (posponer).
4. **Reintentos:**
   * Este proceso de decidir si transmitir o posponer se repite en cada ranura, hasta que la estación consiga transmitir exitosamente, o hasta que otra estación comience a transmitir. En caso de que se detecte que otra estación ha comenzado a transmitir, se  **actúa como si hubiera ocurrido una colisión** : la estación espera un tiempo aleatorio y comienza el proceso nuevamente.
5. **Refinamiento en IEEE 802.11:**
   * El estándar **IEEE 802.11** para redes Wi-Fi emplea una versión refinada de este protocolo para gestionar el acceso al canal compartido, con reglas adicionales para optimizar el rendimiento en redes de alta densidad.

##### **Ventajas del CSMA persistente-p:**

* **Flexibilidad en la transmisión:**
  * Al permitir que la estación **decida probabilísticamente** si transmitir o esperar, este protocolo introduce un equilibrio entre transmisión inmediata y espera, reduciendo la probabilidad de colisiones en comparación con el **CSMA persistente-1** y  **CSMA no persistente** .
* **Menos congestión en canales con tráfico pesado:**
  * Al usar una probabilidad para decidir si transmitir o esperar, se evita que múltiples estaciones intenten transmitir al mismo tiempo, lo cual es más probable en redes congestionadas.

##### **Desventajas:**

* **Mayor complejidad:**
  * El comportamiento probabilístico introduce **complejidad adicional** en la implementación y el análisis del protocolo, en comparación con el **CSMA persistente-1** más simple.
* **Rendimiento subóptimo a altas cargas:**
  * Si el tráfico en la red es muy alto, el rendimiento puede  **decaer** , ya que la probabilidad de que las estaciones sigan esperando a transmitir aumenta, lo que resulta en  **bajos niveles de utilización del canal** . Sin embargo, es más eficiente que el **ALOHA puro** o **ALOHA ranurado** en muchos casos.

##### **Relación con el rendimiento:**

* El **rendimiento del protocolo CSMA persistente-p** es mejor que el ALOHA en situaciones de tráfico moderado. A medida que la carga de tráfico aumenta, el rendimiento mejora, pero también comienza a deteriorarse por las decisiones de esperar o transmitir.

#### CSMA/CD (Acceso Múltiple con Detección de Colisiones)

es una mejora significativa sobre los protocolos CSMA persistente y no persistente, ya que permite que las estaciones  **detecten y aborten rápidamente las colisiones** , lo que optimiza el uso del canal y ahorra tiempo y ancho de banda. Este protocolo es especialmente utilizado en **Ethernet** (en redes cableadas) y tiene un funcionamiento clave para mantener la eficiencia en redes compartidas.

##### Funcionamiento de CSMA/CD:

1. **Escucha el canal** : Al igual que en los protocolos anteriores, cuando una estación tiene datos para transmitir, primero escucha el canal para verificar si está libre. Si el canal está libre, comienza a transmitir inmediatamente.
2. **Colisiones y detección** :

* Si dos estaciones transmiten al mismo tiempo, sus señales se  **colisionan** . Sin embargo, con el CSMA/CD, las estaciones pueden detectar estas colisiones **de inmediato** al comparar la señal transmitida con la señal recibida en el canal.
* Si una estación detecta que su transmisión ha colisionado, **detiene su transmisión** de inmediato para no seguir ocupando el canal con datos corruptos.

1. **Espera aleatoria** :

* Después de abortar la transmisión, la estación espera un tiempo **aleatorio** (según el algoritmo de retroceso exponencial), y luego intenta transmitir de nuevo. Este mecanismo reduce las probabilidades de que las estaciones vuelvan a colisionar en el siguiente intento.

##### Detalles del proceso de contención:

El protocolo CSMA/CD usa un modelo de **contención** en el que las estaciones compiten por el canal. Este modelo tiene  **periodos de contención, transmisión e inactividad** .

* **Periodo de contención** : Cuando una estación quiere transmitir, primero verifica si el canal está libre. Si está ocupado, espera.
* **Periodo de transmisión** : Cuando el canal está libre, la estación transmite. Si ocurre una colisión, la estación aborta la transmisión y pasa al siguiente  **periodo de contención** .
* **Periodo de inactividad** : Si no hay datos para enviar, las estaciones permanecen inactivas.

##### Detección de colisiones:

El tiempo que tarda una estación en **detectar una colisión** depende del **tiempo de propagación** de la señal entre las estaciones.

* En un  **escenario de colisión** :

  * Supongamos que dos estaciones comienzan a transmitir al mismo tiempo.
  * La estación que está más cerca de la colisión detecta la interferencia casi de inmediato.
  * Sin embargo, la estación más distante no detecta la colisión hasta que la **señal de la colisión** regresa a ella, lo que puede tomar hasta **2τ** (donde τ es el tiempo de propagación).

  Este **tiempo de propagación** influye en la longitud mínima del **periodo de contención** y es crucial para calcular el  **ancho de las ranuras de contención** .

##### Comparación con ALOHA ranurado:

El **CSMA/CD** se comporta de manera similar al  **ALOHA ranurado** , pero con una diferencia significativa: en el CSMA/CD, las estaciones **detectan y abortan las colisiones** lo que mejora la eficiencia en comparación con el ALOHA ranurado, que solo permite esperar o retransmitir después de una colisión sin un mecanismo inmediato de detección.

##### **Ventajas** :

1. **Reducción de tiempo perdido** : La capacidad de detectar colisiones en tiempo real reduce el tiempo desperdiciado por transmisiones corruptas.
2. **Mayor eficiencia que ALOHA** : Al permitir que las estaciones abandonen las transmisiones de manera inmediata tras una colisión, se mejora el uso del canal comparado con ALOHA, donde se sigue transmitiendo hasta completar la trama y luego se detecta la colisión.
3. **Prácticamente en tiempo real** : A medida que la estación transmite y escucha el canal, las colisiones se detectan rápidamente, lo que permite reintentos rápidos y más eficientes.

##### **Desventajas** :

1. **No aplicable a redes inalámbricas** : En redes inalámbricas, la **detección de colisiones** es mucho más difícil debido a la diferencia de potencia entre la señal transmitida y la señal recibida. Las estaciones no siempre pueden escuchar lo suficientemente bien el canal mientras están transmitiendo.
2. **Interferencia y colisiones aumentadas en redes grandes** : En redes grandes con muchos dispositivos, las colisiones y los intentos de retransmisión pueden aumentar, lo que lleva a una menor eficiencia si no se controla adecuadamente el  **tiempo de contención** .

### Protocolos libres de colisiones

#### Protocolo de mapa de bit

* **Definición inicial:**
  * Hay **N estaciones** conectadas al canal.
  * Cada estación tiene un número único del 0 al **N**−**1**.
* **Ranuras de contención:**
  * El tiempo se divide en  **N ranuras de contención** , una para cada estación.
  * Durante la ranura **j**, **sólo la estación j** puede transmitir un bit.
    * Si la estación tiene algo que enviar, transmite un  **1** .
    * Si no tiene nada que enviar, transmite un  **0** .
  * **Resultado:** Después de estas **N** ranuras, todas las estaciones saben cuáles quieren transmitir.
* **Transmisión ordenada:**
  * Las estaciones que quieren transmitir lo hacen **en orden numérico** (0, 1, 2, ..., N-1).
  * No hay colisiones porque ya se reservó el canal durante el mapa de bits.
* **Reinicio:**
  * Una vez que todas las estaciones que tenían algo para enviar han terminado, se repite el ciclo: comienza otro periodo de contención de **N** ranuras.

#### Paso de token

El **protocolo de paso de token** es una técnica utilizada en redes para organizar el acceso al canal de comunicación de forma ordenada y sin colisiones. Funciona mediante el uso de un mensaje especial llamado  **token** , que se pasa de una estación a otra en un orden predefinido. El token representa el permiso para enviar.
Si una estación tiene una trama puesta en cola para transmitirla cuando recibe el token, puede enviar esa
trama antes de pasar el token a la siguiente estación. Si no tiene una trama puesta en cola, simplemente
pasa el token.

#### Conteo Ascendente binario

El **conteo descendente binario** es un protocolo utilizado para resolver la contención por el canal en redes con múltiples estaciones. Su objetivo principal es seleccionar una estación ganadora de manera eficiente, utilizando direcciones binarias y un canal que combina las transmisiones de las estaciones (OR booleano). Para ello se establece direcciones binarias para las estaciones y el ganador en cada ronda es el de mayor direccion. La eficiencia de canal de este metodo es $\frac{d}{d+log_{2}N}$.

### Contencion limitada

Usa lo mejor de los protocolos de contencion como el CSMA y los protoclos libres de colision.

#### Protocolo de recorrido de arbol adaptable

El **protocolo de recorrido de árbol adaptable** mejora el acceso al canal en redes de difusión al dividir las estaciones en subgrupos organizados en un  **árbol binario** . Cada nodo del árbol corresponde a una  **ranura de contención** , y las estaciones compiten por el canal según su ubicación en el árbol. Si hay una  **colisión** , se examinan los nodos inferiores recursivamente para identificar qué estaciones están listas para transmitir. La búsqueda comienza más abajo en el árbol cuando hay una alta carga en el sistema, optimizando la contención.

 **Mejoras clave** :

1. **Búsqueda adaptativa** : Empieza en el nivel adecuado del árbol según el número de estaciones.
2. **Optimización** : Se omiten nodos inactivos para reducir la sobrecarga.

El protocolo reduce las colisiones y mejora la eficiencia, especialmente en redes grandes.

### Protocolos de LAN inalambrica

El protocolo **MACA (Multiple Access with Collision Avoidance)** se usa para evitar colisiones en redes inalámbricas (como Wi-Fi) donde las estaciones (como computadoras o dispositivos) comparten el mismo canal de comunicación.

#### **Problemas que resuelve** :

1. **Terminal Oculta** : Si una estación A está enviando datos a una estación B, y otra estación C está fuera del alcance de A pero cerca de B, C podría empezar a transmitir sin saber que A ya está enviando datos a B. Esto causaría una colisión.
2. **Terminal Expuesta** : Si una estación C está cerca de B pero no de A, podría escuchar que B está transmitiendo y decidir no enviar datos a D, aunque no haya ninguna interferencia entre C y D.

#### **Cómo funciona MACA** :

1. **RTS (Request to Send)** : A envía una pequeña señal a B (RTS) para decirle que quiere empezar a enviar datos.
2. **CTS (Clear to Send)** : B responde con un mensaje (CTS), diciéndole a A que puede enviar los datos. Este mensaje también informa a otras estaciones cercanas que deben esperar.
3. **Estaciones cercanas** :

* Las estaciones que escuchan la **RTS** de A y la **CTS** de B saben que no deben transmitir mientras A está enviando datos a B.
* Las estaciones que solo escuchan la **RTS** de A pueden transmitir sin problema, siempre que no interfieran con la señal de B.

#### **Colisiones** :

Si dos estaciones intentan enviar la **RTS** al mismo tiempo, habrá una colisión. Después de eso, ambas estaciones esperan un tiempo aleatorio antes de intentarlo de nuevo.

#### **En resumen** :

* **MACA** es un protocolo para coordinar las transmisiones entre estaciones en una red inalámbrica, asegurando que no interfieran entre sí y evitando colisiones.
* Usa los mensajes RTS y CTS para avisar a las estaciones cercanas de que una estación va a transmitir y que deben esperar.

## Dispositivos

- **Repetidores** (capa fisica): Amplificar y reevniar las sennales fisicas.
- **Hub** (capa fisica): Conecta multiples dispositivos en una red de are local(LAN) . Opera en la capa física, y simplemente retransmite los datos a todos los dispositivos conectados sin tomar decisiones inteligentes.
- **Cables (Ethernet, fibra, medios inalambricos de capa fisica)**
- **Modems :** Convierte las sennales digitales a analogicas y viceversa. Esto es crucial en conexiones a Internet mediante líneas telefónicas o cable coaxial (por ejemplo, ADSL).
- **Antenas WIFI :** Los sistemas de acceso permiten la transmisión de señales de radio entre los dispositivos y la infraestructura de red. Las antenas amplían el rango de cobertura de una red inalámbrica.
- **Switches** (capa de enlace): conecta varios dispositivos dentro de una red local (LAN). Opera en la capa de enlace de datos. A diferencia de un hub, un switch puede leer las direcciones MAC (Media Access Control) de los dispositivos y enviar los datos solo al dispositivo correspondiente
- **Bridge (puente)** :**Función** : El puente conecta dos segmentos de una red y opera en la capa de enlace de datos. Puede filtrar el tráfico entre los segmentos según las direcciones MAC y segmentar la red para reducir el tráfico.. Se usa para dividir una red en segmentos más pequeños y mejorar la eficiencia.
- **NIC (Tarjeta de interfaz de red):** La tarjeta de red es un dispositivo que conecta un dispositivo final (como una computadora) a la red. Opera en la capa de enlace de datos y se encarga de la comunicación de la computadora con la red. Se instala en las computadoras y otros dispositivos finales.
- **Router:** (capa de red) pero tmb interactua con la capa de enlace de datos. Se encarga de dirigir los paquetes de datos entre diferentes redes. Un router examina las direcciones IP y elige la mejor ruta para que los datos lleguen a su destino. Se usa para conectar redes diferentes, como una LAN a Internet o una LAN a otra LAN.

# Capa de Red

La capa de red es la capa más
baja que maneja la transmisión de extremo a extremo. Para lograr sus objetivos, la capa de red debe conocer la topología de la red (es decir,
el conjunto de todos los enrutadores y enlaces) y elegir las rutas apropiadas incluso para
redes más grandes. También debe tener cuidado al escoger las rutas para no sobrecargar
algunas de las líneas de comunicación y los enrutadores, y dejar inactivos a otros. Por
último, cuando el origen y el destino están en redes diferentes, ocurren nuevos problemas. La
capa de red es la encargada de solucionarlos.

## ASPECTOS DE DISEÑO DE LA CAPA DE RED

el funcionamiento de la **conmutación de almacenamiento y reenvío** en una red de comunicaciones. En este contexto, se presentan los componentes principales de la red, como los enrutadores del Proveedor de Servicio de Internet (ISP) y los equipos de los clientes. Un ejemplo de estos equipos es el host H1, que está conectado directamente a un enrutador del ISP, mientras que H2 está en una LAN conectada a su propio enrutador que se comunica con el ISP.

El proceso comienza cuando un host desea enviar un paquete. Este se transmite al enrutador más cercano, ya sea dentro de la LAN o a través de un enlace con el ISP. El paquete se almacena en el enrutador hasta que se procesa completamente, verificando la suma de verificación. Luego, se reenvía al siguiente enrutador en la ruta hasta llegar al destino final, donde se entrega.

Este proceso de transmitir, almacenar y reenviar paquetes en la red se denomina  **conmutación de almacenamiento y reenvío** , que es un enfoque fundamental para el envío de datos en redes de comunicaciones.

### Servicios proporcionados a la capa de transporte

La capa de red proporciona servicios a la capa de transporte en la interfaz entre la capa de red y de transporte. Hay que diseñar los servicios de manera cuidadosa, con los siguientes objetivos en mente:

1. Los servicios deben ser independientes de la tecnología del enrutador.
2. La capa de transporte debe estar aislada de la cantidad, tipo y topología de los enrutadores presentes.
3. Las direcciones de red disponibles para la capa de transporte deben usar un plan de numeración uniforme, incluso a través de redes LAN y WAN.

Para ellos se ofrece dos tipos de servicios que la capa de red deberia ofrecer:

1. **Servicios sin conexion**: este enfoque argumenta que los enrutadores deben encargarse solo de mover paquetes sin preocuparse por la confiabilidad. Los paquetes se envían sin conexión y no se realiza un seguimiento del estado o del orden de los paquetes. La responsabilidad de controlar errores y flujo recae en los  **hosts** .
2. **Servicio orientado a conexion**: Este enfoque argumenta que la red debería garantizar un servicio confiable, similar al sistema telefónico tradicional, para asegurar calidad en el servicio, especialmente en aplicaciones de tiempo real como voz y video. Este modelo es más cercano a la idea de un servicio orientado a conexión, donde la red establece una conexión antes de que los paquetes se envíen y se maneja el control de errores y flujo de manera centralizada.

### Implementacion del servicio sin conexion

cómo funciona una **red de datagramas** cuando la capa de red ofrece un  **servicio sin conexión** . En este tipo de servicio, los paquetes de datos se envían de manera independiente, sin necesidad de una conexión previa entre los enrutadores. Cada paquete se maneja por separado y se enruta según la información contenida en su dirección, sin coordinación con los otros paquetes del mismo mensaje.

#### Funcionamiento de una red de datagramas:

1. **División de los mensajes** :

* Supongamos que un proceso (P1) en un host (H1) tiene un mensaje largo que desea enviar a otro proceso (P2) en un host (H2). La capa de transporte se encarga de dividir este mensaje en varios paquetes, ya que el mensaje es más grande que el tamaño máximo permitido por el protocolo de la capa de red.

1. **Envío de los paquetes** :

* Los paquetes se entregan a la capa de red, que los divide y los envía uno por uno a través de la red. Cada paquete se transmite por el enrutador más cercano según las tablas de enrutamiento de los enrutadores.

1. **Tabla de enrutamiento** :

* Los enrutadores utilizan tablas internas que les indican a qué salida (línea de transmisión) enviar los paquetes, basándose en las direcciones de destino. Cada entrada en la tabla es un par de destino y línea de salida. El enrutador toma la decisión de dónde enviar cada paquete de acuerdo con estas tablas.

1. **Almacenamiento y reenvío** :

* Los enrutadores almacenan temporalmente los paquetes después de recibirlos, verifican su integridad (mediante sumas de verificación) y luego los reenvían al siguiente enrutador o destino. Los paquetes pueden tomar diferentes rutas en la red, como se ve en el ejemplo de la figura 5-2, donde el paquete 4 es enviado por una ruta diferente a los otros paquetes debido a un cambio en la tabla de enrutamiento.

1. **Algoritmos de enrutamiento** :

* Los enrutadores utilizan **algoritmos de enrutamiento** para decidir la mejor ruta para los paquetes. Estos algoritmos pueden ajustar las rutas en tiempo real según el tráfico o la congestión de la red.

#### Ejemplo de servicio sin conexión:

* El **Protocolo IP** (Internet Protocol) es el ejemplo principal de un servicio sin conexión. En IP, cada paquete lleva una dirección IP de destino que los enrutadores utilizan para reenviar el paquete hacia su destino. IP no establece una conexión antes de enviar los paquetes, y cada paquete se enruta de forma independiente. En  **IPv4** , las direcciones son de 32 bits, y en  **IPv6** , son de 128 bits.

### Implementacion del servicio orientado a conexion

El servicio **orientado a conexión** en redes de comunicación, se basa en la creación de  **circuitos virtuales** . La idea detrás de los circuitos virtuales es evitar la necesidad de elegir una nueva ruta para cada
paquete enviado. En cambio, cuando se establece una conexión, se elige una ruta de
la máquina de origen a la máquina de destino como parte de la configuración de conexión y se almacena
en tablas dentro de los enrutadores. Esa ruta se utiliza para todo el tráfico que fluye a través de la conexión,
de la misma forma en que funciona el sistema telefónico. Cuando se libera la conexión, también se termina el circuito virtual. Con el servicio orientado a conexión, cada paquete lleva un identificador que indica
a cuál circuito virtual pertenece. Si un tercer host quisiera establecer conexion con alguno de los involucrados, tambien puede usar el identificador de conexion 1, inicialmente, pero es tarea de los enrutadores de asignar un unevo identificador a la conexion nueva para eevitar confusion.

## Algoritmos de enrutamiento

El algoritmo de enrutamiento es aquella parte del software de la capa de red responsable de decidir por cuál
línea de salida se transmitirá un paquete entrante. Si la red usa datagramas de manera interna, esta decisión
debe tomarse cada vez que llega un paquete de datos, dado que la mejor ruta podría haber cambiado desde
la última vez. Si la red usa circuitos virtuales internamente, las decisiones de enrutamiento se toman
sólo al establecer un circuito virtual nuevo. En lo sucesivo, los paquetes de datos simplemente siguen la ruta
ya establecida. Este último caso a veces se llama enrutamiento de sesión, dado que una ruta permanece
vigente durante toda una sesión (por ejemplo, durante una sesión a través de una VPN).

- Enrutamiento estatico (algortimos no adaptativos): no basan sus decisiones de enrutamiento en mediciones o estimaciones del tráfico y la topología actuales. En cambio, la decisión de qué ruta se usará para llegar de I a J
  (para todas las I y J ) se calcula por adelantado, fuera de línea, y se descarga en los enrutadores al arrancar la red
- Enrutamiento dinamico (algoritmo adaptativos) : cambian sus decisiones de enrutamiento para reflejar los cambios de topología y algunas veces también los cambios en el tráfico

Todos los algortimos usan arboles sumideros que no es mas que la red de rutas optimas de todos los orignes a un destino dado que forma un arbol con raiz en el destino

### Algoritmo de la ruta mas corta

Aplica el algoritmo conocido de Dijkstra

### Inundacion

La **inundación** es una técnica de enrutamiento en la que cada paquete recibido se envía a todos los enrutadores vecinos, excepto al que lo recibió. Esto asegura que el paquete llegue a todos los nodos de la red, pero puede generar muchos paquetes duplicados, lo que no es eficiente.

Para evitar la propagación infinita de paquetes, se utilizan dos mecanismos:

1. **Contador de saltos** : Cada paquete tiene un contador que disminuye con cada salto. Cuando llega a cero, el paquete se descarta.
2. **Registro de paquetes enviados** : Cada enrutador lleva un registro de los paquetes que ya ha enviado para no retransmitirlos. Utiliza un número de secuencia para identificar los paquetes y evitar duplicados.

Aunque la inundación no es eficiente para la mayoría de los casos, es muy robusta y garantiza la entrega de paquetes, incluso en redes con fallos. Es útil en redes donde se necesita difundir información a todos los nodos, como en redes inalámbricas.

### Enrutamiento por vector de distancia

opera haciendo que cada enrutador mantenga una tabla (es decir, un vector) que proporcione la mejor distancia conocida a cada destino y
el enlace que se puede usar para llegar ahí. Para actualizar estas tablas se intercambia información
con los vecinos. Eventualmente, todos los ruteadores conocen el mejor enlace para alcanzar cada
destino. Éste fue el algoritmo original de enrutamiento
de ARPANET y también se usó en Internet con el nombre de RIP (uso de Bellman Ford). Se puede utilizar metricas como el salto o el retardo. La principal desventaja es destinos inalcanzable por salida del enlace. Los enrutadores vecinos no lo sabran y seguiran intentando usar rutas fallidas durante varios intercambios de informacion.

### Enrutamiento por estado de enlace

Las variantes de este enrutamiento
llamadas IS-IS y OSPF son los algoritmos de enrutamiento más utilizados dentro de las redes extensas y
de Internet en la actualidad.
La idea detrás del enrutamiento por estado del enlace es bastante simple y se puede enunciar en cinco
partes. Cada enrutador debe realizar lo siguiente para hacerlo funcionar:

1. **Descubrir a sus vecinos y conocer sus direcciones de red** : Cada enrutador debe identificar sus vecinos, generalmente enviando paquetes de tipo HELLO a través de enlaces punto a punto y esperando respuestas.
2. **Establecer la métrica de distancia o de costo para cada uno de sus vecinos**: Cada enrutador asigna una métrica a cada uno de sus enlaces (por ejemplo, costo basado en el ancho de banda o el retardo de los enlaces).
3. **Construir un paquete que indique todo lo que acaba de aprender**: Una vez que se recaba la información necesaria, el enrutador crea paquetes con los detalles sobre los enlaces descubiertos y sus costos. Estos paquetes se envían a otros enrutadores.
4. **Enviar este paquete a todos los demás enrutadores y recibir paquetes de ellos** : Los paquetes de estado del enlace se distribuyen a todos los enrutadores mediante un proceso de inundación. Los enrutadores mantienen un registro de los paquetes para evitar duplicados y asegurar que la topología esté actualizada.
5. **Calcular la ruta más corta a todos los demás enrutadores.** : Cada enrutador usa el algoritmo de Dijkstra para calcular la ruta más corta hacia otros enrutadores y actualiza sus tablas de enrutamiento.

De hecho, se distribuye la topología completa a todos los enrutadores. Después se puede ejecutar el
algoritmo de Dijkstra en cada enrutador para encontrar la ruta más corta a los demás enrutadores.

### Enrutamiento jerarquico

El **enrutamiento jerárquico** se utiliza para gestionar redes de gran tamaño, donde las tablas de enrutamiento tradicionales pueden volverse demasiado grandes y difíciles de manejar. A medida que las redes crecen, los enrutadores deben gestionar un mayor número de rutas, lo que puede consumir mucha memoria, tiempo de procesamiento y ancho de banda. El enrutamiento jerárquico organiza la red en **regiones** o **niveles** para reducir el tamaño de las tablas de enrutamiento, simplificando la administración de rutas.

#### Concepto básico:

* **Regiones** : La red se divide en áreas o regiones, cada una con su propia topología interna. Los enrutadores dentro de una región conocen bien la estructura local pero no la de otras regiones.
* **Rutas jerárquicas** : En lugar de que cada enrutador conozca la topología de toda la red, solo conoce la topología dentro de su propia región y cómo llegar a otras regiones. El tráfico entre regiones se enruta a través de un enrutador designado para esa región, reduciendo la complejidad de las tablas de enrutamiento.

#### Ventajas:

* **Reducción del tamaño de las tablas de enrutamiento** : El ejemplo en el texto muestra que, al dividir la red en varias regiones, la tabla de enrutamiento de un enrutador se reduce significativamente.
* **Escalabilidad** : Al organizar la red en jerarquías, se pueden manejar redes de mucho mayor tamaño sin sobrecargar a los enrutadores.

#### Desventajas:

* **Aumento de la longitud de la ruta** : Aunque se reducen las tablas de enrutamiento, las rutas pueden volverse más largas. Por ejemplo, un paquete puede necesitar pasar por más enrutadores de diferentes regiones para llegar a su destino, lo que incrementa el tiempo de transmisión.

#### Ejemplo de jerarquía multinivel:

* En una red grande como la de un país o un continente, se pueden utilizar varios niveles de jerarquía. Por ejemplo, un enrutador local en Berkeley podría enviar paquetes a Los Ángeles, este a Nueva York, y luego a Nairobi antes de llegar a su destino en Kenia.

#### Número de niveles óptimos:

* En una red con  **N enrutadores** , el número óptimo de niveles en la jerarquía es **ln N** (logaritmo natural de N). Esto significa que la jerarquía no debe ser demasiado profunda para evitar largas rutas, pero debe ser suficiente para reducir el tamaño de las tablas de enrutamiento. En el ejemplo, con 720 enrutadores, se podría dividir la red en 24 regiones, cada una con 30 enrutadores, o usar una jerarquía de tres niveles con 8 clústeres de 9 regiones, lo que reduce significativamente el número de entradas en las tablas.

### Enrutamiento por difusion (broadcasting)

Es un proceso en el que un mensaje se envia simultaneamente a varios o todos los hosts en uan red.

Los principales métodos son:

1. **Envío individual:** El origen envía un paquete a cada destino.
   * **Problema:** Ineficiente, lento y requiere conocer todos los destinos.
2. **Enrutamiento multidestino:** Un paquete incluye una lista de destinos.
   * **Ventaja:** Usa mejor el ancho de banda.
   * **Problema:** Complejo y el origen aún debe conocer todos los destinos.
3. **Inundación:** Reenvía paquetes por todas las líneas excepto la de entrada.
   * **Ventaja:** Simple.
   * **Problema:** Genera duplicados excesivos.
4. **Reenvío por ruta invertida (RPF):** Solo reenvía paquetes que llegan por la mejor ruta al origen; descarta duplicados.
   * **Ventaja:** Más eficiente que la inundación.
   * **Problema:** No minimiza completamente los paquetes.
5. **Árbol de expansión:** Reenvía paquetes solo por un árbol que conecta todos los enrutadores sin ciclos.
   * **Ventaja:** Usa el mínimo número de paquetes.
   * **Problema:** Los enrutadores deben conocer la estructura del árbol, lo que no siempre es posible.

* **RPF:** Genera 24 paquetes con algunos duplicados.
* **Árbol de expansión:** Usa solo 14 paquetes, minimizando el tráfico.

### Enrutamiento multidifusion(multicasting)

es un método para enviar mensajes a grupos específicos en una red, optimizando el uso del ancho de banda.

#### Principales conceptos:

1. **Multidifusión frente a difusión:**
   * La difusión envía un mensaje a toda la red, lo que puede ser ineficiente si muchos nodos no necesitan el mensaje.
   * La multidifusión optimiza esto al enviar mensajes solo a nodos que pertenecen a un grupo definido.
2. **Árboles de expansión recortados:**
   * Los paquetes se envían a través de árboles que conectan únicamente a los miembros del grupo.
   * Ejemplo: Para dos grupos en una red, se crean árboles distintos que eliminan enlaces innecesarios, reduciendo el tráfico y aumentando la eficiencia.
3. **Protocolos para multidifusión:**
   * **MOSPF (Multicast OSPF):** Cada enrutador construye su propio árbol de expansión recortado, eliminando enlaces no relevantes.
   * **DVMRP (Distance Vector Multicast Routing Protocol):** Utiliza mensajes **PRUNE** para recortar el árbol de expansión, eliminando ramas no necesarias.
4. **Árboles basados en núcleo:**
   * En lugar de múltiples árboles por emisor, se crea un solo árbol por grupo con un punto central (núcleo).
   * Los emisores envían paquetes al núcleo, que luego los distribuye por el árbol.
   * Ventaja: Reduce el almacenamiento y el cálculo en los enrutadores.
   * Desventaja: Puede ser menos eficiente para ciertos emisores, dependiendo de la ubicación del núcleo.
5. **Uso práctico:**
   * Los árboles compartidos, como los basados en núcleo, son comunes para grupos dispersos en Internet. Ejemplo: PIM (Protocol Independent Multicast).

### Enrutamiento anycast

En anycasy , un paquete se entrega al miembro mas cercano de un grupo. En ocasiones los nodos proporcionan un servicio, como la hora del dia o la distribucion del contenido , en donde todo lo que importa es obtner la informacion correcta sin importar el nodo con el que haya hecho contacto.

### Enrutamiento para hosts moviles

aborda el desafío de localizar y enrutar paquetes a dispositivos que cambian de ubicación mientras permanecen conectados a la red. Este problema surge en escenarios como usuarios con laptops o dispositivos móviles que desean mantener conectividad constante, sin importar su ubicación. Para ello utiliza su direccion base permanente para determinar su ubicacion base. Si el host se mueve, obtiene una nueva direccion local llamada direccion de custodia.

El host movil informa a un agente base sobre su nueva direccion. Los paqutes enviados al host movil van primero a su agente de base, este lo encapsula los paquetes (tunelizacion) y los reenvia a la direccion de custodia del host . Una vez que el emosir conoce la nueva direccion del host movel, puede enviar paquetes directamente evitando al agente de base .

### Enrutamiento en redes ad hoc

En el caso anterior, los host son moviles pero los enrutadores son fijos. Un caso extremo es cuando los enrutadores mismo son moviles. (bomberos en areas de peligros, vehiculos militares, flota de barco , reunion de personas con computadoras portatiles en un area que no cuenta con WiFi )

#### **Características principales** :

1. **Dinámica de la red** :

* Los nodos se mueven constantemente, lo que cambia la topología sin previo aviso.
* Esto hace que el enrutamiento sea mucho más complicado que en redes cableadas.

1. **AODV (Ad hoc On-demand Distance Vector)** :

* Algoritmo popular que encuentra rutas "bajo demanda", es decir, solo cuando se necesitan.
* Esto ahorra recursos, ya que evita mantener rutas que podrían volverse obsoletas rápidamente.

---

#### **Cómo funciona AODV** :

1. **Descubrimiento de rutas** :

* Si un nodo quiere enviar un paquete y no tiene una ruta al destino, genera una  **solicitud de ruta (ROUTE REQUEST)** .
* La solicitud se difunde a través de la red mediante inundación controlada, alcanzando los nodos vecinos.
* Cuando la solicitud llega al destino, este responde con un  **paquete de respuesta (ROUTE REPLY)** , que vuelve al origen usando la ruta inversa.
* Cada nodo en el camino almacena información para reenviar paquetes futuros.

1. **Mantenimiento de rutas** :

* Los nodos periódicamente envían mensajes de "hello" para verificar que los enlaces a sus vecinos siguen activos.
* Si un enlace falla, los nodos eliminan las rutas afectadas y notifican a otros nodos para que también actualicen sus tablas.
* Nuevas rutas se descubren cuando sea necesario.

1. **Optimización** :

* El algoritmo usa números de secuencia para evitar confusiones entre rutas antiguas y nuevas.
* Se limita la difusión para reducir la sobrecarga, comenzando con un área pequeña y ampliándola si es necesario.

---

#### **Otros enfoques** :

* **DSR (Dynamic Source Routing)** : Similar a AODV pero almacena la ruta completa en los paquetes.
* **GPSR (Greedy Perimeter Stateless Routing)** : Usa la ubicación geográfica de los nodos para calcular rutas sin necesidad de tablas de enrutamiento.

## Algoritmos de Control de Congestion

Congestion: Situacion en la cual hay demasiado trafico de paquetes en una red, lo que provoca que el bufer de los enrutadores dentro de los enrutadores se llenen y se pierden algunos paquetes.

Cuando en una red hay  **congestión** , significa que hay más datos (tráfico) tratando de pasar por los recursos disponibles (como cables o enrutadores). Esto provoca retrasos, pérdida de paquetes y una red lenta. Hay dos maneras principales de manejar este problema:

1. **Aumentar los recursos** :
   Esto significa dar más espacio para el tráfico. Algunos ejemplos son:

* **Mejorar la red** : Usar cables más rápidos o enrutadores más potentes.
* **Abrir rutas alternativas** : Como activar caminos de respaldo cuando hay demasiados datos en uno principal, igual que abrir más carriles en una autopista llena.
* **Ajustar rutas según el tráfico** : Si una ruta está muy ocupada, desviar los datos por caminos menos congestionados.

1. **Reducir el tráfico** :
   Esto significa limitar la cantidad de datos que se envían. Algunas formas de hacerlo son:

* **Negar nuevas conexiones** : Si una red está llena, simplemente no aceptar más conexiones para evitar que todo se detenga.
* **Enviar advertencias a los usuarios** : Si una parte de la red está congestionada, se puede pedir a las computadoras o dispositivos que envían muchos datos que bajen su velocidad.
* **Eliminar paquetes no importantes** : Si no hay otra opción, la red puede descartar los datos menos prioritarios para liberar espacio.

### Enrutamiento consciente del trafico

es un enfoque que considera la carga de los enlaces de la red para calcular las mejores rutas para enviar datos. A diferencia de los métodos de enrutamiento tradicionales que usan **ponderaciones fijas** basadas en características como el ancho de banda o el retardo de propagación, este enfoque incluye variables dinámicas como la **carga actual** o el  **retardo de encolamiento** .

Cuando las ponderaciones cambian en función de la carga, pueden generarse oscilaciones:

1. Si un enlace está congestionado, el sistema redirige el tráfico a otra ruta menos ocupada.
2. Esto puede congestionar la nueva ruta, y el sistema vuelve a cambiar las rutas al enlace original.
3. Este ciclo puede repetirse, causando **enrutamiento errático** e inestabilidad en la red.

### Control de admision

Es una tecnica utilizada en las redes de circuitos virtuales para evitar la congestion. La idea es no establecer un nuevo circuito virtual a menos que la red pueda transportar el trafico adicional sin congestionarse. Si la red está cerca de la saturación, se rechaza la solicitud para evitar que la situación empeore, similar a cuando un sistema telefónico no permite nuevas llamadas si está sobrecargado.

### Regulacion de trafico

Es el proceso de controlar el flujo de datos en una red para evitar que se congestione. La idea es asegurarse de que los emisores no envíen más datos de los que la red puede manejar sin que se atasque.

#### 1. **Detección de congestión**

* Los enrutadores de la red están vigilando constantemente el uso de los recursos de la red, como los **bufers** (donde se guardan los paquetes) y los  **tiempos de retraso** . Si los enrutadores detectan que los paquetes se están acumulando o que los tiempos de espera aumentan, significa que la red está a punto de congestionarse.

#### 2. **Notificación de congestión**

* Cuando un enrutador detecta que hay congestión, tiene que avisar a los **emisores** (los dispositivos que envían datos). Esto se hace de varias maneras:
* **Paquetes reguladores** : El enrutador envía un paquete especial de vuelta al emisor, diciéndole que **reduzca la velocidad** con la que está enviando datos (por ejemplo, un 50% menos).
* **Notificación Explícita de Congestión (ECN)** : En lugar de enviar paquetes adicionales, el enrutador simplemente marca los paquetes con una señal que indica que hubo congestión en el camino. El emisor verá esta señal y reducirá su velocidad cuando reciba la respuesta.
* **Contrapresión de salto por salto** : En lugar de esperar que el emisor reduzca su velocidad, la red puede "empujar" hacia atrás la señal de congestión desde el lugar donde se detectó. Así, los enrutadores intermedios también comienzan a reducir el flujo de datos hacia la zona congestionada.

#### 3. **¿Por qué es importante?**

* La regulación de tráfico es crucial para  **evitar que la red se colapse** . Si no se controla, los paquetes pueden empezar a **perderse** y los tiempos de espera se incrementan, lo que afecta el rendimiento de la red.

### Desprendimiento de carga

es una estrategia utilizada por los enrutadores para manejar la congestión cuando ya no pueden procesar más paquetes. Es como una medida extrema para evitar que la red se colapse, similar a cómo se apagan algunas áreas de una red eléctrica cuando hay demasiada demanda. Se usa principlametn cuando no se resuelve la congestion con los metodos anteriores.

#### ¿Cómo decidir qué paquetes eliminar?

* **Para transferencias de archivos** : es mejor eliminar los paquetes antiguos, ya que los nuevos aún no se pueden usar.
* **Para streaming de video o audio (tiempo real)** : es mejor eliminar los paquetes nuevos, ya que los antiguos ya no sirven.

Existen dos enfoques para esto:

1. **Vino** : se elimina primero el paquete más antiguo.
2. **Leche** : se elimina primero el paquete más nuevo.

#### **Desprendimiento inteligente de carga**

Los enrutadores pueden  **marcar la importancia de los paquetes** , de modo que si deben eliminar algunos, descarten primero los de menor importancia.

#### **Detección temprana aleatoria (RED)**

En lugar de esperar a que la red se sature, los enrutadores pueden empezar a **descartar paquetes al azar** cuando la cola de paquetes empieza a ser muy larga. Esto da tiempo a los emisores para reducir su velocidad antes de que el problema empeore.

#### **ECN vs RED**

**ECN** (Notificación Explícita de Congestión) es mejor que RED, ya que le avisa al emisor directamente sobre la congestión, lo que permite reaccionar más rápido.

En resumen, el desprendimiento de carga ayuda a evitar que la red se colapse, y puede hacerse de manera más inteligente al eliminar primero los paquetes menos importantes.

## Capa de red de Internet

* **Internet como una red de redes** : Internet está compuesta por múltiples redes interconectadas, llamadas  **Sistemas Autónomos (AS)** .
* **Redes troncales** : Son las redes de alto ancho de banda que conectan diversas partes de Internet. Las más grandes son llamadas  **redes de Nivel 1** .
* **Proveedores de Servicios de Internet (ISP)** : Conectan redes regionales y proporcionan acceso a Internet para hogares, negocios y centros de datos.
* **Capa de red de Internet** : El protocolo **IP (Protocolo de Internet)** es el principal responsable de interconectar estas redes y transportar paquetes entre la fuente y el destino sin garantizar la entrega.

##### **Funcionamiento de la comunicación en Internet:**

1. **Capa de transporte** : Divide los datos en paquetes.
2. **Enrutadores IP** : Reenvían los paquetes a través de las redes hasta el destino.
3. **Capa de red en el destino** : Ensambla los paquetes para devolver los datos completos al proceso receptor.

##### **Redundancia y rutas en Internet:**

* Existen **múltiples rutas** entre dos puntos debido a la conectividad redundante en las redes troncales e ISP.
* Los **protocolos de enrutamiento** se encargan de decidir qué rutas tomar para enviar los paquetes de forma eficiente.

En resumen, la capa de red de Internet fue diseñada siguiendo principios claros para garantizar su funcionamiento eficiente, sencillo y escalable. La interconexión de redes, utilizando IP, permite la transferencia de paquetes a través de diversas rutas, garantizando la comunicación entre miles de millones de dispositivos.

### EL protocolo IP version 4 (IPv4)

El encabezado de un datagrama IPv4 consta de dos partes : una fija de 20 bytes y una opcional cuya longitud varia. Los bits se transmiten de izquierda  a derecha y de arriba hacia abajo, en un orden de red big-endian , lo que requiere una conversion en maquinas little-endian.

Campos:

- Version(4 bits): INdica la version del protocolo, con la version 4 como la mas utilizada. IPv6 es la siguiente
- IHL (Internet Header Lenght - 4 bits) : Especfica la longitud del encabezado en palabras de 32 bits. El valor minimo es 5 y el maximo es 15 lo que limita el encabezado a 60 bytes.
- Servicios diferenciados (6bits ): Originalmente destinado a priorizar diferentes clases de servicio (por ejemplo, voz o transferencia de archivos), este campo ha cambiado de nombre y ahora se utiliza para marcar el paquete con una clase de servicio y gestionar la congestión.
- Longitud Total (16 bits): Indica el tamaño total del datagrama (encabezado + datos), con un límite de 65,535 bytes
- Identificacion ( 16 bits): Usado para identificar fragmentos de un datagrama y asegurar que pertenezcan al mismo paquete.

* **Suma de verificación del encabezado (16 bits):** Se utiliza para detectar errores en el encabezado mientras el paquete viaja por la red. El algoritmo suma todas las
  medias palabras de 16 bits del encabezado a medida que vayan llegando, mediante el uso de la aritmética de complemento a uno, y después obtiene el complemento a uno del resultado. Para los fines de este
  algoritmo, se supone que la Suma de verificación del encabezado es cero al momento de la llegada. Dicha
  suma de verificación es útil para detectar errores mientras el paquete viaja por la red. Tenga en cuenta que
  se debe recalcular en cada salto, ya que por lo menos hay un campo que siempre cambia (el campo Tiempo
  de vida), aunque se pueden usar trucos para agilizar ese cálculo
* **Desplazamiento del Fragmento (13 bits):** Indica la posición del fragmento dentro del paquete original, permitiendo la reconstrucción del datagrama.
* **Tiempo de Vida (TTL - 8 bits):** Contador que limita la vida útil del paquete en la red. En cada salto, este valor disminuye hasta que llega a cero, momento en el cual el paquete se descarta.
* **Protocolo (8 bits):** Especifica el protocolo de capa superior, como TCP o UDP.
* **Dirección de Origen (32 bits):** Dirección IP del origen del paquete.
* **Dirección de Destino (32 bits):** Dirección IP del destino del paquete.
* **Opciones (Variable):** Permite incluir características adicionales, como seguridad, enrutamiento estricto o libre, y registro de ruta.

## Direcciones IP

Una característica que define a IPv4 consiste en sus direcciones de 32 bits. Cada host y enrutador de Internet tiene una dirección IP que se puede usar en los campos Dirección de origen y Dirección de destino de
los paquetes IP. Es importante tener en cuenta que una dirección IP en realidad no se refiere a un host, sino a una interfaz de red, por lo que si un host está en dos redes, debe tener dos direcciones IP. Sin embargo, en la práctica la mayoría de los hosts están en una red y, por ende, tienen una dirección IP. En contraste, los enrutadores tienen varias interfaces y, por lo tanto, múltiples direcciones IP.

### Prefijos

Las direcciones `IPv4` tienen una mascara que consiste de un numero de 32 bits con un prefijo de $d$ bits todos puestos en $1$ y los demas en $0$. El prefijo representa la direccion de la red mientras que el resto representa la direccion de un host en particular.

Las direcciones IP son jerarquicas , esto significa que la direccion IP se divide en una parcion de red (que es comun para todos los hosts en una misma red) y una porcion de host (que varia entre los diferentes dispositivos en al red). Un prefijo de red es un bloque de direcciones IP continuas . Se representa como `DireccionIP/longitudDeRed` por ejemplo `128.208.0.0/24` donde el `/24` indica que los primeros 24 bits corresponden a la red y el resto son para los hosts.

Los **enrutadores** utilizan este prefijo para hacer el reenvío de los paquetes, basándose únicamente en la porción de red de la dirección.

La `mascara de subred` se utiliz para separar la porcion de red y la porcion de host de una direccion IP. Se representa en forma binaria con una serie de 1s (para la red) y 0s (para los hosts)

OK, funcionamiento:

- Cada enrutador ( y host)) tiene una tabla de ruta, con campos como : Direccion de Red, Mascara de Red, Interfaz , Metrica ,....
- Cuando llega un datagrama, se toma la direccion de destino y por cada mascara de red se hace la operacion AND , si coincide el resultado con el correspondiente direccion en red, entonces se decide enviar el datagrama por esa red.
- Analogamente para un host, se ve si la direccion de desino pertence a la misma red, etonces no necesita ser enviada ela route, mediante las direcciones MAC

### Subredes

El proceso de creacion de una subred es un tecnica fundamental para adminsitrar direccion IP dentro de una red, permitiendo dividir una red mas grande en varias mas pequennas. Por ejemplo una organizacion quiere dividir en partes mas pequennas para diferentes departamnetos o segmentos de su infrastructura.

Por ejemplo a un red que se le asigna `128.208.0.0/16` se divide en subredes para tres departamntos:

- Ciencias COmputacionales : `128.208.0.0/17` que cubre direcciones de `128.208.128.0` a `128.208.191.255`

Lo que se ahce para saber el rango es fijar todos los bits del host a `1` y a partir de ahi se calcual la longtidu del rango y se le suma a la direccion de la red.

Cuando un paquete llega a un enrutador, el enrutador debe determinar a qué subred pertenece la dirección IP de destino. Para hacerlo, el enrutador realiza una operación de **AND** entre la dirección de destino del paquete y las máscaras de subred de las subredes configuradas. La idea es verificar qué subred tiene el prefijo más largo que coincide con la dirección de destino.

Al dividir la red en subredes, los enrutadores no tienen que mantener una tabla con todas las direcciones de cada host (lo que sería ineficiente). En cambio, pueden usar las **máscaras de subred** y realizar la operación AND para verificar qué subred corresponde a la dirección de destino. Esto permite que el proceso de enrutamiento sea más eficiente.

### CDIR : Enrutamiento Interdominio sin Clases

El problema central que aborda CIDR es la **explosión de las tablas de enrutamiento** en Internet.

#### **Problemas en el Enrutamiento**

1. **Tamaño de las tablas de enrutamiento** :

* Los enrutadores en ISP grandes deben manejar tablas de enrutamiento con millones de entradas.
* Buscar en estas tablas a altas tasas de transmisión requiere hardware especializado y memoria rápida.

1. **Intercambio de información de enrutamiento** :

* Los enrutadores deben compartir información sobre las rutas.
* A mayor tamaño de las tablas, mayor complejidad en el intercambio y mayor probabilidad de errores.

1. **Ineficiencia en la asignación de direcciones IP** :

* Una jerarquía rígida (como en la red telefónica) haría ineficiente el uso de los 32 bits de las direcciones IP.

---

#### **Solución: CIDR**

1. **Agregación de rutas** :

* Combina múltiples prefijos pequeños en uno más grande.
* Ejemplo: Tres redes (Cambridge, Oxford y Edimburgo) se resumen en un único prefijo `/19`, reduciendo el número de entradas en las tablas.

1. **Flexibilidad en la asignación de direcciones** :

* Las direcciones no están restringidas por clases rígidas (A, B, C).
* Permite que diferentes prefijos representen bloques de distintos tamaños.

1. **Prefijo más largo coincidente** :

* Cuando un paquete coincide con múltiples prefijos, se elige el que tiene  **la mayor cantidad de bits significativos**
* Ejemplo: Un paquete destinado a una dirección en San Francisco coincidirá primero con un prefijo más específico `/22` antes que con un prefijo más general `/19`.

---

#### **Ejemplo de Asignación de Direcciones**

| Universidad | Dirección inicial | Dirección final  | Tamaño del bloque | Prefijo |
| ----------- | ------------------ | ----------------- | ------------------ | ------- |
| Cambridge   | `194.24.0.0`     | `194.24.7.255`  | 2048 direcciones   | `/21` |
| Edimburgo   | `194.24.8.0`     | `194.24.11.255` | 1024 direcciones   | `/22` |
| Disponible  | `194.24.12.0`    | `194.24.15.255` | 1024 direcciones   | `/22` |
| Oxford      | `194.24.16.0`    | `194.24.31.255` | 4096 direcciones   | `/20` |

* Los enrutadores locales mantienen entradas para cada prefijo.
* En un enrutador distante (ej., Nueva York), los prefijos se combinan en un solo bloque `/19` para reducir las tablas de enrutamiento.

---

#### **Ventajas de CIDR**

1. **Reducción de tablas de enrutamiento** :

* La agregación disminuye las entradas necesarias, lo que reduce costos y complejidad.

1. **Mayor eficiencia en el uso de direcciones IP** :

* Se asignan bloques con tamaños adecuados, evitando desperdicio.

1. **Escalabilidad** :

* Permite que Internet maneje un mayor número de redes sin problemas significativos en el enrutamiento.

### Direccionamiento con clases y especiales

las clases de direcciones son :

- A : bit inicial 0 y prefijo /8
- B : bits iniciales 10 y prefijo /16
- C: bits inciales 110 y prefijo /24
- D : bits iniciales 1110 y no tien prefijo (se usa para enviar paquetes a mutiples host)
- E : bits inciiales 1111 y refijo reservado : para uso futuro

Los problemas son: las redes de clase A son demasidado grande para la mayoria de organiczaiones

Las redes de clase B incluso tambien ,pero son las que mas de adecuan . Las de tipo C son ya muy pequennas , con apenas 256 direcciones. Por tanto se desperdicia de direcciones.

Entonces se introdujo los conceptos de subrdes y CDIR , permitiendo usar prefijos arbitrarios y haciendo mas eficientes las tablas de enrutamiento globales.

`0.0.0.0` representa 'esta red' utilizado spo un host durante el arranque

`255,255.255.255` direccion de difusion para todos los hosts en la reed local

`127.x.y.z` reservada para pruebas de loopback, paquetes no salen del hsot

Direcciones con un solo bit 1 en el campo del host: Usada apra difusiones dirigidas a redes especficas.

### NAT (network address translation)

tecnica descrita en el RFC 3022 que traduce direcciones IP internas privadas en una direccion IP publica para comunicarse con Internet. Es comun en redes domesticas y pequennas empresas, donde un enrutador o caja NAT actua como intermedio.

#### **Funcionamiento de NAT**

1. **Dentro de la red interna:**
   * Cada dispositivo tiene una dirección IP privada (por ejemplo,  **10.0.0.1** ).
   * Los paquetes generados llevan esta dirección como origen.
2. **En el dispositivo NAT:**
   * La dirección IP de origen se reemplaza por la dirección IP pública del cliente (por ejemplo,  **198.60.42.12** ).
   * Se utiliza el campo **puerto de origen** del encabezado TCP/UDP para identificar la conexión original, evitando conflictos si varios dispositivos internos usan el mismo puerto.
3. **Cuando llega una respuesta de Internet:**
   * La caja NAT consulta su tabla de traducción para identificar el dispositivo interno correspondiente y reescribe la dirección IP de destino al reenviar el paquete.

---

#### **Ventajas de NAT**

* **Ahorro de direcciones IP públicas:** Un ISP puede asignar una sola dirección IP pública a una red con múltiples dispositivos internos.
* **Privacidad y seguridad básica:** Bloquea paquetes entrantes no solicitados por defecto.
* **Compatibilidad con redes existentes:** Funciona sin modificar significativamente la infraestructura de red.

---

#### **Problemas y Limitaciones de NAT**

1. **Viola el modelo IP original:**
   * Cada IP debería ser única globalmente, pero NAT permite que múltiples dispositivos compartan una dirección pública.
2. **Rompe la conectividad de extremo a extremo:**
   * Un host externo no puede iniciar una conexión con un dispositivo interno sin configuraciones adicionales (como **port forwarding** o técnicas de NAT transversal), por ejemplo dos hosts interno en redes privadas que usan NAT (donde se tiene configurado por el enrutador el reenvio de puertos)
3. **Dependencia del estado de conexión:**
   * Si la caja NAT falla, se pierden las conexiones activas.
4. **Problemas de compatibilidad con capas superiores:**
   * NAT depende de los encabezados TCP/UDP. Si estos cambian (por ejemplo, puertos más grandes), NAT deja de funcionar.
5. **Limitación de puertos:**
   * Cada dirección pública puede gestionar un máximo de 65,536 conexiones simultáneas (menos en la práctica debido a los puertos reservados).
6. **Problemas con aplicaciones específicas:**
   * Protocolos como FTP o multimedia (H.323) pueden fallar, ya que incluyen direcciones IP en sus datos y NAT no los entiende de forma nativa.

## IPv6

**IPv6** tiene como objetivos:1. Soportar miles de millones de dispositivos.

1. Reducir el tamaño de las tablas de enrutamiento.
2. Hacer el procesamiento de paquetes más rápido.
3. Mejorar la seguridad (autenticación y privacidad).
4. Mejorar la calidad del servicio, especialmente para multimedia.
5. Soportar la  **multidifusión** .
6. Permitir la **movilidad de los dispositivos** sin necesidad de cambiar su dirección.
7. Evolucionar con el tiempo y coexistir con IPv4 durante una transición gradual.

- IPv6 tiene direcciones de 128 bits en vez de 32 bits .
- Tiene solo 7 campos en el encabezado comparado con los 13 campos en IPv6
- Mejora en seguridad , autenticacion y privacidad son integradas en IPv6.
- Mejora en calidad de servicios

### Encabezados de IPv6

- Version : Campo siempre tiene el valor de 6 para IPv6.
- Servicios diferenciados: Similar al cmapo de IPv4 se usa para al calidad de servicios y manejar paquetes con requisitos especiales como los de baja laencia . Los dos bits inferiores se usan para indicar congestionamiento
- Etiqueta de flujo: Permite agrupas paquetes con los mismos requisitos de tratamiento.
- **Longitud de carga útil** : Este campo indica la longitud del contenido del paquete, excluyendo los 40 bytes del encabezado
- 

* **Siguiente encabezado** : Señala el próximo encabezado de extensión (si lo hay), o el protocolo de transporte como TCP o UDP. Esto ayuda a simplificar el encabezado al permitir encabezados de extensión opcionales.
* **Límite de saltos** : Similar al campo TTL (Time to Live) en IPv4, se utiliza para evitar que los paquetes queden atrapados en un bucle infinito. El valor se decrementa en cada salto de red.
* **Dirección de origen y destino** : Las direcciones son de 128 bits (16 bytes), lo que proporciona una cantidad prácticamente ilimitada de direcciones. Las direcciones IPv6 se representan en formato hexadecimal y pueden ser abreviadas utilizando ciertas reglas.

IPv6 no incluye una suma de verificacion en el encabezado ya que se considera inneceario debidao a las sumas de verificacion ya implementados en las capas de enlace de datos y transporte.

Se ha desarrollado una nueva notacion para escribir direcciones de 16 bytes las cuales se escriben como 8 grupos de 4 digitos digitos hexadecimal, separando los grupos por dos puntos como sigue :

`8000:0000:0000:0000:0123:4567:89AB:CDEF`

## Protocolos de control de Internet

Son protocolos que complementan el protocolo IP en la capa de red del modelo OSI o TCP/IP. Su objetivo es gestionar, supervisar y controlar la comunicacion en la red.

### ICMP: protoclo de mensaje de control de internet

> Es un protocolo disennado para gestionar y diagnosticar problemas en la red. opera encapsulado en paquetes IP y permite la comunicacion entre dispositivos para informar eventos , errores y pruebas.
>
> Tipo de mensajes ICMP mas importantes
>
> - Destination unreachable (Destino inaccesible): Se genera cuando un enrutador no puede entregar un paquete a su destino.
> - Time Excedded (timepo excedido): Se envia cuando el TTL (Time to Live) de un paquete llega a cero
> - Parameter Problem (problema de parametros): Indica errores en campos del encabezado IP, sugiriendo problemas en el software del host o enrutador.
> - **Source quench (Fuente disminuida)** :Antiguamente usado para regular el flujo de paquetes en situaciones de congestión.
> - **Redirect (Redirección)** :Un enrutador indica al host emisor que actualice su tabla de rutas con una mejor ruta disponible.
> - **Echo (Eco) y Echo reply (Respuesta de eco)** : Usado para verificar si un dispositivo está activo y alcanzable.
> - Timestamp request/reply (Estampa de tiempo, Petición/Respuesta): Similar a Echo/Echo reply, pero incluye marcas de tiempo para evaluar el rendimiento de la red.
> - **Router advertisement/solicitation (Anuncio/Solicitud de enrutador)** :Facilita la detección de enrutadores cercanos.
>
> `ping` y `traceroute` son herramientas basadas en ICMP

### ARP : Protocolo de Resolucion de Direcciones

El **ARP (Address Resolution Protocol)** es un protocolo de red que traduce las direcciones **IP** (de capa de red) en direcciones **MAC** (de capa de enlace de datos). Este protocolo es esencial en redes como Ethernet, donde las tarjetas de interfaz de red (NIC) utilizan direcciones físicas únicas de 48 bits, y no entienden las direcciones IP directamente.

#### **Cómo funciona ARP?**

1. **Escenario inicial:**
   * Supongamos que tienes dos computadoras en la misma red local:
     * **PC1** :
     * Dirección IP: `192.168.1.2`
     * Dirección MAC: `AA:BB:CC:DD:EE:01`
     * **PC2** :
     * Dirección IP: `192.168.1.3`
     * Dirección MAC: `AA:BB:CC:DD:EE:02`
   * Ahora, **PC1** quiere enviar un mensaje a  **PC2** .
2. **Problema:**
   * PC1 sabe la dirección IP de PC2 (`192.168.1.3`), pero no conoce su dirección MAC (`AA:BB:CC:DD:EE:02`), que es necesaria para enviar un paquete en Ethernet.
3. **Proceso ARP:**
   * **PC1 envía un mensaje de difusión ARP** a toda la red local:
     * "¿Quién tiene la IP `192.168.1.3`? Dime tu dirección MAC".
     * Este mensaje se envía a todas las computadoras de la red (dirección MAC de difusión: `FF:FF:FF:FF:FF:FF`).
4. **Respuesta:**
   * Solo **PC2** responde al mensaje ARP porque es el dueño de la IP `192.168.1.3`.
   * PC2 envía un mensaje directo a PC1 diciendo:
     * "Yo tengo la IP `192.168.1.3` y mi dirección MAC es `AA:BB:CC:DD:EE:02`".
5. **Guardado en caché:**
   * PC1 guarda esta información (IP ↔ MAC) en una tabla llamada **caché ARP** para no tener que preguntar otra vez en un futuro cercano.
6. **Envío del paquete:**
   * Ahora que PC1 conoce la dirección MAC de PC2, puede enviar el paquete directamente a su dirección MAC.

---

#### **Resumen en pasos**

1. Un dispositivo necesita la dirección MAC asociada a una IP.
2. Envía una difusión ARP preguntando: *"¿Quién tiene la IP X?"*
3. El dispositivo con esa IP responde con su dirección MAC.
4. La información se guarda en la caché ARP para futuros usos.
5. El paquete se envía a la dirección MAC encontrada.

---

#### **¿Por qué es importante?**

ARP permite que las computadoras en una red local Ethernet se comuniquen sin necesidad de configurar manualmente las direcciones MAC. Esto simplifica mucho la gestión de redes.

No son importantes las direcciones MAC en un entorno fuera de una red local, ya que las direcciones MAC son especidficas de la capa de enlace de datos.

### Funcionamiento cuando H1 (host) envia datos en Internet a H2  (host)

1. H1 revisa si H2 esta en la misma red local (LAN), para ellos revisa la mascar de subred y la direccion IP de H2. Si H2 esta en al misma red, entonces H1 usara ARP para encontrar la direccion MAC de H2 directamnte y enviar el datagrama. SI no tiene exito , sabe que debe enviar el paquete a su router (gateway predeterminada)
2. H1 lanzara un ARP para encontrar la MAC del router. Si la direccion MAC de router no esta en la cache ARP de H1, H1 envia una solicitud ARP para la direccion IP del router. El router responde y H1 usa esta direccion como destino en la trama.
3. El paquete viaja hacia el router , por ahi envia lainformacion hasta que llega a la red correspondiente usando las tabalas de rutas.
4. Cuando llega al destino que alcanza al router que tiene acceso a la red H2, se hace ARP para encontrar la direccion MAC de H2, si la direccion esta en la cache ARP de H2 se usa sino se hace una solictud. H2 responde y envia su MAC para que le puedan enviar la trama, extrae el paquete IP y lo procesa.

### DHCP : Protocolo de Configuracion Dinamica de Host

Es un mecanismo que permite asignar automaticamente configuraciones esenciales de red como direcciones IP a los dispositivos en una red, eliminando la necesidad de configurar manualmente a cada equipo.

#### **Resumen del funcionamiento de DHCP**

1. **Solicitud de configuración (DHCP DISCOVER):**
   * Cuando un dispositivo arranca, solo tiene su dirección MAC (de la NIC) y no cuenta con una dirección IP.
   * El dispositivo envía un mensaje de difusión **DHCP DISCOVER** para buscar un servidor DHCP.
2. **Oferta de configuración (DHCP OFFER):**
   * El servidor DHCP responde con un mensaje  **DHCP OFFER** , asignando una dirección IP disponible.
   * Si el servidor DHCP está en otra red, el router puede retransmitir las solicitudes y respuestas.
3. **Asignación y confirmación:**
   * El host acepta la dirección IP ofrecida enviando un  **DHCP REQUEST** .
   * El servidor confirma la asignación mediante un mensaje  **DHCP ACK** .
4. **Duración de la asignación (arrendamiento):**
   * Las direcciones IP asignadas tienen un período de arrendamiento.
   * Antes de que expire, el host debe enviar una solicitud de renovación al servidor DHCP.
   * Si el host no renueva, la dirección IP queda libre para ser reasignada.

### Protocolo de enrutamiento en Internet

#### OSPF (Open Shortest Path First)

 un estándar ampliamente utilizado para el enrutamiento intradominio. Aquí tienes un resumen estructurado de los puntos más importantes:

##### 1. **Contexto del Protocolo OSPF**

* **Clasificación:** Protocolo de enrutamiento intradominio (puerta de enlace interior).
* **Origen:** Diseñado por IETF en 1988, se convirtió en estándar en 1990.
* **Finalidad:** Superar limitaciones de protocolos anteriores como RIP (e.g., convergencia lenta, problema de conteo al infinito).
* **Base:** Protocolo de estado del enlace basado en grafo.

##### 2. **Requerimientos y Características Clave**

1. **Publicación Abierta:** Garantiza la disponibilidad del protocolo a cualquier organización.
2. **Soporte para Métricas de Distancia:** Incluye distancia física, retardo, entre otras.
3. **Adaptabilidad Dinámica:** Responde automáticamente a cambios en la topología.
4. **Enrutamiento por Tipo de Servicio:** Originalmente diseñado para IP con diferentes tipos de tráfico.
5. **Balanceo de Carga (ECMP):** Divide tráfico entre rutas de igual costo para optimizar el rendimiento.
6. **Jerarquías de Enrutamiento:** Soporte para áreas jerárquicas que facilitan la escalabilidad.
7. **Seguridad Básica:** Evita la inyección de información falsa.
8. **Soporte para Enlaces y Túneles:** Compatible con múltiples tipos de redes y configuraciones.

##### 3. **Estructura y Operación**

* **Modelado con Grafos:**
  * Representa redes como grafos con nodos y arcos ponderados.
  * A cada enlace se le asigna un costo.
* **Tipos de Enrutadores:**
  * **Internos:** Operan dentro de un área específica.
  * **De Frontera de Área:** Conectan áreas a la red troncal.
  * **Troncales:** Gestionan la red troncal (Área 0).
  * **De Límite de AS:** Conectan sistemas autónomos distintos.
* **Áreas:**
  * Dividen grandes sistemas autónomos en unidades manejables.
  * Cada AS incluye un área troncal que conecta todas las demás áreas.

##### 4. **Mensajes OSPF**

Cinco tipos principales:

1. **Hello:** Descubre vecinos.
2. **Link State Update:** Actualiza información de estado del enlace.
3. **Link State Ack:** Confirma recepción de actualizaciones.
4. **Database Description:** Anuncia entradas de estado del enlace.
5. **Link State Request:** Solicita información específica.

##### 5. **Proceso Operativo**

* Los enrutadores intercambian mensajes para construir una base de datos topológica.
* Cada enrutador calcula las rutas más cortas dentro de su área mediante algoritmos como Dijkstra.
* Los enrutadores de frontera y troncales manejan rutas inter-áreas y hacia otros sistemas autónomos.

##### 6. **Ventajas**

* Escalabilidad mediante áreas jerárquicas.
* Balanceo de carga para mejor rendimiento.
* Respuesta rápida a cambios de topología.
* Protocolo abierto y ampliamente adoptado.

##### Caracteristicas

- Algoritmo de Dijkstra , estado de enlace , velocidad, latencia y congestion
- Envia actualizaciones modulares

### BGP : protocolo de Puerta Enlace Exterior

BGP (Border Gateway Protocol): protocolo de enrutamiento externo que se utiliza para intercambiar información de enrutamiento entre sistemas autónomos (AS). A diferencia de los protocolos de enrutamiento internos como OSPF, que operan dentro de una única red, BGP es crucial para la conectividad entre diferentes redes en Internet. BGP utiliza un enfoque de política de enrutamiento basado en políticas de acceso y preferencias de ruta para determinar las rutas más eficientes para el tráfico entre AS. Esto permite a BGP manejar la complejidad y la escalabilidad de Internet, donde hay millones de routers y redes.

* **BGP se utiliza para interconectar redes (AS)** en lugar de simplemente administrar las rutas dentro de una red.
* **Las decisiones de enrutamiento no se basan solo en la distancia** , sino en políticas que pueden estar relacionadas con costos, seguridad o acuerdos comerciales.
* **Escalabilidad** : BGP maneja redes masivas como las de Internet, donde existen millones de rutas y redes interconectadas


### 5.6.8 **Multidifusión de Internet**

La **multidifusión** permite que un proceso envíe datos a múltiples receptores de forma simultánea, en lugar de tener que enviar una copia a cada receptor individualmente (como en la comunicación uno a uno). Esto es útil para aplicaciones como transmisión de eventos en vivo, actualizaciones de programas, o conferencias telefónicas entre varios participantes.

* **Direcciones IP de clase D** : Estas direcciones son usadas para identificar grupos de hosts que forman parte de una red de multidifusión. Existen más de 250 millones de grupos posibles gracias a los 28 bits disponibles para estas direcciones.
* **Direcciones de multidifusión locales** : Estas direcciones están reservadas para la comunicación dentro de una red local (LAN), como 224.0.0.1 (para todos los sistemas en una LAN) o 224.0.0.251 (para servidores DNS en una LAN).
* **Protocolo IGMP** : Utilizado por los hosts para unirse o abandonar grupos de multidifusión. Los enrutadores multicast envían consultas periódicas a los hosts para que informen a qué grupos pertenecen.
* **Protocolos de enrutamiento para multidifusión** : Como  **PIM (Protocol Independent Multicast)** , que se utiliza dentro de un AS para crear árboles de expansión de multidifusión. PIM tiene dos modos: **denso** (cuando los miembros están distribuidos por toda la red) y **disperso** (cuando los miembros están distribuidos en lugares específicos como suscriptores de televisión por IP).

### 5.6.9 **IP Móvil**

La **IP móvil** permite que los usuarios de Internet mantengan su conexión mientras se desplazan entre diferentes redes, como un dispositivo que cambia de ubicación de una red a otra (por ejemplo, al moverse entre diferentes puntos de acceso Wi-Fi).

* **Desafíos de la movilidad** : En un sistema de direccionamiento IP tradicional, los paquetes enviados a una dirección IP fija no llegarán al dispositivo si este se traslada a otro lugar. Esto plantea problemas para mantener la conectividad sin interrumpir las aplicaciones en uso.
* **Agentes de base** : Cada red que permite la movilidad debe tener un "agente de base" que facilite la comunicación con los dispositivos móviles. Cuando un host móvil se conecta a una red foránea, obtiene una nueva dirección IP (llamada dirección de custodia) y notifica al agente de base sobre su nueva ubicación. Los paquetes destinados al host móvil se envían a través de un túnel al agente de base, que los redirige al dispositivo móvil.
* **ARP y Proxy ARP** : Para asegurarse de que los paquetes lleguen correctamente a los hosts móviles, se utiliza ARP. Cuando el móvil está en su ubicación original, responde con su dirección Ethernet. Cuando está en una red foránea, el agente de base responde a las consultas ARP en lugar del móvil.
* **Problemas de NAT y filtrado de ingreso** : Los paquetes enviados por el host móvil desde una red foránea pueden ser descartados debido al filtrado de ingreso en los enrutadores, ya que su dirección IP de origen no coincide con su ubicación real. La solución es utilizar túneles para enviar los paquetes correctamente.
* **IPv6 para movilidad** : En IPv6, la solución de IP móvil es más eficiente, ya que los paquetes iniciales siguen una ruta larga, pero luego se optimizan para tomar una ruta directa entre el móvil y el destino.


### RESUMEN


La capa de red se encarga de enrutar los paquetes desde la fuente hasta el destino, proporcionando servicios a la capa de transporte. Dependiendo de la red, este proceso puede basarse en datagramas, donde se decide la ruta para cada paquete, o en circuitos virtuales, donde la ruta se define al establecer el circuito.

**Algoritmos de enrutamiento:**

1. **Inundación:** Es un algoritmo simple que envía un paquete a todas las rutas disponibles.
2. **Enrutamiento por vector de distancia:** Cada nodo mantiene una tabla con las distancias a los demás nodos.
3. **Enrutamiento de estado del enlace:** Cada nodo mantiene información sobre el estado de sus enlaces.

Estos algoritmos se adaptan a los cambios en la topología de la red, buscando rutas eficientes y cortas.

**Enrutamiento avanzado:**

* **Jerarquía:** Utilizada en redes grandes para organizar las rutas en varios niveles.
* **Enrutamiento para hosts móviles:** Permite a los dispositivos moverse sin perder la conectividad.
* **Difusión, multidifusión y anycast:** Permiten enviar paquetes a varios destinatarios (multidifusión) o a uno entre varios posibles (anycast).

**Congestión y calidad de servicio (QoS):**
Las redes pueden congestionarse fácilmente, lo que lleva a aumentos en los retrasos y pérdida de paquetes. Los diseñadores de redes deben crear infraestructuras con suficiente capacidad, elegir rutas descongestionadas y aplicar métodos de control como la reducción de la velocidad de las fuentes. La calidad del servicio (QoS) se refiere a asegurar que los paquetes de ciertas aplicaciones se entreguen dentro de ciertos parámetros (por ejemplo, con un retardo mínimo o máxima velocidad de transmisión). Los métodos comunes para garantizar QoS incluyen:

* **Modelado de tráfico**
* **Reservación de recursos en enrutadores**
* **Control de admisión**

**Interconexión de redes:**
Cuando diferentes redes se interconectan, pueden surgir problemas como:

* Diferentes tamaños de paquetes, lo que requiere fragmentación.
* Diferentes protocolos de enrutamiento, lo que necesita protocolos comunes entre redes.
* La **tunelización** puede ayudar en redes hostiles o cuando las redes de origen y destino son diferentes.

**Protocolos en la capa de red:**

* **IP (Internet Protocol):** El protocolo base para el enrutamiento.
* **ICMP (Internet Control Message Protocol):** Usado para mensajes de control.
* **ARP (Address Resolution Protocol):** Asocia direcciones IP con direcciones MAC.
* **DHCP (Dynamic Host Configuration Protocol):** Asigna direcciones IP dinámicamente.
* **MPLS (Multiprotocol Label Switching):** Permite enrutar paquetes IP a través de diversas redes.
* **OSPF (Open Shortest Path First):** Un protocolo de enrutamiento utilizado dentro de una red.
* **BGP (Border Gateway Protocol):** Utilizado para enrutar entre diferentes redes.

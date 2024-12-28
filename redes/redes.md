## Modelos:

* modelo cliente-servidor: servidor y clientes
* modelo peer-to-peer : no hay division de quien es cliente y quien es servidor (redes sociales)

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

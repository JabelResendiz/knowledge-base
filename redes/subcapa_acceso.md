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

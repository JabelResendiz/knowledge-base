# Conferencia #1: Capa física

## Medios de transmisión dirigidos

1. **Almacenamiento persistente**: Mayor ancho de banda posible con aprox. `4.1TB/s` pudiendo entregar petabytes en un lapso de 24 horas. No es operable para comunicacion en tiempo real.
1. **Pares trenzados**: de tipos `UTP`, `Cat 5e Gbit`, `Cat 6 10 Gbit`, `Cat 7 protected`, `Cat 8 10+ Gbit` (menos de 30m). Tiene una distancia máxima sin repetidor de aprox 5km.
1. **Cable coaxial**: Tiene la mayor protección contra interferencias.
1. **Cableado electrico**: Conecta varios dispositivos dentro de una misma red electrica como la del hogar.
1. **Fibra óptica**: Tiene un limite teórico de `50TB/s`, en la actualidad su capacidad real aprovechada es de `100GB/s`. Necesita repetidores cada `50km` max. Es muy frágil(es de vidrio). Necesita de operadores especializados. Tiene dos variantes:
    1. Partial internal reflection
    1. Total internal reflection

## Medios de transmisión inalámbricos

1. **Ondas de Radio**: Fáciles de generar, alcanzan largas distancias, pasan obstáculos sin problemas, son omnidireccionales. Son muy inseguras. Poco ancho de banda.
1. **Microondas**: ej. WiFi, Bluetooth, Red celular... Son direccionales, direccionales, interfieren con los objetos, son absorbidas por el agua, necesitan un repetidor cada aprox `50km`. Tiene mejor ancho de banda que las ondas de radio.
1. **Ondas Infrarojas**: Solo son utilizables en comunicaciones de corta distancia como los controles remotos.
1. **Luz**: Son baratas y seguras pero tienen la desventaja de que se necesitan fotodetectores. Tiene el mayor ancho de banda.

## Sistemas conmutados de telefonía

Permiten conectar múltiples usuarios sin necesitar conectarlos 2 a 2. Consiste de conexiones locales que van a una oficina local, de ahí a una oficina de conmutado y luego pasa por un trunk de alto bandwidth y permite conectar usuarios con un sistema centralizado.

## Conexiones locales

1. **Módem**: Es un dispositivo que convierte señales digitales en señales analógicas para su transmisión a través de la línea telefónica o cablemódem, y viceversa. Permite la comunicación entre computadoras a través de estas líneas, generalmente utilizando una interfaz RS-232 para la transferencia de datos digitales.
1. **ADSL** (Asymmetric Digital Subscriber Line): Utiliza la línea telefónica existente de 2 alambres de cobre para proporcionar acceso a Internet. ADSL permite velocidades de descarga más rápidas que las de las conexiones dial-up, pero las velocidades de carga son generalmente más lentas. Este tipo de conexión es común en áreas urbanas y permite realizar llamadas telefónicas mientras se está conectado a Internet.
1. **Fibra óptica**: Es una tecnología de conexión a Internet que utiliza cables de fibra óptica para transmitir datos a alta velocidad. A diferencia de ADSL, la fibra óptica ofrece velocidades de descarga y carga muy rápidas, lo que la hace ideal para aplicaciones que requieren un alto ancho de banda, como transmisión de video en alta definición, juegos en línea y streaming de video. La fibra óptica es más resistente a la interferencia electromagnética y puede soportar una mayor cantidad de usuarios en una red local.

### Conmutadores de paquetes

Los conmutadores de paquetes, también conocidos como switches, son dispositivos fundamentales en las redes de comunicación electrónica, especialmente en las redes locales (LAN). Su principal función es facilitar la comunicación entre dispositivos dentro de una red, enviando paquetes de datos a su destino correcto basándose en la dirección MAC (Media Access Control) de cada paquete

# Conferencia #3 Subcapa de control de acceso al medio

El problema de asignacion de canales consiste en que solo existe un medio compartido por n usuarios y el uso compartido por parte de todos ellos de forma inadecuada interfiere con el resto de los usuarios.

## Posibles soluciones

1. Asignacion estatica de canales
    1. Radio FM
    1. Telefonia fija
    1. Divide el espectro en n bandas iguales y a cada estacion se le asigna una
1. Asignacion dinamica de canales
    1. Trafico independiente
    1. Único Canal
    1. Colisiones observables
    1. Tiempo continuo o divido en intervalos
    1. Sentido o asuencia de sentido del medio

## Protocolos de acceso multiple

* ALOHA:
    1. Cada estación transmite si tiene datos que enviar a una estación central
    1. Se retransmiten los datos desde la estación central a las secundarias
    1. Se eliminan los paquetes involucrados en una colisión
    1. En caso de colisión. Se espera una cantidad de tiempo aleatorio para volver a enviar
* ALOHA con intervalos:
    1. Reloj central que emite ticks marcando el inicio del intervalo
    1. Solo se permite enviar frames al inicio de un intervalo
* 1-persistent CSMA:
    1. Cada estación escucha el medio hasta que puede transmitir
    1. Si el medio esta libre. Transmite sus datos con probabilidad 1
    1. Si ocurre una colisión espera un intervalo de tiempo aleatorio y comienza de nuevo
    1. Suceptible a la demora de la propagación
* CSMA no persistente:
    1. Si el medio esta ocupado, espera un tiempo aleatorio para volver a escuchar el medio
    1. Menos colisiones
    1. Mayor tiempo de espera
* p-persistent CSMA:
    1. Medios con intervalos de tiempo
    1. Cada estación escucha el medio hasta que puede transmitir
    1. Si el medio esta libre. Transmite sus datos con probabilidad p
    1. Si ocurre una colisión espera un intervalo de tiempo aleatorio y comienza de nuevo
* Sentido del medio:
    1. 1-persistent CSMA ( carrier sense multiple access )
    1. CSMA no persistente
    1. p-persistent CSMA
    1. CSMA con detección de colisiones

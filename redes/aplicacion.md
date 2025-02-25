## CAPA DE APLICACIÓN

### DNS

El Sistema de Nombres de Dominio (DNS) es fundamental para la navegación en Internet, ya que permite a los usuarios acceder a recursos en la red mediante nombres legibles en lugar de direcciones IP numéricas. Aunque es posible referirse a páginas web y otros recursos usando direcciones IP, recordar estos números es complicado para las personas. Por ejemplo, si un servidor web cambia su dirección IP, todos tendrían que ser informados sobre la nueva dirección. Corre por el puerto 53(UDP) de protocolo UDP.

> ##### Cómo Funciona el DNS
>
> 1. **Proceso de Resolución** : Para convertir un nombre de dominio en una dirección IP, una aplicación utiliza un procedimiento de biblioteca llamado  **resolvedor** .
> 2. **Consulta** : El resolvedor envía una consulta al servidor DNS local con el nombre del dominio.
> 3. **Respuesta** : El servidor DNS busca el nombre y devuelve la dirección IP al resolvedor.
> 4. **Conexión** : Una vez que se obtiene la dirección IP, la aplicación puede establecer una conexión TCP o enviar paquetes UDP a ese host.

Los mensajes de solicitud y respuesta entre el resolvedor y el servidor DNS se transmiten utilizando paquetes UDP, lo que permite una comunicación eficiente y rápida.

#### Jerarquía del DNS:

* **Nivel Superior (Raíz)** : En Internet, la jerarquía comienza en la raíz (sin nombre) y se divide en  **dominios de nivel superior (TLDs)** , administrados por ICANN (Internet Corporation for Assigned Names and Numbers). Cada dominio de nivel superior puede contener subdominios.
* **Dominios Genéricos** : Los TLDs genéricos incluyen dominios como `.com`, `.org`, `.edu`, etc. Estos dominios agrupan diferentes tipos de organizaciones y tienen ciertos criterios para su uso (por ejemplo, `.edu` para instituciones educativas).
* **Dominios de País** : Se incluyen en esta categoría los dominios asignados a países según la norma ISO 3166, como `.us` para Estados Unidos, `.jp` para Japón, etc. Además, en 2010 se introdujeron dominios internacionalizados, permitiendo el uso de alfabetos distintos al latín, como árabe o chino.
* **Subdivisión de Dominios** : Los dominios se subdividen jerárquicamente a medida que se desciende en el árbol. Por ejemplo, un dominio como `eng.cisco.com` representa un subdominio dentro de `cisco.com`, que a su vez es parte de `com`.
* **Dominios Absolutos y Relativos** : Un nombre de dominio absoluto siempre termina con un punto (`eng.cisco.com.`), mientras que un dominio relativo no lo hace y se interpreta en un contexto determinado (por ejemplo, `eng.cisco.com` en un contexto de búsqueda dentro del dominio).

#### Registro de recursos

Un **registro de recursos** es una **5-tupla** que contiene información clave para resolver una consulta DNS. El formato general es:

```nginx
Nombre_dominio Tiempo_de_vida Clase Tipo Valor
```

* **Nombre_dominio** : El dominio asociado al registro, siendo la clave primaria de búsqueda.
* **Tiempo_de_vida (TTL)** : Tiempo durante el cual el registro se mantiene válido en caché. Este valor se expresa en segundos.
* **Clase** : Casi siempre es **IN** (para Internet), pero puede variar en otros casos.
* **Tipo** : Especifica el tipo de registro DNS (A, MX, NS, etc.).
* **Valor** : Depende del tipo de registro, como una dirección IP o un nombre de dominio.

```css
example.com. 86400 IN A 93.184.216.34
```


#### Resumen

Cuando se escribe una URL como `github.com` en tu navegador , el sistema DNS se encarga de traducir este nombre de dominio a una dirección IP que el navegador necesita para establecer una conexión con el servidor de GitHub. Lo primero que hace el navegador es verificar si ya tiene la dirección IP correspondiente a `github.com` almacenada en su  **caché local** . Si no está en la caché del navegador, entonces necesita realizar una consulta DNS para obtenerla.

Si la dirección no está en la caché del navegador, la solicitud se envía a un servidor  **DNS recursivo** . Este servidor generalmente es proporcionado por tu ISP (Proveedor de Servicios de Internet) o puede ser un servidor DNS público como los de Google (8.8.8.8) o Cloudflare (1.1.1.1).

El servidor recursivo intenta resolver la consulta de la forma más eficiente posible. Si tiene la dirección IP de `github.com` en su  **caché** , la devuelve al navegador inmediatamente.

Si el servidor DNS local no tiene la dirección IP en su caché, comienza a hacer consultas a otros servidores. Primero, envía una consulta a un  **servidor raíz** . Los servidores raíz no conocen la dirección IP de `github.com` directamente, pero saben qué servidores manejarán los dominios de nivel superior, como `.com`.

Por ejemplo, el servidor raíz diría: "No sé dónde está `github.com`, pero sé que los servidores de nombres del TLD `.com` pueden ayudar".

El servidor raíz responde con la dirección de los **servidores de nombres** responsables de los dominios `.com`. El servidor DNS recursivo ahora consulta uno de esos servidores.

El servidor TLD `.com` tampoco tiene la IP directa de `github.com`, pero sabe que el dominio `github.com` tiene servidores específicos responsables de él, es decir, los **servidores autoritativos** de GitHub.

El servidor TLD `.com` responde con la dirección de los  **servidores DNS autoritativos de GitHub** . Estos servidores contienen la información precisa para resolver `github.com`.

El servidor DNS recursivo ahora realiza una consulta a los servidores autoritativos de GitHub para obtener la dirección IP de `github.com`.

Los servidores autoritativos de GitHub responden con la dirección IP asociada a `github.com`.

La dirección IP de `github.com` se envía de vuelta al servidor DNS recursivo, que la guarda en su caché para futuras consultas. Luego, el servidor DNS recursivo envía esta dirección IP al navegador.

Una vez que el navegador recibe la dirección IP, puede usar ese valor para realizar una conexión directa con el servidor de GitHub a través de  **TCP/IP** . El navegador ahora puede enviar solicitudes HTTP(S) al servidor de GitHub, y recibir la página web que pediste.

Los servidores DNS suelen guardar la dirección IP en su caché durante un tiempo determinado. Este tiempo se controla mediante el campo **TTL** (Time to Live), que indica cuánto tiempo una respuesta DNS debe considerarse válida antes de tener que consultar nuevamente. El TTL puede variar, pero generalmente puede ser desde unos pocos minutos hasta varias horas.

##### Resumen del Flujo de Proceso para `github.com`:

1. El navegador consulta si la IP está en su caché.
2. Si no está, envía la consulta al servidor DNS recursivo. (de tu proveedor de red o una publica como la de google (8.8.8.8))
3. El servidor DNS recursivo consulta los servidores raíz.
4. El servidor raíz remite la consulta a los servidores del TLD `.com`.
5. Los servidores del TLD `.com` remiten la consulta a los servidores autoritativos de GitHub.
6. Los servidores autoritativos de GitHub devuelven la dirección IP de `github.com`.
7. El navegador se conecta a GitHub usando la dirección IP y carga el contenido.

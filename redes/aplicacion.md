## CAPA DE APLICACIÓN

### DNS

El Sistema de Nombres de Dominio (DNS) es fundamental para la navegación en Internet, ya que permite a los usuarios acceder a recursos en la red mediante nombres legibles en lugar de direcciones IP numéricas. Aunque es posible referirse a páginas web y otros recursos usando direcciones IP, recordar estos números es complicado para las personas. Por ejemplo, si un servidor web cambia su dirección IP, todos tendrían que ser informados sobre la nueva dirección.


> ##### Cómo Funciona el DNS
>
> 1. **Proceso de Resolución** : Para convertir un nombre de dominio en una dirección IP, una aplicación utiliza un procedimiento de biblioteca llamado  **resolvedor** .
> 2. **Consulta** : El resolvedor envía una consulta al servidor DNS local con el nombre del dominio.
> 3. **Respuesta** : El servidor DNS busca el nombre y devuelve la dirección IP al resolvedor.
> 4. **Conexión** : Una vez que se obtiene la dirección IP, la aplicación puede establecer una conexión TCP o enviar paquetes UDP a ese host.



Los mensajes de solicitud y respuesta entre el resolvedor y el servidor DNS se transmiten utilizando paquetes UDP, lo que permite una comunicación eficiente y rápida.


from platform import machine
from re import M


promiscuidad = [10, "abc", 3.14, (100, 200), {"nombre": "juan", "edad": 25}]
print (f"Tengo de todo {len(promiscuidad)} items\n  {promiscuidad}")
input()
promiscuidad += (20, 30, 40)
print (f"Puedo crecer, ahora tengo {len(promiscuidad)} items\n  {promiscuidad}\n")
input()
i = 3
promiscuidad[i] = "ya no soy un tuplo"
print (f"Me cambiaron el elemento en la posicion {i}")
print (f"  Ahora soy \n  {promiscuidad}")
input()

print (f"Cada cual es lo que es, le sumo 100 a lo que tengo en la posicion 0 \n  {promiscuidad[0]+100}\n")
input()

#print (f"PERO NO LE PIDAS POR LO QUE NO ES {promiscuidad[1]+100}\n")

#COMENTA LA DE ARRIBA Y PRUEBA CON ESTA
print (f"TAMPOCO ME PIDAS LO QUE NO TENGO {promiscuidad[100]}\n")

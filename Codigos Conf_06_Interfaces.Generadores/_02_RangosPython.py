from string import printable



for i in range(3, 8):
  print(i) #escribe del 3 al 7, el extremo del rango no esta incluido
print()

for i in range(4): #implicito empieza a partir de 0
  print(i)
print()

for i in range(6, -4, -2): #si se ponen tres enteros el tercero es el paso (incremento)
  print(i)
print()

for i in range(10, 0, 4): #Si no hay rango no se genera nada
  print(i)
print()

n = 4
for k in range(n): #Los valores del rango se determinan en runtime
  print(k)
print()

n = 4
for k in range(n): #Los valores del rango se determinan en runtime
  print(k)
  n = 2 #Este es otro n, no afecta el n de cuando se definio el rango
print()

print (f"el rango es una funcion {range(10,20)}") #el range es una funcion no es una lista en memoria
enteros = list(range(10,20)) #pero puede construirse una lista fisica a partir del rango
print(f"el rango convertido en lista {enteros}")
k = 3
enteros[k] = 1000
print(f"la lista luego de modificar el elemento {k} {enteros}")
print (f"el elemento {k} de {range(10, 20)} es {range(10,20)[k]}") #el rango puede indizarse





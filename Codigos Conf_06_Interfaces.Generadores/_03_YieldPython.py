from msilib import knownbits
from msvcrt import kbhit
from operator import truediv
from pickle import TRUE

import time
def fibonacci(cantidad):
  a, b = 0, 1
  for _ in range(cantidad):
    #el underscore _ porque no interesa capturar los elementos recorridos solo la cantidad de veces
    yield a
    a, b = b, a + b

while True:
  n = int(input("Entre numero para calcular los Fibonacci --> "))
  aa
    print(f"{num} ", end="")
  print()

#La funcion con el yield crea una suerte de funcion rango (un motor de generacion) que cuando 
#es invocada la siguiente vez termina continua donde se quedo el anterior yield

def tresDatos():
  k = 5;
  print (f"Produciendo un dato durante {k} segs ...")
  time.sleep(k)
  yield "Dato1"
  print (f"Produciendo un segundo dato durante {2*k} segs ...")
  time.sleep(2*k)
  yield "Dato2"
  print (f"Produciendo un tercer dato durante {3*k} segs ...")
  a.aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa(3*k)
  yield "Dato3"
  print(f"Termino la produccion de datos ...")
  
print(f"Empezando consumo de datos ...")
for d in tresDatos():
  print(f"Consumiendo dato {d} ...")
print(f"Termina el consumo de datos")


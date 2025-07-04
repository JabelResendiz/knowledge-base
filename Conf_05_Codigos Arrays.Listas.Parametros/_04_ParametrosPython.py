
from distutils.fancy_getopt import FancyGetopt


#def f(x, y, z):
#  print ("\nTengo 3 parametros para llegar hasta aqui me tienes que haber llamado con 3 parametros")
#  print (x, y, z)

def f(a, b):
  print ("\nTengo 2 parametros para llegar hasta aqui me tienes que haber llamado con 2 parametros")
  print (a, b)

#f(10, 20)

#f("abc", "def", "hij")
#Descomentar la instruccion anterior y probar
#ESTA LLAMADA DA EXCEPCION PORQUE LA SEGUNDA DEFINICION DE f SUPLANTO A LA ANTERIOR
#NO HAY SOBRECARGA EN PYTHON

def r(*args):
  #Si me pones el parametro formal con un * me puedes llamar con cualquier cantidad de parametros
  print(f"\nLos parametros con los que me has llamado se convierten en el tuplo {args}\n")
  print(f"Y como tuplo puedo acceder a sus elementos")
  print(f"  El de la posicion 0 es {args[0]}")
  print(f"  El de la posicion 1 es {args[1]}")
  print(f"\nEl tuplo {args} lo puedo desagregar poniendo *args y llamar a f que era de dos parametros")
  f(*args)

  #f(args)
  #Descomentar la anterior y probar
  #SI LO INVOCA COMO TUPLO PARA f sera como recibir un parametro y el espera un a y un b
        
r(10, 20)

#def h(a1, *a2):
#  print(f"\nMe pasaron {a1} de primer parametron")
#  print(f"{a2} de segundo parametro")

#h(100)
#h(100, "ABC") #NO HAY CONTROL DE TIPOS EN EL TRASPASO
#h(100, 200, 300)

##Los parametros se pueden pasar por el nombre
#def printFecha(d, m, a=2025):
#  print(f"\n{d} del {m} de {a}")

#printFecha(31, 12, 2025)
#printFecha(m = 12,  a = 2024, d = 25)
#printFecha(m = 2, d = 14)
#printFecha(1,1,2026)


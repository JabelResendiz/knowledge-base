import time
#FUNCIONAL MideTiempo
def MideTiempo(funcion):
  def funcionMedida(*args):
    start = time.time()
    result = funcion(*args)
    end = time.time()
    ms = (end - start)*1000
    return (result, round(ms))
  return funcionMedida

#FUNCIONAL Memoize
def Memoize(funcion):
  dicc = {} #diccionario vacio que hara de clausura de la funcion decorada
  #el diccionario tendra como llave de entrada un tuplo con los parametros que se le pasan a la funcion
  #y tendra como valor asociado el resultado que da evaluar la funcion original para esos parametros
  def memoizedFunction(*args):
    #*args captura en un tuplo args los parametros con los que se llame a esta funcion decorada
    if args in dicc:
      return dicc[args] 
    else:
      result = funcion(*args)
      #llamar con *args siendo args un tuplo desagrega los valores del tuplo para que correspondan
      #con la sintaxis de la funcion original
      dicc[args] = result
      return result
  return memoizedFunction

@MideTiempo
def FibIterativoTimed(n):
  if n == 0: return 0
  if n == 1: return 1
  ultimo = 1
  penultimo = 0
  for k in range (2,n+1):
    ultimo, penultimo = ultimo+penultimo, ultimo
  return ultimo

@Memoize
def FibRecMemoized(n):
  if n==0: return 0
  if (n==1 or n == 2): return 1
  else: 
    return FibRecMemoized(n-1)+FibRecMemoized(n-2)

FibRecMemoizedTimed = MideTiempo(FibRecMemoized)

@MideTiempo
@Memoize
def FibRecMemoizedTimed2(n):
  if n==0: return 0
  if (n==1 or n == 2): return 1
  else: 
    return FibRecMemoizedTimed2(n-1)+FibRecMemoizedTimed2(n-2)


while True:
  s = input("\nEntra un numero para Fibonacci (Enter para terminar): ")
  if s == '': break 
  n = int(s)

  (result, ms) = FibIterativoTimed(n)
  print("FibIterativo de          ",n,"=",result," calculado en ",ms,"ms")

  (result, ms) = FibRecMemoizedTimed(n)
  print("FibRecursivo Memoized de ",n,"=",result," calculado en ",ms,"ms")

  ###RECURSIVO CON DECORADOR APILADO
  (result, ms) = FibRecMemoizedTimed2(n)
  print("FibRecursivoMemoized Apilado con MideTiempo de ",n,"=",result," calculado en ",ms,"ms")
  ##No funciona en este caso porque la decoracion apilada @MideTiempo@Memoize envuelve la funcion original de modo que la decoracion MideTiempo se mete dentro de la recursion
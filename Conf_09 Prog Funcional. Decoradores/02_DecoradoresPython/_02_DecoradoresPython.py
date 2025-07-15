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
  dicc = {} 
  def memoizedFunction(*args):
    if args in dicc:
      return dicc[args] 
    else:
      result = funcion(*args)
      dicc[args] = result
      return result
  return memoizedFunction

def FibIterativo(n):
  if n == 0: return 0
  if n == 1: return 1
  ultimo = 1
  penultimo = 0
  for k in range (2,n+1):
    ultimo, penultimo = ultimo+penultimo, ultimo
  return ultimo

def FibRec(n):
  if n==0: return 0
  if (n==1 or n == 2): return 1
  else: 
    return FibRec(n-1)+FibRec(n-2)

def FibRecDeep(n):
  if n==0: return 0
  if (n==1 or n == 2): return 1
  else: 
    return FibRecDeep(n-1)+FibRecDeep(n-2)

FibRecDeep = Memoize(FibRecDeep)
#El que vamos a memorizar en profundidad se lo tenemos que asignar a el mismo

def SumaLenta(m, n):
  sum = m + n
  time.sleep(sum)
  return sum

def SumaLentaMemoized(m, n):
  sum = m + n
  time.sleep(sum)
  return sum

SumaLentaMemoized = Memoize(SumaLentaMemoized)

#PROBANDO FIBONACCI
while True:
  s = input("\nEntra un numero para Fibonacci (Enter para terminar): ")
  if s == '': break
  n = int(s)

  #ITERATIVO
  fibIterTimed = MideTiempo(FibIterativo)
  (result, ms) = fibIterTimed(n)
  print("FibIterativo de             ",n,"=",result," calculado en ",ms,"ms")

  ##RECURSIVO
  fibRecTimed = MideTiempo(FibRec)
  (result, ms) = fibRecTimed(n)
  print("FibRecursivo de             ",n,"=",result," calculado en ",ms,"ms")

  ##RECURSIVO MEMOIZED SIN PROFUNDIDAD
  fibRecMemoizedTimed = MideTiempo(Memoize(FibRec))
  (result, ms) = fibRecTimed(n)
  print("FibRecursivoMemoized de     ",n,"=",result," calculado en ",ms,"ms")

  ##RECURSIVO MEMOIZED CON PROFUNDIDAD
  fibRecDeepMemoizedTimed = MideTiempo(FibRecDeep)
  (result, ms) = fibRecDeepMemoizedTimed(n)
  print("FibRecursivoDeepMemoized de ",n,"=",result," calculado en ",ms,"ms")

##PROBANDO SUMALENTA
while True:
  s = input("\nEntra primer sumando (Enter para terminar): ")
  if s == '': break
  m = int(s)
  s = input("Entra segundo sumando (Enter para terminar): ")
  if s == '': break
  n = int(s)

  SumaLentaTimed = MideTiempo(SumaLenta)
  (r, t) = SumaLentaTimed(20, 30, 40)
  print("SumaLenta de         ",m," y ",n, "=", r,"en ",t,"ms")

  sumaLentaMemoizedTimed = MideTiempo(SumaLentaMemoized)
  (r, t) = sumaLentaMemoizedTimed(m,n)
  print("SumaLentaMemoized de ",m," y ",n, "=", r,"en ",t,"ms\n")

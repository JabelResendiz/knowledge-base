from platform import machine
from re import M


elems = [100, 50, 120, 70, 200]
print (elems)
def MinMax(a):
  m = a[0]
  n = a[0]
  for i in range(1,len(a)):
    if (a[i]<m): m = a[i]
    elif (a[i]>n): n = a[i]
  return (m,n)
result = MinMax(elems)
print(f"Minimo {result[0]} Maximo {result[1]}")
print(f"Minimo Maximo {result}")
min, max = result
print(f"Desagregados explicitamente Minimo {min+90} Maximo {max}")
print(f"Desagregados por indice Minimo {result[0]} Maximo {result[1]}")


#result[0] = -1000 #ERROR LOS TUPLOS NO PUEDEN SER INDIZABLES
#print(result.min) #ERROR min no es una variable de result
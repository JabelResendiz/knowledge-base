import math

class Punto:
  def __init__(self, x, y):
    self.x = x
    self.y = y

  def distancia(self, otro):
    return math.sqrt((self.x - otro.x)**2 + (self.y - otro.y)**2)

  def __repr__(self):
    return f"Punto({self.x}, {self.y})"

class Poligono:
  def __init__(self, puntos):
    if len(puntos) < 3:
        raise ValueError("Un poligono debe tener al menos 3 puntos")
    self.puntos = puntos

  def perimetro(self):
    perim = 0
    n = len(self.puntos)
    for i in range(n):
        perim += self.puntos[i].distancia(self.puntos[(i+1) % n])
    return perim

  def area(self):
    # Area usando la formula del poligono de coordenadas (formula de Gauss)
    n = len(self.puntos)
    suma = 0
    for i in range(n):
        x1, y1 = self.puntos[i].x, self.puntos[i].y
        x2, y2 = self.puntos[(i+1) % n].x, self.puntos[(i+1) % n].y
        suma += x1 * y2 - x2 * y1
    return abs(suma) / 2

  def __repr__(self):
    return f"Poligono({self.puntos})"

class Circulo:
  def __init__(self, centro, radio):
    if radio < 0:
        raise ValueError("El radio debe ser positivo")
    self.centro = centro
    self.radio = radio
  def area(self):
    return math.pi * self.radio**2
  def perimetro(self):
    return 2 * math.pi * self.radio
  def __repr__(self):
    return f"Circulo(centro={self.centro}, radio={self.radio})"

# Ejemplo de uso:

p1 = Punto(0, 0)
p2 = Punto(4, 0)
p3 = Punto(4, 3)

print(f"Distancia entre {p1} y {p2}: {p1.distancia(p2)}")  # 4.0

triangulo = Poligono([p1, p2, p3])
print(f"\nPerimetro de {triangulo}: {triangulo.perimetro()}")  # 12.0
print(f"Area de { triangulo}: {triangulo.area()}")            # 6.0

rectangulo = Poligono([Punto(0,0), Punto(0,30), Punto(20,30), Punto(20,0)])
print(f"\nPerimetro de {rectangulo}: {rectangulo.perimetro()}")  # 12.0
print(f"Area de {rectangulo}: {rectangulo.area()}")            # 6.0

circ = Circulo(Punto(100,100), 10)
print(f"\nPerimetro de {circ}: {circ.perimetro()}")  # 12.0
print(f"Area de {circ}: {circ.area()}")            # 6.0

figuras = [circ, triangulo, rectangulo]
print("\nFIGURAS")
for x in figuras:
  print(f"  {x}")
figuras = sorted(figuras, key=lambda f: f.area())
print("\nOrdenadas por area de menor a mayor son")
for x in figuras:
  print(f"  {x} area {x.area()}")

#DESCOMENTAR LO QUE SIGUE Y PROBAR ESTE CODIGO
intruso = 1000
figuras = figuras+[intruso]
print("\nFIGURAS + intruso")
for x in figuras:
  print(f"  {x}")
figuras = sorted(figuras, key=lambda f: f.area())
print("\nOrdenadas por area de menor a mayor son")
for x in figuras:
  print(f"  {x} area {x.area()}")



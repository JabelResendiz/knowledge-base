import math

class Punto:
  def __init__(self, x, y):
      self.x = x
      self.y = y

  def distancia(self, otro):
      return math.sqrt((self.x - otro.x)**2 + (self.y - otro.y)**2)

  def __repr__(self):
      return f"Punto({self.x}, {self.y})"

class Figura:
  def area(self):
      """Debe ser implementado en las clases hijas"""
      raise NotImplementedError("El metodo area() debe ser implementado en la subclase")
    
  def perimetro(self):
      """Debe ser implementado en las clases hijas"""
      raise NotImplementedError("El metodo perimetro() debe ser implementado en la subclase")
    
  @staticmethod
  def ordena_por_area(figuras):
      """Ordena la lista de figuras por area"""
      return sorted(figuras, key=lambda f: f.area())
    
  @staticmethod
  def ordena_por_perimetro(figuras):
      """Ordena la lista de figuras por perimetro"""
      return sorted(figuras, key=lambda f: f.perimetro())

class Circulo(Figura):
  def __init__(self, centro, radio):
      self.centro = centro  # puede ser un punto, pero aqui solo usamos radio
      self.radio = radio
    
  def area(self):
      import math
      return math.pi * self.radio ** 2
    
  def perimetro(self):
      import math
      return 2 * math.pi * self.radio
    
  def __repr__(self):
      return f"Circulo(centro {self.centro} radio {self.radio}, perimetro {self.perimetro()} area = {self.area()}"

class Poligono(Figura):
  def __init__(self, puntos):
      self.puntos = puntos  # lista de puntos (tuplas o objetos Punto)
     
  def area(self):
    # Area usando la formula del poligono de coordenadas (formula de Gauss)
    n = len(self.puntos)
    suma = 0
    for i in range(n):
        x1, y1 = self.puntos[i].x, self.puntos[i].y
        x2, y2 = self.puntos[(i+1) % n].x, self.puntos[(i+1) % n].y
        suma += x1 * y2 - x2 * y1
    return abs(suma) / 2

  def perimetro(self):
    perim = 0
    n = len(self.puntos)
    for i in range(n):
      perim += self.puntos[i].distancia(self.puntos[(i+1) % n])
    return perim

  def __repr__(self):
      return f"Poligono {self.puntos} perimetro {self.perimetro()} area {self.area()})"

triangulo = Poligono([Punto(0,0), Punto(0,5), Punto(500,0)])
print(f"\nPerimetro de {triangulo}: {triangulo.perimetro()}")  # 12.0
print(f"Area de { triangulo}: {triangulo.area()}")            # 6.0

rectangulo = Poligono([Punto(0,0), Punto(0,3), Punto(10,3), Punto(10,0)])
print(f"\nPerimetro de {rectangulo}: {rectangulo.perimetro()}")  # 12.0
print(f"Area de {rectangulo}: {rectangulo.area()}")            # 6.0

circ = Circulo(Punto(100,100), 4)
print(f"\nPerimetro de {circ}: {circ.perimetro()}")  # 12.0
print(f"Area de {circ}: {circ.area()}")            # 6.0

figuras = [circ, triangulo, rectangulo]
print("\nFIGURAS")
for x in figuras:
  print(f"  {x}")
figuras = Figura.ordena_por_perimetro(figuras)
print("\nOrdenadas por perimetro")
for x in figuras:
  print(f"  {x}")
figuras = Figura.ordena_por_area(figuras)
print("\nOrdenadas por area")
for x in figuras:
  print(f"  {x}")

intruso = 1000
figurasMasIntruso = figuras+[1000]
print("\nFIGURAS + INTRUSO")
for x in figurasMasIntruso:
  print(f"  {x}")

#DESCOMENTE EL CODIGO A CONTINUACION Y PRUEBE. POR QUE DA EXCEPCION?
ordenados = Figura.ordena_por_perimetro(figurasMasIntruso)





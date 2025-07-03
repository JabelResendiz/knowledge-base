

# operadores magicos en python
#sobrecargadno el operador de suma de vecotres

class Vector:
    def __init__(self,x,y):
        self.x = x
        self.y = y

    def __add__(self,other):
        return Vector(self.x+other.x, self.y+ other.y)
    
    def __repr__(self):
        return f"Vector({self.x},{self.y})"

v = Vector(12,23)

print(v+Vector(12,38))
print(Vector.__mro__)



class A:
    def metodo(self):
        print("A")

class B(A):
    def meto2do(self):   
        print("B init")
        super().metodo()

class C():
    def metodo(self):
        print("C")
        super().metodo()

class D(B,C):
    def metodo(self):
        print("D")
        super().metodo()


d= D()
d.metodo()
print(D.__mro__)
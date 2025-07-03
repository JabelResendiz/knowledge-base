

class A:
    def metodo(self):
        print("A")

class B(A):
    def FREE(self):
        print("B")
        

class C:
    def metodo(self):
        print("C")

class D(B,C):
    def metodo(self):
        print("D")
        super().metodo()


class E(D,B):
    def metodo(self):
        print("E")
        super().metodo()

# d= D()
# d.metodo() 

e = E()
e.metodo()

# MRO es : D -> B -> A
# EL MRO HACE UN DFS EN EL MISMO ORDEN BUSCANDO SI EXISTE ALGUNA IMPLEMENTACION DE ESA CLASE , NO IMPORTA QUE b NO TENGA ESA IMPLMENETACION, SEGUIRA BUSCANDO RECURSIVAMENTE EN SUS HIJOS

def contract(require = None, ensure = None):
    def decorador(func):
        def wrapper(*args, **kwargs):
            if require is not None:
                if not require (*args, **kwargs):
                    raise ValueError(f"Precondicion fallida : {require.__name__}")
            
            result = func(*args,**kwargs)

            if ensure is not None:
                if not ensure(result):
                    raise ValueError(f"Postcondicion fallida : {ensure.__name__}")

            return result
        return wrapper
    return decorador   

@contract(require = lambda x: x>0                     #precondicion : x debe ser positivo
          , ensure = lambda result: result >0 )       # postoncdicion: el ersutlado debe ser positivo
def calcular_raiz(x):
    return x**0.5

print(calcular_raiz(12))
#print(calcular_raiz(-9))
print(calcular_raiz(81))

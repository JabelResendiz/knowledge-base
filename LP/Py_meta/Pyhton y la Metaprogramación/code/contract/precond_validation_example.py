from contract_decorator import contract, ContractError

# Definimos precondiciones específicas para cada firma de función
def pre_f0(x):
    return True

def pre_f1(x, y):
    return True

def pre_f2(x, y=0):
    return True

def pre_f3(x, *, y):
    return True

def pre_f4(x, *, y=0):
    return True

def pre_f5(x, y, *, z):
    return True

def pre_f6(x, y, *, z=0):
    return True

def pre_f7(x, y=0, *, z):
    return True

def pre_f8(x, y=0, *, z=0):
    return True

# Definimos una postcondición simple que siempre es verdadera para demostrar
def result_always_true(result):
    return True

@contract(require=pre_f0, ensure=result_always_true)
def f0(x):  # Bien
    return True

@contract(require=pre_f1, ensure=result_always_true)
def f1(x, y):  # Mal
    return True

@contract(require=pre_f2, ensure=result_always_true)
def f2(x, y=0):  # Bien
    return True

@contract(require=pre_f3, ensure=result_always_true)
def f3(x, *, y):  # Mal
    return True

@contract(require=pre_f4, ensure=result_always_true)
def f4(x, *, y=0):  # Bien
    return True

@contract(require=pre_f5, ensure=result_always_true)
def f5(x, y, *, z):  # Mal
    return True

@contract(require=pre_f6, ensure=result_always_true)
def f6(x, y, *, z=0):  # Mal
    return True

@contract(require=pre_f7, ensure=result_always_true)
def f7(x, y=0, *, z):  # Mal
    return True

@contract(require=pre_f8, ensure=result_always_true)
def f8(x, y=0, *, z=0):  # Bien
    return True

def test_functions():
    """Prueba todas las funciones y muestra si cumplen con la validación del contrato."""
    functions = [
        (f0, "f0(1)", lambda: f0(1), "Bien - Solo parámetro posicional"),
        (f1, "f1(1)", lambda: f1(1), "Mal - Falta argumento posicional requerido 'y'"),
        (f2, "f2(1)", lambda: f2(1), "Bien - Parámetro 'y' tiene valor por defecto"),
        (f3, "f3(1)", lambda: f3(1), "Mal - Falta argumento keyword-only requerido 'y'"),
        (f4, "f4(1)", lambda: f4(1), "Bien - Parámetro keyword-only 'y' tiene valor por defecto"),
        (f5, "f5(1)", lambda: f5(1), "Mal - Falta argumento posicional requerido 'y'"),
        (f6, "f6(1)", lambda: f6(1), "Mal - Falta argumento posicional requerido 'y'"),
        (f7, "f7(1)", lambda: f7(1), "Mal - Falta argumento keyword-only requerido 'z'"),
        (f8, "f8(1)", lambda: f8(1), "Bien - Todos los parámetros opcionales tienen valores por defecto"),
    ]
    
    print("=== Validación de funciones con @contract ===\n")
    print("Explicación:")
    print("- 'Bien': La función puede ser llamada con un solo argumento")
    print("- 'Mal': La función requiere argumentos adicionales obligatorios")
    print("- El decorador @contract valida que las precondiciones y postcondiciones sean compatibles\n")
    
    for func, call_str, call_func, explanation in functions:
        print(f"Probando {call_str}: {explanation}")
        try:
            result = call_func()
            print(f"  ✓ Éxito")
        except TypeError as e:
            print(f"  ✗ Error de tipo: {e}")
        print()

if __name__ == "__main__":
    test_functions()
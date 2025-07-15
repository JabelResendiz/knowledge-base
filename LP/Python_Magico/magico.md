## Python Magico

### metodos built-in (funciones integradas)

Son funciones predefinidas en Python que estan disponibles sin necesidad de importar modulos

| Función     | Descripción                      | Ejemplo                            |
| ------------ | --------------------------------- | ---------------------------------- |
| `len()`    | Devuelve la longitud de un objeto | `len([1, 2, 3]) → 3`            |
| `type()`   | Devuelve el tipo de un objeto     | `type(5) → <class 'int'>`       |
| `str()`    | Convierte a string                | `str(42) → "42"`                |
| `int()`    | Convierte a entero                | `int("10") → 10`                |
| `sum()`    | Suma elementos iterables          | `sum([1, 2, 3]) → 6`            |
| `max()`    | Devuelve el máximo valor         | `max([5, 2, 8]) → 8`            |
| `min()`    | Devuelve el mínimo valor         | `min([5, 2, 8]) → 2`            |
| `sorted()` | Ordena un iterable                | `sorted([3, 1, 2]) → [1, 2, 3]` |
| `eval()`   | Evalúa una expresión en string  | `eval("2 + 3 * 4") → 14`        |

### Metodos magicos(dunder methods)

Son métodos especiales que Python llama automáticamente en ciertas situaciones. Empiezan y terminan con doble guión bajo (`__metodo__`). Python los llam internamente. Permite definir como responden los objetos a operadores como +,-,*,...

- Control acceso a atributos `(__getattr__)` llamadas a funciones `__call__`
- Se usan implicitamente (aunque puedes llamarlos manualmente si es necesario)

### **1. Creación y Destrucción de Objetos**

| Método            | Trigger      | Uso                                            |
| ------------------ | ------------ | ---------------------------------------------- |
| `__new__(cls)`   | `Objeto()` | Controla la creación (antes que `__init__`) |
| `__init__(self)` | `Objeto()` | Constructor (inicialización)                  |
| `__del__(self)`  | GC/del       | Destructor (poco usado)                        |

| Método              | Trigger                      | Debe Retornar                                                  |
| -------------------- | ---------------------------- | -------------------------------------------------------------- |
| `__str__(self)`    | `print(obj)`, `str(obj)` | String legible                                                 |
| `__repr__(self)`   | Consola,`repr(obj)`        | String técnico (idealmente código válido) es para los print |
| `__format__(self)` | `format(obj)`              | Representación formateada                                     |

| Método                     | Operador | Ejemplo      |
| --------------------------- | -------- | ------------ |
| `__add__(self, otro)`     | `+`    | `v1 + v2`  |
| `__sub__(self, otro)`     | `-`    | `v1 - v2`  |
| `__mul__(self, otro)`     | `*`    | `v1 * 5`   |
| `__truediv__(self, otro)` | `/`    | `v1 / 2`   |
| `__eq__(self, otro)`      | `==`   | `v1 == v2` |

| Método                          | Trigger                      | Uso                               |
| -------------------------------- | ---------------------------- | --------------------------------- |
| `__getitem__(self, key)`       | `obj[key]`                 | Acceso como secuencia/diccionario |
| `__setitem__(self, key, val)`  | `obj[key] = val`           | Asignación                       |
| `__getattr__(self, name)`      | `obj.atributo_inexistente` | Manejo de atributos faltantes     |
| `__setattr__(self, name, val)` | `obj.atributo = val`       | Intercepta asignaciones           |

```python
class Matriz:
    def __getitem__(self, indices):
	i,j = indices
        return self.datos[i][j]

  
    def __setitem__(self,indices,valor):
	i,j = indices
	self.datos[i][j] = valor

m = Matriz(3, 3)
m[0, 2] = 5  # Llama a __setitem__ con indices=(0, 2), valor=5
print(m[0, 2])  # Llama a __getitem__ con indices=(0, 2) → 5

```

| Método            | Trigger          | Debe Retornar                       |
| ------------------ | ---------------- | ----------------------------------- |
| `__iter__(self)` | `for x in obj` | Objeto iterador                     |
| `__next__(self)` | Iteración       | Siguiente valor o `StopIteration` |
| `__len__(self)`  | `len(obj)`     | Longitud (entero)                   |

```python
class Rango:
    def __iter__(self):
        self.n = 0
        return self
  
    def __next__(self):
        if self.n >= 10:
            raise StopIteration
        self.n += 1
        return self.n
```

| Método                   | Trigger   | Uso                               |
| ------------------------- | --------- | --------------------------------- |
| `__call__(self, *args)` | `obj()` | Hace que un objeto sea "llamable" |

```python
class Multiplicador:
    def __call__(self, x, y):
        return x * y

mul = Multiplicador()
mul(5, 3)  # → 15 (igual que mul.__call__(5, 3))
```

```python
class Vector:
    def __init__(self, x, y):
        self.x = x
        self.y = y
  
    def __add__(self, otro):
        return Vector(self.x + otro.x, self.y + otro.y)
  
    def __mul__(self, escalar):
        return Vector(self.x * escalar, self.y * escalar)
  
    def __repr__(self):
        return f"Vector({self.x}, {self.y})"
  
    def __len__(self):
        return 2  # Siempre 2D
  
    def __getitem__(self, i):
        return [self.x, self.y][i]

# Uso
v1 = Vector(1, 2)
v2 = Vector(3, 4)
print(v1 + v2)  # Vector(4, 6)
print(v1 * 3)   # Vector(3, 6)
print(v1[1])    # 2
```

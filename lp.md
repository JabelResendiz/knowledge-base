## conferenci #5 : Arrays

Arrays: Expresan una secuencia "enumerada" (por lo general a partide 0) de valores de un mismo tipo que son accedidos no a traves de un nombre como en la composicion sino por su posicion numerica(indice) en la secuencia

#### C/C++

En C los arrays y los punteros estan estrechamnete relacionados, pero no son lo mismo:

```c
int arr[5] = {10, 20, 30, 40, 50};
printf("%d\n", *arr); // Imprime 10 (primer elemento)
```

- UN puntero es una varaible que almacena la direccion de la memoria, puede apuntar a aun array o a memoria dinamica reservada con malloc

```c
int *ptr = malloc(5 * sizeof(int)); // Puntero a un array dinámico
ptr[0] = 100; // Acceso como array
free(ptr); // Liberar memoria
```

#### C#

En c# los arrys y listas ocupan un espacio fijo ocupado en el heap, por no pueden crecer. Es responsabilidad ocuapar o acceder a los espacios. En el caso de una lista ,se crea un espacio predeterminadao y se copian los valores de este para el nuevo

#### Python

##### **Características:**

* **Dinámicas** : Pueden crecer o reducirse en tiempo de ejecución (`append()`, `pop()`, etc.).
* **Heterogéneas** : Pueden almacenar elementos de distintos tipos (enteros, strings, otras listas, etc.).
* **Implementación** : Internamente, son **arreglos de referencias** a objetos (no almacenan los datos directamente, sino punteros a ellos).
* **Modificables (mutables)** : Cambiar un elemento no crea una nueva lista.

```python
lista = [1, "hola", [2, 3], 4.5]
lista.append(10)  # Se puede modificar
```

```python
a = [1, 2, 3]
b = a  # 'b' es una referencia a la misma lista que 'a'
b[0] = 99
print(a)  # Output: [99, 2, 3] (¡Se modificó 'a' también!)
```

#### Formas de Traspaso de parametro

- Por copias: normal se crea una copia del valor
- Por resultado: No se pasa una copia del valor al llamar la funcion sino que el parametro formal actua como una variable local no inicializada, al finalizar la funcion el valor del parametro formal se copia de vueta al paraemtro real. En c# usar `out`
- Lazy Evaluation: Es una estrategia donde las xpresiones no se evaluan hasta que su vloar sea necesario. Se usa en : lenguajes funciones, parametros lambdas y optimizacion calculos costoss.

## conferencia 6: interfaces y genericidad

- range(n) en python se ejecuta primer en el ciclo, y no se comprueba de nuevo en cada iteracion
- covarianze: Si `A` es subtipo de `B`, entonces Container `<A> es sutipo de Container<B>`

## conferencia 7: herencia, interfaces y bindings

### **1. Estructura en Memoria**

Cuando una clase (ej: `Circulo`) implementa `IFigura`, ocurre lo siguiente:

#### **A. Tabla de Métodos Virtuales (VTable)**

* Cada tipo (clase o interfaz) en C# tiene una  **tabla de métodos virtuales (VTable)** .
* Esta tabla almacena **direcciones de memoria** de los métodos que el tipo puede ejecutar.
* Para interfaces, se usa una **tabla adicional llamada "Interface Map"** vinculada a la VTable principal de la clase( Apunta a la sección de la VTable donde están los métodos de la interfaz)

#### **2. ¿Qué va al *Heap* y qué a la  *Pila* ?**

* **Heap (Montículo)** :
  * **Objetos completos** (`new A()`, `new B()`).
  * **Campos de instancia** (`ValorA`, `ValorB`).
  * **Puntero a la VTable** (para resolver llamadas a métodos).
* **Stack (Pila)** :
  * **Variables de referencia** (`objA`, `objB`), que apuntan al objeto en el  *heap* .
  * **Parámetros de métodos** y variables locales.

```csharp
class A {
    public int ValorA;
    public void MetodoA() { Console.WriteLine("Método A"); }
}

class B : A {
    public int ValorB;
    public void MetodoB() { Console.WriteLine("Método B"); }
}

A objA = new A();

```

La memoria se organiza así:

| **Componente**      | **Ubicación** | **Contenido**                                                                     |
| ------------------------- | -------------------- | --------------------------------------------------------------------------------------- |
| **Heap**            | Almacena el objeto   | - Campos (`ValorA`) + Bloque de métodos (puntero a la **VTable** de `A`).    |
| **VTable de `A`** | Memoria estática    | - Direcciones de `MetodoA()` y métodos heredados (ej: `ToString()` de `Object`). |

```csharp
B objB = new B();
```

| **Componente**      | **Ubicación** | **Contenido**                                                                                                    |
| ------------------------- | -------------------- | ---------------------------------------------------------------------------------------------------------------------- |
| **Heap**            | Almacena el objeto   | - Campos de `A` (`ValorA`) + Campos de `B` (`ValorB`) + **VTable Ptr** (apunta a la VTable de `B`).    |
| **VTable de `B`** | Memoria estática    | -**Herencia de VTable** : Primero métodos de `A` (`MetodoA`), luego métodos nuevos de `B` (`MetodoB`). |

```csharp
Animal miAnimal = new Perro(); // Tipo estático: Animal, Tipo real: Perro
miAnimal.Comer(); // ✅ Llama a Perro.Comer() gracias a la VTable.
```

## 8- Programacion Funcional

### Coneceptro Claves de la Programacion Funcional

* **Funciones como ciudadanos de primera clase** : Pueden asignarse a variables, pasarse como argumentos y retornarse.
* **Inmutabilidad** : Los datos no cambian; se crean nuevos.
* **Funciones puras** : Sin efectos secundarios (mismo input → mismo output).
* **Expresiones Lambda** : Funciones anónimas y concisas.
* **Higher-Order Functions** : Funciones que reciben o retornan otras funciones.

```csharp
// Funciones Lambdas
Func<int, int, int> sumar = (a, b) => a + b;
Console.WriteLine(sumar(3, 5)); // 8
```

```csharp
// LINQ (Manipulacion de Datos Funcional)

var numeros = new List<int> { 1, 2, 3, 4 };
var pares = numeros.Where(n => n % 2 == 0).Select(n => n * 2);
// Resultado: [4, 8]
```

### Delegados

| Delegado                            | Descripción                                      | Uso Típico                     |
| ----------------------------------- | ------------------------------------------------- | ------------------------------- |
| **`Func<T1, T2, TResult>`** | Función con 2 parámetros y retorno.             | Cálculos, transformaciones.    |
| **`Action<T1, T2>`**        | Función con 2 parámetros**sin retorno** . | Métodos que ejecutan acciones. |
| **`Predicate<T>`**          | Función con 1 parámetro y retorno `bool`.     | Filtrado (ej:`List.FindAll`). |

```csharp
void ProcesarDatos<T1, T2, TResult>(T1 a, T2 b, Func<T1, T2, TResult> operacion) {
    TResult resultado = operacion(a, b);
    Console.WriteLine($"Resultado: {resultado}");
}

// Uso:
ProcesarDatos(10, 20, (x, y) => x + y); // Output: 30
```

```csharp
var numeros = new List<int> { 1, 2, 3 };
var textos = numeros.Select((num, index) => $"Número {num} en posición {index}").ToList();
// textos = ["Número 1 en posición 0", "Número 2 en posición 1", ...]
```

### Python y La Programacion Funcional

```python
// FUNCIONES LAMBDAS

sumar = lambda a,b: a+b
print(sumar(3,5)) #8

// FUnciones de orden superior
def aplicar_operacion(func,a,b):
	return func(a,b)

resultado = aplicar_operacion(lambda x,y : x*y, 4,5)
print(resultado) #20

numeros = [1, 2, 3, 4]
pares = list(filter(lambda x: x % 2 == 0, numeros))  # [2, 4]
duplicados = list(map(lambda x: x * 2, numeros))     # [2, 4, 6, 8]

// Listas Comprehensions (estilo funcional)
cuadrados = [x**2 for x in numeros]  # [1, 4, 9, 16]

```

- Importante tener en cuenta que trabajan bajo demanda( osea no crea un IEnumerable `<T>` )

| **Característica**    | **C#**                                 | **Python**                                |
| ---------------------------- | -------------------------------------------- | ----------------------------------------------- |
| **Soporte de FP**      | Híbrido (OOP + FP con LINQ).                | Más flexible y orgánico.                      |
| **Inmutabilidad**      | Registros (`record`), campos `readonly`. | Tuplas,`frozenset`.                           |
| **Expresiones Lambda** | Sintaxis más verbosa (`=>`).              | Sintaxis concisa (`lambda x: x + 1`).         |
| **Herramientas FP**    | LINQ,`Func<>`, `Action<>`.               | `map`, `filter`, `reduce`, `itertools`. |
| **Tipado**             | Estático (mejor soporte para FP genérica). | Dinámico (más flexible pero menos seguro).    |

## 9- Decoradores

**Decorador** : Patrón de diseño que envuelve una función/clase para agregar comportamiento adicional (ej: logging, timing, caching).

#### **Analogía** :

* **Python** : Un decorador es como un "wrapper" (envoltorio) que modifica una función.
* **C#** : Similar, pero se implementa con funciones lambda o clases.

### **. Decoradores en Python**

```python
def decorador(func):
    def wrapper(*args, ** kwargs):
	print("Antes de llamar ala funcion")
	result = func(*args, **kwargs)
	print("Despues de llamar a al funcion")
	return result
   return wrapper

@decorador
def saludar(nombre):
    print(f"Hola , {nombre}")

saludar("Juan")

// OUTPUT
//Antes de llamar a la función
//Hola, Juan
//Después de llamar a la función
```

```python
from functools import wraps

def memoize(f):
    cache = {}

    @wraps(f)
    def wrapper(*args, **kwargs):
        key = (args, frozenset(kwargs.items()))
        if key in cache:
            return cache[key]
        result = f(*args, **kwargs)
        cache[key] = result
        return result

    return wrapper

// FUncion memoize en python

@memoize
def sumar(int a ,int b):
	return a +b

sumar (2,3)

```

### Decoradores en C#

```csharp
// ASPECTP

Func<T, R> name <T,TResult> (Func<T,TResult> f);

// T Entrada de mi nuevo tipo de la func decoradora
// R Mi resultado de mi funcion decoradora

// f es la funcion  a ser decorada que recibe un entrada y devuelve un resultado
```

- decorar una funcion `f` de tipo (`Func<T,TResult>`) para agregar informacion extra determinado en R que es tipo de retorno de mi nueva funcion decoradora

```csharp
using System;

Func<int,int> Decorador(Func<int,int> func)
{
    return (int x) =>
    {
	Console.WriteLine("Antes de llamar a la funcion");
	int result = func(x);
	Console.WriteLine("Despues de llamar a la funcion");
	return result;  
    };
}


Func<int,int> Doblar = x=> x*2;

var DoblarDecorado = Decorador(Doblar);

Console.WriteLine(DoblarDecorado(5)); // 10
```

## 10- Dynamic C#

- `dynamic` es un tipo introducido en C# 4.0
- Permite desactviar la verificacion estatica de tipos en tiempo de compilacion y resolver operaciones en timepo de ejecucion
- Es decir, cuando usar una variable `dynamic`, el compilador no verifica que los metodos o propiedades existan. La comprobacion y la ejecucion se resuelven en tiempo de ejecucion
- Permite trabajar con objetos que no conoces hasta que se ejecuta el programa (por ejemplo, objetos COM, objetos JSON dinamicos, etc)

```csharp
dynamic d = "Hola";
Console.WriteLine(d.Length); // OK , Length existe en string

d= 123;
Console.WriteLine(d.Length); // No da error en compilacion, pero en ejecucion lanza RuntimeBinderExecption

```

### Cuando usar `dynamic` ?

- Cuando trabajas con APIs dinamicos (COM,JSON,XML)
- Para interoperar con lenguajes dinamicos (Python, JS)
- Para simplificar reflexion y acceso a objetos desconocidos
- Para facilitar la escritura de codigo flexible o prototipos rapidos

| Ventajas                       | Desventajas                                     |
| ------------------------------ | ----------------------------------------------- |
| Código más simple y flexible | Sin verificación estática de tipos            |
| Permite llamadas dinámicas    | Errores detectados solo en tiempo de ejecución |
| Útil para objetos dinámicos  | Menor rendimiento (binding en tiempo real)      |

### Clase DyanmicObject

- Es una clase base en `System.Dynamic` que permite crear objetos personalizados con coportamiento dinamico
- Al heredar de `DyanmicObject` , puedes controlar que pasa cuando se acceden a propiedades, metodos , indices
- Muy util para crear objetos que simulan ser dinamicos (por ejemplo , wrappers, proxies, objetos que cambian sus estrcutra en runtime)

### Metodo mas comunes de  `DyanmicObject`

* `TryGetMember(GetMemberBinder binder, out object result)`: controla la lectura de propiedades.
* `TrySetMember(SetMemberBinder binder, object value)`: controla la escritura de propiedades.
* `TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)`: controla la llamada a métodos.
* `TryGetIndex`, `TrySetIndex`: para acceso a índices (como arrays).
* Otros para operaciones aritméticas, conversión, etc.


```csharp
using System;
using System.Dynamic;
using System.Collections.Generic;

public class DynamicDictionary : DynamicObject
{

}

```

## Herencia

- Evitar duplicacion de codigo
- Organizacion jerarquica
- Extender/modificar comportamientos

### Herencia Multiple en C++

- En C++ la sintaxis $\textbf{class Derivada: public Base1, private Base2 {...}}$ especifica la herencia y el nivel de acceso. El orden de construccion se rige por el orden de declaracion de bases y el destructor invoca el orden inverso.
- Para resolver el diamante ,se emplea la herencia virtual **virtual Base** , esto garantiza que solo exista una instancia de la base comun, evitando datos duplicados y llamdas a multiples constructores

```cpp
class A {}
class B: virtual public A{}
class C:virtual public A{}
class D: public b, public c {/*Unica A compartida*/}


```

Sin *virtual* , D contendrai dos subobjetos A y la llamada a A::methodo() seria ambigua.


### Herencia Multiple en Python

- En herencia múltiple, cuando una clase hereda de varias clases padre, puede haber ambigüedad sobre qué versión de un método debe usarse cuando hay métodos con el mismo nombre en diferentes clases padre. El MRO resuelve esta ambigüedad.


#### El algoritmo C3

El algoritmo C3 fue creado específicamente para Python (adaptado de Dylan) y sigue estas reglas:

1. **Consistencia de orden local** : Mantiene el orden en que se declaran las clases padre
2. **Monotonía** : Si la clase A precede a la clase B en el MRO de C, entonces A debe preceder a B en el MRO de cualquier subclase de C
3. **Visibilidad** : Todos los padres deben ser visibles en el MRO

se construye usando la siguiente formula:

$L[Clase(Base1, Base2,...)] = Clase + merge(L[Base1], L[Base2],..., [Base1, Base2,...])$

donde `merge` es una operacion que :

1. toma le primer elemento de la primera lista
2. verificar que este elemento no aparezca en ninguna ptra lista
3. si cumple , lo annade al resultado y lo elimina de todas las listas
4. Repite hasta que todas las listas esten vacias

Ejemplo:

```python
class A: pass
class B(A): pass
class C(A): pass
class D(B,C): pass
class E(B,D): pass
```

Aqui el MRO de D es 

$$
L[D] = D+ \text{merge}(L[B] , L[C] ,[B,C])
\\
L[B] = B + \text{merge}(L[A],A) = [B,A]
\\
L[C] = C + \text{merge}(L[A],A) = [C,A]
\\
L[D] = D + \text{merge}([B,A],[C,A],[B,C]) = [D,B,C,A]
$$

### Herencia en C#

- no se permite la herencia mutiple de clases pero se puede lograr cierta funcionalidad similar utilizando interfaces y composicion


#### Implementacion Implicita:

Es la forma mas comun de implementar interfaces , donde los miembros de la interfaz son directamente accesibles a traves de la clase:

- Se usara la implementacion explicita si hay colisiones entre varias interfaces con el mismo nombre del metodo

| Característica       | Implementación Implícita | Implementación Explícita                    |
| --------------------- | -------------------------- | --------------------------------------------- |
| Modificador de acceso | Público                   | Privado (solo accesible mediante la interfaz) |
| Sintaxis              | `public void Metodo()`   | `void IInterface.Metodo()`                  |
| Acceso desde la clase | Directo                    | Solo mediante casting a la interfaz           |
| Uso con colisiones    | No posible                 | Obligatoria                                   |
| Visibilidad           | Parte de la API pública   | Oculto para usuarios de la clase              |

### Casteo


## Tabla Comparativa

| Lenguaje         | Casteo Estático               | Casteo Dinámico                              |
| ---------------- | ------------------------------ | --------------------------------------------- |
| **C++**    | `static_cast` (compilación) | `dynamic_cast` (runtime, solo polimórfico) |
| **Python** | Funciones como `int()`       | Duck typing e `isinstance()`                |
| **C#**     | `(Tipo)` o `as`            | `dynamic` (DLR)                             |

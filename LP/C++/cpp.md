

### Inferencia de Tipos

1. auto : Permite que el compilador deduzca el tipo de una variable basandose en el valor que se inicializa.
2. decltype: Se puede obtener el tipo exacto de una expresion , preservando todas sus caractersiticas incluidos los calificadores const y las referencias
3. decltype (auto) : Combina los comportamientos de auto y de decltype  en la deduccion del tipo

### Template

1. ```cpp
   template <typename T> class Geek {}
   ```
2. ```cpp
   template <typename T> T suma (a,b) => a+b;
   ```


### Referencias y Punteros

En C++ las referencias y los punteros te permiten manipular datos indirectamente , es decir, sin trabajar directamente con el valor de al variable , sino a traves de una conexion a ella.

#### Referencias

Aquí están las características clave de las referencias:

* **Alias para una variable existente:** Una referencia es un nombre alternativo para una variable ya creada.
* **Debe inicializarse:** Una referencia debe ser inicializada en el momento de su declaración con una variable existente. No puedes declarar una referencia sin inicializarla. Por ejemplo, `int& r;` es un error.
* **No se puede reasignar:** Una vez que una referencia se une a una variable, no se puede cambiar para hacer referencia a otra variable. Si intentas reasignar una referencia, lo que sucederá es que el *valor* de la variable a la que la referencia apunta originalmente se actualizará con el valor de la nueva variable, en lugar de que la referencia apunte a la nueva variable. Tu código de ejemplo lo muestra claramente: `r_b = r_c;` no hace que `r_b` apunte a `r_c`, sino que el valor de `r_a` (a la que `r_b` referencia) se copia el valor de `r_c`.
* **No pueden ser nulas:** Una referencia siempre debe hacer referencia a una ubicación de memoria válida. No puedes tener una referencia nula.
* **Se usan comúnmente en parámetros de función:** Son muy útiles para pasar argumentos a funciones por referencia, lo que permite que la función modifique la variable original sin copiarla, mejorando la eficiencia y permitiendo múltiples valores de retorno "indirectos".

$\textbf{const int* f (Puntero a una constante entera)}$

1. EL valor apuntado es el cste

```cpp
int a = 10;
int b = 20;

const int* f = &a; // ahora no se puede modificar el valor de a desde f

// *f = 15; Error


//se puede hacer
f = &b; // ahora b no se puede moficiar desde f
```

$\textbf{int* const f (Puntero costante a un entero)}$

1. Le puntero es el cste

```cpp
int a = 10;
int b= 20;

int* const f = &a; // 'f' es un puntero constante a 'a' . Siempre apuntara a 'a'

*f = 15; // valido puedes cambiar el valor de 'a' a traves de 'f'

f = &b; // Error: no se reasignar 'f' para que apunte a otra variable
```

$\textbf{}$$\textbf{const int* const f (Puntero cste a una cste entera)}$

1. Tanto valor como ptr es constante

```cpp
int a = 10;
int b = 20;

const int * const f = &a;

// *f = 15; ERROR
// f =&b; ERROR
```

## Golang

### Intro

- Es un lenguaje de programacion Go que utiliza una forma de procesamiento basada en compilacion directa a codigo maquina.
- Es un lengueja compilado estaticamente, lo que significa que se traduce directamente a un binario ejecutable nativo, especifico para el SO y la arquitectura , antes de su ejecucion.
- Alto rendimiento, como C#
- Compilacion cruzada sencilla : Es posible compilar para diferentes SO y arqutiectrau usando variables de entorno
- Inicio rapido: Idea para entornos serverless, ya que los binarios arrancan rapidamente sin necesidad de cargar entornos de ejecucion

#### Desventajas

- Tamano grande los binarios
- Menor flexibilidad dinmica
- Compilacion lenta en proyectos grandes
- Soporte limitado para moviles e interfaces graficas

### Sumario

```go
package main

import "fmt"

func main()
{
	fmt.Println("Hol mundo!")
}
```

- Go no requiere clases ni metodos estaticos

```go
var edad int =25  // Declaracion explicita
nombre := "Gopher" // INferencia de tipo (inicializa)

var c int  // declaracion
c = 34 // asignacion 
c = 46 // reasignacion de valor
const PI = 314159  // Constante
```

- `:=` Permite declarar e inicializar variables de forma concisa
- Go es fuertemente tipado, pero sin sacrificar legibilidad

```go
for i:= 0; i< 5;i++ {
	fmt.Println("Iteracion:",i)
}

// ciclo while
i:=0
for i <10
{
   i++;
}

// ciclo infinito
for {
	hacerAlgo();
}
```

- En go no existen los `while` ni los `do-while`
- Go permite declara varaibles dentro de la condicion `if` cuyo alcance es limitado al bloque `if` (y opcional al `else`)

```go
if variable := expresion ; condicion 
{
}

// ejemplo

if err := hacerAlgo(); err!= nil
{
   fmt.Println("Ocurrio un error: ",err)
}
```

- GO permite que una funcion retorno mutiples valores , muy util para manjear errores explicitamtne sin exepciones

```go
func dividir(a, b float64) (float64, error) {
    if b == 0 {
        return 0, fmt.Errorf("no se puede dividir entre cero")
    }
    return a / b, nil
}

resultado, err := dividir(10,2)
if err != nil
{
  fmt.Println("Error: ",err)
}
else
{ 
  fmt.Println("resutlado: ", resultado)
}
```

- Declaracion Multiples de varaibles

```go
var 
(
	x int 
	y string = "hola"
	z = true
)
```

- Funciones anonimas

```go
doble := func(n int) int {
	return n*2;
}

fmt.Println(doble(4))
```

### Tipos nativos en GO

* **Enteros:** `int` (depende de arquitectura), `int8`, `uint`, `byte` (alias de `uint8`).
* **Punto flotante:** `float64` (por defecto para decimales).
* **Cadenas y caracteres:** `string` (inmutables, UTF-8), `rune` (alias de `int32`, para caracteres Unicode).
* **Booleanos:** `bool` (`true` o `false`).
* **Arrays y slices:**

```go
var numeros [3] int = [3]int {1,2,3} // array fijo
numerosDinamicos := []int {1,2,3,4} // Sclice dinamico
```

- Mapas(diccionarios)

```go
edades := map[string]int{"Ana": 25, "Luis": 30}
```

- structs:

```go
type Person struct
{
   Nombre string
   Edad int
}
```

- Interfaces:

```go
type Hablador interface
{
   Hablar() string
}
```

- punteros

```go
var p *int // puntero nulo
var m map[string]int // mapa nulo
```

---

### 1. Arrays y Slices

* **Arrays** : tienen tamaño fijo que se define en su declaración, por ejemplo:

```go
  var a [3]int           // array de 3 enteros
  a2 := [2]int{1, 2}     // array con valores iniciales
```

* **Slices** : son estructuras dinámicas que “envuelven” un array subyacente y pueden crecer o reducirse.

```go
  var s []int            // slice sin tamaño ni capacidad asignada
  s2 := []int{1, 2, 3}   // slice con valores iniciales
```

---

## 2. Funciones nativas para slices: `make`, `append`, `copy`

* `make`: crea slices, maps o channels con longitud y capacidad inicial:
  ```go
  s := make([]int, 3, 5)  // slice con longitud 3 y capacidad 5
  ```
* `append`: agrega elementos a un slice; si la capacidad se excede, crea internamente un array más grande y devuelve un nuevo slice:
  ```go
  s = append(s, 4, 5)
  ```
* `copy`: copia elementos de un slice origen a otro destino y devuelve cuántos se copiaron:
  ```go
  n := copy(destino, origen)
  ```

---

## 3. ¿Son los slices listas dinámicas?

Sí, los slices son listas dinámicas que pueden crecer o reducir su tamaño en tiempo de ejecución, con longitud (elementos actuales) y capacidad (espacio disponible antes de redimensionar).

---

## 4. Comparación con arrays y listas dinámicas en C# o C++

* En  **Go** , los arrays se asignan **por valor** (se copian completamente), mientras que en C# son asignados por referencia.
* Los slices y listas dinámicas son similares en ambos lenguajes, basándose en arrays internos con redimensionamiento automático.
* Go permite **compartir memoria entre slices** (un slice puede ser una “vista” parcial de otro), lo que no es común en C#.

Ejemplo:

```go
a := []int{1, 2, 3}
b := a[:2]   // b comparte memoria con a (toma los dos primeros elementos del slice)
b[0] = 99
fmt.Println(a) // [99, 2, 3]
```

---

## 5. Tipos en Go: por valor y punteros

* Por defecto, todos los tipos en Go son **por valor** (copian el contenido).
* Los slices, maps, canales y funciones actúan como referencias, compartiendo datos internos.
* **Punteros** en Go almacenan direcciones de memoria, pero:
  * No hay aritmética de punteros (más seguro que C).
  * Tienen seguridad añadida con Garbage Collector.
  * Se usan con `*Tipo` para declarar y `&variable` para obtener la dirección.

Ejemplo:

```go
var x int = 42
var p *int = &x
fmt.Println(*p) // 42
```

---

## 6. Seguridad y manejo de punteros

* Go evita errores comunes con punteros (sin aritmética, acceso a punteros `nil` produce panic).
* Usa **Escape Analysis** para decidir si variables locales se mueven al heap si se retornan sus referencias.

Ejemplo:

```go
func crearPuntero() *int {
  x := 42
  return &x  // x escapa al heap, seguro
}
```

---

## 7. Keyword `defer`

* Ejecuta una función justo antes de que la función que lo contiene termine.
* Es útil para liberar recursos, cerrar archivos, desbloquear mutex, etc.
* Los defer se apilan y se ejecutan en orden LIFO (último en entrar, primero en salir).

Ejemplo:

```go
func main() {
    defer fmt.Println("Primero")
    defer fmt.Println("Segundo")
    fmt.Println("Inicio")
}
// Salida:
// Inicio
// Segundo
// Primero
```

---

## 8. Structs en Go vs C

* En Go:
  ```go
  type Persona struct {
      Nombre string
      Edad   int
  }
  p := Persona{"Ana", 30}    // Por valor
  p2 := &Persona{Edad: 25}   // Por referencia (puntero)
  ```
* En C:
  ```c
  struct Persona p1 = {"Ana", 30};          // Stack
  struct Persona* p2 = malloc(sizeof(struct Persona));  // Heap
  ```
* Go simplifica la memoria con Garbage Collector y sin aritmética manual de punteros.

---

## 9. Composición e interfaces

* **Composición** : Go usa embedding para “tener un” tipo dentro de otro (en lugar de herencia).

Ejemplo:

```go
type Animal struct {
  Nombre string
}

func (a Animal) Comer() {
  fmt.Println(a.Nombre, "está comiendo")
}

type Perro struct {
  Animal  // Embedding
  Raza string
}

p := Perro{Animal: Animal{"Fido"}, Raza: "Labrador"}
p.Comer()  // Acceso directo a método de Animal
```

* **Interfaces** : definen métodos que un tipo debe implementar; no se declara explícitamente la implementación.

```go
type Sonido interface {
    HacerSonido() string
}

type Gato struct{}

func (g Gato) HacerSonido() string {
    return "Miau"
}
```

---

## 10. Comparación composición vs herencia

* **Composición** :
* Modular, bajo acoplamiento.
* Evita problemas como la herencia múltiple.
* Más flexible, permite mezclar comportamientos.
* Requiere escribir más código (no polimorfismo automático).
* **Herencia** :
* Relación “es-un”.
* Hereda todo, incluso lo no necesario.
* Puede traer problemas de ambigüedad (diamante).

---

## 11. Curiosidades y sintaxis especial de Go

* No existe `while` o `do-while`: solo `for`.
* Declaración corta `:=` para variables dentro de funciones.
* `if` permite declaración de variable en condición, restringiendo su alcance.
* No hay clases ni métodos estáticos: se usan structs y funciones libres.
* Herramienta `gofmt` estandariza formato y estilo.
* Manejo explícito de errores con múltiples retornos, no excepciones.

---

```go
// Encapsulameinto (campos provado y getter/setter)

type Vehicle struct
{
    brand string // es minusucla, entonces es pv
    model string
}

// Getter para brand(public)
func (v Vehicle) Brand() string
{
   return v.brand
}

// Setter para brand (publico)

func (v* Vehicle) SetBrand(brand string)
{
   v.brand = brand
}

func main()
{
   car:= Vehicle{}
   car.SetBrand("Ford")
   fmt.Println(car.Brand()) // Ford

   // car.brand = "chevy " error no se puede accdeder a campos pv
}
```

```go
// "HERENCIA"

type Vehicle struct
{
  Brand string
  Model string
}


func (v Vehicle) DisplayInfo()
{
  fmt.Println("Brnad : %s, Model: %s\n", v.Brand, v.Model)
}

type Car struct
{
 
 Vehicle // Embedding : Car "tiene un " Vechicle
 Doors int
}

func main()
{
   myCar := Car {Vehicle {Brand :"BW", Model : "X5"}, Doors : 5,}
   myCar.DisplayInfo()         // Brand : BMW, Model: x5
   fmt.Println(myCar.Doors)   // 5
}


```

```go
// GENERICIDAD

func imprimirSlice[T any](s []T)
{
    for _,v:= range s(fmt.Println(v);)
}


func main()
{
   imprimirSlice([]int{1,2,3})
   imprimirSlice([]string{"a","b","f"})
}
```

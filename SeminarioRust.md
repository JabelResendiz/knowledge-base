
# Introducción

Todos los programas tienen que administrar la forma en que usan la memoria de un computador mientras se ejecutan. Algunos lenguajes tienen recolección de basura que busca regularmente la memoria que ya no se usa mientras el programa se ejecuta; en otros lenguajes, el programador debe asignar y liberar la memoria explícitamente. Rust usa un tercer enfoque: la memoria se administra a través de un sistema de ownership con un conjunto de reglas que el compilador verifica. Si alguna de las reglas se viola, el programa no se compilará.

# Reglas de Ownership

• Cada valor en Rust tiene un `propietario`.
• Solo puede haber un propietario a la vez.
• Cuando el propietario sale del alcance(scope), el valor se descartará.

## Variables y Ownership

Cuando declaras una variable en Rust, se convierte en el propietario del valor asignado a ella. Por ejemplo:

```rust
fn main() {
    let x = 5;
    // x es el propietario del valor 5
}
```

En este caso, `x` es el propietario del valor `5`. Cuando `x` sale del alcance al final del bloque `main`, el valor `5` se elimina automáticamente.

## Transferencia de Propiedad: Move Semantics

Rust utiliza el concepto de "move semantics" para transferir la propiedad de un valor de una variable a otra. Cuando se mueve un valor, la variable original ya no es el propietario y no puede ser utilizada. Ejemplo:

```rust
fn main() {
    let s1 = String::from("hello");
    let s2 = s1;
    // s1 ya no es válido
    println!("{}", s2); // Funciona
    // println!("{}", s1); // Error: s1 no es válido
}
```

En este caso, la propiedad del `String` se mueve de `s1` a `s2`, y `s1` ya no es válido.

## Préstamo de Valores: Borrowing

A veces, necesitas acceder a un valor sin tomar su propiedad. Rust permite el préstamo de valores mediante referencias. Hay dos tipos de referencias: referencias inmutables y referencias mutables.

### Referencias Inmutables

Las referencias inmutables permiten leer un valor sin modificarlo:

```rust
fn main() {
    let s1 = String::from("hello");
    let len = calculate_length(&s1);
    println!("La longitud de '{}' es {}", s1, len);
}

fn calculate_length(s: &String) -> usize {
    s.len()
}
```

En este ejemplo, `&s1` crea una referencia inmutable a `s1` que se pasa a la función `calculate_length`.

### Referencias Mutables

Las referencias mutables permiten modificar un valor:

```rust
fn main() {
    let mut s = String::from("hello");
    change(&mut s);
    println!("{}", s);
}

fn change(some_string: &mut String) {
    some_string.push_str(", world");
}
```

Aquí, `&mut s` crea una referencia mutable que se pasa a la función `change`, permitiendo modificar el `String`.

### Reglas de Borrowing

Rust impone reglas estrictas para el borrowing para garantizar la seguridad:

1. Puedes tener cualquier número de referencias inmutables, pero solo una referencia mutable a un valor en un momento dado.

2. Las referencias deben ser siempre válidas.

Estas reglas evitan condiciones de carrera y garantizan la seguridad en el acceso concurrente a datos.
Rust garantiza un manejo seguro de las concurrencias al delegar esta responsabilidad al compilador. Esto asegura que no ocurran errores relacionados con condiciones de carrera o accesos concurrentes inseguros, liberando a los programadores de esta carga.

# ¿Por qué no es necesaria la recolección de basura?

El sistema de ownership de Rust garantiza que cada recurso tenga un único propietario y que se libere automáticamente cuando el propietario sale del alcance. El compilador prohíbe usar valores después de que fueron movidos, evitando errores. Esto elimina la necesidad de un recolector de basura (como en lenguajes como Java o Python), ya que Rust realiza la gestión de memoria en tiempo de compilación.

# Resumen

Los conceptos de ownership y borrowing aseguran la seguridad de la memoria en los programas Rust en tiempo de compilación. El lenguaje Rust te da control sobre el uso de la memoria de la misma manera que otros lenguajes de programación de sistemas, pero el hecho de que el propietario de los datos limpie automáticamente esos datos cuando salen del scope significa que no tienes que escribir y depurar código extra para obtener este control.



# Genericidad en Rust

## Beneficios de los Genéricos

El uso de genéricos en Rust aporta múltiples ventajas que mejoran tanto la calidad como el rendimiento del código:

- **Reutilización de código**: Los genéricos permiten escribir funciones y estructuras que funcionan con múltiples tipos, evitando la duplicación de código.
- **Código más claro y mantenible**: Al abstraer la lógica común, el código se vuelve más compacto, legible y fácil de mantener.
- **Seguridad de tipos y alto rendimiento**: Rust garantiza la seguridad de tipos en tiempo de compilación, eliminando errores en tiempo de ejecución. Además, los genéricos no introducen penalizaciones de rendimiento.

## ¿Cómo funcionan los Genéricos en Rust?

Rust implementa los genéricos mediante un proceso llamado **monomorfización**. Durante la compilación, el compilador genera versiones específicas del código genérico para cada tipo concreto utilizado en el programa. Esto asegura que el código sea seguro y eficiente.

### Genéricos en el Binario

En el binario final, los tipos genéricos son concretos. Esto significa que la información sobre los tipos genéricos se conserva en el ejecutable, permitiendo optimizaciones específicas y garantizando la seguridad en tiempo de ejecución.

### Comparación con Otros Lenguajes

A diferencia de lenguajes como C#, donde los genéricos se compilan a un tipo base (como `object`) y se realizan conversiones automáticas en tiempo de ejecución, Rust adopta un enfoque diferente. En Rust:

1. **Optimización específica por tipo**: Cada versión monomorfizada del código es optimizada para el tipo concreto utilizado, logrando un rendimiento equivalente al código escrito manualmente para ese tipo.
2. **Seguridad en tiempo de compilación**: El compilador verifica que todas las operaciones sean válidas para los tipos utilizados, eliminando errores de tipo en tiempo de ejecución.
3. **Evita conversiones implícitas peligrosas**: No se realizan conversiones automáticas que puedan introducir errores o comportamientos inesperados.

Este enfoque garantiza que las operaciones sean siempre válidas y seguras, sin comprometer el rendimiento.

## Resumen

La genericidad en Rust combina la reutilización de código con la seguridad de tipos y el rendimiento. Gracias al proceso de monomorfización, Rust logra que los genéricos sean tan eficientes como el código escrito manualmente, sin introducir errores en tiempo de ejecución. Esto convierte a los genéricos en una herramienta poderosa para escribir código robusto, seguro y altamente eficiente.


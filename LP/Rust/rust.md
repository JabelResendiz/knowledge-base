## 1. Gestión de Paquetes y Dependencias (Cargo y Crates.io)

* **Cargo** : Herramienta integral que automatiza el ciclo de vida del desarrollo en Rust (creación, compilación, pruebas, documentación y publicación).
* **Crates.io** : Repositorio centralizado de bibliotecas Rust ("crates"), similar a npm o pip, pero con mayor integración y seguridad.
* **Comparación con otros lenguajes** :
* Más integrado que pip (Python) y menos fragmentado que npm (JavaScript)
* Validación estricta de dependencias y metadatos
* Soporte nativo para compilación desde fuente


## 2. Sintaxis de Acceso a Miembros

* **Operador `::`** : Acceso a funciones asociadas (métodos estáticos), módulos y constantes
  **rust**

```rust
  let mg = rand::thread_rng(); // Acceso a función en crate rand
  let c = Circle::new(0.0, 0.0, 2.0); // Constructor
```

* **Operador `.`** : Acceso a métodos y campos de instancias **rust**

```rust
  let area = c.area(); // Método de instancia
  println!("Radio: {}", c.radius); // Campo de instancia
```


## 3. Manejo Seguro de Errores

* **Enums `Result` y `Option`** : Alternativa segura a excepciones
  **rust**

```rust
  match "42".parse::<i32>() {
      Ok(num) => num * 2,
      Err(_) => 0 // Obligatorio manejar ambos casos
  }
```

* **Ventajas** :
* Todos los errores deben ser manejados explícitamente
* Sin errores inesperados en tiempo de ejecución
* Mayor claridad en el flujo del programa

## 4. Sistema de Traits (Polimorfismo)

* **Concepto** : Similar a interfaces pero más potente
  **rust**

```rust
  trait TieneArea {
      fn area(&self) -> f64;
  }

  impl TieneArea for Circle {
      fn area(&self) -> f64 {
          PI * self.radius * self.radius
      }
  }
```

* **Características avanzadas** :
* Métodos con implementación por defecto
* Genéricos acotados por traits (`<T: TieneArea>`)
* Composición flexible sin herencia


## 5. Sistema de Ownership (Gestión de Memoria)

* **Reglas fundamentales** :

1. Cada valor tiene un único dueño
2. El valor se libera cuando el dueño sale de ámbito
3. Solo una referencia mutable o múltiples inmutables

* **Ejemplo** :
  **rust**

```rust
  let s1 = String::from("hola");
  let s2 = s1; // s1 ya no es válido (movimiento de ownership)
```

* **Ventajas** :
* Sin recolector de basura (GC)
* Sin fugas de memoria
* Seguridad garantizada en tiempo de compilación


## 6. Concurrencia Segura

* **Prevención de data races** :

1. Reglas estrictas de borrowing
2. Tipos sincronizados (Mutex, Arc)
3. Sistema de ownership aplicado a hilos

* **Ejemplo seguro** :
  **rust**

```rust
  let counter = Arc::new(Mutex::new(0));
  // El compilador verifica acceso seguro entre hilos
```

## 7. Genericidad y Eficiencia

* **Implementación** :
  **rust**

```rust
  enum Option<T> {
      Some(T),
      None
  }
```

* **Ventajas** :
* Monomorfización: Genera código específico para cada tipo en compilación
* Sin overhead en tiempo de ejecución
* Reutilización de código con seguridad de tipos

## Conclusiones Clave

1. **Seguridad sin sacrificar rendimiento** : Rust logra seguridad en memoria y concurrencia sin GC mediante su sistema de ownership.
2. **Expresividad moderna** : Traits, pattern matching y genericidad permiten abstracciones poderosas.
3. **Ecosistema integrado** : Cargo y Crates.io ofrecen una experiencia de desarrollo cohesiva.
4. **Adecuado para sistemas críticos** : Ideal para sistemas embebidos, servicios de red y componentes de bajo nivel donde la seguridad y eficiencia son primordiales.

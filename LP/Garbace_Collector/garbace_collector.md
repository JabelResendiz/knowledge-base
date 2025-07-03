## Garbage Collection, GC vs Manejo Manual en C++

##### **Recolección Automática de Basura (GC)**

Consiste en un mecanismo que **libera automáticamente la memoria** que ya no está en uso por el programa. El recolector de basura:

* **Identifica objetos no accesibles** (que ya no tienen referencias).
* **Libera su memoria** para evitar fugas ( *memory leaks* ) 
* **Reduce errores** como *dangling pointers* (punteros que apuntan a memoria ya liberada).


#### **Manejo Manual en C++**

En C++, la gestión de memoria es  **responsabilidad del programador** :

* **`new` / `delete`** para asignar y liberar memoria.
* **Ventajas** :
* Mayor control sobre el rendimiento.
* Sin sobrecarga por GC.
* **Desventajas** :
* Riesgo de *memory leaks* si no se libera memoria , si no se usa delete o free, se queda memoria ocupada al final del programa.
* Posibles *dangling pointers* (acceder a punteros despues de liberar su memoria)o *double free* (liberar memoria dos veces).

## Estrategias de Recoleccion Automatica de Basura

### 1.Conteo de Referencias

- Cada objeto posee un contador que registra las referencias que apuntan hacia el. Este conteador se incrementa al crear una referencia y disminuye al eliminarla. El objeto se liberea cuando el contador llega a cero.
- Entre las ventajas esta: Liberacion inmediata de memoria sin esperas y la baja latencia en operaciones individuales
- Entre las desventajas estas: no detecta ciclos de referencias y sobrecarga por actaulizar contadores cstemente

### 2.Marcar y Barrer (Mark and Sweep)

* **Funcionamiento** :

1. **Marcar** : Recorre todos los objetos accesibles desde las raíces (variables globales, stack).
2. **Barrido** : Libera los objetos no marcados.

* **Ventajas** :
  * Maneja referencias cíclicas.
* **Desventajas** :
  * Pausas en la ejecución ( *stop-the-world* ).
  * Fragmentación de memoria.

### 3.Recoleccion Generacional

* **Funcionamiento** :
  * Divide los objetos en generaciones (joven, vieja).
  * Recolecta con más frecuencia la generación joven ( *minor GC* ).
  * Recolecta la generación vieja con menos frecuencia ( *major GC* ).
* **Ventajas** :
  * Más eficiente (la mayoría de objetos mueren jóvenes).
* **Desventajas** :
  * Complejidad en la gestión de referencias entre generaciones.

### 4.Copia de Memoria

- **Funcionamiento**:
  - Divide el heap en dos mitades : front-space y to-space. Durante la recoleccion , los pbjetos vivos se copian del front-space al to-space, compactando al memoria. El espacio original se borra y se intercambian los roles.
- Ventajas:
  - Elimina la fragmentacion
- Desventajas:
  - Rquiere el doble de memoria
  - Costoso en aplicaciones con mucho objetos vivos

### 5.Recoleccion Incremental

- Funcionamiento:
  - Divide el proceso de recoleccion en pequennos pasos que se intercalan con la ejecucion del programa
  - Utiliza tecnicas como el marcado tri-color para rasrear objetos de forma segura mientras la aplicacion sigue en funcionamiento
- Ventajas:
  - Reduce las pausas perceptibles(stop - the - world)
  - Mejora la fluidex en aplicaciones interactivas
- Desventajas:
  - Complejidad para manejar cambios en el grafo de objetos
  - Mayor overhead total debido a la interrupcion frecuente

### 6-Recoleccion Concurrente

- Funcionamiento
  - Ejecuta la recoleccion en paralelo con el programa principal, utilizando hilos separados
  - El recolector y la aplicacion acceden al heap simultaneamente empleadno mecanismos de sincronizacion para evitar conflictos
- Ventajas:
  - MInimiza o elimina las pausas largas
  - Es ideal para entornos como servidores
- Desventajas:
  - Implica una sincronizacion compleja entre hilos del recolector y la aplicacion .
  - Puede generar mayor consumo de recursos , tatno de CPU como de memoria, debido a la ejecucion paralela

### 7-Basado en Regiones

- Funcionamiento
  - Divide la memoria en regiones independientes , como bloque de 2MB.
  - Cada region se gestiona por separado y solo aquellas que estan llenas o presentan alta fragmentacion son recolectadas, optimizando el proceso
- Ventajas:
  - Flexibilidad para recolectar areas especificas
  - Reduce la fragmentacion localmente
- Desvetnajas:
  - Complejidad al rastrear referencias entre regiones
  - Overhead al gestionar metadatos de regiones

### 9-Tracing vs Non Tracing

- Funcionamiento:
  - Identifica a basura rastreando objetos vivos desde la raiz (ej Mark and sweep , geenrational GC).  Su ventajas es que manjea ciclos y heaps complejos, pero su desventajas son las pausas largas
- Non-Tracing:
  - Utiliza metadatos externos, como conteo de referneicas. Su ventaja es que no genera pausas largas, pero su desventajaj es que no maneja cilos sin ayuda adicional.


## Manejo de Memoria en Diferentes Lenguajes

- Rust : Rust no usa GC, sino un sistema de propiedad (ownership) y prestamos(borrowing)
  - ```rust
    let s = String::from("hello")' // 's' es duenno de la memoria
    ```
  - ```rust
    let len = calcular_longitud(&s); // Presta 's' sin tranferir propiedad
    ```
  - ```rust
     fn longest<'a>(x: &'a str, y: &'a str) -> &'a str { ... }; //El compilador verifica que las referencias no sobrevivan a sus dueños.
    ```
  - Ventajas:
    - Sin GC: maximo rendimiento
    - Seguidad en tiempo de compilacion; evit dangling pointer y fugas
    - Sin pausas: ideal para sistemas en tiempo real.
  - Desventajas:
    - Curva de aprendizaje por el sistema de ownersjip
    - No es adecuado para todos los escenarios (estr. complejas con referencias ciclicas)

### **Resumen por Lenguaje**

| Lenguaje         | Estrategia Principal           | Característica Clave                     |
| ---------------- | ------------------------------ | ----------------------------------------- |
| **C#**     | Generational GC (3 gens)       | Compactación para evitar fragmentación. |
| **Python** | Ref Counting + Generational GC | GC secundario para ciclos.                |
| **Java**   | G1/ZGC/Shenandoah              | Recolección concurrente.                 |
| **Go**     | Concurrent Mark-Sweep          | Bajo latency, sin generaciones.           |
| **JS**     | Generational + Incremental     | Optimizado para pausas cortas.            |
| **Rust**   | Ownership (sin GC)             | Seguridad en tiempo de compilación.      |

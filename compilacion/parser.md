# Parsing Descendente

### Construyendo un Parser Descendente (Problemas Iniciales)

**Inicialmente, se presenta una "gramática de expresiones natural**:

**E**→**E**+**E**∣**E**−**E**∣**E**∗**E**∣**E**/**E**∣**(**E**)**∣**i**

Esta gramática tiene dos problemas principales:

1. **No modela la precedencia de los operadores:** Por ejemplo, en matemáticas, la multiplicación y división tienen mayor precedencia que la suma y resta. **Esta gramática no refleja eso, lo que podría llevar a interpretaciones incorrectas de expresiones como "a + b * c"**.

**Para resolver la precedencia, se introduce una nueva gramática con no-terminales por "nivel" de precedencia**:

**E**→**T**+**E**∣**T**−**E**∣**T**
**T**→**F**∗**T**∣**F**/**T**∣**F**
**F**→**(**E**)**∣**i**

Pero esta gramática introduce un nuevo problema:

2. **Asocia "incorrectamente" hacia la derecha:** Esto se refiere a la asociatividad de los operadores. Por ejemplo, en **a**−**b**−**c**, se espera que se evalúe como **(**a**−**b**)**−**c** (asociatividad izquierda). **Sin embargo, la gramática anterior tendería a agrupar como
   **a**−**(**b**−**c**) (asociatividad derecha).

### Asociatividad y Recursión Izquierda

**Se propone una nueva gramática para intentar corregir la asociatividad**:

**E**→**E**+**T**∣**E**−**T**∣**T**
**T**→**T**∗**F**∣**T**/**F**∣**F**
**F**→**(**E**)**∣**i**

Sin embargo, esta gramática tiene un problema fundamental para los parsers descendentes:

**no se puede parsear recursivamente**. Esto se debe a la **recursión izquierda** .

**Recursión Izquierda:**
Una gramática es **recursiva izquierda** si un no-terminal **S** puede derivar en una forma oracional que comience nuevamente con **S** (formalmente, **S**→**∗**S**ω**, donde **ω** es cualquier secuencia de terminales y no-terminales)^^.

* **Recursión directa izquierda:**S**→**S**a**∣**b**^^. Aquí,
  **S** se deriva directamente a sí mismo como primer símbolo.

La recursión izquierda es un problema para los parsers descendentes porque si el parser intenta expandir un no-terminal recursivo izquierdo, podría entrar en un bucle infinito (por ejemplo, al intentar expandir **E**→**E**+**T**, el parser intentaría expandir **E** nuevamente, y así sucesivamente sin consumir ninguna entrada).

Una gramatica libre del contexto $G = <S,N,T,P>$ se dice recursiva izquierda ssi $S \rightarrow ^*S\omega$ (donde $\omega \in \{N \cup T\}^*$) es una forma oracional)

G= <S,N,T,P> se dice que esta factorizada a la izuqierda si que si un no terminal tiene multiples producciones, todas ellas deben comenzar con un simbolo terminal o no terminal diferente

S -> cA | cB
A -> aA | a
B -> bB | b

como arreglar la ambiguedad

S -> cX
X -> A | B
A -> aA | a
B -> bB | b

**Definición:** Sea G=<S,N,T,P> una gramática libre de contexto, α∈{N∪T}
una forma oracional, y x∈T un terminal.
Decimos que x∈First(α) si y solo si α→ *xβ (donde β∈{N∪T} es otra forma oracional).

El conjunto First(α) de una forma oracional α (que puede ser una secuencia de terminales y/o no-terminales) contiene todos los terminales con los que puede comenzar una cadena que se derive de α.

**Puntos clave sobre First:**

Si α puede derivar en la cadena vacía (ϵ), entonces ϵ también se incluye en First(α). Esto es importante porque si una parte de la gramática puede ser opcional (derivar en nada), los símbolos que la siguen también podrían ser los primeros

**Follow (Siguientes)**
Definición: Sea G=<S,N,T,P> una gramática libre de contexto, X∈N un no-terminal, y x∈T un terminal.
Decimos que

x∈Follow(X) si y solo si S→ ∗αXxβ (donde α,β∈{N∪T}∗ son formas oracionales cualesquiera)

**En términos más sencillos:**
El conjunto Follow(X) de un no-terminal X contiene todos los terminales que pueden aparecer inmediatamente después de X en cualquier cadena válida que se pueda derivar desde el símbolo inicial de la gramática.

**Puntos clave sobre Follow:**
El símbolo de fin de cadena ($) siempre pertenece al Follow(S) (donde S es el símbolo inicial de la gramática). Esto representa el final del archivo.

Por definición, ϵ (la cadena vacía) nunca pertenece al Follow(X) para ningún no-terminal X

**Informalmente se les llamara gramatica LL(1) si estos conjunto nos permiten escoger siempre**

- Si una gramatica es ambigua , no es LL1 (el algoritmo dice donde)
- Si una gramatica no es LL1, no tiene por que ser ambigua (hay otros parsers )

# Parsing Bottom-Up y parser LR(0)

A diferencias del parsing descendente que construye el arbol de parseo de arriba hacia abajo (del simbolo inicial a las hojas ), el parsing ascendente lo hace de abajo hacia arriba (de las hojas al simbolo inicial)

## Parsers Shift-Reduce

Los parsers shift-reduce son el mecanismo central del parsing ascendente. Funcionan con dos estructuras principales:

- Una pila de símbolos (s): Donde se van acumulando los símbolos de la entrada que ya han sido procesados.
- Una secuencia de terminales (T): La parte restante de la cadena de entrada que aún no ha sido procesada.
- El estado del parser se denota como α|ω, donde α es el contenido de la pila y ω es la entrada restante

Hay dos operaciones fundamentales:

- Shift (Desplazar): Mueve el siguiente símbolo de la entrada c a la pila. Si el parser está en un estado α|cω, pasa al estado αc|ω.
- Reduce (Reducir): Si la parte superior de la pila β coincide con la parte derecha de una producción X -> β, se reemplaza β en la pila por el no-terminal X. Si el parser está en un estado αβ|ω y X→β es una producción, pasa al estado αX|ω.

## LR0

### Paso 1: Aumentar la Gramática

Para facilitar la detección del final del análisis (parseo), modificamos ligeramente la gramática original.

* Si **S** es el símbolo inicial de tu gramática original, introducimos un **nuevo símbolo inicial S′** y una  **nueva producción** :
  **S**′→S

### Paso 2: Definir los Ítems LR(0)

Un **ítem LR(0)** es una representación de una producción de la gramática con un punto (`.`) insertado en el lado derecho. Este punto nos dice qué parte de la producción ya ha sido reconocida o está en la pila del parser.

* **Formato:** **A**→**α**.**β**
  * **α** : Son los símbolos que ya hemos  **procesado** .
  * **β** : Son los símbolos que aún nos quedan  **por procesar** .
* **Ejemplo:** Para la producción **F**→**(**E**)**, sus ítems LR(0) son:
  * **F**→**.**(**E**)
  * **F**→**(**.**E**)
  * **F**→**(**E**.**)
  * **F**→**(**E**)**.

### Paso 3: Construir el Autómata LR(0) (Colección Canónica de Ítems LR(0))

Este autómata es un **Autómata Finito Determinista (DFA)** cuyos estados son  **conjuntos de ítems LR(0)** . Reconoce todos los "prefijos viables" de la gramática, es decir, las secuencias de símbolos que podrían aparecer en la pila del parser.

#### Operaciones Fundamentales:

1. **Clausura de un Conjunto de Ítems (**C**L**(**I**)**):**
   * Comienza incluyendo todos los ítems del conjunto inicial **I**.
   * Si encuentras un ítem de la forma **A**→**α**.**Xβ** (donde **X** es un  **no-terminal** ), entonces para cada producción **X**→**γ** en tu gramática, debes **añadir el ítem **X**→**.**γ** a **C**L(**I**).
   * Repite este proceso hasta que no puedas añadir más ítems.
   * **Propósito:** Asegura que cada estado contenga todos los posibles inicios de producciones cuando el punto está delante de un no-terminal.
2. **Función GoTo (**G**o**T**o**(**I**,**S**ı**ˊ**mb**o**l**o**)**):**
   * Encuentra todos los ítems en el conjunto **I** donde el punto está justo antes de un **S**ı**ˊ**mb**o**l**o** (que puede ser un terminal o un no-terminal).
   * Para cada uno de esos ítems (**A**→**α**.**S**ımb**o**l**o**β), crea un nuevo ítem **moviendo el punto más allá del **S**ımb**o**l**o (**A**→**α**S**ımb**o**l**o.β).
   * Finalmente, aplica la operación **Clausura** al conjunto de todos estos nuevos ítems.
   * **Propósito:** Define las transiciones entre los estados del DFA, representando cómo cambia el estado del parser al procesar un **S**ı**ˊ**mb**o**l**o**.

#### Algoritmo de Construcción del DFA:

1. **Estado Inicial (**I**0**):

   * Calcula **I**0=**C**L({**S**′**→**.**S**}). Este será el primer estado de tu DFA.
   * Crea una lista de **estados pendientes** (inicialmente con **I**0) y una lista de **estados construidos** (vacía).
2. **Iteración:**

   * Mientras la lista de `pendientes` no esté vacía:
     * Toma un estado **I** de `pendientes`.
     * Para cada símbolo gramatical **X** (terminal o no-terminal) que aparezca después de un punto en algún ítem de **I**:
       * Calcula **N**u**e**v**o**_**E**s**t**a**d**o=**G**o**T**o(**I**,**X**).
       * Si **N**u**e**v**o**_**E**s**t**a**d**o no está vacío:
         * Si **N**u**e**v**o**_**E**s**t**a**d**o ya es idéntico a un estado **I**k en `estados_construidos`:
           * Añade una **transición** de **I** a **I**k con la etiqueta **X**.
         * Si **N**u**e**v**o**_**E**s**t**a**d**o **no es idéntico** a ningún estado existente:
           * Añade **N**u**e**v**o**_**E**s**t**a**d**o a `estados_construidos` y a `pendientes`.
           * Añade una **transición** de **I** a **N**u**e**v**o**_**E**s**t**a**d**o con la etiqueta **X**.
3. **Finalización:** El proceso termina cuando no se pueden generar nuevos estados ni transiciones. La lista `estados_construidos` contendrá todos los estados de tu DFA.

### Paso 4: Construir la Tabla de Parseo LR(0)

La tabla de parseo es una matriz crucial que guía al parser, indicándole qué acción realizar para cada combinación de estado actual y el siguiente símbolo de entrada.

* **Filas:** Representan los estados de tu DFA (**I**0,**I**1,**…**).
* **Columnas:** Se dividen en dos secciones:
  * **ACTION:** Columnas para los **símbolos terminales** (incluyendo el símbolo de fin de entrada `$`).
  * **GOTO:** Columnas para los  **símbolos no-terminales** .

#### Reglas de Llenado:

1. **Acción Shift (**s**j**):
   * Si en el estado $I_k$ hay un ítem **A**→**α**.**tβ** (donde **t** es un  **terminal** ), y **G**o**T**o(**I**k,**t**) resulta en el estado $I_j$:
   * Coloca $s_j$ en **A**CT**I**ON[**I**k,**t**].
2. **Acción Reduce (**r**m**):
   * Si en el estado **I**k hay un ítem **A**→**α**. (el punto está al final de la producción **A**→**α**, que es la **m-ésima producción** en tu lista numerada de producciones):
   * Para **todos** los terminales **t** (y `$`) de la gramática, coloca **r**m en **A**CT**I**ON[**I**k,**t**]. (¡Esta regla es la principal causa de conflictos en LR(0)!)
3. **Acción Accept (**a**cc):**
   * Si en el estado **I**k está el ítem **S**′**→**S**.**:
   * Coloca **a**cc en **A**CT**I**ON[**I**k,**$**].
4. **Acción GoTo (**j**):**
   * Si **G**o**T**o($I_k$,**A**) (donde **A** es un  **no-terminal** ) resulta en el estado $I_j$:
   * Coloca **j** en **GOTO**[$I_k$,**A**].

### Paso 5: Identificar y Manejar Conflictos

Una gramática se considera **LR(0)** si y solo si la tabla de parseo construida  **no presenta ningún conflicto** . Los conflictos ocurren si una celda de la tabla termina con más de una entrada:

* **Conflicto Shift-Reduce:** Una celda **A**CT**I**ON[**I**k,**t**] contiene una acción **shift** y una acción  **reduce** .
* **Conflicto Reduce-Reduce:** Una celda **A**CT**I**ON[**I**k,**t**] contiene  **dos o más acciones reduce diferentes** .

Si tu gramática presenta cualquiera de estos conflictos, significa que  **no es LR(0)** , y un parser LR(0) no podrá analizarla de forma determinística. En estos casos, se requieren técnicas más avanzadas (como  **SLR(1)** , **LALR(1)** o  **LR(1) completo** ) que utilizan información de anticipación (lookahead) para resolver estas ambigüedades.

## SLR1

Pasos 1,2,3los mismo que LR0

### Paso 4: Calcular los Conjuntos FOLLOW

Aquí es donde SLR(1) introduce su principal diferencia. Para resolver conflictos de reducción, necesitamos saber qué terminales pueden seguir a un no-terminal.

* **Definición de FOLLOW(A):** Para un no-terminal **A**, **FO**LL**O**W(**A**) es el conjunto de todos los terminales **t** que pueden aparecer inmediatamente después de **A** en alguna forma sentencial. Además, si **A** es el símbolo inicial y puede ser el último símbolo de una derivación, entonces `$` (fin de entrada) también está en **FO**LL**O**W(**A**).
* **Algoritmo para calcular FOLLOW(A):**
  1. Inicialmente, si **S**′ es el símbolo inicial de la gramática aumentada, entonces añade `$` a **FO**LL**O**W**(**S**′**).
  2. Para cada producción **A**→**α**Bβ:
     * Todo en **F**I**RST**(**β**) (excepto **ϵ**, si está presente) se añade a **FO**LL**O**W**(**B**)**.
     * Si **β** es nulo (**ϵ**) o **F**I**RST**(**β**) contiene **ϵ** (es decir, **β** puede derivar en la cadena vacía), entonces todo en **FO**LL**O**W**(**A**)** se añade a **FO**LL**O**W**(**B**)**.
  3. Repite los pasos anteriores hasta que los conjuntos FOLLOW no cambien más.

---

### Paso 5: Construir la Tabla de Parseo SLR(1)

La tabla de parseo es una matriz que guía al parser.

* **Filas:** Representan los estados del DFA ($I_0$,$I_1$,**…**).
* **Columnas:** Se dividen en dos secciones:
  * **ACTION:** Columnas para los símbolos terminales (incluyendo `$`).
  * **GOTO:** Columnas para los símbolos no-terminales.
* **Reglas de Llenado (Modificadas respecto a LR(0) en el paso de Reducción):**
  1. **Acción Shift (**s**j**):
     * Si en el estado **I**k hay un ítem **A**→**α**.**tβ** (donde **t** es un  **terminal** ), y **G**o**T**o(**I**k,**t**) resulta en el estado $I_j$:
     * Coloca **s**j en **A**CT**I**ON[$I_k$,**t**]. (Igual que LR(0))
  2. **Acción Reduce (**r**m**):
     * Si en el estado **I**k hay un ítem **completo** **A**→**α**. (el punto está al final de la producción **A**→**α**, que es la **m-ésima producción** en tu lista numerada de producciones,  siendo **m**>**0** para no considerar la producción **S**′→*S* ):
     * Para  **cada terminal **t** en **FO**LL**O**W**(**A**) **, coloca **r**m en **A**CT**ION[$I_k$,**t**].
     * **¡Esta es la diferencia clave con LR(0)!** En LR(0), se colocaba **r**m en todas las columnas de terminales. Aquí, solo se hace para los terminales en **FO**LL**O**W(**A**), usando la información de anticipación para decidir cuándo es seguro reducir.
  3. **Acción Accept (**a**cc):**
     * Si en el estado **I**k está el ítem **S**′**→**S**.**:
     * Coloca **a**cc en **A**CT**I**ON[**I**k,**$**]. (Igual que LR(0))
  4. **Acción GoTo (**j**):**
     * Si **G**o**T**o(**I**k,**A**) (donde **A** es un  **no-terminal** ) resulta en el estado **I**j:
     * Coloca **j** en **GOTO**[**I**k,**A**]. (Igual que LR(0))
  5. **Entradas de Error:** Las celdas que quedan vacías se consideran entradas de error.

---

### Paso 6: Identificar y Manejar Conflictos

Una gramática es **SLR(1)** si y solo si la tabla de parseo construida no presenta ningún conflicto. Si una celda tiene más de una entrada, hay un conflicto:

* **Conflicto Shift-Reduce:** Una celda **A**CT**I**ON[**I**k,**t**] contiene una acción **shift** (**s**j) y una acción **reduce** (**r**m).
* **Conflicto Reduce-Reduce:** Una celda **A**CT**I**ON[**I**k,**t**] contiene **dos o más acciones reduce diferentes** (**r**m, **r**p).

Si la gramática tiene estos conflictos, no es SLR(1). En estos casos, se necesitarían técnicas de parsing más potentes como LALR(1) o LR(1) completo, que utilizan información de anticipación más precisa (ítems LR(1) en lugar de solo los conjuntos FOLLOW).

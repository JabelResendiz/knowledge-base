

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

Paso 1: Aumentar la Gramática
Para facilitar el reconocimiento del final del parseo, se añade una nueva producción al inicio de la gramática.

Si S es el símbolo inicial de la gramática original, se introduce un nuevo símbolo inicial S′ y una nueva producción:S′→S


Para construir un parser LR(0), se sigue un proceso sistemático que transforma una gramática libre de contexto en una tabla de parseo determinística. Este parser es de tipo ascendente (bottom-up).

Aquí te presento los pasos completos:

Paso 1: Aumentar la Gramática
Para facilitar el reconocimiento del final del parseo, se añade una nueva producción al inicio de la gramática.

Si S es el símbolo inicial de la gramática original, se introduce un nuevo símbolo inicial S′y una nueva producción:
S′→S

Paso 2: Definir los Ítems LR(0)
Un ítem LR(0) es una producción de la gramática con un punto (.) insertado en alguna posición de su lado derecho. Este punto indica cuánto de la producción ya ha sido "reconocido" o está en la pila del parser.

Formato: A→α.β

α: Símbolos ya procesados.

β: Símbolos aún por procesar.

Ejemplo: Para la producción F→(E), sus ítems LR(0) son:

F→.(E)

F→(.E)

F→(E.)

F→(E).


Paso 3: Construir el Autómata LR(0) (Colección Canónica de Ítems LR(0))
Este autómata es un Autómata Finito Determinista (DFA) que reconoce todos los "prefijos viables" de la gramática. Sus estados son conjuntos de ítems LR(0).

Operaciones Fundamentales:

Clausura de un conjunto de ítems I (CL(I)):

Inicialmente, incluye todos los ítems de I.

Para cada ítem de la forma A→α.Xβ en CL(I) (donde X es un no-terminal):

Para cada producción X→γ en la gramática, añade el ítem X→.γ a CL(I).

Repite este proceso hasta que no se puedan añadir más ítems.

Propósito: Asegura que cada estado contenga todos los ítems que representan el posible inicio de una producción cuando el punto precede a un no-terminal.

Función GoTo (GoTo(I, Símbolo)):

1. Encuentra todos los ítems en el conjunto I donde el punto precede a Símbolo (que puede ser un terminal o un no-terminal).

2. Para cada uno de esos ítems (A→α.Simboloβ), crea un nuevo ítem moviendo el punto más allá del Símbolo (A→αSımbolo.β).

3. Aplica la operación Clausura al conjunto de todos estos nuevos ítems.

- Propósito: Define las transiciones entre los estados del DFA, representando el cambio de estado del parser al procesar un Símbolo.

Algoritmo de Construcción del DFA:

1. Estado Inicial (I0):

- Calcula I0=CL({S′→.S}). Este será el primer estado de tu DFA.

- Crea una lista de estados pendientes (inicialmente con I0) y una lista estados_construidos (vacía).

2. Iteración:

- Mientras la lista pendientes no esté vacía:

- Toma un estado I de pendientes.

- Para cada símbolo gramatical X (terminal o no-terminal) que aparezca después de un punto en algún ítem de I:

- Calcula Nuevo_Estado = GoTo(I, X).

- Si Nuevo_Estado no está vacío:

- Si Nuevo_Estado ya es idéntico a un estado Ik en estados_construidos:

- Añade una transición de I a Ik con la etiqueta X.

- Si Nuevo_Estado no es idéntico a ningún estado existente:

- Añade Nuevo_Estado a estados_construidos y a pendientes.

- Añade una transición de I a Nuevo_Estado con la etiqueta X.

3. Finalización: El proceso termina cuando no se pueden generar nuevos estados ni transiciones. La lista estados_construidos contiene todos los estados del DFA.

4. Construir la Tabla de Parseo LR(0)
La tabla de parseo es una matriz que guía el parser, indicándole qué acción realizar para cada combinación de estado actual y siguiente símbolo de entrada.

1. Filas: Representan los estados del DFA (I0,I1,…).

2. Columnas: Se dividen en dos secciones:

- ACTION: Columnas para los símbolos terminales (incluyendo el de fin de entrada $).

- GOTO: Columnas para los símbolos no-terminales.

3. Reglas de Llenado:
- Acción Shift (s j):Si en el estado Ik
​hay un ítem A→α.tβ (donde t es un terminal), y GoTo(Ik, t) resulta en el estado Ij: Coloca sj en ACTION[Ik, t].

- Acción Reduce (r m):Si en el estado Ik hay un ítem A→α. (el punto está al final de la producción A→α, que es la m-ésima producción en tu lista numerada de producciones):

Para todos los terminales t (y $) de la gramática, coloca rm en ACTION[Ik, t]. (Esta regla es la causa principal de conflictos en LR(0)).

- Acción Accept (acc):Si en el estado Ik está el ítem S′→S.: Coloca acc en ACTION[Ik, $].

- Acción GoTo (j): Si GoTo(Ik, A) (donde A es un no-terminal) resulta en el estado Ij:Coloca j en GOTO[Ik, A].

- Entradas de Error: Las celdas que quedan vacías después de aplicar estas reglas se consideran entradas de error.

5. Identificar y Manejar Conflictos
Una gramática se dice que es LR(0) si y solo si la tabla de parseo construida no presenta ningún conflicto. Los conflictos ocurren si una celda de la tabla tiene más de una entrada:

Conflicto Shift-Reduce: Una celda ACTION[Ik, t] contiene una acción shift y una acción reduce.

Conflicto Reduce-Reduce: Una celda ACTION[Ik, t] contiene dos o más acciones reduce diferentes.

Si la gramática tiene estos conflictos, no es LR(0) y un parser LR(0) no podrá parsearla de forma determinística. En tales casos, se necesitan técnicas más avanzadas (como SLR(1), LALR(1) o LR(1) completo) que utilizan información de anticipación (lookahead) para resolver estas ambigüedades.
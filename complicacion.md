# Resumen de Compilacion

> Un lenguaje formal L es un conjunto de cadenas sobre un alfabeto, por ejemplo: *L=a,ab,abc*
>
> Un alfabeto V es un conjunto de símbolos. Por ejemplo: *V=a,b,c*

## Automata Finito Determinista

Un FDA es un automata con un conjunto finito de estados que "lee" la cadena de inicio a fin una sola vez y que tiene que tomar una decision , aceptar o rechazar la cadena.

Formalmente  es una tupla $A= <V,Q,q_0, F, f>$ donde:

- V es un alfabeto de entrada
- Q es un conjunto finito de estados
- $q_0 \in Q$ es un estado especial "incial"
- F es un subconjunto de estados "finales"
- f es una funcion de transicion $VxQ \rightarrow Q$

### Lenguaje regular

> Llamaremos **Lenguaje Regular** a todo lenguaje formal L tal que existe un automata finito determinista A tal que $ L= L(A)$ , es decir el automata solo reconoce las palabras del lenguaje.

### Demostrando que un lenguaje es regular (via directa)

Para demostrar que un lenguaje es regular por via directa hay que encontrar un FDA que lo reconozca. Esto implica construir un FDA y demostrar que $L=L(A)$. Esto conlleva demostrar que $L \sub L(A)$ y $L(A) \sub L$.

- Para el primer caso , $L \sub L(A)$ cogemos una cadena arbitraria de L y demostramos que cualquiera sea la secuencia de ejecucion de dicha cadena, debe terminar en un estado final
- Para el segundo caso, cogemos una secuencia de ejecucion arbitraria que termina en un estado final y demostramos que corresponde a una cadena de L

> El FDA es finito porque tiene una cantidad finita de estados y es determinista porque la funcion de transicion permite moverse a un solo estado siguiente para cualquier combinacion estado-simbolo.

## Automata Finito No-Determinista

Es la misma tupla pero mi funcion de transficion: $f : V x Q \rightarrow 2^Q $ 

> Los lenguajes finitos no deterministas definen exactamnete el mismo conjunto de lenguajes que los finitos deterministas, es decir , los **Lenguajes Regulares** 

> $\epsilon -clausura$ de un estado es el conjunto de estados que se pueden alcanzar a partir de solo transiciones $\epsilon$

> GOTO de un conjunto de estados con un simbolo es el conjunto de estados para los cuales existe alguna transicion con ese simbolo en alguno de los estados del conjunto original (no es recursiva)
>
> $GOTO(S, a) = \{ q' | ∃ q ∈ S \text{ tq } q --a--> q' \}$

### Algoritmo para convertir un AFND a un AFD

* **Estado inicial del AFD** :

  * Es `ε-closure({q₀})`, o sea, todos los estados accesibles desde `q₀` sin consumir símbolos.
  * Lo llamamos `S₀`.
* **Estados del AFD** :

  * Cada **estado del AFD** será  **un conjunto de estados del AFN** , es decir, un subconjunto de `Q`.
  * Por eso se dice que el conjunto de estados del AFD está en `2^Q` (conjunto potencia de `Q`).
* **Transiciones** :

  * Para cada conjunto `S` (estado del AFD) y para cada símbolo `x`, haces:

    * `GOTO(S, x)` → los estados a los que puedes ir desde `S` con `x`
    * `ε-closure(GOTO(S, x))` → añades todos los estados alcanzables desde esos por ε
    * Ese nuevo conjunto será el nuevo estado en el AFD al que vas desde `S` con la letra `x`.
* **Estados finales del AFD** :

  * Un subconjunto `S` del AFD es final si  **contiene algún estado final del AFN original** .

## Operaciones de Lenguajes Regulares

### Union de lenguajes regulares

Sean $L_1$ y $L_2$ lenguajes regulares, que sean reconocidos por al union de dos AFND. Pasos para construir mi automata de la union de esos lenguajes:

#### 🛠️ Construcción paso a paso

Supongamos:

* `A₁ = (Q₁, Σ, δ₁, q₀₁, F₁)`
* `A₂ = (Q₂, Σ, δ₂, q₀₂, F₂)`

Queremos construir un **nuevo autómata A = (Q, Σ, δ, q₀, F)** tal que:

##### 1. **Nuevo estado inicial**

* Crea un nuevo estado `q₀` que no está en `Q₁ ∪ Q₂`

##### 2. **Estados del nuevo autómata**

* `Q = Q₁ ∪ Q₂ ∪ {q₀}`

##### 3. **Función de transición**

* La función de transición `δ` es igual a `δ₁` y `δ₂`,  **más** :
  * `δ(q₀, ε) = {q₀₁, q₀₂}`

    (Desde el nuevo estado inicial, con una  **ε-transición** , puedes ir al estado inicial de A₁ o A₂)

##### 4. **Estados finales**

* `F = F₁ ∪ F₂`

### Complemento de un Lenguaje

- Se convierte de AFND a AFD
- Se invierten los estados finales si el AFD es completo
- Sino :

Si no lo está, debes  **completarlo** :

#### Paso 1: Agrega un estado "pozo" o "trampa", `q_sink`

Este es un **estado no final** que absorbe todo:

* Para cada estado `q ∈ Q`, para cada símbolo `a ∈ Σ`:
  * Si `δ(q, a)`  **no está definido** , entonces pon `δ(q, a) = q_sink`.
* Desde `q_sink`, para **todo** símbolo `a ∈ Σ`, también `δ(q_sink, a) = q_sink`.

Ahora el autómata está completo.

### Interseccion de conjuntos 

$$
L_1 \cap L_2 = (L_{1}^C \cup L^C_{2})^C
$$

$$
L_1 - L_2 = L_1 \cap L_{2}^C
$$

### Multiplicacion de automatas

Ahora vamos a construir directamente un autómata que reconozca la intersección de dos lenguajes $L_1$ y $L_2$ a partir de sus autómatas:


* Sea $A_1 = (Q_1,\sum, \delta_1, q_{0,1},F_1)$ un automata para $L_1$
* Sea $A_1 = (Q_2,\sum, \delta_2, q_{0,2},F_2)$

### Construcción intuitiva:

* El autómata que reconoce $L_1 \cap L_2$ tendra como estado el procuto cartesiano $Q = Q_1 x Q_2$
* Esto significa que cada estado del nuevo autómata es un par $(q_1,q_2)$ donde $q_1 \in Q_1$ y $q_2 \in Q_2$
* El estado inicial será $(q_{0,1}, q_{0,2})$
* Las transiciones se definen para cada símbolo $a\in \sum$ asi:

$$
\delta((q_1,q_2),a) = (\delta_1(q_1,a),\delta_2(q_2,a))
$$

* Los estados finales serán todos los pares donde ambos componentes son finales:

$$
F = \{(q_1,q_2) | q_1 \in F_1 \text{ y } q_2 \in F_2\}
$$

## Lema del Bombeo

> Sea $L$ un lenguaje regular. Existe entonces una constante $n$ (que depende de $L$) tal que para toda cadena $w$ perteneciente a $L$ con $|w| \geq n$ , podemos descomponer $w$ en tres cadenas , $w=xyz$ , tales que :
>
> 1. $|y| \geq 1$
> 2. $|xy| \leq n$
> 3. Para todo $k \geq 0$ , la cadena $xy^kz$ tambien pertenecen a $L$

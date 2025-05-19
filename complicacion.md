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

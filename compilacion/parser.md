## Parsing Descendente

### Construyendo un Parser Descendente (Problemas Iniciales)

**Inicialmente, se presenta una "gramática de expresiones natural"**^^:

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

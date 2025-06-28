# Lenguaje

- Un lenguaje L es un conjunto de cadenas sobre un alfabeto V
- Una gramatica libre de contexto es una tupla G= <T,N,S,P> donde
  - T es un conjunto de simbolos terminales (el vocabulario)
  - N es un conjunto de simbolos no terminales
  - $S \in N$ es le simbolo inicial
  - P es un conjunto de producciones de la forma $A \rightarrow \alpha$ donde $A \in N$ y $\alpha \in \{T \text{x} N\}^+$ o $\alpha = \epsilon$

En resumen, una gramática libre de contexto te proporciona un conjunto de "ladrillos" (terminales), "categorías" (no terminales), un punto de inicio (símbolo inicial) y un conjunto de "recetas" (producciones) para construir todas las cadenas válidas de un lenguaje.

> Una "forma oracional" es una expresion que contiene una mezcla de simbolos terminales y no terminales $\alpha \in \{T \text{x} N\}^+$

> Una "oracion" es una cadena que solo contiene simbolos terminales. $\alpha \in \{T\}^+$

> Una forma oracional $\alpha_1$ deriva en otra $\alpha_2$ si se puedes transformarla usando una secuencia de reemplazos de las producciones en P

> Decimos que una cadena $\omega$ pertenece al lenguaje generado por la gramatica $L(G)$ si puedes comenzar desde el simbolo inicial S y a traves de una secuencia de deruvaciones llegar a  $\omega(S \rightarrow^* \omega)$



**Árboles de derivación:**
Para visualizar cómo se genera una cadena, se utilizan árboles de derivación. En estos árboles:

* **Las hojas del árbol forman la cadena final**.
* **Los nodos internos del árbol son siempre símbolos no terminales**.
* **La raíz del árbol es el símbolo inicial S**.
* **Cada nodo y sus hijos representan una aplicación de una regla de producción, donde el nodo padre es el no terminal que se expande y sus hijos son los símbolos de la parte derecha de la producción**.

**Utilidad de las GLC:**
**Si tienes una gramática para un lenguaje y un algoritmo para obtener el árbol de derivación de cualquier cadena, tienes resuelto el "problema de parsing"**. **El problema de parsing consiste en determinar si una cadena pertenece a un lenguaje y, si es así, cómo se puede derivar (es decir, construir su árbol de derivación)**. 

**Parsing Izquierdo:**

Secuencia de derivaciones donde siempre se sustituye primero el no terminal mas a la izquierda, de la misma forma el parsing derecho

**Gramática de Ejemplo (para expresiones aritméticas simples):**

* **E**→**E**+**T**
* **E**→**T**
* **T**→**T**∗**F**
* **T**→**F**
* **F**→**(**E**)**
* **F**→**n**

Queremos hacer una **derivación extrema izquierda** de la cadena: `n + n * n`

**Pasos de la Derivación Extrema Izquierda:**

1. **Inicio:** Siempre comenzamos con el símbolo inicial, que es **E**.
   *Forma oracional actual: **E***
2. **Expansión de **E**:** Necesitamos generar una suma (`+`), por lo que elegimos la producción **E**→**E**+**T**.
   *Forma oracional actual: **E**+**T***
   (En este momento, tenemos dos no-terminales: **E** y **T**. El no-terminal más a la izquierda es **E**).
3. **Expansión del **E** más a la izquierda:** El **E** que está más a la izquierda debe eventualmente convertirse en la primera `n`. Para ello, lo expandimos a **T** (usando la producción **E**→**T**).
   *Forma oracional actual: **T**+**T***
   (Ahora tenemos dos no-terminales: **T** (el primero) y **T** (el segundo). El no-terminal más a la izquierda es el primer **T**).
4. asi sucesivamente

**Gramatica Ambigua:**

Existe al menos una cadena con dos (o mas) derivaciones extrema izquierda (derecha) posibles. Si esto no sucede para ninguna cadena, la gramatica es no ambigua.

Ejemplo:

* **E**→**E**+E
* **E**→E * E
* E→n

La cadena de entrada : `n + n * n`, hay dos arboles que me devuelven lo mismo. 

**Parsing Recursivo Descendente:**

**El parsing recursivo descendente es un algoritmo de análisis sintáctico que construye el árbol de derivación de una cadena, o determina si pertenece al lenguaje de una gramática dada, de forma recursiva**^^.

Aquí te detallo sus características clave:

* **Idea Fundamental:** La base de este algoritmo es que cada símbolo no terminal de la gramática se convierte en un método o función recursiva^^.
* **Construcción de Derivaciones:** Estos métodos recursivos construyen la secuencia de derivaciones del lenguaje, eligiendo de manera conveniente la producción que "tocaría" aplicar en cada paso.
* **Producciones y Ramas:** Cada producción para un no-terminal se mapea a una posible "rama" o camino dentro del método correspondiente a ese no-terminal.
* **Eficiencia con LL(1):** Si la gramática cumple ciertas características (conocidas como LL(1)), el parsing recursivo descendente puede realizarse sin necesidad de "backtrack" (retroceso o ensayo y error) y con una eficiencia de tiempo lineal, es decir, en **O**(**∣**ω**∣**)**, donde **∣**ω**∣** es la longitud de la cadena de entrada**

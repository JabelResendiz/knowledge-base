## Planos cortantes II

Variantes de algortimo de planos cortantes que garantizan que no se pierde el caracter entero de la solucion por tanto  eliminan la dificultad sennalada  los cortes de Gomory de utilizar como criterio de parada la comprobacion de que se ha alcanzdo una solucion entera.

### Algoritmo Dual Todo Entero

1. El objetivo es garantizar que el pivote correspondiente a una iteracion del algortimo Dual Simplex sea -1.

2. La idea que se utiliza es escoger un valor apropiado de h en al expresion del corte fundamental.

\[\sum_{j \in R} ([hy_{ij}]- [h]y_{ij})x_j \leq [hy_{i0}]- [h]y_{i0}] \]

por tanto cualquier valor de h<1 que satifaga 

# ID3

ID3 (Iterative Dichotomiser 3) es un algoritmo de aprendizaje `supervisado` que construye un arbol de decisión a partir de un dataset etiquetado. El arbol predice una varaible objetivo Y (por ejemplo "¿jugar tenis?") a partir de varaibles de entrada \(X_1, X_2,..., X_n\) por ejemplo (clima, viento, humedad).



## Objetivo
Construir un árbol donde:
- cada nodo interno representa una pregunta sobre un atributo
- cada rama representa una respuesta posible
- cada hoja representa una clase final (etiqueta)

EL objetivo : maximizar la pureza de las hojas, o sea, que en cada hoja las instancias pertenezcan a una sola clase. Que cada grupo final sea lo más homogéneo posible.


## 3.Entropía (desorden o incertidumbre)

- La entropía mide cuán mezcladas están las clases en un conjunto de datos S:

\[
    H(S) = -\sum_{c=1}{k}p(c)log_2 p(c)
\]

donde :


- \( p(c) \): proporción de ejemplos de la clase c
- \( H(S) \): mide la incertidumbre total.

- \( H(S)=0 \): conjunto puro(todas las instancias son de la misma clase)
- \(H(S) = 1\): conjunto totalmente mezclado (mitad y mitad de cada clase)

## 4. Ganancia de Información (Information Gain)

- Cuando dividimos el dataset según un atributo A , la entropía cambia. La ganancia de información mide cuánto reduce la incertidumbre al dividir según A:

\[
    Gain(S,A) = H(S) - \sum_{v \in valores(A)} \frac{|S_v|}{|S|} H(S_v)
\]

donde:

- \( S_v \): subconjunto donde el atributo A=v
- \( H(S_v) \): entropia de ese subconjunto.

El atribuot con `mayor ganancia de infromación` es el más útil para dividir en ese punto del arbol.



## 5. Algoritmo
1. **calcular la entropía:** del conjunto actual S.
2. **Para cada atributo A:** calcular la ganancoa de información-
3. **Elegir el atributo:** con mayor ganancia de información - sera el nodo raiz.
4. **Dividir el dataset:** segun los valores posibles de ese atributo
5. **Repetir recursivamente:** para cada subconjunto
6. **Condicion de parada:** todos los ejemplos son de la misma clase -crear hoja. No hay atribuot restante -crear hoja con la mayor clase mayoirtaria.

---

## 6. Limitaciones
- Solo maneja variables categoricas (las nuemericas deben discretizarse)
- Tiende al overfitting, especialmente con muchos atributos
- Sesgo hacia atributos con muchos valores (por ejemplo, "ID" tendrai ganancia infinita). por eso se introdujo la ganancia de informacion normalizada.

---

## 7. Trade-off : bias vs varianza

| Arbol | Profundidad | Bias | Varianza | Error en prueba |
|---------|----------|-------|----------|-----------|
| Arbol pequeño | Baja | Alto | Bajo | Alto (underfitting)|
| arbol medio | moderado |medio | medio | bajo (optimo)|
| arbol enorme | alta | bajo | alto | alto(overfitting)|


para manteenr el equilibrio, los arboles usan regularizacion estructural:
- Max-Depth: limitar la profundidad del arbol
- Min_samples_split: exigir un numoer minimo de eejmplo para dividir un nodo
- Prunning(poda): cortar ramas que no aportan ganacia significativa (reduce la varianza).
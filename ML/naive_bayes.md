

# Naive Bayes

Es un clasificador probabilístico basado en el Teorema de Bayes, que asigna una clase a una observación basada en la probabilidad condicional de sus características. Se llama "naive" porque asume que todas las características son independiente entre sí, dado el valor de la clase, lo cual es raramente cierto, pero funciona sorprendemente bien en la práctica. `algoritmo de aprendizaje supervisado`


## 1. Teorema de Bayes

El teorema de Bayes permite calcular la probabilidad de una clase \(C_k\) dado un vector de características \(x = (x_1, x_2, ..., x_n)\):

\[
P(C_k \mid x) = \frac{P(C_k) \, P(x \mid C_k)}{P(x)}
\]

- \(P(C_k)\) = probabilidad a priori de la clase \(C_k\)  
- \(P(x \mid C_k)\) = probabilidad de observar las características \(x\) dado que la clase es \(C_k\)  
- \(P(x)\) = probabilidad de observar esas características (normalización)  

Para clasificación, solo necesitamos maximizar el numerador, porque \(P(x)\) es la misma para todas las clases:

\[
\hat{y} = \arg\max_{C_k} P(C_k) \prod_{i=1}^{n} P(x_i \mid C_k)
\]

---

## 2. La “ingenuidad” – independencia condicional

Naive Bayes supone que las características son independientes dado el valor de la clase:

\[
P(x \mid C_k) = \prod_{i=1}^{n} P(x_i \mid C_k)
\]

Esto simplifica enormemente los cálculos, incluso con muchas características.

---

## 3. Tipos de Naive Bayes

- **Gaussian Naive Bayes:**  
  Para características continuas, se asume que  
  \(x_i \mid C_k \sim \mathcal{N}(\mu_{k,i}, \sigma^2_{k,i})\).

- **Multinomial Naive Bayes:**  
  Para datos de conteo (ej. palabras en documentos), probabilidad basada en frecuencia.

- **Bernoulli Naive Bayes:**  
  Para características binarias (0/1).

---

## 4. Entrenamiento del modelo

1. Calcular \(P(C_k)\) = frecuencia relativa de cada clase.  
2. Calcular \(P(x_i \mid C_k)\) según el tipo de Naive Bayes.  
3. Guardar estos parámetros para usar en predicciones.

---

## 5. Predicción

Dada una nueva observación \(x\):

\[
\hat{y} = \arg\max_{C_k} P(C_k) \prod_{i=1}^{n} P(x_i \mid C_k)
\]

- Se calcula la probabilidad de cada clase y se elige la que tenga mayor valor.

---

## 6. Ventajas

- Muy rápido de entrenar y predecir.  
- Funciona bien con datos de **alta dimensión**.  
- Requiere pocos datos para estimar probabilidades.

---

## 7. Limitaciones

- La suposición de **independencia entre características** raramente se cumple.  
- No captura relaciones entre características.  
- Sensible a características con frecuencia cero (solucionado con **Laplace smoothing**).

---

## 8. Ejemplo simple (documentos)

Supongamos que queremos clasificar correos como **spam (S)** o **no spam (H)**:

- **Características:** presencia de palabras como “gratis”, “dinero”, “urgente”.  
- **Entrenamiento:** calcular \(P(S)\), \(P(H)\), \(P(\text{“gratis”}|S)\), \(P(\text{“gratis”}|H)\), etc.  
- **Predicción:** dado un correo, multiplicamos las probabilidades de las palabras según la clase y elegimos la clase con mayor probabilidad.


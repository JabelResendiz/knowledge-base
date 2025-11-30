
# Regresión Lineal 

Busca modelar una relación lineal entre una variable (o varias) de entradas y una variable de salida. En otras palabras, intenta encontrar una ``recta (o hiperplano)` que mejor se ajuste a los datos.

$$
h_\theta(x) = \theta _0 +  \theta _1 x_1+ ...+ \theta _m x_m
$$

donde 
$$
x= (x_1,x_2,...,x_m) son las características (inputs)
$$

$$
\theta = (\theta _0,\theta _1, ...., \theta _m) son los parametros del modelo
$$


$$
h_\theta(x) = \theta ^T x
$$


## Objetivo del Aprendizaje

Queremos que la predicción $h_\theta(x)$ sea lo más cercana posible al valor real $y$. 
Para medir qué tan bien lo hacemos, definimos una función de costo o pérdida:

$$
J(\theta) = \frac{1}{2m} \sum_{i=1}^{m} \big(h_\theta(x^{(i)}) - y^{(i)}\big)^2
$$


## Como funciona el algoritmo (Entrenamiento)

El proceso de entrenamiento consiste en **minimizar** \( J(\theta) \), es decir, encontrar los valores de \( \theta \) que hacen mínimo el error. Existen dos formas principales de hacerlo:

---

### Solución analítica

Podemos resolver directamente derivando \( J(\theta) \) y buscando el mínimo:

\[
\frac{\partial J(\theta)}{\partial \theta} = 0
\]

El resultado es la **ecuación normal**:

\[
\theta = (X^T X)^{-1} X^T y
\]

donde:

- \( X \): matriz de diseño (cada fila es un ejemplo, cada columna una característica)
- \( y \): vector de etiquetas

Esto da la **solución exacta**, pero solo es eficiente si el número de características es pequeño, ya que invertir \( X^T X \) tiene un costo de \( O(n^3) \).

---

### 2. Solución Iterativa (Descenso de Gradiente)

Cuando los datos son grandes, usamos un método iterativo como **descenso de grandiente**

1. Inicializamos \( \theta \) con valores pequeños (a veces ceros o aleatorios).  
2. Repetimos hasta converger:

\[
\theta_j := \theta_j - \alpha \frac{\partial J(\theta)}{\partial \theta_j}
\]

donde:
- \( \alpha \): tasa de aprendizaje (learning rate)
- el gradiente es:

\[
\frac{\partial J(\theta)}{\partial \theta_j} = \frac{1}{m} \sum_{i=1}^{m} (h_\theta(x^{(i)}) - y^{(i)}) x_j^{(i)}
\]

Intuitivamente, el gradiente indica **hacia dónde mover los parámetros para reducir el error**.


---

### 🧮 Regularización

Para evitar el **sobreajuste (overfitting)**, se añaden penalizaciones al tamaño de los parámetros:

#### 🔹 Ridge (L2):

\[
J(\theta) = \frac{1}{2m} \sum (h_\theta(x) - y)^2 + \lambda \sum_{j=1}^{m} \theta_j^2
\]

#### 🔹 Lasso (L1):

\[
J(\theta) = \frac{1}{2m} \sum (h_\theta(x) - y)^2 + \lambda \sum_{j=1}^{m} |\theta_j|
\]

Esto empuja los parámetros a valores pequeños o incluso cero → **modelos más simples y generalizables**.

---

### 📊 Evaluación del Modelo

Métricas típicas:

- **MSE (Mean Squared Error):** error promedio cuadrático.  
- **MAE (Mean Absolute Error):** error promedio absoluto.  
- **\( R^2 \) (Coeficiente de determinación):**

\[
R^2 = 1 - \frac{SSE}{SST}
\]

Mide qué porcentaje de la varianza de \( y \) explica el modelo (1 = perfecto, 0 = nada).

####  📊 Coeficiente de Determinación \( R^2 \)

El **coeficiente de determinación** \( R^2 \) mide **qué tan bien el modelo explica la variabilidad de los datos**.

Se define como:

\[
R^2 = 1 - \frac{SSE}{SST}
\]

donde:

| Símbolo | Significado | Descripción |
|----------|--------------|-------------|
| \( SSE \) | **Sum of Squared Errors** | Mide el **error del modelo**, es decir, qué tan lejos están las predicciones de los valores reales. |
| \( SST \) | **Total Sum of Squares** | Mide la **variabilidad total** de los datos reales respecto al promedio. |

---

#### 🔹 **SSE (Sum of Squared Errors o Residual Sum of Squares)**

\[
SSE = \sum_{i=1}^{m} (y^{(i)} - h_\theta(x^{(i)}))^2
\]

Cuanto menor sea el \( SSE \), mejor se ajusta el modelo a los datos.

---

#### 🔹 **SST (Total Sum of Squares)**

\[
SST = \sum_{i=1}^{m} (y^{(i)} - \bar{y})^2
\]

donde:

\[
\bar{y} = \frac{1}{m} \sum_{i=1}^{m} y^{(i)}
\]

El \( SST \) mide cuánta **variabilidad total** existe en los datos sin considerar ningún modelo.

---

#### 🔹 Intuición

- La fracción \( \frac{SSE}{SST} \) representa la proporción del error **no explicado por el modelo**.  
- Por lo tanto, \( R^2 = 1 - \frac{SSE}{SST} \) indica **la proporción de la variabilidad de \( y \)** que **sí es explicada** por el modelo.

---

#### 📈 Interpretación de \( R^2 \)

| Valor de \( R^2 \) | Interpretación |
|----------------------|----------------|
| \( R^2 = 1 \) | El modelo predice perfectamente los datos. |
| \( R^2 = 0 \) | El modelo no mejora respecto a predecir siempre el promedio \( \bar{y} \). |
| \( R^2 < 0 \) | El modelo es **peor** que predecir el promedio. |

---

---

### 🚀 En Resumen

| Concepto | Descripción |
|-----------|--------------|
| **Tipo de aprendizaje** | Supervisado (predicción de variable continua) |
| **Hipótesis** | \( h_\theta(x) = \theta^T x \) |
| **Función de costo** | MSE |
| **Optimización** | Ecuación normal o descenso de gradiente |
| **Regularización** | L1 / L2 |
| **Propósito** | Predecir valores numéricos a partir de entradas |





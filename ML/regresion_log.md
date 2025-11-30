

# Regresión Logística

La regresión logística es un modelo supervisado usado para `clasificación`, es decir, predecir la probabilidad de que una observación pertenezca a una clase. Generalmente se usa para clases binarias (0 o 1), aunque existen extensiones para múltiples clases (multimodal logistic regression)


## 1. Hipótesis del modelo

A diferencia de la regresión lineal, que predice valores continuos, en regresión logística queremos **probabilidades entre 0 y 1**:

\[
P(y=1 \mid x) = h_\theta(x)
\]

Para esto usamos la **función sigmoide** (o logística):

\[
h_\theta(x) = \frac{1}{1 + e^{-\theta^T x}}
\]

donde:

- \(x \in \mathbb{R}^n\) es el vector de características.  
- \(\theta \in \mathbb{R}^n\) son los parámetros del modelo.  
- \(h_\theta(x)\) devuelve la probabilidad de que \(y=1\).

**Interpretación de la predicción:**

- Si \(h_\theta(x) > 0.5\) → predicción \(y=1\)  
- Si \(h_\theta(x) \leq 0.5\) → predicción \(y=0\)


## 2. Función de costo

No podemos usar **error cuadrático** como en regresion lineal porque el gradiente no sería convexo. EN su lugar usamos **log-loss** o **cross_entropy loss**:

\[
J(\theta) = -\frac{1}{m} \sum_{i=1}^{m} \Big[ y^{(i)} \log(h_\theta(x^{(i)})) + (1 - y^{(i)}) \log(1 - h_\theta(x^{(i)})) \Big]
\]

- \(m\) = número de ejemplos.  
- Minimizar \(J(\theta)\) significa **maximizar la probabilidad de los datos bajo el modelo**.

---

## 3. Entrenamiento del modelo

### 🔹 Descenso de gradiente

Actualizamos los parámetros iterativamente:

\[
\theta_j := \theta_j - \alpha \frac{\partial J(\theta)}{\partial \theta_j}
\]

Con derivada del costo:

\[
\frac{\partial J(\theta)}{\partial \theta_j} = \frac{1}{m} \sum_{i=1}^{m} \big( h_\theta(x^{(i)}) - y^{(i)} \big) x_j^{(i)}
\]

- \(\alpha\) = tasa de aprendizaje.  
- Este proceso se repite hasta convergencia.

### 🔹 Regularización

Para prevenir **overfitting**:

#### L2 (Ridge)

\[
J(\theta) = -\frac{1}{m} \sum_{i=1}^{m} \Big[ y^{(i)} \log(h_\theta(x^{(i)})) + (1 - y^{(i)}) \log(1 - h_\theta(x^{(i)})) \Big] + \frac{\lambda}{2m} \sum_{j=1}^{n} \theta_j^2
\]

#### L1 (Lasso)

\[
J(\theta) = -\frac{1}{m} \sum_{i=1}^{m} \Big[ y^{(i)} \log(h_\theta(x^{(i)})) + (1 - y^{(i)}) \log(1 - h_\theta(x^{(i)})) \Big] + \frac{\lambda}{m} \sum_{j=1}^{n} |\theta_j|
\]

- \(\lambda\) grande → aumenta bias, disminuye varianza (modelo más simple).  
- \(\lambda\) pequeño → disminuye bias, aumenta varianza (modelo más flexible).

---

## 4. Interpretación de los parámetros

- \(\theta_j\) representa el **efecto de la característica \(x_j\) en la probabilidad de \(y=1\)**.  
- La **razón de probabilidades (odds ratio)**:

\[
\text{odds}(y=1 \mid x) = \frac{h_\theta(x)}{1 - h_\theta(x)}
\]

- Tomando logaritmo:

\[
\log \text{odds}(y=1 \mid x) = \theta^T x
\]

De ahí viene el nombre “**regresión logística**”.

---

## 5. Evaluación del modelo
Supongamos que tenemos un modelo binario que predice \(y \in \{0,1\}\).  
Se definen:

- **TP (True Positive):** predice 1 y realmente es 1  
- **TN (True Negative):** predice 0 y realmente es 0  
- **FP (False Positive):** predice 1 pero realmente es 0  
- **FN (False Negative):** predice 0 pero realmente es 1  

---
### 1. Accuracy (Precisión global)

\[
\text{Accuracy} = \frac{TP + TN}{TP + TN + FP + FN}
\]

- Mide la proporción de predicciones correctas.  
- Bueno si las clases están balanceadas.  
- No es confiable si las clases están desbalanceadas.

---

### 2. Precision (Precisión de la clase positiva)

\[
\text{Precision} = \frac{TP}{TP + FP}
\]

- Mide **qué tan confiables son las predicciones positivas**.  
- Alta precision → pocos falsos positivos.  
- Importante cuando **falsos positivos son costosos** (ej. detección de fraude).

---  

### 3. Recall (Sensibilidad o Tasa de Verdaderos Positivos)

\[
\text{Recall} = \frac{TP}{TP + FN}
\]

- Mide **qué proporción de los positivos reales se detecta correctamente**.  
- Alta recall → pocos falsos negativos.  
- Importante cuando **falsos negativos son costosos** (ej. diagnóstico médico).

---
### 4. F1-Score

\[
F1 = 2 \cdot \frac{\text{Precision} \cdot \text{Recall}}{\text{Precision} + \text{Recall}}
\]

- Es el **promedio armónico de Precision y Recall**.  
- Útil cuando necesitamos balancear **falsos positivos y falsos negativos**.  

---

### 5. Log-Loss (Cross-Entropy Loss)

\[
\text{Log-Loss} = -\frac{1}{m} \sum_{i=1}^{m} \Big[ y^{(i)} \log(\hat{y}^{(i)}) + (1-y^{(i)}) \log(1-\hat{y}^{(i)}) \Big]
\]

- Mide la **calidad de las probabilidades predichas**.  
- Penaliza fuertemente predicciones confiadas incorrectas (\(\hat{y} \approx 1\) cuando \(y=0\)).  
- Mientras menor Log-Loss → mejor ajuste de probabilidades.

---

### 6. ROC-AUC (Receiver Operating Characteristic - Área bajo la curva)

- La curva **ROC** grafica **tasa de verdaderos positivos (TPR)** vs **tasa de falsos positivos (FPR)** para distintos umbrales de decisión.  

\[
\text{TPR} = \frac{TP}{TP + FN}, \quad \text{FPR} = \frac{FP}{FP + TN}
\]

- **AUC** = área bajo la curva ROC, varía entre 0 y 1.  
- AUC ≈ 0.5 → modelo aleatorio  
- AUC ≈ 1 → modelo perfecto  
- Evalúa la **capacidad de discriminación** del modelo sin depender de un umbral específico.

---

### 📌 Resumen rápido

| Métrica | Qué mide | Ideal |
|---------|----------|-------|
| Accuracy | % de aciertos | 1 |
| Precision | Fiabilidad de predicciones positivas | 1 |
| Recall | Captura de positivos reales | 1 |
| F1-Score | Balance entre Precision y Recall | 1 |
| Log-Loss | Calidad de probabilidades | 0 (menor mejor) |
| ROC-AUC | Capacidad de separar clases | 1 |

---


## 6. Sesgo y varianza en regresión logística

- **Bias alto:** underfitting, la frontera de decisión no separa bien las clases.  
- **Varianza alta:** overfitting, la frontera se ajusta demasiado al ruido del dataset de entrenamiento.  

**Regularización** ayuda a controlar este trade-off.

---

## 7. Resumen

| Concepto | Descripción |
|----------|------------|
| Tipo de modelo | Supervisado, clasificación binaria |
| Hipótesis | \(h_\theta(x) = \frac{1}{1 + e^{-\theta^T x}}\) |
| Función de costo | Log-loss / cross-entropy |
| Optimización | Descenso de gradiente o variantes (BFGS, Newton) |
| Regularización | L1, L2 para controlar overfitting |
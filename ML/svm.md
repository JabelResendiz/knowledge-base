# 🧠 Máquinas de Soporte Vectorial (SVM)

## 1. Introducción

Las **Máquinas de Soporte Vectorial (SVM)** son modelos de **aprendizaje supervisado** utilizados principalmente para **clasificación**.  
Buscan encontrar el **hiperplano que mejor separa las clases** en el espacio de características.

Fueron desarrolladas en 1963 por **Vladimir Vapnik** y **Alexei Chervonenkis** en la Unión Soviética.

---

## 2. Idea principal: el hiperplano separador

En un problema de clasificación binaria, los datos se dividen según una ecuación:

\[
w^T x + b = 0
\]

- \( w \): vector normal al hiperplano.  
- \( b \): sesgo (distancia del hiperplano al origen).  
- La predicción se realiza con el signo de \( f(x) = w^T x + b \):

\[
\text{sign}(f(x)) =
\begin{cases}
+1, & \text{si pertenece a la clase positiva}\\
-1, & \text{si pertenece a la clase negativa}
\end{cases}
\]

---

## 3. Margen y vectores de soporte

SVM no busca **cualquier** hiperplano que separe las clases, sino el que **maximiza el margen**, es decir, la distancia entre el hiperplano y los puntos más cercanos.

\[
\text{Margen} = \frac{2}{||w||}
\]

Los puntos más cercanos a la frontera son los **vectores de soporte**.  
Ellos son los que definen la posición y orientación del hiperplano.

---

## 4. Formulación matemática

El problema se plantea como:

\[
\min_{w,b} \frac{1}{2} ||w||^2
\]

sujeto a:

\[
y_i (w^T x_i + b) \ge 1, \quad \forall i
\]

Esto es un **problema de optimización cuadrática convexa**, cuya solución da el hiperplano con margen máximo.

- El vector w define la orientación del hiperplano
- Su norma || w || está inversamente relacionado con el margen: cuanto más pequeño || w || , más ancho el margen.
- Las restricciones garantizan que no hay puntos mal clasificados. 
- LOs puntos que tocan las lineas w^T x + b = +1 o -1 son los vectores de soporte.


---

## 5. SVM con datos no linealmente separables

Cuando no es posible separar las clases perfectamente, se introduce un término de error \(\xi_i\):

\[
\min_{w,b} \frac{1}{2} ||w||^2 + C \sum_i \xi_i
\]

sujeto a:

\[
y_i (w^T x_i + b) \ge 1 - \xi_i, \quad \xi_i \ge 0
\]

- \( C \): parámetro de penalización que controla el equilibrio **bias–varianza**.  
  - \( C \) grande → menos errores, mayor varianza (overfitting).  
  - \( C \) pequeño → más tolerancia a errores, mayor bias (underfitting).

---

## 6. SVM no lineales y el truco del kernel

Si los datos no son separables linealmente, SVM aplica una **transformación no lineal** de las características a un espacio de mayor dimensión:

\[
\phi: \mathbb{R}^n \rightarrow \mathbb{R}^m
\]

donde en ese espacio **sí** existe un separador lineal.

En lugar de calcular explícitamente \(\phi(x)\), SVM usa una **función kernel** \(K(x_i, x_j)\) que mide la similitud entre puntos en ese espacio transformado: 

\[
K(x_i, x_j) = \langle \phi(x_i), \phi(x_j) \rangle
\]

en cuetion toma todo par de puntos , \(x_i, x_j\) y crea una matriz kernel , y el algoritmo de SVM usa solo esa matriz para encontrar los multiplicadores de Lagrange, y por tanto, la frontera óptima.

---

## 7. Funciones de kernel más usadas

| Kernel | Fórmula | Tipo de frontera |
|---------|----------|------------------|
| **Lineal** | \( K(x, x') = x^T x' \) | Hiperplano |
| **Polinomial** | \( K(x, x') = (x^T x' + c)^d \) | Curva polinómica |
| **RBF (Radial Basis Function)** | \( K(x, x') = e^{-\gamma ||x - x'||^2} \) | Frontera no lineal |
| **Sigmoide** | \( K(x, x') = \tanh(\alpha x^T x' + c) \) | Similar a una red neuronal |

---

## 8. Interpretación geométrica

- En el **espacio original**, la frontera puede ser curva o compleja.  
- En el **espacio transformado**, SVM encuentra un hiperplano lineal.  
- Los **vectores de soporte** son los únicos puntos que realmente afectan el modelo.  

---

## 9. Propiedades clave

- **Margen máximo:** mejor generalización.  
- **Dependencia en pocos puntos:** eficiente.  
- **Kernel trick:** permite separaciones no lineales sin aumentar mucho el costo computacional.

---

## 10. Ventajas y desventajas

✅ **Ventajas:**
- Alta precisión en espacios de gran dimensión.  
- Robusto frente a overfitting (si \(C\) y \(\gamma\) se eligen bien).  
- Usa solo vectores de soporte → modelo compacto.

❌ **Desventajas:**
- Ajuste de parámetros \(C\) y \(\gamma\) puede ser complejo.  
- No escala bien con datasets enormes.  
- No produce probabilidades directamente (solo etiquetas).

---

## 11. Intuición visual

- **SVM lineal:** encuentra la recta/plano que maximiza el margen.  
- **SVM con kernel:** proyecta los puntos en una dimensión superior donde sí existe una separación lineal.  
- Al volver al espacio original → frontera no lineal.

---

## 12. Resumen

| Concepto | Descripción |
|-----------|-------------|
| Tipo | Supervisado (clasificación) |
| Hipótesis | \( f(x) = w^T x + b \) |
| Optimización | Maximiza el margen \(\frac{2}{||w||}\) |
| Parámetro | \(C\): control de error; \(\gamma\): forma del kernel RBF |
| Kernel Trick | Mapea los datos a un espacio donde son separables |
| Resultado | Frontera de decisión óptima definida por vectores de soporte |

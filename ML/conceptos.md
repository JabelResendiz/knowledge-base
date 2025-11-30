
# Conceptos 

## Curva de aprendizaje

Es un graáfico que muetra cómo se mejora el rendimiento de un modelo a mediad que entrena con más datos o más iteraciones.


### Que nos dice la curva
- Si el error disminuye con mas datos , el modelo está aprendiendo correctamente
- Si el error se mantiene alto aunque entrenemos mas, el modelo es demasiado simple (underfitting)
- Si el error en training es bajo pero el error en validacion sigue alto, modelo se sobreajutsta a los datos (overfitting)

- Existen las curvas de entrenamiento y de validación

|Conceptos| Qué significa | Consecuencia práctica |
|------------|------------|------------|
| Sesgo (Bias)     | Error debido a suposiciones demasiado simples en el modelo    | El modelo no logra capturar la relacipon real (underfitting)   |
| Varianza    | Error debido a la sensibilidad del modelo a los datos de entrenamiento   | El modelo aprende demasiaod el ruido (overfitting)  |


### Sesgo alto
- pasa cuando el modelo es demasiaod simple para capturar la relación real
- Los datos siguen una curva cuadratica, pero usamos un modelo lineal
- Resultado, alto error de entrenamiento y de prueba
- LLamada underfitting

### Varianza alta
- Ocurre cuando el modelo es muy flexible o tiene demasiados parametros
- usamos polinomios de grado alto o muchas features sin regularización
- Bajo error de entrenamiento, pero alto error de prueba
- Llamaado overfitting


### El trade-off entre Bias y Varianza

El error total esperado de un modelo puede descomponerse como:

\[
E\big[(y - \hat{y})^2\big] = (\text{Bias}[\hat{y}])^2 + \text{Var}[\hat{y}] + \sigma^2
\]

donde:

- \( \text{Bias}[\hat{y}] \) es el sesgo del modelo.  
- \( \text{Var}[\hat{y}] \) es la varianza del modelo.  
- \( \sigma^2 \) es el ruido irreducible de los datos.

El objetivo es minimizar la **suma del bias y la varianza**, ya que el **ruido no se puede eliminar**.


### Cómo calcular Bias y Varianza

Supongamos que queremos predecir una variable \(y\) a partir de un conjunto de features \(x\) usando un modelo que genera estimaciones \(\hat{f}(x)\).  
Nuestro modelo depende del **dataset** de entrenamiento \(D\), que puede variar por muestreo o ruido.

---

#### 1. Bias (sesgo)

El **bias** en un punto \(x\) se define como la diferencia entre la predicción promedio del modelo y el valor real:

\[
\text{Bias}[\hat{f}(x)] = E_D[\hat{f}(x)] - f(x)
\]

- \(f(x)\) es la función verdadera que genera los datos.  
- \(E_D[\hat{f}(x)]\) es el promedio de las predicciones del modelo sobre muchos datasets distintos.

El **Bias al cuadrado** mide el error sistemático:

\[
(\text{Bias}[\hat{f}(x)])^2
\]

---

#### 2. Varianza

La **varianza** mide cuánto cambian las predicciones del modelo si entrenamos con distintos datasets:

\[
\text{Var}[\hat{f}(x)] = E_D\Big[(\hat{f}(x) - E_D[\hat{f}(x)])^2\Big]
\]

- Alta varianza → el modelo es inestable y sensible a pequeñas variaciones en los datos.  
- Baja varianza → el modelo es consistente entre diferentes datasets.

---

#### 3. Error total esperado

El **error total esperado** en un punto \(x\) se descompone como:

\[
E_D[(y - \hat{f}(x))^2] = (\text{Bias}[\hat{f}(x)])^2 + \text{Var}[\hat{f}(x)] + \sigma^2
\]

- \(\sigma^2\) = varianza del ruido irreducible (lo que **ningún modelo puede predecir**).

---

#### 4. Cómo estimarlo en la práctica

Como normalmente no tenemos infinitos datasets, podemos estimar bias y varianza de forma empírica:

1. Dividir los datos en **varios conjuntos de entrenamiento** (bootstrap o cross-validation).  
2. Entrenar el modelo en cada conjunto → obtenemos varias predicciones \(\hat{f}_1(x), \hat{f}_2(x), \dots, \hat{f}_k(x)\).  
3. Calcular la predicción promedio:

\[
\overline{f}(x) = \frac{1}{k} \sum_{i=1}^{k} \hat{f}_i(x)
\]

4. Estimar bias al cuadrado y varianza:

\[
\text{Bias}^2(x) = (\overline{f}(x) - f(x))^2
\]

\[
\text{Var}(x) = \frac{1}{k} \sum_{i=1}^{k} (\hat{f}_i(x) - \overline{f}(x))^2
\]

5. Repetir para varios puntos \(x\) del dataset y promediar si se quiere un valor global.

---

#### 5. Intuición rápida

- **Bias alto** → el modelo es demasiado simple → underfitting.  
- **Varianza alta** → el modelo es muy complejo → overfitting.  
- **Bajo bias y baja varianza** → modelo óptimo que generaliza bien.

---


## Algoritmos parametricos y no parametricos 

- Parametricos : Tiene un conjunto fijo de parametros (logistic reg, naive bayes, redes neuronales, svm)
- No parametricos: el numero de parametros crece con el conjunto de entrenamiento  (knn , dbscan)


## Proceso de experimentacion
- Dividir en train y test
- Dentro de train, dividir un conjunto a validation.

## k-fold
- es una tencincia para evaluar como de bien funciona unmodelo sin desperdiciar datso. Se usa para evitar que la evaluacion dependa de un solo conjunto de entrenameinto/valiadcion
- Se divide los datos de train en k partes igaules(folds)
- Iterar k veces, cada bloque difretnes se usa como conmjunto de validacion y los k-1 restantes se usan como conjunto de entrenamiento
- Promediarel rendimienot, al final tiene k evaluaciones del modelo que se promedias y se calcula varainza para obtener un score mas confiable

## Estratificación
- Tenica para dividir los datos de amnera que la proporcion de clases se amntena igaul en cada fold
- Se usa dentro de k-fold para asegurar que cada fold sea represetnativa del dataset completo, especialmente datasets desequilibrados

## Para comparar modelos.
- Se hace prubea de normlaidd(shapiro-wilk). p>0.05 datos aproximadamente normales. p<0.05 ,d atos no normales
- si abmos fuesen normales se hacen pruebas de t-test
- Si son test parametricos (t-student) y no parametricos (Mann-Whitney)

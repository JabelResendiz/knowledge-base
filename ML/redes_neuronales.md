

# Red Neuronal

Una red neuronal artificial es un modelo de aprendizaje `supervisado` que intenta aprender una función \(f^*: X -> Y\) a partir de datos de entrenamientos (x,y). 

Su objetivo central es aproximar relaciones complejas y no lineales entre entradas y salidas, algo que los modelos lineales (com regresion logistica) no pueden hacer bien.


## 🎯 2️⃣ Objetivo central

Aprender una función de la forma:

\[
\hat{y} = h_\theta(x)
\]

donde:

- \( h_\theta \) es la **hipótesis del modelo** (la red neuronal),
- \( \theta \) son los **parámetros** del modelo (pesos y sesgos).

👉 En otras palabras: queremos que para cada entrada \(x\),  
la red produzca una **salida lo más** cercana posible a la real y.

## Base matemática -la neurona-

Una **neurona artificial** es el bloque básico y combina las entradas de forma lineal y luego aplica una función no lineal:

\[
z = w_1x_1 + w_2x_2 + \dots + w_nx_n + b = w^T x + b
\]
\[
a = f(z)
\]

donde:

- \( x_i \): **entradas** del modelo  
- \( w_i \): **pesos**, indican la importancia de cada entrada  
- \( b \): **sesgo**, permite desplazar la función de activación  
- \( f(\cdot) \): **función de activación**, introduce no linealidad al modelo  
- \( a \): **salida** de la neurona (resultado final)

💡 En esencia, la neurona toma una combinación ponderada de las entradas,  
le aplica una transformación no lineal y produce una salida que puede alimentar a otras neuronas.


## Conexión con la regresión logística
La regresion logistica es en realidad una red neuronal con una sola neurona:

\[
\hat{y} = \sigma(w^T x + b)
\]


donde \(\sigma(z)\) es la **función sigmoide**:

\[
    \sigma(z)= \frac{1}{1+e^{-z}}
\]

Esto es ya una neurona artificial:

- **Entradas->:** \(x_1,x_2,...\)
- **Pesos->:** \(w_1,w_2,...\)
- **Activación->:** sigmoide
- **Salida->:** probabilidad de clase positiva

En conclusión , la regresión logística es la forma más simple de una red neuronal.

> una sola capa y una sola neurona


## 🧱 5️⃣ De una neurona a una red

Una **red neuronal** es simplemente una extensión del modelo de regresión logística:  
en lugar de tener **una sola neurona**, ahora tenemos **muchas**, organizadas en **capas**.  

Cada capa toma las salidas de la anterior, las transforma, y pasa el resultado a la siguiente.  
Así, la red va construyendo representaciones cada vez más complejas de los datos.

Formalmente, una red neuronal se define como:

\[
a^{(l)} = f\big(W^{(l)} a^{(l-1)} + b^{(l)}\big)
\]

donde:

- \(a^{(0)} = x\) → **las entradas** del modelo (por ejemplo, características o píxeles).  
- \(W^{(l)}\) → **la matriz de pesos** de la capa \(l\), que define cómo se combinan las entradas.  
- \(b^{(l)}\) → **el sesgo (bias)** de la capa \(l\), que ajusta la salida independientemente de las entradas.  
- \(f(\cdot)\) → **la función de activación**, que introduce no linealidad (sigmoide, ReLU, tanh, etc.).  
- \(a^{(l)}\) → **las activaciones** de la capa \(l\), es decir, las salidas después de aplicar \(f\).  (activaciones son los valores de cada capa de la red después de aplicar la funcion de activación)
- \(a^{(L)} = \hat{y}\) → **la salida final** de la red, que puede representar una probabilidad o una clase predicha.  

🧠 En resumen:
> Una red neuronal no es más que **muchas regresiones logísticas apiladas**, donde cada capa aprende una representación más abstracta de los datos.

### 💡 Intuición

- Cada capa **toma las activaciones** de la capa anterior como entrada.  
- Las transforma mediante una combinación lineal \(W^{(l)}a^{(l-1)} + b^{(l)}\).  
- Luego aplica una **función de activación no lineal** para producir nuevas activaciones.

\[
a^{(l)} = f(W^{(l)} a^{(l-1)} + b^{(l)})
\]


### 🧠 Qué representan

- En las **capas iniciales**, las activaciones detectan *patrones simples* (bordes, líneas, etc.).  
- En **capas intermedias**, combinan esos patrones (formas, texturas).  
- En **capas finales**, representan *conceptos abstractos* (una cara, un número, una palabra, etc.).

Cada capa **aprende una representación más útil del input**.

---


> Osea cada capa tiene neuronas y todas las neuronas recibne los mismo inputs , los inputs son las activaciones de la capa anterior. Cada neurona ve todas esas activaciones, pero cada neurona decide de forma distinta que es importante gracias a su propios pesos.
>
> La capa de salida(output layer), tomas las activaciones de la ultima capa oculta y las combina con pesos de salida para generar la prediccion final.


## Feed-Forward (alimentacion hacia adelante)

- La estructura de la red, cómo están conectadas las capas y las neuronas
- Los datos fluyen solo hacia adelante , desde la capa de entrada, capas ocultas y capas salidas
- **Punto clave:** no hay ciclos, no hay retroalimentación ; es la arquitectura de la red.


## Forward Propagation (propagación hacia adelante)

- Es el proceso de cálculo de activaciones usando la arquitectura feed-forward
- Cada neurona recibe las activaciones de la capa anterior \(a_i ^{(l-1)}\). Calcula la suma ponderada de sus inputs + bias. Aplica la función de activación , las activaciones se pasan a la siguiente capa. Finalmente se calcula la prediccion de al red en la capa de salida.

## 3️⃣ Backpropagation (Retropropagación del Error)

**Qué es:**  
El método para entrenar la red neuronal, ajustando los pesos para que la predicción se acerque al valor real.

**Cómo funciona:**

1. **Calculas el error en la salida:**

\[
E = f(y_{\text{pred}}, y_{\text{real}})
\]

2. **Actualizas los pesos de la última capa** usando **gradiente descendente**:

\[
w \leftarrow w - \alpha \frac{\partial E}{\partial w}
\]

3. **Para capas ocultas**, el error se propaga hacia atrás desde la salida usando la **regla de la cadena**:

\[
E(a_j^{(l)}) = \sum_k w_{jk}^{(l+1)} E(a_k^{(l+1)})
\]

donde:  
- \(a_j^{(l)}\) → neurona \(j\) de la capa oculta \(l\)  
- \(a_k^{(l+1)}\) → neuronas de la siguiente capa \(l+1\)  

4. **Actualización de pesos intermedios:**  
No necesitas conocer el “valor ideal” de cada neurona intermedia; solo se usa su activación y el error propagado hacia atrás.

\[
w \leftarrow w - \alpha \frac{\partial E}{\partial w}
\]


💡 **Analogía rápida:**  
Es como corregir una receta después de probar el plato final: si dices *“la mezcla estaba muy salada”*, ajustas cada ingrediente de las capas anteriores proporcionalmente para mejorar el resultado.



# En general El Forward Back propagation

1. Se propaga las activaciones hacia adeltante, guardando el valor de activacion de cada neurona
2. Se calcula el error final en funcion edl valor esperado en el entrenamiento
3. Los pesos de la ultima capa se actualizan igual qu en Reg. logistica
4. En unca capa intermedia , el error se calcula como al suma de los pesos de salida multiplicados por el error de al neurona sigueinte
5. La derevida del error se puede calcular sin necesidad de conocer el valor optimo en una capa intermedia, solo teniendo el error y el valor de activacion. Para esto se diseñan funciones de activacion conveniente



## Red Feed Forward clasica

- cada neurona de una capa está conectada a todas las neuronas de la siguiente capa
- Esto se llama conexion completa


## Red Convolucional
- arquitectura con compartiemineto de pesos. En toda las neuronas de una capa los pesos de salida hacia la misma neurona son iguales. Ideal apra funcioanes invaraintes a traslación.

## Red Recurrente
- Arquitectura con memoria. Cada neurona no solo recibe la activacion de la capa anterior en el tiempo actual, sino tambien su propio estado de al activacion anterior . Idea para secuncia con invariancia en el tiempeo (texto, sonido, series de tiempo)
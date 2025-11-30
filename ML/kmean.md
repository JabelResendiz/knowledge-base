
# K-Means

El algoritmo de K-Means es uno de los métodos más clásicos y simples de aprendizaje `no supervisado` en machine learning. Se usa para agrupar datos (`clustering`) cuando no tenes etiquetas , o sea, cuando el sistema tiene que descubrir por sí mismo qué puntos se parecen entre sí.


## Idea Central
Queremos dividir un conjunto de datos en k grupos o cluster, de manera que los puntos dentro de un mismo grupo sean lo más parecidos posibles, y los grupos entre sí sean lo más distintos posibles.


## Algoritmo
1. **Se elige un número k** (número de clusters)
2. **Inicializar los centroides** : Elegir `aleatoriamente` k puntos del espacio de datos como "centros" iniciales de los clusters (los centroides)
3. **Asignación de puntos**: Cada punto se asigna al centro más cercano según una métrica (usualmente la euclidiana). Esto crea los k grupos iniciales.
4. **Actualización de centroides**: Recalcular el centro de cada cluster como el promedio de todos los puntos asignados a ese cluster.
5. **Iterar**: Repetir los pasos 3 y 4 hasta que los centroides no cambien casi nada o el cambio total sea mínimo (algoritmo converge)


## Qué busca minimizar??
K-Means minimiza una función de costo llamada **inercia** o **SSE (Sum of Squared Errors)**:

$$
J = \sum_{i=1}^{k} \sum_{x_j \in C_i} \| x_j - \mu_i \|^2
$$


## Limitaciones
- Hay que elegir k a priori (se puede estimar con el método del codo)
- Es sensible a los valores iniciales de los centroides
- No maneja bien outliers
- Solo funciona bien con clusters de forma más o menos esférica y separables.

## Complejidad: O(n)

## Metricas (Coeficiente de Silueta)


Es una metrica que evalua la calidad de un clustering (como K_mean) indicandoq ue tan bien separados y compactos estan los clusters.

Para cada punto i:

- a(i) : distancia promedio entre i y todos los otros punetos en su mismo cluster
- b(i): distancia promedio entre i y todos los puentos del cluster mas cercano al que no pertenece

El coeficiente de siluyeta del punto se define como:

\[
    s(i) = \frac{b(i)-a(i)}{max(a(i),b(i))}
\]

- La interpretacion es que cerca de 1, estan bien agrupados , lejos de otros clusters
- Cerca de 0 : ceracno al limite de dos clusters
- Negativo : posiblemente asignado al cluster incorrecto
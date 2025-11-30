
# K-Medoids

K-Medoids es otro algoritmo de clustering `no supervisado`, parecido a K-Means per con una diferencia clave:

> En lugar de usar el promedio(centroide) como representante de un grupo, usa un punto real del dataset - llamado medoide- que minimiza la distancia total a los demás puntos del cluster


## Algoritmo
1. **Elegir k** (número de clusters)
2. **Inicializar los medoides:** eligiendo k puntos aleatorios del dataset
3. **Asignación de puntos:** Cada punto se asigna al medoide más cercano según una métrica de dsitancia
4. **Actualización de medoides:** para cada clusters, se evalúa si reemplazar el medoide actual por otro punto dentro del cluster reduce el costo total:


$$
C = \sum_{i=1}^{k} \sum_{x_j \in C_i} \| x_j - \mu_i \|^2
$$

5. **Iterar:** hasta que los medoides no cambien o el costo deje de mejorar


## Diferencia conceptuales con K-Means

|Aspectos| k_mean | k-medoids |
|------------|------------|------------|
| Representante del cluster     | Centroide(promedio)     | Medoide(punto real)     |
| Tipo de distancia     | Usualmente euclideana     | Cualquiera(manhattan, coseno)     |
| Sensible a outliers     | sí, mucho     | no tanto     |
| Costo computacional     | rápido     | más costoso     |
| Ideal para    | Datos numéricos     | Datos mixtos  o con outliers    |

## Complejidad: O(k(n-k)^2)
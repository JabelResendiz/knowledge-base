
# KNN

KNN es un algoritmo de aprendizaje `supervisado` usado para clasificación y también regresión. Su lema es:

> Dime quiénes son tus vecinos y te diré quién eres

No tiene una fase de entrenamineto en el sentido tradicional: `memoriza los datos de entrenamiento` y usa la distancia entre puntos para tomar decisiones.


## Algoritmo
Supongamos que queremos clasificar un nuevo punto x.

1. **Elegir un número k:** número de vecinos que vas a mirar.
2. **Calcular la distancia:** entre x y todos los puntos del conjunto de entrenamiento. La más común es la distancia euclideana.
3. **Buscar los k vecinos más cercanos:** los puntos con menor distancia.
4. **Votación o promedio:** si es clasificación, cada vecino vota por su clase y gana la mayoría. Si es regresión, tomar el promedio del valor de los vecinos.
5. **Asignar el resultado:** al nuevo punto.


## Elección k
- Si k es demasiado pequeño, el modelo se vuelve sensible al ruido(overfitting)
- SI k es demasiado grande, el modelo pierde detalle (underfitting)
- lo ideal es probar varios valores y usar validación cruzada
- A menudo, se elige un k impar para evitar empates.

## Ventaja y Desventajas

| Ventajas | Desventajas |
|------------|------------|------------|
| Intuitivo , simple, sin superposiciones previas    | Lento con muchos datos (porque compara con todos) |
| Funciona con cualquier tipo de frontera de decisión     | Muy sensible a la escala (conviene normalizar) |
| No requiere entrenamiento costoso     | Sufre con datos de alta dimensión |

## Recuperacion de Informacion (RI)

La **recuperación de información** se refiere al proceso de obtener información relevante de una gran cantidad de datos no estructurados. La RI es comúnmente asociada con la búsqueda de información dentro de grandes volúmenes de contenido, como texto, documentos, imágenes, y otros tipos de datos no organizados. La idea principal detrás de la RI es ayudar a los usuarios a encontrar los documentos o fragmentos de información más relevantes a sus consultas.

#### Características clave de la Recuperación de Información:

* **Objetivo** : Buscar y recuperar la información que mejor responde a una consulta del usuario. No siempre se busca recuperar un conjunto de datos específico o exacto.
* **Tipo de Datos** : En su mayoría, la RI se enfoca en datos no estructurados, como texto, imágenes, videos, etc. Un ejemplo típico es el uso de motores de búsqueda en Internet (como Google), que recuperan páginas web relevantes basadas en una consulta textual.
* **Consulta** : Las consultas son generalmente en lenguaje natural o palabras clave que representan la intención de búsqueda del usuario.
* **Relevancia** : En la RI, la relevancia de la información recuperada es un aspecto crucial. Los resultados no siempre son exactos, sino que se basan en cómo de bien los documentos coinciden con la consulta del usuario.
* **Ejemplos** : Motores de búsqueda web, bases de datos bibliográficas, sistemas de recomendación.

## Recuperacion de Datos (RD)

La **recuperación de datos** se refiere al proceso de obtener datos específicos de una base de datos estructurada. A diferencia de la RI, que se enfoca en datos no estructurados, la RD se centra en datos organizados en tablas, registros y relaciones (como bases de datos relacionales). La RD suele ser más precisa, ya que los datos están bien definidos y organizados en esquemas.

#### Características clave de la Recuperación de Datos:

* **Objetivo** : Recuperar datos específicos o precisos, como registros de una base de datos, de acuerdo a ciertas condiciones o consultas.
* **Tipo de Datos** : Los datos en la RD son  **estructurados** , es decir, están organizados en bases de datos que siguen un esquema rígido (como tablas, filas y columnas).
* **Consulta** : Las consultas en la RD se realizan típicamente mediante **lenguajes de consulta estructurados** como SQL. Las consultas suelen ser muy específicas y devuelven un conjunto claro de resultados.
* **Precisión** : En la RD, los resultados son muy precisos, ya que la consulta busca datos específicos que coinciden exactamente con los criterios de la consulta.
* **Ejemplos** : Sistemas de bases de datos relacionales, sistemas de gestión de bases de datos (DBMS), consultas SQL.

### Diferencias Clave entre Recuperación de Información y Recuperación de Datos:

| **Aspecto**       | **Recuperación de Información (RI)**                             | **Recuperación de Datos (RD)**                                                  |
| ----------------------- | ------------------------------------------------------------------------ | -------------------------------------------------------------------------------------- |
| **Tipo de Datos** | Datos no estructurados (texto, imágenes, videos, etc.)                  | Datos estructurados (tablas, filas, columnas)                                          |
| **Objetivo**      | Encontrar la información más relevante a una consulta.                 | Obtener datos exactos y específicos según los criterios dados.                       |
| **Consulta**      | Generalmente en lenguaje natural o palabras clave.                       | Consultas estructuradas (como SQL).                                                    |
| **Precisión**    | Los resultados no siempre son exactos, se mide la relevancia.            | Los resultados son exactos y precisos.                                                 |
| **Ejemplos**      | Motores de búsqueda web, sistemas de recomendación.                    | Sistemas de bases de datos, consultas SQL.                                             |
| **Procesamiento** | Procesamiento semántico, análisis de relevancia, indexación.          | Filtrado y búsqueda de datos mediante claves primarias o índices.                    |
| **Contexto**      | Generalmente se usa en contextos como búsqueda de documentos, web, etc. | Se usa en contextos donde se necesita obtener datos específicos de una base de datos. |

Un modelo de recuperacion de informacion es un cuadruplo [D,Q,F,R($q_i$, $d_j$) donde:

- D es un conjunto de representaciones logicas de los datos de la coleccion.
- Q es un conjunto compuesto por representaciones logicas de las necesidades del usuario, denominadas “consultas”.
- F es un framework para modelar las representaciones de los datos, consultas y sus relaciones.
- R es una funcion de ranking que asocia un numero real a una consulta  q ∈ Q y un documento
  d ∈ D. La evaluacion de esta funcion establece un cierto orden entre la informacion de acuerdo a la consulta

## Tipos basicos de SRI

- Clasico
  - Booleano
    - Difuso : Mas sencillo de todos (la presencia o no de las palabras)
    - Extendido: en lugar de considerar solo 0 y 1 en los vectores considera la frecuencia con que aparecen un termino en un documento
  - Vectorial
    - Generalizado
    - Semantica Latente
    - Redes Neuronales
  - Probabilisticos:
    - Redes de Inferencia
    - Redes de Creencia
- Estructurado
  - Listas no Solapadas
  - Nodos Proximales

## Arquitectura generica de un SRI

- Modulo de gestion de documentos:
  - Parsear los documentos que forman la coleccion para extraer informacion de ellos
  - Acceder a los documentos o a la informacion asociada a estos
- Modulo de operaciones de texto:
  - tranformar el documento original en una representacion del mismo
  - transformar la query original en una representacion de la misma
- Modulo de indexacion:
  - Construir indices sobre los documentos
  - Los recursos de tiempo y espacio que conllevan la creacion de indices se amortizan en la recuperacion
- Modulo de operaciones de queries:
  - Expansion de terminos de representacion de la query (sinonimos, parlabras relacionadas uso de WordNet)
  - Eliminacion de terminos
- Modulo de busqueda:
  - Busca en los indices para lograr matchings entre las representaciones de los documentos y la query
- Modulo de ranking
  - Ordena los documentos recuperados de acuerdo con la relevancia respecto a la query
  - A veces tambien se cierra el ciclo aqui con relevance feedback

# Conferencia #2 : Analisis Modelos Clasicos RI

#### Modelo Boolenao de RI

- Basada en la Teoria de Conjuntos y el Algebra Booleana
- Solo considera si los terminos indexados se encuentran o no en el documento, siendo $w_{ij} \in \{0,1\}$
- Una consulta est formada por los conectores : not , and, or.
- Una consulta q es una expresion booleana convencional
- Se define la funcion de similitud : $sim (d_j,q)$ =1 si el documento tiene todas las palabras de la query

D: Conjunto de terminos indexados

Q: Expresion booleana sobre los terminos indexados, utilizando los operadores : not , and, or

F: Algebra booleana sobre conjunto de terminos y conjunto de documentos

R: $sim(d_j,q) \in \{0,1\}$

##### Ventajas

- Modelo simple basado en conjuntos
- Facil de comprender e implementar
- Consultas con precision sintactica

##### Desventajas

- No tiene nocion de orden o ranking
- Solo recupera documentos donde la coincidencia es exacta
- Puede considerarse como un modelo de recuperacion de datos por presentar correspondencia exacta
- El lenguaje de consulta puede ser complejo para usuarios inexpertos
- Recupera muchos o pocos documentos
- Todos los terminos son igual de importantes

#### Modelo Vectorial de RI

- Aprovecha el Algebra Vectorial para definir relaciones de semejanzas entre las representaciones vectoriales de los datos
- La consulta se define en lenguaje natural
- $$
  w_{ij} \in \real , w_{ij} \geq 0
  $$
- La consulta y cada docuemnto se representan por un vector numerico de pesos
- Un termino que aparece en muchos documentos no debe ser mas importantes que otro que aparece en pocos documentos
- Un documento con mucha ocurrencia de un termino no debe considerarse menos importante que un documento con pocas ocurrencias de ese termino
- Se utiliza la funcion de similitud coseno para establecer la similitud entre un docuemnto y la consulta

$$
cos(\theta) = sim (d_j,q) = \frac{d_j * q}{|d_j|*|q|}
$$

- $$
  tf_{i,j} = \frac{freq_{i,j}}{max_i freq_{i,j}} = \alpha +(1-\alpha)*\frac{freq_{i,j}}{max_ifreq_{i,j}}
  $$

donde $freq_{i,j}$ es la frecuencia del termino $t_i$ en el documento $d_j$. $max_i freq_{i,j}$ mayor frecuencia de todos los terminos de $d_j$

$\alpha$ ($\alpha \in [0,1]$\) termino de suavizado y permite amortiguar la contribucion de la frecuencia del termino. Los valores mas usados son 0,4 y 0,5

Si el termino $t_i$ no esta en un docuemnto  $d_j$ entonces $tf_{i,j}=0$

$$
idf_i= log \frac{N}{n_i}
$$

mide la frecuencia de ocurrencia de un termino dentro del conjunto de datos donde:

N es la cantidad de documentos dentro del corpus

$n_i$ es la cantidad de documentos en los que aparece el termino t_i

$$
w_{i,j} = tf_{i,j} * idf_{i}
$$

##### Formal:

D: Vectores de pesos no binarios asociado a los terminos de los documentos

Q: Vectores de pesos no binarios asociados a los terminos de consulta

F : Espacio n-dimensional y operaciones entre vectores del Algebra Lineal

R: $sim(d_j,q) = cos(\theta)$

##### Ventajas

- Permite ordenar los documentos segun el grado de similitud con la consulta.
- La estrategia de coincidenciaa parcial permite la recuperacion de documentos que se aproximen a los requerimientos de la consulta.
- El esquema de ponderacion mejora el rendimiento de la recuperacion de los documentos.

##### Desventajas

- Asume que los terminos indexados son mutuamente independientes.

#### Modelo Probabilistico de RI

- Modelo intenta calcular la probabilidad en el que un docuemnto sea relevante para una consulta realizada
- Existe un subconjunto de todos los datos que el usuario prefiere como respuesta a la consulta y el modelo debe maximizar la relevancia de la informacion esperada por el usuario
- $$
  sim(d_j,q) = O(R|d_j)= \frac{p(d_j\ \text{sea relevante})}{p(d_j\  \text{no sea relevante} )}
  $$

donde R es la relevancia del documento con respecto a la consulta

Para poder computar la razon se usa:

- El principio del Ranking Probabilistico
- Teorema de Bayes $p(A|B) = \frac{p(B|A)p(A)}{p(B)}$
- la informacion de ocurrencia de los terminos de la consulta en el documento

$$
sim(d_j*q) = \sum_{i}^{n} w_{i,q}*w_{i,j}*(log \frac{p(t_i|R)}{1-p(t_i|R)} + log\frac{1-p(t|\hat{R})}{p(t_i|\hat{R})})
$$

donde $p(t_i|R)= 0.5\ \text{y} \ p(t_i|\hat{R})=\frac{n_i}{N} $

##### Formalidad

D: Vectores de pesos binarios asociados a los terminos de los documentos

Q: vectores de pesos binarios asociados a los terminos de la consulta

F: Teoria de Probabilidades

R: $sim(d_j,q) = O(R|d_j)= \frac{p(d_j\ \text{sea relevante})}{p(d_j\  \text{no sea relevante} )}$

##### Ventajas

- Permite obtener un ranking entre los documentos recuperados

##### Desventajas

- El peso de los terminos es binario por lo que se considera la frecuencia de ocurrencias de los mismos
- Se asume independencia entre los terminos
- Es necesario encontrar un primer conjunto de documentos relevantes para los valores particualres de $p(t_i|R) $ y $p(t_i|\hat{R})$
- $$


  $$

## Conferencia #3 : evaluacion y retroalimentacion

### Matriz de confusion

Herramienta intuitiva para medir el rendimiento de un clasficador

|                | Relevantes          | No relevantes       |
| -------------- | ------------------- | ------------------- |
| Recuperados    | True Positive (RR)  | False Positive (RI) |
| No recuperados | False Negative (NR) | True Negative (NI)  |

### Medidas objetivas:

- **Precision**: que tan relevante son los documentos recuperados (documentos recuperados relevantes sobre el total de documentos de recuperados, mientras mayor sea mas precisos) $P= \frac{|RR|}{|RR \cup RI|}$
- **Recobrado** : que tanto del total de documentos relevantes fueron recuperados $R= \frac{|RR|}{|RR \cup NR|}$
- Se prioriza obtener un alto valor de **Recobrado** tolerando una pequenna cnatidad de falsos positivos (RI)
- **F**: balance entre precision y recobrado $F1= \frac{(1+ \beta^2)PR}{\beta^2P + R}$

donde P es (Precision) y R es (Recobrado):

$$
\beta =1\ \text {igual peso o enfasis para la Precision y el recobrado}
\\
\beta >1\ \text{Mayor peso o importancia a la precision}
\\
\beta <1\ \text{Mayor peso o importancia al recobrado}
$$

en un caso especial de la medida F cuando $\beta =1$ (llamado **F1 Score**). es una medida toma alto valor cuando al precision y el recobrado son altos, lo que puede interpretarse como un esfuerzo por encontrar el mejor compromiso entre Precision y Recobrado.

> #### Dificutald con la precision y el recobrado
>
> - los documentos irrelevantes no son tenidos en cuenta
> - la P se indefine cuando no se recupera informacion
> - el R se indefine cuando no hay informacion relevante
> - se necesita un juicio experto tanto para aplicar las medidas e interpretarlas como para crear las colecciones de prueba
> - Evaluar el sistema requiere un gran conjunto de consultas y aun asi, no se garantiza el rendimiento del sistema si las metricas arrojaron buenos resultados
> - no toman en cuenta el orden de los resultados que satisfacen la consulta

- **R- Precision:** Calcula la precision hasta la posicion k del ranking $R-Precision_k$
- **Proporcion de fallo:** toma en cuenta la cantidad de informacion irrelevante en ranking con respecto al total de irrelevantes $Fallout_k= \frac{\text{cantidad de datos irrelevantes en los primeros k}}{\text{total de datos irrelevantes}}$
- **Rango Reciproco Medio (MRR)**: Mide la eficiencia de un sistema al considerarla posicion del primer resultado relevante para una lista de consultas $MRR = \frac{1}{|Q|} \sum_{i=1}^{|Q|} \frac{1}{rango_i}$ donde:
  - Q es conjunto de consultas
  - $rango_i$ posicion del primer resultado relevate de la i-esima consulta
  - La notacion $MRR@k$ significa que solo se considera los primers k elementos de la respuesta de la consulta durante el calculo de la metrica
- Ganancia Acumulada Descontada Normalizada (NDCG): Evalua que tan bien un sistema ordena los resultados relevantes, dando mas peso a los que aparece  en primeras posiciones y normalizando contra un ranking ideal
  - Ganancia acumulada descontada: $DCG@k = \sum_{i=1}^k \frac{rel_i}{log_{2}(i+1)}$ donde $rel_i$ es la relevancia del elemento en posicion i
  - Ganancia acumulada descontada ideal: $IDCG@k = \sum_{i=1}^k \frac{rel_i ^ {ideal}}{log_{2}(i+1)}$
  - DCG normalizado: $NDCG@k = \frac{DCG@k}{IDCG@k}$
  - Si el NDCG =1 entonces los elemtnos estan ordenados perfectamente por al relevancia esperada
  - Si el NDCG =0 entonces los elementos recuperados (top k ) no son relevantes
  - Sino $NDCG \in (0,1)$mientras mas alto es el mejor valor sera el sistema

### Medidas subjetivas de evaluacion

- Proporcion de novedad: Proporcion entre la informacion recuperada desconocida por el usuario y la informacion relevante recuperada
- Proporcion de cobertura: Proporcion sobre la cantidad de informacion recuperada relevante conocida por el usuario y la cantidad de informacion relevante desconocida por el usuario
- Esfeurezo del usuario: Trabajo requerido por el usuario en la formulacion de consultas, guiado por la busqueda y la visualizacion del resultado
- Tiempo de respuesta: Intervalo de tiempo entre las especficacion de la consulta , guiado por la busqueda y la visualizacion del resultado
- Forma de presentacion: Formato de presentacion de los resultados

### Retroalimentacion

Mecanismo en que cierta proporcion de la salida de un sistema se redirige a la entrada para controlar su comportamiento.

#### Retroalimentacion en el MRI Vectorial

**Idea**: Encontrar un vector consulta q que maximice la similitud con la informacion relevante y minimice la similitud con la informacion no relevante.

**Consideracion**: Los vectores relevantes a una consulta son similares y tienen una diferencia notable con respecto a los no relevantes.

Si se tiene que :

1. $C_r$ es el conjunto de informacion relevante
2. $C_{nr}$ es el conjunto de informacion no relevante

Entonces:

    $q_{opt} = argmax(sim(q,C_r) - sim(q,C_{nr}))$

Utilizanod la distancia coseno entre los vetores de la consulta y los datos , queda:

$$
q_{opt}= \frac{1}{|C_r|} \sum_{d_j \in C_r} d_j - \frac{1}{|C_{nr}|}\sum_{d_j \in C_{nr}}d_j
$$

> Intuitivamente es el vector diferecnia entre los centroides de los datos relevantes y los no relevantes.
>
> * El **centroide de los documentos relevantes** es el vector promedio de todos los vectores relevantes.
> * El **centroide de los documentos no relevantes** es el promedio de los vectores no relevantes.
>
> Es decir,  **⃗q_opt apunta en dirección hacia los documentos relevantes y se aleja de los no relevantes** . Esa es la intuición: el sistema intenta "mover" la consulta hacia la región del espacio vectorial donde están los documentos buenos y alejarse de los malos.

##### Algoritmo de Rocchio

Se parte de que dada una consulta solo se conoce parcialmente el conjunto de los datos relevantes (factor $\beta$) y los no relevantes (factor $\gamma$).

Se tenia que $q_{opt-mod} = \alpha q + \frac{\beta}{|C_r|}\sum_{d_j \in C_r} d_j - \frac{\gamma}{|C_{nr}|}\sum_{d_j \in C_{nr}}d_j$

#### Retroalimentacion en el MRI Probabilistico

Estima la probabilidad de que un documento sea relevante para una consulta. Se usa la rzon de verosimilitud:

Cuando el usuario  **marca algunos documentos como relevantes** , se puede usar esa información para mejorar la estimación de las probabilidades p($t_i$∣R) y p($t_i$∣¬R). Se estiman como:

$$
p(t_i|R) = \frac{|VR_{t_i}|}{|VR|}
$$

$$
p(t_i| \hat{R}) = \frac{df_{t_i}- |VR_{t_i}|}{N-|VR|}
$$

N : tamano del conjunto de datos
$df_{t_i}$: cantidad de datos que contienen al termino $t_i$
VR : conjunto de datos relevantes conocidos
$VR_{t_i}$: subconjunto de VR que contienen al termino $t_i$

#### Ventajas

- automatiza el proceso de mejorar la seleccion de la informacion relevante
- aumenta la precision y el recobrado

#### Desventajas

- Pocos usuarios pasan a la segunda vista de los datos paginados, por lo que noes comun su interes en participar en la retroalimnetacion
- Es complicado entender por los usuario la importancia de la retroalimentacion
- Las consultas generadas por los algoritmos de retroalimentacion son muy grandes e ineficientes para los algoritmos de recuperacion

### Matriz de coocurrencia

Es una matriz cuadrada y simetrica que cuenta cuantas veces coocurren dos terminos (es decir, aparecen cerca uno del otro). Sirve para detectar relaciones implicitas entre palabras y sugerir terminos relacionados para expandir la consulta.

* La expansión de consulta **ayuda a superar el problema del vocabulario** (sinónimos, formas distintas).
* El análisis local (como la matriz de coocurrencia) **explota la información ya indexada** sin depender de fuentes externas.

## Conferencia #4 : Introduccion a la representacion del conocimiento

### TIpos de conocimientos

#### 📘 1. Conocimiento Declarativo

* **¿Qué es?** Saber *qué* es algo.
* **En qué consiste:** Hechos, definiciones y datos.
* **Ejemplos:**
  * París es la capital de Francia.
  * El agua es H₂O.
  * Un triángulo tiene tres lados.

---

#### 🧩 2. Conocimiento Estructural

* **¿Qué es?** Saber *cómo se relacionan* las cosas.
* **En qué consiste:** Relaciones jerárquicas, de pertenencia o agrupación.
* **Ejemplos:**
  * Un CPU es parte de una computadora.
  * Los perros son mamíferos.

---

#### ⚙️ 3. Conocimiento Procesal

* **¿Qué es?** Saber *cómo hacer* algo.
* **En qué consiste:** Instrucciones, estrategias y reglas de acción.
* **Ejemplos:**
  * Para hervir agua, caliéntala a 100 °C.
  * Si llueve, lleva paraguas.
  * Para resolver ∫x²dx, aplica la regla de las potencias.

---

#### 🧠 4. Metaconocimiento

* **¿Qué es?** Saber  *lo que ya sabes* .
* **En qué consiste:** Conocimiento sobre el propio conocimiento (autorreflexión).
* **Ejemplos:**
  * Sé que domino las reglas gramaticales.
  * Las analogías ayudan a explicar conceptos difíciles.

---

#### 💡 5. Conocimiento Heurístico

* **¿Qué es?** Saber  *por experiencia* .
* **En qué consiste:** Reglas prácticas que funcionan en muchos casos (pero no siempre garantizadas).
* **Ejemplos:**
  * Si alguien tiene fiebre y tos, podría tener gripe.
  * Reiniciar el router suele arreglar fallos de conexión.
  * Usar colores contrastantes mejora la legibilidad

## Conferencia #5 :Fundamentos de la representacion semantica

### Formas de representar las palabras

- One-Hot : Es una forma de convertir **categorías** (como colores, nombres, países, etc.) en **números binarios** que las computadoras pueden procesar.
- Bolsa de palabras (BoW, Bag of Word): Representa un texto como un vector de conteo de palabras. Caputa la frecuencia de las palabras para representar su importancia. Cada docuemnto es un vector con la frecuencia de sus palabras en el mismo.
- TF - IDF: Representar un texto como un vector . Se construye a partir de la frecuencia de las palabras dentro del corpus.

#### Desventajas:

- ASumen independencia entre los terminos
- NO captura relaciones semanticas entre palabras
- Alta dimnesionalidad y dspersion
- Perdida del orden de las palabras

### Otras formas de representar para captura las relaciones

- N-gramas: tecnica que implica dividir el texto en secuencias contiguas de N palabras
- Embeddings: Un **embedding** es un **vector denso** de números reales (por ejemplo, de dimensión 50, 100, 300…), entrenado para capturar **relaciones semánticas** y **contexto** entre palabras.

#### Modelos estaticos de embeddings

| Método      | Ventajas                          | Limitaciones               |
| ------------ | --------------------------------- | -------------------------- |
| Word2Vec     | Captura relaciones semánticas    | Ignora subpalabras         |
| GloVe        | Combina estadísticas globales    | Menos eficiente en memoria |
| FastText     | Maneja palabras OOV (subpalabras) | Más lento que Word2Vec    |
| TF-IDF + PCA | Simple para documentos            | No captura semántica fina |
| SVD / LSA    | Basado en álgebra lineal         | Sensible al ruido          |

#### Modelos contextuales

| Método        | Direccionalidad                      | Uso típico          | Función |
| -------------- | ------------------------------------ | -------------------- | -------- |
| BERT (Encoder) | Bidireccional (contexto completo)    | Clasificación, NER  | Entender |
| GPT (Decoder)  | Unidireccional (izquierda a derecha) | Generación de texto | Generar  |

#### Representaciones vectoriales en NLP

##### Modelo Basado en Frecuencia (Esparcido)

- Fundamentados en estadisticas co-ocurrencia
- Representacion explicita en espacios de alta dimensionalidad
- Cada dimension corresponde a un elemento linguistico (palabra, documento,etc)
- Ejemplo: TF-IDF, bolsa de palabras , matriz de co-ocurrencia

##### Modelo de Embeddings(Denso)

- Aprendizaje automatico de representaciones distribuidas
- Espacio vectoriales continuos de baja dimensionalidad
- Capturan relaciones semanticas y sintacticas implicitas
- Valores continuos aprendidos
- Ejemplo: Word2vec, GloVe, BERT

#### OWL ( Web Ontology Language)

- Lenguaje estandar del W3C disennado para definir ontologias complejas dentro del contexto de la web semantica
- Que es web semantica ? es una extension de la web actual que busca darle sgnfiicado a la infromacion en la web, de manera que pueda ser comprendida por las maquinas
- OWL permite modelar jerarquias de clases y propiedades. Annadir restricciones logicas como la cardinalidad , habilitar razonamineto automatico.
- Se basa en XML y RDF

#### RDF (Resource Description Framework)

- Modelo para representar informacion estructurada sobre recursos de la web
- Es un estandar del W3C para describir datos de amnera que puedan ser entendidos por maquinas
- Permite describir recursos usando tripletas (Sujero, Predicado y Objeto)

  ```bash
  <http://ejemplo.org/Persona/Juan> <http://ejemplo.org/tieneEdad> "30"
  ```

Esto signifca " Juan tiene edad 30"


#### SPARQL (SPARQL Protocol And RDF Query Language)

- Lenguaje estandar del W3C disennado para consultar y manipular datos representados en RDF (Resource Description Framework) que es el modelo de datos base del Web Semantica
- Es el equivalente de SQL para bases de datos relacionales pero aplicados a grafos RDF. En lugar de usar tablas , SPARQL trabaja con tripletas(sujeto, predicado y objeto) que forman grafos de conocimiento

  ```sql
  SELECT ?nombre
  WHERE {
    ?persona rdf:type ex:Profesor .
    ?persona ex:nombre ?nombre .
  }

  ```

(selecciona los nombres de todas las personas que son del tipo Profesor)

```sql_more
PREFIX ex: <http://example.org/>
SELECT ?persona ?lugar
WHERE {
?persona ex:naci´oEn ?lugar.
FILTER(?lugar = ex:Alemania)
}

```


#### Que es un sistema de conocimiento semantico?

- Es un sistema que representa y razona sobre informacion de manera estrcuturada y logica, usando ontologias (OWL), vocabularios (RDFS) , datos estrcuturados (RDF) y consultas inteligentes (SPARQL)
- RDF es la base de datos semantica: Modela los datos en forma de tripletas `<sujeto> <predicado> <objeto>` permitiendo describir recursos y sus relaciones
- RDFS vocabulario basico: Define clases, subcalses , propiedades y jerarquias
- OWL , ontologias y logicas : amlia RDFS con restricciones logicas e inferencias complejas como cardinalidad, propiedades , equivalencias y disyunciones
- SPARQL es el lengauje de consultas: Se usa para consutlar grafos RDF , incluyendo lo que se infirio en OWL

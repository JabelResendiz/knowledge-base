from typing import List
import json

class Pelicula:
    def __init__(
        self,
        titulo: str,
        pais: List[str],
        fecha: str,
        director: str,
        genero: List[str],
        actores_principales: List[str],
        imdb: float
    ):
        self.titulo = titulo
        self.pais = pais
        self.fecha = fecha
        self.director = director
        self.genero = genero
        self.actores_principales = actores_principales
        self.imdb = imdb

    def __repr__(self):
        return (
            f"\nFILM(\n  titulo={self.titulo!r},\n  pais={self.pais!r},\n  fecha={self.fecha!r},"
            f"\n  director={self.director!r},\n  genero={self.genero!r},"
            f"\n  actores_principales={self.actores_principales!r},\n  imdb={self.imdb!r})"
        )

def generador_peliculas(ruta_archivo):
  with open(ruta_archivo, 'r', encoding='utf-8') as f:
      objetos = json.load(f)
      for item in objetos:
          yield Pelicula(
              titulo=item['titulo'],
              pais=item['pais'],
              fecha=item['fecha'],
              director=item['director'],
              genero=item['genero'],
              actores_principales=item['actores_principales'],
              imdb=item['imdb']
          )

def Where(fuente, filtro):
  for x in fuente:
    if filtro(x): yield x

ruta = 'C:\\Users\\mkm\\Documents\\LP\\Curso LP 2025\\Projects 2025\\Conf_08 ProgFuncional\\MK Films.json'
films = generador_peliculas(ruta)
print("FILMS")
for f in films:
  print(f)

films = generador_peliculas(ruta)
print("\nBEST FILMS")
for f in Where(films, lambda f: f.imdb >=9):
  print(f)

films = generador_peliculas(ruta)
print("\nFILMS con Brad Pitt")
for f in Where(films, lambda f: "Brad Pitt" in f.actores_principales):
  print(f)

  #IMPLEMENTE UN METODO GROUP BY EN PYTHON
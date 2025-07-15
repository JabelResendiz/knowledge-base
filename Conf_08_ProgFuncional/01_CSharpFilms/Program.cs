namespace LP
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Runtime.ConstrainedExecution;
  using System.Text.Json;
  using System.Text.Json.Serialization;

  public class Film
  {
    public string titulo { get; set; }
    public List<string> pais { get; set; }
    public string fecha { get; set; }
    public string director { get; set; }

    public List<string> genero { get; set; }

    [JsonPropertyName("actores_principales")] 
    //Podemos poner esta propiedad si queremos cambiar el nombre
    //que tiene en el archivo Json matchee con el nombre
    //que le damos a la propiedad a continuación (Actores) en este caso
    public List<string> Actores { get; set; }
    public double imdb { get; set; }

    public override string ToString()
    {
      return $"Título: {titulo}\nFecha: {fecha}\nPais(es): {string.Join(", ",pais)}\nDirector: {director}\n" +
             $"Género(s): {string.Join(",",genero)}\nActores principales: {string.Join(",",Actores)}\nIMDb: {imdb}";
    }
  }

  class Program
  {
    static void Main()
    {
      string rutaArchivo = "C:\\Users\\mkm\\Documents\\LP\\Curso LP 2025\\Projects 2025\\Conf_08 ProgFuncional\\MK Films.json"; // Cambia esta ruta al archivo JSON correcto

      try
      {
        string jsonString = File.ReadAllText(rutaArchivo);

        List<Film> films = JsonSerializer.Deserialize<List<Film>>(jsonString);

        Console.WriteLine("FILMS");
        foreach (var f in films)
        {
          Console.WriteLine(f);
          Console.WriteLine(new string('-', 40));
        }

        var bestFilms = films.Where((f) => f.imdb >=9);
        Console.WriteLine("\nBEST FILMS");
        foreach (var f in bestFilms)
        {
          Console.WriteLine(f);
          Console.WriteLine(new string('-', 40));
        }

        var withClintEastwood = films.Where((f) => f.director == "Clint Eastwood" || 
                                                   f.Actores.Contains("Clint Eastwood"));
        Console.WriteLine("\nCLINT EASTWOOD FILMS");
        foreach (var f in withClintEastwood)
        {
          Console.WriteLine(f);
          Console.WriteLine(new string('-', 40));
        }

        #region GROUP BY DIRECTOR
        //Implementar un método GroupBy
        var filmsByDirector = films.GroupBy((f) => f.director);
        foreach (var g in filmsByDirector)
        {
          Console.WriteLine($"\n{g.Key.ToUpper()}");
          foreach (var f in g)
            Console.WriteLine($"  {f.titulo}");
        }
        #endregion

      }


      catch (Exception ex)
      {
        Console.WriteLine($"Error leyendo o deserializando el archivo JSON: {ex.Message}");
      }
    }
  }
}

/* PROGRAMAR MAS ADELANTE LA VERSION CON ASYNC
 * using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

public class Film
{
    public string Titulo { get; set; }
    public List<string> Pais { get; set; }
    public string Fecha { get; set; }
    public List<string> Director { get; set; }
    public List<string> Genero { get; set; }
    public List<string> ActoresPrincipales { get; set; }
    public double Imdb { get; set; }
}

class Program
{
    static async Task Main()
    {
        string rutaArchivo = "MK Films.json";

        await foreach (var film in LeerPeliculasAsync(rutaArchivo))
        {
            Console.WriteLine($"Título: {film.Titulo}, IMDb: {film.Imdb}");
        }
    }

    public static async IAsyncEnumerable<Film> LeerPeliculasAsync(string rutaArchivo)
    {
        using FileStream stream = File.OpenRead(rutaArchivo);

        // Deserializa el JSON (array) en streaming como IAsyncEnumerable<Film>
        await foreach (var film in JsonSerializer.DeserializeAsyncEnumerable<Film>(stream))
        {
            if (film != null)
                yield return film;
        }
    }
}
Puntos clave
La función que usa await foreach debe ser async y devolver Task o IAsyncEnumerable<T>.

DeserializeAsyncEnumerable<T>(Stream) devuelve un IAsyncEnumerable<T>.

Se puede consumir con await foreach dentro de métodos async.

En el ejemplo, LeerPeliculasAsync es un método async IAsyncEnumerable<Film> que abre el archivo y devuelve cada película deserializada.

Main es async Task Main() para poder usar await y await foreach.

Resumen
Función que usa await	Debe ser
async	Sí
Retorno	Task, Task<T>, o IAsyncEnumerable<T>

*/
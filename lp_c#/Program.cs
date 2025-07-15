
// using Genericidad;


// Animal[] patos = new Pato[3];
// Animal[] leones = new Leon[3];

// //patos[2] = new Leon(); 
// // error en tiempo de ejecucion , porque cuando en tiempo de ejecucion se realiza el chequeo en realidad patos[0] es de tipo Pato , no acepta Animal
// // pero el compilador lo deja pasar porque se tipo que era de tipo Animal , primero

// // Animal pato = new Pato();

// // pato.Accion();


// public class Animal
// {

//     public void Accion()
//     {
//         Console.WriteLine("no hace nada");
//     }

// }


// public class Pato : Animal
// {

//     public void Accion()
//     {
//         Console.WriteLine("Cuac, cuac");
//     }


//     public void Graznar()
//     {
//         Console.WriteLine("graznar graznar");
//     }
// }


// public class Leon : Animal
// {
//     public void Accion()
//     {
//         Console.WriteLine("Roar,roar");
//     }


// }



using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Genericidad;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string rutaArchivo = "C:\\Users\\HP\\Documents\\Github\\REST_API_CLIENT\\privated\\lp_c#\\MK_Films.json";
            string jsonString = File.ReadAllText(rutaArchivo);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<Film> films = JsonSerializer.Deserialize<List<Film>>(jsonString, options);

            Agrupar<string, Film> filmsAgrupados = new Agrupar<string, Film>(films);
            var filmsByDirector = filmsAgrupados.GroupBy((f) => f.director);

            foreach (var g in filmsByDirector)
            {
                Console.WriteLine($"\nDirector: {g.Key}");
                foreach (var f in g)
                {
                    Console.WriteLine($"- {f.titulo}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

public class Film
{
    public string titulo { get; set; }
    public List<string> pais { get; set; }
    public string fecha { get; set; }
    public string director { get; set; }
    public List<string> genero { get; set; }

    [JsonPropertyName("actores_principales")]
    public List<string> Actores { get; set; }
    public double imdb { get; set; }

    public override string ToString()
    {
        return $"Título: {titulo}\nFecha: {fecha}\nPais(es): {string.Join(", ", pais)}\nDirector: {director}\n" +
               $"Género(s): {string.Join(", ", genero)}\nActores principales: {string.Join(", ", Actores)}\nIMDb: {imdb}";
    }
}

public interface IAgruparPor<T, R>
{
    T Key { get; }
    IEnumerable<R> Values { get; }
}

public class Agrupar<T, R>
{
    public List<R> List { get; }

    public Agrupar(List<R> list)
    {
        List = list ?? throw new ArgumentNullException(nameof(list));
    }

    public IEnumerable<IGrouping<T, R>> GroupBy(Func<R, T> keySelector)
    {
        return List.GroupBy(keySelector);
    }
}



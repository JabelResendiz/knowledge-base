// namespace Genericidad;


// string rutaArchivo = "C:\\Users\\HP\\Documents\\Github\\REST_API_CLIENT\\privated\\lp_c#\\MK_Films.json"; // Cambia esta ruta al archivo JSON correcto

// string jsonString = File.ReadAllText(rutaArchivo);

// List<Film> films = JsonSerializer.Deserialize<List<Film>>(jsonString);


// Console.WriteLine("FILMS");

// foreach (var f in films)
// {
//     Console.WriteLine(f);
//     Console.WriteLine(new string('-', 40));
// }


// Agrupar<string,Film> filmsAgrupados = new Agrupar<string, Film>(films);

// var filmsByDirector = filmsAgrupados.groupBy((f) => f.director);

// for(var g in filmsByDirector)
// {
//     Console.WriteLine(g.clave);

//     for(var f in g.values)
//     {
//         Console.WriteLine(f.titulo);
//     }
// }


// public class Film
// {
//     public string titulo { get; set; }
//     public List<string> pais { get; set; }
//     public string fecha { get; set; }
//     public string director { get; set; }

//     public List<string> genero { get; set; }

//     [JsonPropertyName("actores_principales")]
//     //Podemos poner esta propiedad si queremos cambiar el nombre
//     //que tiene en el archivo Json matchee con el nombre
//     //que le damos a la propiedad a continuación (Actores) en este caso
//     public List<string> Actores { get; set; }
//     public double imdb { get; set; }

//     public override string ToString()
//     {
//         return $"Título: {titulo}\nFecha: {fecha}\nPais(es): {string.Join(", ", pais)}\nDirector: {director}\n" +
//                $"Género(s): {string.Join(",", genero)}\nActores principales: {string.Join(",", Actores)}\nIMDb: {imdb}";
//     }
// }



// public interface IAgruparPor<T, R>
// {
//     T clave;
//     IEnumerable<R> values;
// }


// public class Agrupar<T, R> 
// {
//     public List<R> list;
    
//     public Agrupar(List<R> list) {this.list = list;}
//     public IEnumerable<IAgruparPor<T, R>> groupBy(Function<R,T> func)
//     {
//         // func: obtengo un filme devuelvo un string 
//         // debo despues agrupar 

//         return list.GroupBy(func);
//     }
// }




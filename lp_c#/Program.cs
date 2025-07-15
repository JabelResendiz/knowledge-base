
Animal[] patos = new Pato[3];
Animal[] leones = new Leon[3];

//patos[2] = new Leon(); 
// error en tiempo de ejecucion , porque cuando en tiempo de ejecucion se realiza el chequeo en realidad patos[0] es de tipo Pato , no acepta Animal
// pero el compilador lo deja pasar porque se tipo que era de tipo Animal , primero

Animal pato = new Pato();

pato.Accion();


static (int min, int max) MinMax(int[] a)
{
    if (a == null) throw new ArgumentNullException("Parametro null");
    else if (a.Length == 0) throw new ArgumentException("Array vacío");
    else
    {
        (int min, int max) result = (a[0], a[0]);
        for (int i = 1; i < a.Length; i++)
        {
            if (a[i] <= result.min) result.min = a[i];
            else if (a[i] >= result.max) result.max = a[i];
        }
        return result;
    }
}

var elems = new int[] { 100, 50, 120, 70, 200 };
var r = MinMax(elems);
Console.WriteLine($"Minimo {r.min} Maximo {r.max}");
var r_original = r; // se coppia no apunta a la misma ubicacion
Console.WriteLine($"r {r} y r_original {r_original}");
r.max = 1000;
//Se puede "cambiar" una componente del tuplo, lo que hace es crear otro tuplo
Console.WriteLine($"r cambiado {r}");
Console.WriteLine($"el r original {r_original}");
//Console.WriteLine(r[1]); //No se puede indizar una componente de un tuplo
r.Item1 = -1000;
//Me puedo referir a las componentes de forma directa por su posición
//Pero empiezan en Item1
Console.WriteLine($"({r.Item1},{r.Item2})");





public class Animal
{

    public void Accion()
    {
        Console.WriteLine("no hace nada");
    }

}


public class Pato : Animal
{

    public void Accion()
    {
        Console.WriteLine("Cuac, cuac");
    }


    public void Graznar()
    {
        Console.WriteLine("graznar graznar");
    }
}


public class Leon : Animal
{
    public void Accion()
    {
        Console.WriteLine("Roar,roar");
    }


}
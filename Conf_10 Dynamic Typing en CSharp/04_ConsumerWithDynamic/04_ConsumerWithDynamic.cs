using LP;

namespace LP
{
  internal class ConsumerWithDynamic
  {
    static void Main(string[] args)
    {
      var productor = new ObjectProductor();
      while (true)
      {
        //Cdo programamos esto conocíamos la existencia de 
        //de la interface IM y de las clases A y B
        dynamic d = productor.ProduceObject();
        Console.WriteLine($"Soy de tipo {d.GetType()}");
        try
        {
          d.M();
        }
        catch
        {
          Console.WriteLine($"No tengo método M");
        }
        try
        {
          d.F();
        }
        catch
        {
          Console.WriteLine($"No tengo método F");
        }
        try
        {
          string s = d.ToUpper();
          Console.WriteLine($"Soy string {d} y en mayúscula soy {s}");
        }
        catch
        {
          Console.WriteLine($"No me puedes aplicar ToUpper()");
        }
        try
        {
          int k = d * 2;
          Console.WriteLine($"Soy {d} multiplicado por 2 soy {k}");
        }
        catch
        {
          Console.WriteLine($"No me puedes multiplicar por 2");
        }
        try
        {
          int n = 10;
          int square = d(n);
          Console.WriteLine($"Soy de tipo (int x) => x*x aplicado a {n} soy {square}");
        }
        catch
        {
          Console.WriteLine($"No me puedes invocar como función");
        }
        Console.ReadLine();
      };
    }
  }
}
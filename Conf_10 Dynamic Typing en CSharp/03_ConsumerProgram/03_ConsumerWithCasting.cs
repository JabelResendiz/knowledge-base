namespace LP
{
    internal class ConsumerWithCasting
    {
      static void Main(string[] args)
      {
        var productor = new ObjectProductor();
        while (true)
        {
          //Cdo programamos esto conocíamos la existencia de 
          //de la interface IM y de las clases A y B
          object x = productor.ProduceObject();
          if (x is IM) ((IM)x).M();
          //Sabemos los otros tipos que pueden ser
          else if (x is M3) ((M3)x).M();
          else if (x is M4) ((M4)x).M();
          //else 
          else
          {
            bool tieneM = false;
            //Investigar por reflection si es de un tipo que tiene un método M
            foreach (var m in x.GetType().GetMethods())
            {
              if (m.Name == "M")
              {
                m.Invoke(x, null); //si M tuviese parámetros en lugar de null tendríamos que poner un array con los parámetros
              tieneM = true;
              break;
              }
            }
            if (!tieneM)
              Console.WriteLine($"Es de tipo {x.GetType()} y que yo sepa no tiene un método M");
           }
          Console.ReadLine();
        };
      }
    }
  }
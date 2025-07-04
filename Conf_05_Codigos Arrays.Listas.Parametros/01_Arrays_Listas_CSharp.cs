namespace LP
{
  internal class Program
  {
    static void Main()
    {
      #region ARRAYS PRIMARIOS (comentar esta region para probar la otra)
      //var a = new int[100];
      //a[0] = 100;
      //a[10] = 200;
      //int k = 5;
      //Console.WriteLine($"El valor de la componente {k + 2} es {a[k + 2]}");
      ////Trabaja con una componente a la que no le ha dado un valor explicitamente
      ////Inicializa by default todos a 0 o a null si no es numérico el tipo

      ////a[a.Length] = 1000;
      ////Controla que no me salga del rango

      //a = a + [100];
      //No le puedo añadir elementos
      #endregion

      #region LISTAS (descomentar para probar)
      var b = new List<int> { 0, 100, 200, 300, 400, 500, 600, 700, 800, 900 };
      //Hay que inicializarla con valores explicitos, no tiene huecos
      //Vaya con Go to definition a List y vea todo lo que tiene
      Console.WriteLine($"La lista tiene un total de {b.Count()} el valor de la ultima componente es {b[b.Count() - 1]}");

      int i = 5;
      b[i + 1] = 777; //Se puede acceder o modificar el valor de una componente que ya existe
      Console.WriteLine($"La lista tiene un total de {b.Count()} el valor de la componente {i + 1} es ahora {b[i + 1]}");

      b.Add(1000);
      //Se puede hacer crecer adicionando elementos
      Console.WriteLine($"La lista tiene un total de {b.Count()} el valor de la ultima componente es {b[b.Count() - 1]}");

      Console.WriteLine($"Acceder a una posicion que no existe da excepcion {b[500]}");

      #endregion
    }
  }
}
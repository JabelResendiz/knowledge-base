using System.Diagnostics;
using System.Dynamic;

namespace LP
{
  #region PARA EJEMPLO DE USAR TRYINVOKE
  class MyDynamicFunction : DynamicObject
  {
    public override bool TryInvoke(InvokeBinder binder, object[] args,
                                   out object result)
    //Si un objeto de este tipo asignado a una variable dynamic f se usa de la forma f(...argumentos ...)
    //Esta será la función que se aplicará
    //Devolver true el DLR lo interpretará como invocación exitosa y el resultado será lo que esté en el parámetro result
    {
      result = 999;
      return true;
    }
  }
  #endregion

  #region CLASE PARA TRATAR ARRAY DE OBJECT COMO LLAVE A DICCIONARIO
  class MultiKey
  {
    object[] key;
    public MultiKey(object[] key)
    {
      this.key = key;
    }
    public override bool Equals(object obj)
    {
      MultiKey entry = (MultiKey)obj;
      if (entry.key.Length != key.Length) return false;
      else
      {
        for (int k = 0; k < key.Length; k++)
          if (!key[k].Equals(entry.key[k])) return false;
        return true;
      }
    }
    public override int GetHashCode()
    {
      int total = 0;
      for (int i = 0; i < key.Length; i++) total += key[i].GetHashCode();
      return total;
    }
  }
  #endregion

  #region CLASE MEMOIZE PARA FUNCIONES DE CUALQUIER CANTIDAD DE ARGUMENTOS
  public class DynamicFunctionMemoize : DynamicObject
  {
    Dictionary<MultiKey, object> dicc;
    public Delegate _method;
    public DynamicFunctionMemoize(Delegate method)
    {
      dicc = new Dictionary<MultiKey, object>();
      _method = method;
      //Inicializa el diccionaro y guarda el delegado que se le da al constructor
    }
    public override bool TryInvoke(InvokeBinder binder,
                                    object[] args, out object result)
    {
      var entry = new MultiKey(args); //Convierte los parámetros en formarto de llava a diccionario
      if (dicc.TryGetValue(entry, out result)) return true;
      //Si está en el diccionario el valor ya fue calculado para esos parámetros y eso es lo que se devuelve como resultado
      else
      {
        //Si no está en el diccionario se calcula para la función original
        result = _method.DynamicInvoke(args);
        dicc.Add(entry, result); //Se adiciona al diccionario y ese es el valor que se devuelve como resultado
        return true;
      }
    }
  }
  #endregion

  #region CLASE MIDETIEMPO PARA FUNCIONES DE CUALQUIER CANTIDAD DE PARÁMETROS
  //class DynamicObjectMideTiempo : DynamicObject
  //{
  //  Delegate _method;
  //  Stopwatch crono;
  //  public DynamicObjectMideTiempo(Delegate method)
  //  {
  //    _method = method; //Guarda método que se quiere medir
  //    crono = new Stopwatch();
  //  }
  //  public override bool TryInvoke(InvokeBinder binder,
  //                                  object[] args, out object result)
  //  {
  //    crono.Restart();
  //    object r = _method.DynamicInvoke(args);
  //    result = (r, crono.ElapsedMilliseconds);
  //    return true;
  //  }
  //};
  #endregion
  internal class ProbandoDynamicType
  {
    static void Main(string[] args)
    {
      #region PROBANDO MYFUNCTIONOBJECT
      //dynamic F = new MyDynamicFunction();
      ////F lo podre invocar como funcion y usara la redefinicion de TryInvoke
      //Console.WriteLine(F(3, "caos") + 1);
      //Console.WriteLine($"El valor del objeto es {F}");
      //Console.ReadLine();
      #endregion

      #region FIBONACCI
      Func<int, long> FibIterativo = (n) =>
      {
        if (n <= 0) throw new Exception("N debe ser mayor que 0");
        long penultimo = 1L; long ultimo = 1L;
        for (int k = 3; k <= n; k++)
        {
          (ultimo, penultimo) = (ultimo + penultimo, ultimo);
        };
        return ultimo;
      };

      Func<int, long> FibRecursivo = null;
      FibRecursivo = (n) =>
      {
        if (n <= 0) throw new Exception("N debe ser mayor que 0");
        else if (n <= 2) return 1L;
        else return FibRecursivo(n - 1) +
                    FibRecursivo(n - 2);
      };

      dynamic FibRecMemoized = null; //Para que el compiler la deje usar en parte derecha
      FibRecMemoized = new DynamicFunctionMemoize((Func<int, long>)((n) =>
      {
        if ((n == 1) || (n == 2))
          return 1L;
        else
          return FibRecMemoized(n - 1) + FibRecMemoized(n - 2);
      }));
    #endregion

      #region SUMA LENTA
      Func<int, int, int> SumaLenta =
      (n, m) =>
      {
        System.Threading.Thread.Sleep(n + m);
        return n + m;
      };
      dynamic SumaLentaMemoized = new DynamicFunctionMemoize(SumaLenta);
      #endregion

      #region PROBANDO CON FIBONACCI
      var crono = new Stopwatch();
      while (true)
      {
        Console.Write("\nEntre número a calcular Fibonacci ");
        var s = Console.ReadLine();
        if (s == "") break;
        int k;
        if (int.TryParse(s, out k))
        {
          if (k > 0)
          {
            long result;
            long time;
            crono.Restart();
            result = FibIterativo(k);
            crono.Stop();
            time = crono.ElapsedMilliseconds;
            Console.WriteLine($"Fib Iterativo de    {k} es {result} calculado en {time} ms");
            crono.Restart();
            result = FibRecursivo(k);
            crono.Stop();
            time = crono.ElapsedMilliseconds;
            Console.WriteLine($"Fib Recursivo de    {k} es {result} calculado en {time} ms");
            crono.Restart();
            result = FibRecMemoized(k);
            crono.Stop();
            time = crono.ElapsedMilliseconds;
            Console.WriteLine($"Fib Rec Memoized de {k} es {result} calculado en {time} ms");

            //DESCOMENTAR PARA PROBAR QUE NO DA ERROR DE COMPILACION PERO EXCEPCION PORQUE SE LLAMA CON NUMERO INCORRECTO DE PARÁMETROS
            var r = FibRecMemoized(k, 3);
          }
        }
      }
      #endregion

      #region PROBANDO CON SUMA LENTA (FUNCION DE DOS PARAMETROS)
      //Descomentar para probar que el mismo Memoize funciona para una funcion de dos parametros
      while (true)
      {
        int suma;
        long time;
        int sum1, sum2;
        Console.Write("\nEntre primer  sumando: ");
        var s1 = Console.ReadLine();
        if (!int.TryParse(s1, out sum1)) break;
        Console.Write("Entre segundo sumando: ");
        var s2 = Console.ReadLine();
        if (!int.TryParse(s2, out sum2)) break;
        crono.Restart();
        suma = SumaLenta(sum1, sum2);
        crono.Stop();
        time = crono.ElapsedMilliseconds;
        Console.WriteLine($"Suma Lenta de          {sum1} y {sum2} = {suma} calculado en {time} ms");
        crono.Restart();
        suma = SumaLentaMemoized(sum1, sum2);
        crono.Stop();
        time = crono.ElapsedMilliseconds;
        Console.WriteLine($"Suma Lenta Memoized de {sum1} y {sum2} = {suma} calculado en {time} ms");
      }
      #endregion
    }
  }
} 

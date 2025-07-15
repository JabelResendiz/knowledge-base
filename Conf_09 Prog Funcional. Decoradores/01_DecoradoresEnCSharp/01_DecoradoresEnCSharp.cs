using System;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;

namespace LP
{
  class Program
  {
    public static Func<T, (TResult r, long t)> 
      MideTiempo<T, TResult>(Func<T, TResult> f)
    {
      return (T x) =>
      {
        Stopwatch sw = Stopwatch.StartNew();
        TResult resultado = f(x);
        sw.Stop();
        return (resultado, sw.ElapsedMilliseconds);
      };
    }

    public static Func<T1, T2, (TResult r, long t)> 
      MideTiempo<T1, T2, TResult>(Func<T1, T2, TResult> f)
    {
      return (T1 x, T2 y) =>
      {
        Stopwatch sw = Stopwatch.StartNew();
        TResult resultado = f(x, y);
        sw.Stop();
        return (resultado, sw.ElapsedMilliseconds);
      };
    }
    //ES UN INCORDIO TENER QUE REPETIR CASI EL MISMO PATRÓN PARA DIFERENTE CANTIDAD DE PARÁMETROS CUANDO NO JUEGAN NINGÚN ROL EN LA DECORACIÓN
    public static Func<T, TResult> Memoize<T, TResult>(Func<T, TResult> f)
    {
      var mem = new Dictionary<T, TResult>();
      return arg =>
      {
        if (mem.TryGetValue(arg, out TResult valor))
        {
          return valor;
        }
        TResult result = f(arg);
        mem[arg] = result;
        return result;
      };
    }
    public static Func<T, TResult> RecursiveMemoize<T, TResult>(Func<Func<T, TResult>, 
                                                                     Func<T, TResult>> 
                                                                     f)
    {
      var mem = new Dictionary<T, TResult>();
      Func<T, TResult> func = null;
      //Para usar internamente la función original a través de aquí

      func = f(arg =>
      {
        if (mem.TryGetValue(arg, out TResult valor))
          return valor;

        TResult resultado = func(arg);
        mem[arg] = resultado;
        return resultado;
      });

      return func;
    }

    #region FUNCIONES PARA PROBAR
    public static string ToUpperLento(string s)
    {
      var n = s.Length*100;
      Thread.Sleep(n);
      return s.ToUpper();
    }

    public static string ConcatLento(string s1, string s2)
    {
      var n = (s1.Length + s2.Length)*100;
      Thread.Sleep(n);
      return (s1 + s2);
    }
    public static long FibonacciRec(int n) 
    //Ineficiente implementación de Fibonacci
    {
      if (n <= 0) return 0;
      if (n == 1) return 1;
      return FibonacciRec(n - 1) + FibonacciRec(n - 2);
    }
    // Fibonacci iterativo (eficiente)
    static long FibonacciIter(int n)
    {
      if (n == 0) return 0;
      if (n == 1) return 1;
      long anterior = 0; long actual = 1;
      for (int i = 2; i <= n; i++)
      {
        long temp = actual;
        actual = actual + anterior;
        anterior = temp;
      }
      return actual;
    }
    #endregion

    static void Main()
    {
      #region DECORANDO FUNCIONES ToUpperLento y ConcatLento PARA PROBAR FUNCIONAL MideTiempo
      //var toUpperLentoTimed = MideTiempo<string, string>(ToUpperLento);
      //var concatLentoTimed = MideTiempo<string, string, string>(ConcatLento);
      //while (true)
      //{
      //  Console.WriteLine("Entra string a covertir a mayúscula");
      //  var cadena = Console.ReadLine();
      //  if (string.IsNullOrWhiteSpace(cadena))
      //  {
      //    break;
      //  }
      //  var (s, t) = toUpperLentoTimed(cadena);
      //  Console.WriteLine($"\n{cadena} en mayuscula {s} usando ToUpperLento en: {t} ms\n");
      //  (s, t) = concatLentoTimed(cadena, cadena);
      //  Console.WriteLine($"\n{cadena} concatenada con sí misma {s} usando ConcatLento en: {t} ms\n");
      //}
      #endregion

      #region DECORANDO FUNCIONES DE FIBONACCI PARA PROBAR FUNCIONAL Memoize
      var fibRecTimed = MideTiempo<int, long>(FibonacciRec);
      var fibIterTimed = MideTiempo<int, long>(FibonacciIter);
      var fibRecMemoized = Memoize<int, long>(FibonacciRec);
      var fibRecMemoizedTimed = MideTiempo<int, long>(fibRecMemoized);
      //Tengo que garantizar que la función que estoy decorando se llama a sí misma decorada
      var fibRecRecursiveMemoize = RecursiveMemoize<int, long>(self => n =>
      {
        if (n <= 0) return 0;
        if (n == 1) return 1;
        return self(n - 1) + self(n - 2);
      });
      var fibRecRecursiveMemoizeTimed = MideTiempo<int, long>(fibRecRecursiveMemoize);
      while (true)
      {
        Console.Write("Entra valor a calcular Fibonacci = ");
        string input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
          break;
        }
        if (int.TryParse(input, out int n) && n >= 0)
        { //ir descomentando para probar todas las variantes de 
          var (r, t) = fibIterTimed(n);
          Console.WriteLine($"Fibonacci Iterativo({n}) = {r}, calculado en : {t} ms\n");
          (r, t) = fibRecTimed(n);
          Console.WriteLine($"Fibonacci Rec({n}) = {r}, calculado en : {t} ms\n");

          //Memorización no recursiva. No tiene efecto dentro de la propia recusion
          (r, t) = fibRecMemoizedTimed(n);
          Console.WriteLine($"Fibonacci Rec Memorizado({n}) = {r}, calculado en : {t} ms\n");

          //Memorización recursiva. Tiene efecto dentro de la propia recursion 
          (r, t) = fibRecRecursiveMemoizeTimed(n);
          Console.WriteLine($"Fibonacci Rec Memorizado Recursivamente ({n}) = {r}, calculado en : {t} ms\n");
        }
        else
        {
          Console.WriteLine("El número debe ser entero positivo.\n");
        }
      }
      #endregion
    }
  }
}

//EJERCICIOS
//ESCRIBA UN DECORADOR TIMES PARA CONTAR LA CANTIDAD DE VECES QUE SE LLAMA A UNA FUNCION
//ESCRIBA UN DECORADOR DELAY PARA RETARDAR LA EJECUCIÓN DE UNA FUNCION UNA CANTIDAD DE MILISEGUNDOS
//ESCRIBA UN DECORADOR PRECONDITION PARA PONER UNA PRECONDICION A LA EJECUCION DE UNA FUNCION
//ESCRIBA UN DECORADOR RESCUE PARA ASOCIAR A UNA FUNCION UNA FUNCION ALTERNATIVA POR SI LA EJECUCIÓN DE LA FUNCION ORIGINAL DA EXCEPCION
//CREE QUE PUEDE SUGERIR UNA MODIFICACION A C# PARA SIMPLIFICAR CÓDIGO CUANDO SE QUIERE APLICAR UN MISMO PATRÓN DE DECORACIÓN INDEPENDIENTE DE LA CANTIDAD DE PARÁMETROS DE LA FUNCION A DECORAR
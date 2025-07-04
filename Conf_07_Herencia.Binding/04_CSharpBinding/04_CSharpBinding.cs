using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace LP
{
  public class C
  {
    public int var0 = 0;
    public int var1 = 1;
    public int var2 = 2;
    public int var3 = 3;

    // No virtual
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void QuienSoy()
    {
      Console.WriteLine($"Me llamaron como C");
    }
    public void NoVirtual()
    {
      var0 = 1000; // operación trivial
    }

    // Virtual
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void Virtual1()
    {
      var1 = 1; //operación trivial
    }
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void Virtual2()
    {
      var2 = 2; // operación trivial
    }
    public virtual void Virtual3()
    {
      var3 = 3; // operación trivial
    }
  }

  public class C1 : C
  {
    // Redefine ambas funciones
    //[MethodImpl(MethodImplOptions.NoInlining)]
    public new void QuienSoy()
    {
      // el uso de new en el metodo QuienSoy() de la clase C1 tiene un comportamiento especifco en C#
      // oculta el metodo heredado de la clase base , sin sobreescribirlo
      // crea un metodo nuevo C1 que no esta realciona con el metodo de la clase C
      // no usar la tabla de metodos virtuales , por lo q la llamada se resuelve en tiempo de compilacion
      Console.WriteLine($"Me llamaron como C1");
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void Virtual1()
    {
      var1 = 10; //Hacer algo
    }
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void Virtual2()
    {
      var2 = 20; //Hacer algo
    }
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void Virtual3()
    {
      var3 = 30; //Hacer algo
    }
  }

  class Program
  {
    static void Main()
    {
      long N = 3000_000_000; // cantidad de iteraciones
      C1 c1 = new C1(); // Tipado estático de c1 es C1
      C c = new C(); //Tipado estático de c es C.
      c = c1; //Ahora en c hay un c1

      //El funcionamiento de y dependera si se usa un metodo virtual o no

      //Console.WriteLine("Se asigno c1 a c, c=c1");
      //Console.WriteLine($"c y c1 somos el mismo objeto {c==c1}");
      //c.QuienSoy();  //usarlo estáticamente como c
      //c1.QuienSoy(); //usarlo estáticamente como c1


      Stopwatch sw = new Stopwatch();
      // Medir función  virtual
      sw.Restart();
      for (long k = 0; k < N; k++)
      {
        c = c1;
        c.Virtual1(); c.Virtual2(); c.Virtual3();
      };
      sw.Stop();
      Console.WriteLine($"Llamando {N} veces a tres virtual:    {sw.ElapsedMilliseconds} ms");

      // Medir función  no virtual
      sw.Restart();
      for (long k = 0; k < N; k++)
      {
        c.NoVirtual(); c.NoVirtual(); c.NoVirtual();
      };
      sw.Stop();
      Console.WriteLine($"Llamando {N} veces a tres no virtual: {sw.ElapsedMilliseconds} ms");
    }
  }
  }
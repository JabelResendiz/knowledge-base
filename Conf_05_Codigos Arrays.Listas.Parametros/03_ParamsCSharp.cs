namespace LP
{
  //Este ejemplo solo tiene como objetivo ilustrar las diferentes opciones de sobrecarga
  //No pretende para nada mostrar cual es la mejor forma de diseñar un tipo Fecha
  class Fecha
  {
    public int D { get; set; }
    public int M { get; set; }
    public int A { get; set; }

    //Tres sobrecargas de constructor de Fecha
    public Fecha(int d, int m)
    {
      D = d; M = m; A = 2025;
    }
    public Fecha(int d, int m, int a)
    {
      D = d; M = m; A = a;
    }
    public Fecha(string mes, int d, int a)
    {
      D = d; A = a;

      //Codigo para a partir del string nombre del mes obtener el número del mes .....
      M = 12;
    }
    public override string ToString()
    {
      return $"({D}, {M}, {A})";
    }
  }
  internal class Program
  {

    static void Main(string[] args)
    {
      Console.WriteLine(new Fecha(5, 4));
      Console.WriteLine(new Fecha(6, 5, 2026));
      Console.WriteLine(new Fecha("Diciembre", 31, 2024));
    }
  }
}
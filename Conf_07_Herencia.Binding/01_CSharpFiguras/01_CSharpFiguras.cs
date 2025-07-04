using System;
using System.Collections.Generic;
using System.Linq;

namespace LP
{
  // Clase punto con método Distancia
  public class Punto
  {
    public double X { get; }
    public double Y { get; }

    public Punto(double x, double y) => (X, Y) = (x, y);

    // Calcula distancia al punto pasado como parámetro
    public double Distancia(Punto otro) =>
        Math.Sqrt(Math.Pow(X - otro.X, 2) + Math.Pow(Y - otro.Y, 2));

    public override string ToString() => $"({X}, {Y})";
  }

  // Interfaz para figuras, con implementación por defecto de ToString
  public interface IFigura
  {
    double Area();
    double Perimetro();
    string ToStringFigura() 
      => $"Area: {Area():N2}, Perimetro: {Perimetro():N2}";
  }

  // Círculo
  public class Circulo : IFigura
  {
    public Punto Centro { get; }
    public double Radio { get; }

    public Circulo(Punto centro, double radio) => (Centro, Radio) = (centro, radio);

    public double Area() => Math.PI * Math.Pow(Radio, 2);
    public double Perimetro() => 2 * Math.PI * Radio;

    public override string ToString()
    { 
      return $"Circulo Centro: {Centro}, Radio: {Radio:N2} {((IFigura)this).ToStringFigura()}";
    }
  }

  // Polígono
  public class Poligono : IFigura
  {
    private List<Punto> Vertices { get; }

    public Poligono(IEnumerable<Punto> vertices) => Vertices = vertices.ToList();

    public double Area()
    {
      double suma = 0;
      int n = Vertices.Count;
      for (int i = 0; i < n; i++)
      {
        var actual = Vertices[i];
        var siguiente = Vertices[(i + 1) % n];
        suma += actual.X * siguiente.Y - siguiente.X * actual.Y;
      }
      return Math.Abs(suma) / 2;
    }

    public double Perimetro()
    {
      double total = 0;
      int n = Vertices.Count;
      for (int i = 0; i < n; i++)
      {
        total += Vertices[i].Distancia(Vertices[(i + 1) % n]);
      }
      return total;
    }

    public override string ToString()
    {
      string result = $"Poligono\n";
      foreach (var v in Vertices) result += $"  {v}";
      return result += $"\n  {((IFigura)this).ToStringFigura()}";
    }
  }

  // Funciones estáticas para ordenar listas de figuras
  public static class FigurasUtils
  {
    public static List<IFigura> OrdenaPorArea(IEnumerable<IFigura> figuras) =>
        figuras.OrderBy(f => f.Area()).ToList();

    //Haga directamente su propia implementación de List<IFigura>OrdenaPorArea(List<IFigura> figuras)
    //Usando su propia implementación de ordenar y el método Area de IFigura.
    //Pruebe con una lista que tenga circulos y poligonos
    //El primero en mandar un código correcto será bonificado

    public static List<IFigura> OrdenaPorPerimetro(IEnumerable<IFigura> figuras) =>
        figuras.OrderBy(f => f.Perimetro()).ToList();
  }

  // Ejemplo de uso
  class Programa
  {
    static void Main()
    {
      var figuras = new List<IFigura>
          {
              new Circulo(new Punto(0, 0), 3),
              new Poligono(new List<Punto>
              {
                new Punto(0, 0),
                new Punto(0, 1),
                new Punto(20, 1),
                 new Punto(20, 0)
              }),
              new Circulo(new Punto(0, 0), 1),
              new Poligono(new Punto[] {
                  new Punto(0, 0),
                  new Punto(0, 2),
                  new Punto(2, 2),
                  new Punto(2, 0)
              })
          };

      Poligono rombo = new Poligono(new List<Punto>
      {
        new Punto(0, 0), new Punto(0, 1),
        new Punto(20, 1),new Punto(20, 0)
      });

      Console.WriteLine("FIGURAS ORIGINALES:");
      foreach (var f in figuras) Console.WriteLine(f);

      Console.WriteLine("\nORDENADAS POR AREA:");
      var ordenadasArea = FigurasUtils.OrdenaPorArea(figuras);
      foreach (var f in ordenadasArea) Console.WriteLine(f);

      Console.WriteLine("\nORDENADAS POR PERIMETRO:");
      var ordenadasPerimetro = FigurasUtils.OrdenaPorPerimetro(figuras);
      foreach (var f in ordenadasPerimetro) Console.WriteLine(f);
    }
  }
}
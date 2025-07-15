using System;
namespace LP
{
  internal class Program
  {
    public static bool BoolGenerator()
    {
      var random = new Random();
      return random.Next(2) == 1;
    }
    static void Main(string[] args)
    {
      int v = 0;
      int i = 0;
      while (true)
      {
        i++;
        if (BoolGenerator())
          v = v+1;
        else
          v = v+"ABC"; // error en tiempo de compilacion

        Console.WriteLine($"{i} {v + 10}");
        Console.ReadLine();
      }
     }
  }
}
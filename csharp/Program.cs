using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

class Program
{
    static List<string> list = new List<string> { "Apple", "Peach" };

    static void Main()
    {
        // Llamar a la función Free con una expresión lambda
        List<string> result = Free(m => m.Contains("a"));

        // Imprimir el resultado
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }

    static List<string> Free(Expression<Func<string, bool>> exp)
    {

        // Filtrar la lista usando la función compilada
        return list.Where(exp).ToList();
    }
}

namespace LP
{
  //Descomentar esta clase y descomentar el case 6 del switch
  //Poner la nueva DLL resultante ObjectProductorLibrary.dll en la carpeta Testing
  //De este modo cuando probamos el ConsumerWithCasting tendremos un objeto de un tipo que no conocíamos cuando se escribió el código
  class M5
  {
    public void M()
    {
      Console.WriteLine("Ejecutando m de un M5 que nadie conoce...");
    }
  }
  public class ObjectProductor
  {
    static Random r = new Random();
    public object ProduceObject()
    {
      //Probar con el primer grupo de clases solamente
      switch (r.Next(8))
      {
        case 0: return new M1();
        case 1: return new M2();
        case 2: return new M3();
        case 3: return new M4();
        case 4: return 100;
        case 5: return (int k)=>k*k; //Devolviendo una función
        case 6: return new M5();
        default: return "Alien";
      }
   }
  }
}
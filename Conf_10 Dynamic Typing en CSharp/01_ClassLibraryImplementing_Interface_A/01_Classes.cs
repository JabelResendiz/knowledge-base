namespace LP
{
  //IM define un método M
  //M1 y M2 implementan la interface IM
  //M2 implementa además un método F
  //M3 no declara implementar IM pero tiene un método M con la misma signatura
  //M4 no declara implementar IM pero un método M y un método F con la misma signatura del F de M2
  //M2 y M4 implementan un método F con la misma signatura pero no declaran implementar ninguna interface común que defina un F
  public interface IM
  {
    void M();
  }
  public class M1 : IM
  {
    public void M()
    {
      Console.WriteLine("Executing method M of M1 ...");
    }
  }
  public class M2 : IM
  {
    public void M()
    {
      Console.WriteLine("Executing method M of M2 ...");
    }
    public void F()
    {
      Console.WriteLine("Executing method F of M2 ...");
    }
  }
  public class M3
  //Tiene un método M pero no declara implementar IM
  {
    public void M()
    {
      Console.WriteLine("Executing method M of M3 ...");
    }
  }
  public class M4
  //Tiene un método M pero no declara implementar IM
  //Tiene un método F con la misma signatura del F de M2
  {
    public void M()
    {
      Console.WriteLine("Executing method M of M4 ...");
    }
    public void F()
    {
      Console.WriteLine("Executing method F of M4 ...");
    }
  }
}

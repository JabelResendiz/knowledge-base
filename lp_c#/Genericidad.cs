

namespace Genericidad;

Film [] film = new Film();






public class Film
{
    public string Name {get;}
    public string Director {get;}
    public long Duration {get;}
    public string Gender {get;}
}



public interface IAgruparPor<T,R>
{
    T clave;
    IEnumerable<R> values;
}


public class Agrupar<T,R> 
{
    public IAgruparPor<T,R> groupBy(Function<T,R> func)
    {

    }
}




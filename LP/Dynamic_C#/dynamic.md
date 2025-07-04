
## Dynamic en C#

### DSL Interno en C# 3.5

Un DSL interno es un lenguaje especifico de dominio implementado dentro de un lenguaje de programacion . En C# se logra mediante:

- Metodos encadenados (Fluent Interface)
- Propiedades dinamicas
- Inicializadores de objetos

```csharp
public class Person
{
	public string FirstName {get;set;}
	public string LastName {get;set;}

	// para aceeso por diccionario
	private Dictionary<string,object> properties = new Dictionary,string,object>();

	public object this[string key]
	{
get => properties.ContainsKey(key) ? properties[key] : null;
set => properties[key] = value ;
}

// Fluent interface
	public Person FirstName (string firstName)
{
FirstName = firstName;
return this;
}

	public Person LastName(string lastName)
{
LastName = lastName;
return this;
}


}


public static class Factory
{
	public static dynamic New = new DynamicFactory();
}

public class DynamicFactory: DynamicObject
{
	public override bool TryGetMember(GetMemberBinder binder, out object result)
    {
        if (binder.Name == "Person")
        {
            result = new Person();
            return true;
        }
        result = null;
        return false;
    }
  
    // Para notación similar a JSON
    public Person Person(string FirstName, string LastName)
    {
        return new Person { FirstName = FirstName, LastName = LastName };
    }
}
```

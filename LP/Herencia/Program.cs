
Perro miPerro = new Perro();
miPerro.HacerSonido(); // "Guau guau!"
IAnimal animal = miPerro;
animal.HacerSonido(); // "Guag guau ! "



Gallina  gallina  = new Gallina();
gallina.Caminar(); // Funcion por defecto

gallina.CaminarCuadrupedo();

((IAve)gallina).Caminar(); // Otra forma de hacer lo de arriba


// Implmentacion Implicita ,es la mas comun

interface IAnimal
{
    void HacerSonido() => Console.WriteLine("hacer sonido por defecto del animal");
}

class Perro: IAnimal
{
    public void HacerSonido()
    {
        Console.WriteLine("Guau guau!");

        
    }


}



// Implementacion Explicita (debes diferenciaar entre implementaciones de varias interfaces)
interface ICuadrupedo
{
    void Caminar();
}

interface IAve
{
    void Caminar();
}

class Gallina : ICuadrupedo, IAve
{
    // Implementación explícita para ICuadrupedo
    void ICuadrupedo.Caminar()
    {
        Console.WriteLine("Caminando en 4 patas");
    }
    
    // Implementación explícita para IAve
    void IAve.Caminar()
    {
        Console.WriteLine("Caminando como ave");
    }
    
    // Método propio de la clase
    public void Caminar()
    {
        Console.WriteLine("Caminando normalmente");
    }

    public void CaminarAve() => ((IAve)this).Caminar();
    public void CaminarCuadrupedo() => ((ICuadrupedo)this).Caminar();

}






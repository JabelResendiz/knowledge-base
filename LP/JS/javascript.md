## JavaScript

### Modelo de objetos de JS

JavaScript utiliza un modelo de objetos basado en prototipos (prototype-based) , a diferencia de los lenguajes como Java o C++ que usan un modelo basado en clases (class-based). Las caracteristicas principales son:

- Prototipos : Cada objeto tiene una referencia a otro objeto llamado su prototipos. Cuando se accede a una propiedad que no existe en el objeto, JS busca en la cadena de prototipos hasta encontrarla o llegar al final (null)
- Herencia prototipal: Los objetos pueden heredar propiedades y metodo de otros objetos a traves de estamcadena
- Objetos dinamicos : Las propiedades puedes ser annadidas o eliminadas en timepo de ejecucion
- Funciones constructoras: Se usa para crear un objeto con un prototipo especfico, Cuando se invoca con `new` crea un nuevo objeto cuuyo prototipos es el objeto referenciado por las propiedaades `prototype` de la funcion.

```javascript
let animal = {
  eats: true
};
let rabbit = {
  jumps: true
};
rabbit.__proto__ = animal; // Establece el prototipo (forma antigua)
// Ahora rabbit puede acceder a eats
console.log(rabbit.eats); // true
```

### disenno de jerarquia con prototipos

Vamos a crear una jerarquia simple: Animal -> Mamifero -> Perro

```javascript
function Animal(name)
{
	this.name = name;
}

Animal.prototype.eats = function()
{
	return this.name + "eats";
}

// Mamifero hereda de Animal
function Mammal(name)
{
	Animal.call(this,name);
}

Mammal.prototype = Object.create(Animal.prototype);
Mammal.prototype.constructor = Mammal;

```

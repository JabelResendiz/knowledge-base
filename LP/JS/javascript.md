## JavaScript

### Modelo de objetos de JS

JavaScript utiliza un modelo de objetos basado en prototipos (prototype-based) , a diferencia de los lenguajes como Java o C++ que usan un modelo basado en clases (class-based). Las caracteristicas principales son:

- Prototipos : En lugar de crear autos nuevso a partir de un plano de autos (clases) , toman un auto existente (prototipo) y haces una copia de el, luego personalizas la copia
- Herencia: Los objetos pueden "heredar" caractersiticas directametne de otros objetos. Asi , si copias un auto, automaticamten tiene ruedas y un motor porque el auto original los tenia
- Cadena de Prototipos: Si intentas acceder a una caracteristicas especifica y no esta directamente en ese objeto, JS buscara en la "en la cadean" a su proposito, luego al prototipo y asi sucesivamente , hasta que lo encuetre o llegue al ""Object .protopty""
- Funciones constructoras: Se usa para crear un objeto con un prototipo especfico, Cuando se invoca con `new` crea un nuevo objeto cuuyo prototipos es el objeto referenciado por las propiedaades `prototype` de la funcion.

### Creacion de Objetos y Propiedades

- Literales de Objetos: Esta es al forma mas facil y comun , como escribir una lsita de caracteristicas para tu objeto.

```javascript
let persona ={
    nombre : "Juan", [cite:76,77] 
    edad: 30, [cite : 78]
    saludar : function () {[cite: 79]
	console.log('Hola, soy ' + [cite:80] this.nombre); [cite:81]
   }
};
```

- Funciones constructoras: Esto es util si quieres crear muchos objetos similares

```javascript
function Person(nombre,edad)
{
   this.nombre = nombre;
   this.edad = edad;
   this.saludar = function()
    {
	console.log('Hola , soy ' + this.nombre);
    }
};


let persona1 = new Persona('Mario',25);
```

### Prototipos y Herencia

- Cada objetos en JS tiene una referencia interna a otro objeto llamado su prototipo. Asi como JS logra la herencia: si un objeto no tiene una propiedad o metodo determinado, busca en su prototipo y luego en el prototipo de su prototipo y asi sucesivmente hasta que lo encuentre o llega al final de la cadena (donde el prototipo es null) . Esto permite que los objetos compartan y reutilicen codigo.

```javascript
//1. Creamos un objeto 'animal' que servira como nuestro prototipo base.
// Este objeto tiene una propiedad 'tipo' y un metodo 'saludar'

const animal = 
{
   tipo : 'desconocido',
   saludar : function() 
   {
     console.log('Hola, soy un ${this.tipo}.');
   }
};


// 2. Creamos un nuevo objeto 'perro' . Queremos que 'perro' herede de 'animal'
// Para esto, usamos Object.create(). Esto crea un nuevo objeto y establece su prototipo
// al objeto que le pasamos (en este caso , 'animal')

const perro = Object.create(animal);

// En este punto, 'perro' no tiene sus propias propiedades 'tipo' o 'saludar'

perro.tipo = 'perro';

// 4. Intentamos llamar al método 'saludar' en 'perro'.
// ¿Qué sucede? 'perro' no tiene un método 'saludar' directamente.
// JavaScript busca 'saludar' en el prototipo de 'perro', que es 'animal'.
// 'animal' sí tiene un método 'saludar', por lo que lo ejecuta.
// Y lo interesante es que 'this.tipo' dentro de 'saludar' se refiere al 'tipo' de 'perro',
// porque el método se llama en el contexto de 'perro'.


perro.saludar(); // Salida: Hola, soy un perro.


// 5. Creamos otro objeto, 'cachorro', y lo hacemos heredar de 'perro'.
const cachorro = Object.create(perro);

// 6. Ahora, 'cachorro' no tiene su propio 'tipo' o 'saludar'.
// Cuando llamamos a 'saludar' en 'cachorro':
// a. JavaScript busca 'saludar' en 'cachorro'. No lo encuentra.
// b. Busca en el prototipo de 'cachorro', que es 'perro'. No lo encuentra directamente en 'perro' (porque lo modificamos en el paso 3, pero no un 'saludar' propio de 'perro' sino que el 'saludar' que llamamos de 'perro' es el que hereda de 'animal').
// c. Busca en el prototipo de 'perro', que es 'animal'.
// d. ¡Lo encuentra en 'animal'! Y lo ejecuta con el 'tipo' de 'perro' porque ese es el valor que se encontró primero en la cadena de prototipos que tenía un valor para 'tipo'.
cachorro.saludar(); // Salida: Hola, soy un perro. (¡Porque cachorro hereda el 'tipo' de perro!)

// 7. Podemos añadir una propiedad específica a 'cachorro'.
cachorro.nombre = 'Fido';



// 8. Creamos un nuevo método específico para 'perro' en su prototipo.
// Esto afectará a 'perro' y a cualquier objeto que herede de 'perro' (como 'cachorro').
perro.ladrar = function() {
  console.log('¡Guau, guau!');
};

// Ahora, 'perro' puede ladrar.
perro.ladrar(); // Salida: ¡Guau, guau!

// Y 'cachorro' también puede ladrar, porque hereda el método 'ladrar' de 'perro'.
cachorro.ladrar(); // Salida: ¡Guau, guau!

// ¿Qué pasa si el prototipo es null?
// Es el final de la cadena de prototipos.
const objetoNulo = Object.create(null);
// objetoNulo.toString(); // Esto daría un error, porque no hay Object.prototype en la cadena.

```

### Es JS un LP OO

- Aunque JS no tenia originalmente "clases" como otros lenguajes OO. las ideas centrales de la POO son:
  - Encapsulamiento: Agrupasr datos y comportamientos realcionados en una sola unidad (el objeto).. JS lo hace con los literales de objeto (un objeto coche con marca y metodo encender)
  - Abtraccion: Ocultar la complejidad interna y mostrar solo lo necesario. En ES2022 podia tener porpiedades privadas (como #saldo en una clase Cuenta) a las que se solo se puede acceder dentro del objeto
  - Herencia: Compartir y reutilizar comportamientos entre diferentes objetos . Como un objeto "Perro" que hereda comportamientos comunes de animales de un prototipo "Animal"
  - Polimorfismo: Permitir que diferentes objetos respondas a la misma instruccion de maneras unicas
  - Funciones de primera clase: Los metodos son funciones que pueden pasarse como argumento

```javascript
// Prototipo base: Animal
function Animal(nombre) {
  this.nombre = nombre;
}

Animal.prototype.hablar = function() {
  console.log(`${this.nombre} hace un sonido genérico`);
};

// Prototipo Perro hereda de Animal
function Perro(nombre) {
  Animal.call(this, nombre); // Llama al constructor de Animal para inicializar 'nombre'
}

// Establece la cadena de prototipos: Perro.prototype hereda de Animal.prototype
Perro.prototype = Object.create(Animal.prototype);
// Corrige el constructor para que apunte a Perro (importante para la consistencia)
Perro.prototype.constructor = Perro;

// Sobrescribe el método 'hablar' para Perro
Perro.prototype.hablar = function() {
  console.log(`${this.nombre} ladra`);
};

// Prototipo Gato hereda de Animal
function Gato(nombre) {
  Animal.call(this, nombre);
}
Gato.prototype = Object.create(Animal.prototype);
Gato.prototype.constructor = Gato;

// Sobrescribe el método 'hablar' para Gato
Gato.prototype.hablar = function() {
  console.log(`${this.nombre} maúlla`);
};

// Creamos instancias
const firulais = new Perro("Firulais");
const michi = new Gato("Michi");
const desconocido = new Animal("Desconocido");

// Llamamos al mismo método
firulais.hablar();   // Salida: Firulais ladra
michi.hablar();      // Salida: Michi maúlla
desconocido.hablar(); // Salida: Desconocido hace un sonido genérico

const animalesAntiguos = [firulais, michi, desconocido];
animalesAntiguos.forEach(animal => animal.hablar());
/* Salida:
Firulais ladra
Michi maúlla
Desconocido hace un sonido genérico
*/
```


### JavaScript: Herencia Multiple

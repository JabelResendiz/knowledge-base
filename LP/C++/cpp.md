

### Inferencia de Tipos

1. auto : Permite que el compilador deduzca el tipo de una variable basandose en el valor que se inicializa.
2. decltype: Se puede obtener el tipo exacto de una expresion , preservando todas sus caractersiticas incluidos los calificadores const y las referencias
3. decltype (auto) : Combina los comportamientos de auto y de decltype  en la deduccion del tipo

### Template

1. ```cpp
   template <typename T> class Geek {}
   ```
2. ```cpp
   template <typename T> T suma (a,b) => a+b;
   ```

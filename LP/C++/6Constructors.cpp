#include <iostream>
using namespace std;

class Example {
private:
    int* value; // sera el encargar ode guardar el valor real del objeto Example en el heap
public:
    Example() { 
        value = new int(0); // asignam memoria para un entero en el heap e inicializa a 0
        cout << "Default Constructor Called!" << endl; 
    }
    Example(int arg) { 
        value = new int(arg); // asigname memoria para un entero en el heap e inicializa con el 'arg'
        cout << "Parameterized Constructor Called! : " << value << endl; 
    }
    Example(Example& other) { 
        value = other.value; // copia la direccion de memoria , no el valor
        // esto significa que this->value y other.value apuntan a al misma ubicacion
        // value = new int(*(other.value))
        cout << "Copy Constructor Called!" << endl; 
    }
    Example(Example&& other) { 
        value = other.value; // transfiere la propiedad de la memoria 
        other.value = nullptr; // anula el puntero original para evitar que lo libere
        cout << "Move Constructor Called!" << endl; 
    }
    ~Example() {
        if (value) { // verifica si el ptr no es nulo
            cout << "Destructor: Memory deleted" << endl;
            delete value; // libera la memoria que value estaba apuntando en el heap
            
        } else {
            cout << "Destructor: No memory to delete" << endl;
        }
    }

    void show(){
        if (value) {
            cout << "Address: " << value << "   Value: " << *value << endl;
        }
        else {
            cout << "Address: null" << "   Value: -" << endl;
        }
    }
};
    
int main() {
    //It's implemented for both: stack allocated objects xxx_1 and heap allocated objects xxx_2 

    // Default constructor call
    Example obj1_1; // Allocate object on the stack, they  will be dropped (call to destructor) at the end of the scope
    Example* obj1_2 = new Example();  // Allocate object on the heap, they will not be dropped
    obj1_1.show();
    obj1_2 -> show(); // This is the equivalent to '(*obj1_2).show()'

    // Parameterized constructor call
    Example obj2_1(5);
    Example* obj2_2 = new Example(5);
    obj2_1.show();
    obj2_2->show();

    // Copy constructor call
    // Example obj3_1 = obj2_1; // If you execute this it fails while dropping objects. Do you know why?? Tip: Double Deletion
    Example* obj3_2 = new Example(*obj2_2);
    cout << "After Copy" << endl;
    // obj2_1.show();
    // obj3_1.show();
    obj2_2->show();
    obj3_2->show();

    // Move constructor call
    Example obj4_1 = move(obj2_1);
    Example* obj4_2 = new Example(move(*obj2_2));  // Given that move return the object we need to store it inside a pointer, thats why new... its done.
    cout << "After Move" << endl;
    obj2_1.show();
    obj4_1.show();
    obj2_2->show();
    obj4_2->show();

    // Could you fallow the flow and know why Destructor printed this?
    // Destructor: Memory deleted
    // Destructor: No memory to delete
    // Destructor: Memory deleted
    return 0;
}
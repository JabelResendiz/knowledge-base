#include <iostream>
using namespace std;

class A {
private:
    int val;
public:
    A(int value): val(value){}
    int getValue() const {
        // el const indica que no se puede modificar el estado delobjeto
        return val;
        // val = 7; // in const functions we can't update the object state
    }
};

// sugiere al compilador que inserte el codigo de la funcion directamente donde se llama 
inline int square(int x) { 
    // Inline keyword suggest the compiler to insert the function code in the call section, the compiler
    // will complay if it think is not a too complex operation. This can avoid unnecessary operations in the stack
    // with frequently called functions
    return x*x;
}

int main() {
    // const functions
    A a(5);
    int a_val = a.getValue();

    // inline functions
    int b = square(8);    

    // const variations
    const int* p1 = &a_val; // Pointer to a constant value
    cout << "P1 addr: " << p1 << " val: " << *p1 << endl; // 5
    p1 = &b; // Pointer can change the directions it's pointing to
    cout << "P1 addr: " << p1 << " val: " << *p1 << endl; // 64
    // *p1 = 8; // Pointer's value can't be updated because its set as a constant

    int* const p2 = &a_val; // Constant pointer to a value
    cout << "P2 addr: " << p2 << " val: " << *p2 << endl; // 5
    // p2 = &b; // Pointer can't change it's direction
    *p2 = 1; // But it can change the value being pointed
    cout << "P2 addr: " << p2 << " val: " << *p2 << endl; // 1

    const int* const p3 = &a_val; // Constant pointer to a constant value
    cout << "P3 addr: " << p3 << " val: " << *p3 << endl; // 1
    // p3 = &b; // Pointer can't change it's direction
    // *p3 = 88; // Pointer's value can't be updated
}
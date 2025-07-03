#include <iostream>
using namespace std;

int main() {
    // Values: Independent copies
    cout << "VALUES" << endl;
    int v_a = 5; // It's the common syntax, nothing new to add here
    cout << "v_a: " << v_a << endl;
    int v_b = v_a; // This creates a copy that's not linked to v_a, they can have different values later on  
    cout << "v_b: " << v_b << endl;
    cout << "Changing value of v_b" << endl;
    v_b = 9;
    cout << "v_a: " << v_a << endl;
    cout << "v_b: " << v_b << endl;

    cout << endl;

    // References: Aliases that can't be null
    cout << "References" << endl;
    int r_a = 5;
    cout << "r_a: " << r_a << endl;
    int& r_b = r_a; // We are now creating a reference to r_a
    // int& r_bb = 5; // References must always be created from a lvalue (variable name)
    cout << "r_b: " << r_b << endl; // We don't need dereference operator to access its value
    // If we update one of them then the other one will have the change
    cout << "Changing value of r_a" << endl;
    r_a = 6;
    cout << "r_a: " << r_a << endl;
    cout << "r_b: " << r_b << endl;
    cout << "Changing value of r_b" << endl;
    r_b = 7;
    cout << "r_a: " << r_a << endl;
    cout << "r_b: " << r_b << endl;
    int r_c = 1;
    cout << "Trying to reference now r_c" << endl;
    r_b = r_c; // References can't change to alias a new variable, instead they will update the previous linked var
    // solo est tomando el valor de r_c y se lo esta dando a la variable a la que r_b es alias
    cout << "r_a: " << r_a << endl;
    cout << "r_b: " << r_b << endl;
    cout << "r_c: " << r_c << endl;
    cout << "Changing value of r_a" << endl;
    r_a = 9;
    // por eso cambiar el valor de r_b o de r_c no afecta a r_c
    cout << "r_a: " << r_a << endl;
    cout << "r_b: " << r_b << endl;
    cout << "r_c: " << r_c << endl;
    const int& r_d = r_a; // If we use the keyword const then the alias can't update the value
    //r_d = 8; // error

    cout << endl;

    // Pointers: Light boxes that point to data
    cout << "Pointers" << endl;
    int p_a = 5;
    int *p_b = &p_a; // With & operator we get the address of an element. This can be confusing with references, look for the differences
    cout << "p_a: " << p_a << endl;
    cout << "p_b val: " << *p_b << "  addr: " << p_b << endl; // To access its value we need the dereference operator *
    p_a = 10; 
    cout << "Changing value of p_a" << endl;
    cout << "p_a: " << p_a << endl;
    cout << "p_b val: " << *p_b << "  addr: " << p_b << endl; // p_b val: 10  addr: 0x21ccdff960 (no ha cambiado al direccion, solo el valor)
    *p_b = 15; 
    cout << "Changing value of p_b" << endl;
    cout << "p_a: " << p_a << endl;    // el valor de p_a= 15 tmb
    cout << "p_b val: " << *p_b << "  addr: " << p_b << endl; // lo mismo, la direccion es la misma solo cambia el valor
    int p_c = 20;
    cout << "Pointing p_b to p_c" << endl;
    p_b = &p_c; // Pointer can change the memory location that they point to
    cout << "p_a: " << p_a << endl; // p_a = 15
    cout << "p_b val: " << *p_b << "  addr: " << p_b << endl; // p_b = 20 y cambio su direccion
    cout << "p_c: " << p_c << endl; // p_c = 20

    p_b = nullptr; // Pinters can be null
    //cout << "p_b val: " << *p_b << "  addr: " << p_b << endl;  // Try this

    cout << "p_a: " << p_a << endl; // p_a = 15
    cout << "p_b val: " << *p_b << "  addr: " << p_b << endl; // p_b = 23 y su direccion es la misma que 
    cout << "p_c: " << p_c << endl; // p_c = 23

    return 0;
}
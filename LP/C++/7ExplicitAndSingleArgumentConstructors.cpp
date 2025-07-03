#include <iostream>
using namespace std;

class A {
private:
    int value;
public:
    A(int val): value(val) { // Member initializer list
        cout << "Created new A object! value: " << value << endl; 
    }
};

class B {
private:
    int value;
public:
    explicit B(int val): value(val) { 
        cout << "Created new B object! : " << value << endl; 
    }
};

int main() {
    // If some Type is expected and the value provided is of the same type as the argument of a single argument
    // constructor of that Type, then an implicit conversion occur.
    A a = 5; 
    // B b = 6; // Unless 'explicit' keyword is used in constructor
}
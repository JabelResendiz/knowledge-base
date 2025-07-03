

#include <iostream>
using namespace std;


class A
{
    private:
        int x;
    public:
        void method()
        {
            x++;
        }
};


class B: virtual public A
{

};

class C : virtual public A {};

class D : public B, public C {};

// POLIMORFISMO

class Base 
{
    public:
    virtual void metodo()
    {
        cout <<"Implementacion en Base" <<endl;
    }
};

class Derivada : public Base
{
    public:
        void metodo() override
        {
            cout << "Implementacion en Derivada" <<endl;
        }
};



int main()
{
    D* d = new D();

    d->method();

    Base* objeto = new Derivada();
    objeto->metodo(); // "Implementacion en Derivada"

    return 0;
}




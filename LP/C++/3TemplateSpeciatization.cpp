#include <iostream>
using namespace std;


// por que aqui no puedo hacer Pair<T,U> ????

template <typename T, typename U>
class Pair
{
public:
    void show() { cout << "Generic Types Pair" << endl; }
};

// Partial specialization when both types are the same
template <typename T>
class Pair<T, T>
{
public:
    void show() { cout << "Matching Types Pair" << endl; }
};

// Full specialization when both types are int
template <>
class Pair<int, int>
{
public:
    void show() { cout << "Int Type Pair" << endl; }
};

int main()
{
    // Generic Template
    cout << "Generic" << endl;
    Pair<int, double> p1;
    p1.show();

    // Full Specialization Template
    cout << "Full specialization" << endl;
    Pair<int, int> p3;
    p3.show();
    

    // Partial Specialization Template
    cout << "Partial specialization" << endl;
    Pair<double, double> p2;
    p2.show();


    return 0;
}
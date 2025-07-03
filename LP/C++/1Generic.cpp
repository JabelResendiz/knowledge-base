#include <iostream>
using namespace std;

// Generic in functions
template <typename T>
T add(T a, T b) {
    return a + b;
}

// EL segundo argumento no es de tipo template
template <class T, int max> int arrMin (T arr[], int n)
{
    int m = max;
    for(int i=0;i<n;i++)
    {
        if(arr[i] < m) m = arr[i];
    }

    return m;
}

// Recursivo suma 

// sumando ningun elemento
int suma_collection()
{
    return 0;
}

template <typename T,typename... Args> T suma_collection(T first, Args... args)
{
    return first + suma_collection(args...);
}

// genericidad con parametros por default
template <typename T1,typename T2 = double, typename T3 = string>
class Geek
{
    public:
        T1 x;
        T2 y;
        T3 z;

        Geek(T1 val1, T2 val2, T3 val3) : x(val1), y(val2), z(val3){}

        // Method to get values
        void getValues()
        {
            cout << x << " " << y << " " << z<<endl;
        }
};

// Generic in classes
template <typename T>
class Box {
private:
    T value;
public:
    Box(T v) : value(v) {}
    void show() { cout << "Value: " << value << endl; }
};

int main() {
    cout << "Function Generics" << endl;
    cout << add(5, 10) << endl;  // Works with integers
    cout << add<double>(5.5, 2.3) << endl;  // Works with floats
    

    cout << "Class Generics" << endl;
    Box<int> intBox(10);
    Box<double> doubleBox(5.5);
    intBox.show();
    doubleBox.show();


    Geek<int,float,string> intFloatStringGeek(10,5.67f,"Hello");

    Geek<char> charDoubleStringGeek('A',3.14,"World");

    intFloatStringGeek.getValues();

    charDoubleStringGeek.getValues();



    int arr1[] = {10,20,15,12};
    int n1 = sizeof(arr1) / sizeof(arr1[0]);

    char arr2[] = {1,2,3};
    int n2 = sizeof(arr2) / sizeof(arr2[0]);

    cout <<arrMin<int,1000> (arr1,n1) <<endl;
    cout << arrMin<char,256> (arr2,n2) <<endl;


    // Sumador de colecciones

    cout << "Sum of 1,2,3 : " << suma_collection(1,2,3) <<endl;
    cout << "Sum of 4,5,6,8: "<< suma_collection(4,5,6,8) <<endl;

    
    return 0;
}
#include <iostream>
#include <vector>
#include <list>
using namespace std;

// Type Template Argument
//  T can be any type: int, string, user defined types...
template <typename T>
void print(T value) {
    std::cout << value << std::endl;
}

// Non-Type Template Argument
//  Specify that template will be created with a constant value passed, that value must be of the
//  type defined
template <int N = 2> // You can define default values for them
void purr() {
    for (int i = 0; i < N; i++)
        std::cout << "\U0001F63B\U0001F4A4" << std::endl;
}






// Template Template Argument
//  They allow to pass template classes as argument to a template
// aqui definimos un Container generico tmb( ya sea un vector, un set, ...)
template <typename T, template <typename> class Container> 
class Wrapper1 {
private:
    Container<T> data; 
public:
    void add(T value) { data.push_back(value); }  // aqui exigimos que la estrucutra tenga una funcion push_back();
    // Note that we are forcing the container class to have push_back() function.
    // If is not found that function it will fail at compilation time.

    void show() { // aqui exigimos que Container tenga un iterador interno
        for (const auto& item : data)
            cout << item << " ";
        cout << endl;
    }
};

template <typename T, template <typename> class Container>
class Wrapper2 {
private:
    Container<T> data;
public:
    void foo(T value) { data.someMethod(value); }
};


// template<typename T> class MyClass
// {
//     private:
//         T x;
//     public:
//         MyClass(T value): x(value){}
    
//         someMethod(T c) 
//         {
//             print<T>(c);
//         }
// };



int main() {
    int number;
    cout << "Enter a number: ";
    cin >> number;
    cout << "You entered: " << number << endl;
    

    // Type Template Arguments
    cout << "Type Arguments" << endl;
    print<int>(number);


    // Non-Type Template Arguments 
    cout << "Non-Type Arguments" << endl;
    purr<3>();
    // purr(); // This will call the function defined by the default template
    // purr<number>(); // They can only be constants known at compile time
    

    // Template Template Arguments
    cout << "Template Template Arguments" << endl;
    Wrapper1<int, vector> intWrapper; // Using vector as the container
    intWrapper.add(10);
    intWrapper.add(20);
    intWrapper.add(24);
    intWrapper.show();

    intWrapper.add(80);
    intWrapper.show();

    Wrapper1<string, list> stringWrapper; // Using list as the container
    stringWrapper.add("Hello");
    stringWrapper.add("World");
    stringWrapper.show();

    // If we use the second wrapper class it fails, list doesn't implement someMethod
    // Wrapper2<string, vector> otherWrapper; 
    // otherWrapper.foo("Hello");

    //MyClass<string> myClass("Hello","world");

    // Wrapper2<string,MyClass> otherWrapper;
    // otherWrapper.foo("string");

    return 0;
}
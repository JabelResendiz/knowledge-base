#include <iostream>
using namespace std;

union MyUnion {
    int integer;
    float floatingPoint;
    char character;
};

int main() {
    // Union allow different data members to share the same memory location. Thats why its size will be the max 
    // of individual sizes of the members. The information written as a member can update the status of all others. 
    // It's up to the programmer to be aware of what type was being used.
    MyUnion u;
    cout << "Saving integer 89" << endl;
    u.integer = 89;
    cout << "Union int:" << u.integer << endl;
    cout << "Union float:" << u.floatingPoint << endl;
    cout << "Union char:" << u.character << endl;

    cout << "Saving float 3.85" << endl;
    u.floatingPoint = 3.85;
    cout << "Union int:" << u.integer << endl;
    cout << "Union float:" << u.floatingPoint << endl;
    cout << "Union char:" << u.character << endl;

    cout << "Saving char 'c'" << endl;
    u.character = 'c';
    cout << "Union int:" << u.integer << endl;
    cout << "Union float:" << u.floatingPoint << endl;
    cout << "Union char:" << u.character << endl;
    
    return 0;
}
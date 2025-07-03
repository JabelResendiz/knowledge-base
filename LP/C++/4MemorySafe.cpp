#include <iostream>
using namespace std;

int main() {
    cout << "Initialized array" << endl;
    int numbers[5] = {5, 6, 7, 8, 10};
    for (int i = 0; i < 5; i++) {
        cout << i << " element: " << numbers[i] << endl;
    }

    cout << "Uninitialized array" << endl;
    int numbers2[5]; // Puff... y entonces??
    for (int i = 0; i < 5; i++) {
        cout << i << " element: " << numbers2[i] << endl;
    }
    // Developer needs to be aware of the condition of the memory that is being used

    return 0;
}
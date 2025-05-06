

#include <iostream>
using namespace std;

class IShape
{

public:
    virtual void draw() const = 0;
    virtual double area() const = 0;

    virtual ~IShape() {} // destructur virtual
};

class Circle : public IShape
{
private:
    double radius;

public:
    Circle(double r) : radius(r) {}

    void draw() const override
    {
        cout << "DIbujando un ciruclo de radio " << radius << endl;
    }

    double area() const override
    {
        return 3.1416 * radius * radius;
    }
};

// Implementación de la interfaz en un rectángulo
class Rectangle : public IShape
{
private:
    double width, height;

public:
    Rectangle(double w, double h) : width(w), height(h) {}

    void draw() const override
    {
        std::cout << "Dibujando un rectángulo de " << width << "x" << height << std::endl;
    }

    double area() const override
    {
        return width * height;
    }
};

int main()
{
    IShape *shape1 = new Circle(5.0);
    IShape *shape2 = new Rectangle(4.0, 6.0);

    shape1->draw();
    std::cout << "Área: " << shape1->area() << std::endl;

    shape2->draw();
    std::cout << "Área: " << shape2->area() << std::endl;

    delete shape1;
    delete shape2;
    return 0;
}
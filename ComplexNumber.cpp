#include "ComplexNumber.h"
using namespace std;

// Default constructor.
ComplexNumber::ComplexNumber()
// Initialize member variables before full construction.
// Can do this instead of an initializer: this->message = "<no name>";.
{
    this->imag = 0;
    this->real = 0;
}

// Overload constructor.
ComplexNumber::ComplexNumber(double r, double i)
// Initialize member variables before full construction.
// Can do this instead of an initializer: this->message = message;
{
    this->real = r;
    this->imag = i;
}

// Copy constructor.
ComplexNumber::ComplexNumber(const ComplexNumber &src)
// Initialize member variables before full construction.
// Can do this instead of an initializer: this->message = src.message;.
{
    this->real = src.getReal();
    this->imag = src.getImag();
}

// Destructor.
ComplexNumber::~ComplexNumber()
{}

void ComplexNumber::setReal(int newReal)
{
    this->real = newReal;
}

void ComplexNumber::setImag(int newImag)
{
    this->imag = newImag;
}

string ComplexNumber::toString()
{
    if(imag < 0) // IF IMAG IS NEGATIVE.
    {
        return to_string(this->real) + " - " + to_string((-1 * this->imag)) + "i";
    }
    else // IF IMAG IS POSITIVE.
    {
        return to_string(this->real) + " + " + to_string(this->imag) + "i";
    }
}

ComplexNumber ComplexNumber::sqrt()
{
    if(this->imag != 0) // FIRST CASE. (B != 0).
    {
        double real = std::sqrt((this->real + (std::sqrt((this->real * this->real)
        + (this->imag * this->imag)))) / 2);
        double imag = std::sqrt(((this->real * -1) + (std::sqrt((this->real * this->real)
        + (this->imag * this->imag)))) / 2);
        return ComplexNumber(real, imag);
    }
    else // SECOND CASE. (B == 0).
    {
        if(this->real >= 0) // IF A >= 0.
        {
        double real = std::sqrt(this->real);
        double imag = 0;
        return ComplexNumber(real, imag);
        }
        else // IF A < 0.
        {
            double real = 0;
            double imag = std::sqrt(this->real * -1);
            return ComplexNumber(real, imag);
        }
    }
}

double ComplexNumber::mag()
{
    return std::sqrt((this->real * this->real) + (this->imag * this->imag));
}

ComplexNumber ComplexNumber::conj()
{
    double real = this->real;
    double imag = (this->imag * -1);
    return ComplexNumber(real, imag);
}

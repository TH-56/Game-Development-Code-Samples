// Pre-compiler guard to prevent circular includes. Can also use #pragma once.
#ifndef ComplexNumber_h
#define ComplexNumber_h

// Some common standard include files:
// <> tells the pre-compiler to search the system directories.
// "" tells the pre-compiler to search the current directories.
#include <string>
#include <cmath>
#include <iostream>

// Set the default namespace, avoids having to do std:: on objects/methods.
using namespace std;
class ComplexNumber
{
    // Set up a public section.
    // Can include member variables and functions.
    // Can have multiple public sections, they do not have to be contiguous in the file.
    public:
        // Default constructor. Constructs: 0 + 0i.
        ComplexNumber();

        // Constructs according to parameters.
        ComplexNumber(double r, double i);

        // Constructs with values from another complex number.
        ComplexNumber(const ComplexNumber &src);

        // Destructor.
        ~ComplexNumber();

        // Additional methods (message handlers).
        // Methods can be declared in the header file and define in the source file.
        // Methods can be declared and defined in the header file.
        // Usually reserved for short methods or special cases (templates -- more later).
        // There is no built-in toString function, you must write your own and call it when needed.

        string toString();
        ComplexNumber sqrt();
        double mag();
        ComplexNumber conj();
        void setReal(int newReal);
        void setImag(int newImag);
        
        // Returns real.
        int getReal() const
        {
            return this->real;
        }

        // Returns imag.
        int getImag() const
        {
            return this->imag;
        }

        // Returns true of both complex numbers are the same.
        bool equals(ComplexNumber o)
        {
            if(this->real == ((ComplexNumber) o).getReal() && this->imag ==
            ((ComplexNumber) o).getImag())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // This + rhs.
        ComplexNumber add(const ComplexNumber& rhs)
        {
            double real = this->real + rhs.getReal();
            double imag = this->imag + rhs.getImag();
            return ComplexNumber(real, imag);
        }

        // This - rhs.
        ComplexNumber sub(const ComplexNumber& rhs)
        {
            double real = this->real - rhs.getReal();
            double imag = this->imag - rhs.getImag();
            return ComplexNumber(real, imag);
        }

        // This * rhs.
        ComplexNumber mult(const ComplexNumber& rhs)
        {
            double real = ((this->real * rhs.getReal()) - (this->imag *
            rhs.getImag()));
            double imag = ((this->real * rhs.getImag()) + (this->imag *
            rhs.getReal()));
            return ComplexNumber(real, imag);
        }

        // This / rhs. Throws an error if denom == 0.
        ComplexNumber div(const ComplexNumber& rhs)
        {
            double denom = ((rhs.getReal() * rhs.getReal()) + (rhs.getImag() *
            rhs.getImag()));

            if(denom == 0)
            {
                throw "Cannot divide by zero!";
            }
            else
            {
                double real = ((this->real * rhs.getReal()) + (this->imag *
                rhs.getImag())) / denom;
                double imag = ((this->imag * rhs.getReal()) - (this->real *
                rhs.getImag())) / denom;
                return ComplexNumber(real, imag);
            }
        }
        
// Set up a private section.
// Can include member variables and functions.
// Can have multiple private sections, they do not have to be contiguous in the file.
private:
    double real;
    double imag;
    }; // IMPORTANT: Don't forget the semi-colon!
    #endif /* ComplexNumber_h */
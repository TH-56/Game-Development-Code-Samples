// Pre-compiler guard to prevent circular includes. Can also use #pragma once.
#ifndef RationalNumbers_h
#define RationalNumbers_h

// Some common standard include files:
//    <> tells the pre-compiler to search the system directories.
//    "" tells the pre-compiler to search the current directories.
#include <string>
#include <cmath>
#include <iostream>
#include <cstdint>

// Set the default namespace, avoids having to do std:: on objects/methods.
using namespace std;

class RationalNumbers
{

// Set up a public section.
// Can include member variables and functions.
// Can have multiple public sections, they do not have to be contiguous in the file.
 public:

    // Default constructor. Constructs with numerator of 0, denominator of 1.
    RationalNumbers();

    // Constructs with numerator of n, denominator of d.
    RationalNumbers(int n, int d);

    // Constructs with numerator of rhs.numerator, denominator of rhs.denominator.
    RationalNumbers(const RationalNumbers &src);

    // Destructor.
    ~RationalNumbers();

    // Additional methods (message handlers).
    // Methods can be declared in the header file and define in the source file.
    // Methods can be declared and defined in the header file.
    // Usually reserved for short methods or special cases (templates -- more later).

    // There is no built-in toString function, must write your own and call it when needed.
    string toString();

    // Returns sqrt((double)this->getNumerator()/(double)this->getDenominator()). Throws an error if this is negative.
    double sqrt();

    // Sets the numerator to the specified value.
    void setNumerator(int newNumerator);

    // Sets the denominator to the specified value.
    void setDenominator(int newDenominator);

    // Returns the numerator.
    int getNumerator() const 
    {
        return this->getNumerator();
    }

    // Returns the denominator.
    int getDenominator() const
    {
        return this->getDenominator();
    }

    // Returns true if o.numerator == this->getNumerator() and o.denominator == this->getDenominator(). False otherwise.
    bool equals(RationalNumbers o)
    {
        if(this->getNumerator() == ((RationalNumbers) o).getNumerator() && this->getDenominator() == ((RationalNumbers) o).getDenominator())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // This + rhs.
    RationalNumbers add(const RationalNumbers& rhs)
    {
        int newNumerator = this->getNumerator() * rhs.getDenominator() + rhs.getNumerator() * this->getDenominator();
        int newDenominator = this->getDenominator() * rhs.getDenominator();
        RationalNumbers result = RationalNumbers(newNumerator, newDenominator);
        return result;
    }

    // This - rhs.
    RationalNumbers sub(const RationalNumbers& rhs)
    {
        int newNumerator = this->getNumerator() * rhs.getDenominator() - rhs.getNumerator() * this->getDenominator();
        int newDenominator = this->getDenominator() * rhs.getDenominator();
        RationalNumbers result = RationalNumbers(newNumerator, newDenominator);
        return result;
    }

    // This * rhs.
    RationalNumbers mult(const RationalNumbers& rhs)
    {
        int newNumerator = this->getNumerator() * rhs.getNumerator();
        int newDenominator = this->getDenominator() * rhs.getDenominator();
        RationalNumbers result = RationalNumbers(newNumerator, newDenominator);
        return result;
    }

    // This / rhs. Throws an error if rhs == 0.
    RationalNumbers div(const RationalNumbers& rhs)
    {
        RationalNumbers result;

        if(rhs.getNumerator() == 0)
        {
            throw "Cannot divide by zero!";
        }
        else
        {
            int tempNumerator = rhs.getDenominator();
            int tempDenominator = rhs.getNumerator();
            int newNumerator = this->getNumerator() * tempNumerator;
            int newDenominator = this->getDenominator() * tempDenominator;
            result = RationalNumbers(newNumerator, newDenominator);
        }

        return result;
    }
  
// Set up a private section.
// Can include member variables and functions.
// Can have multiple private sections, they do not have to be contiguous in the file.
private:

    int64_t numerator;
    int64_t denominator;

    // Finds the greatest common denominator.
    int FindGCD(int a, int b)
    {
        return b == 0 ? a : FindGCD(b, a % b);
    }
    
}; // IMPORTANT: Don't forget the semi-colon!

#endif /* RationalNumber_h */
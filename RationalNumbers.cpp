#include "RationalNumbers.h"

using namespace std;

// Default constructor.
RationalNumbers::RationalNumbers()
// Initialize member variables before full construction.
// Can do this instead of an initializer: this->message = "<no name>";.
{
    this->numerator = 0;
    this->denominator = 1;
}

// Overload constructor.
RationalNumbers::RationalNumbers(int n, int d)
// Initialize member variables before full construction.
// Can do this instead of an initializer: this->message = message;
{
    if(d != 0)
    {
        this->numerator = n;
        this->denominator = d;
    }

    // Throws exception if d is 0.
    else
    {
        throw "The denominator cannot be equal to zero!";
    }
}

// Copy constructor.
RationalNumbers::RationalNumbers(const RationalNumbers &src)
// Initialize member variables before full construction.
// Can do this instead of an initializer: this->message = src.message;.
{
    this->numerator = src.getNumerator();
    this->denominator = src.getDenominator();
}

// Destructor.
RationalNumbers::~RationalNumbers()
{}

void RationalNumbers::setNumerator(int newNumerator)
{
    this->numerator = newNumerator;
}

void RationalNumbers::setDenominator(int newDenominator)
{
    this->denominator = newDenominator;
}

string RationalNumbers::toString()
{
    int wholeNumber = 0;
    int gcd = FindGCD(this->numerator, this->denominator);
    int tempNumerator = this->numerator / gcd;
    int tempDenominator = this->denominator / gcd;

    if(tempNumerator > tempDenominator)
    {
        while(tempDenominator % tempNumerator != 0)
        {
            wholeNumber++;
            tempNumerator = tempNumerator - tempDenominator;
        }

        if(wholeNumber == 0)
        {
            if(tempDenominator < 0)
            {
                return "-" + to_string(tempNumerator) + " / " + (to_string(tempDenominator * -1));
            }
            else
            {
                return to_string(tempNumerator) + " / " + to_string(tempDenominator);
            }
        }
        else
        {
            if(tempNumerator < 0)
            {
                return "-" + to_string(wholeNumber) + " " + (to_string(tempNumerator * -1)) + " / " + to_string(tempDenominator);
            }
            if(tempDenominator < 0)
            {
                return "-" + to_string(wholeNumber) + " " + to_string(tempNumerator) + " / " + (to_string(tempDenominator * -1));
            }
            if(tempNumerator > 0 && tempDenominator > 0)
            {
                return to_string(wholeNumber) + " " + to_string(tempNumerator) + " / " + to_string(tempDenominator);
            }
        }
    }
    else
    {
        return to_string(tempNumerator) + " / " + to_string(tempDenominator);
    }

    return "";
}

double RationalNumbers::sqrt()
{
    double result = std::sqrt((double)this->numerator/(double)this->denominator);

    if(result < 0)
    {
        throw "Arithmetic Exception! Result was negative!";
    }

    return result;
}
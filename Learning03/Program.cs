using System;

public class Fraction
{
    private int _numerator;
    private int _denominator;

    // Constructor with no parameters that initializes the number to 1/1
    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    // Constructor with one parameter for the top and initializes the denominator to 1
    public Fraction(int numerator)
    {
        _numerator = numerator;
        _denominator = 1;
    }

    // Constructor with two parameters, one for the top and one for the bottom
    public Fraction(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }

    // Getter and setter for the numerator
    public int Numerator
    {
        get { return _numerator; }
        set { _numerator = value; }
    }

    // Getter and setter for the denominator
    public int Denominator
    {
        get { return _denominator; }
        set { _denominator = value; }
    }

    // Method to return the fraction in the form "numerator/denominator"
    public string GetFractionString()
    {
        return _numerator + "/" + _denominator;
    }

    // Method to return the decimal value of the fraction
    public double GetDecimalValue()
    {
        return (double)_numerator / _denominator;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating instances of Fraction using different constructors
        Fraction fraction1 = new Fraction();        // 1/1
        Fraction fraction2 = new Fraction(5);       // 5/1
        Fraction fraction3 = new Fraction(3, 4);    // 3/4
        Fraction fraction4 = new Fraction(1, 3);    // 1/3

        // Displaying fractions and their decimal values
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());

        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue());

        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue());

        Console.WriteLine(fraction4.GetFractionString());
        Console.WriteLine(fraction4.GetDecimalValue());
    }
}

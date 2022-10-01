using area_calculator.Interfaces;

namespace area_calculator.Implementations;

public class Triangle : IFigure
{
    private readonly double _firstSide;
    private readonly double _secondSide;
    private readonly double _thirdSide;

    private static bool CheckPositive(double side)
    {
        return side > 0;
    }

    private static bool CheckExistence(double a, double b, double c)
    {
        if (a > b + c)
            return false;
        
        if (b > a + c)
            return false;
        
        if (c > a + b)
            return false;

        return true;
    }

    public Triangle(double firstSide, double secondSide, double thirdSide)
    {
        if (!(CheckPositive(firstSide) && CheckPositive(secondSide) && CheckPositive(thirdSide)))
            throw new ArgumentException("Sides of a triangle cannot be negative or 0");
        
        if(!CheckExistence(firstSide, secondSide, thirdSide))
            throw new ArgumentException("Triangle with these sides doesn't exists");

        _firstSide = firstSide;
        _secondSide = secondSide;
        _thirdSide = thirdSide;
    }

    public double GetArea()
    {
        var p = (_firstSide + _secondSide + _thirdSide) / 2;
        return Math.Sqrt(p * (p - _firstSide) * (p - _secondSide) * (p - _thirdSide));
    }
}
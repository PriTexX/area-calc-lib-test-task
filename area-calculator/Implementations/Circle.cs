using area_calculator.Interfaces;

namespace area_calculator.Implementations;

public class Circle : IFigure
{
    private readonly double _radius;

    public Circle(double radius)
    {
        if (radius < 0)
            throw new ArgumentException("Radius cannot be negative");

        _radius = radius;
    }
    
    public double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}
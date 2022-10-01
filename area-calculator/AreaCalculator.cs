using area_calculator.Interfaces;

namespace area_calculator;

public class AreaCalculator : IAreaCalculator
{
    public double CalculateArea(IFigure figure)
    {
        var area = figure.GetArea();

        if (area < 0)
            throw new ArgumentException("Area cannot be negative");

        return area;
    }
}
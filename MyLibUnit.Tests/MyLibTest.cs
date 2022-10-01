using area_calculator;
using area_calculator.Implementations;
using area_calculator.Interfaces;
using Xunit;

namespace MyLibUnit.Tests;

public class CircleTests
{
    [Fact]
    public void CircleCtor()
    {
        Assert.IsType<Circle>(new Circle(1));
        Assert.Throws<ArgumentException>(() => new Circle(-1));
    }
}

public class TriangleTests
{
    [Fact]
    public void TriangleCtorNegativeSide()
    {
        Assert.Throws<ArgumentException>(() => new Triangle(-1, 1, 1));
        Assert.Throws<ArgumentException>(() => new Triangle(1, -1, 1));
        Assert.Throws<ArgumentException>(() => new Triangle(1, 1, -1));
    }

    [Fact]
    public void TriangleCtorWrongSides()
    {
        Assert.Throws<ArgumentException>(() => new Triangle(5, 1, 2));
        Assert.Throws<ArgumentException>(() => new Triangle(4, 27, 39));
        Assert.Throws<ArgumentException>(() => new Triangle(0, 4, 9));
    }

    [Fact]
    public void TriangleCtorCorrect()
    {
        Assert.IsType<Triangle>(new Triangle(1, 1, 1));
    }
}

public class AreaCalculatorTests
{
    [Fact]
    public void CircleAreaTests()
    {
        var areaCalc = new AreaCalculator();
        
        Assert.Equal(Math.PI, areaCalc.CalculateArea(new Circle(1)));
        Assert.Equal(314.159, areaCalc.CalculateArea(new Circle(10)), 3);
    }

    [Fact]
    public void TriangleAreaTests()
    {
        var areaCalc = new AreaCalculator();
        
        Assert.Equal(0.433, areaCalc.CalculateArea(new Triangle(1,1,1)), 2);
        Assert.Equal(86.086, areaCalc.CalculateArea(new Triangle(10,23,18)), 2);
        Assert.Equal(14.523, areaCalc.CalculateArea(new Triangle(12,5,8)), 2);
    }

    private class MyCustomFigure : IFigure
    {
        public double GetArea()
        {
            return -5;
        }
    }

    [Fact]
    public void CustomFigureAreaTest()
    {
        var areaCalc = new AreaCalculator();

        Assert.Throws<ArgumentException>(() => areaCalc.CalculateArea(new MyCustomFigure()));
    }
}
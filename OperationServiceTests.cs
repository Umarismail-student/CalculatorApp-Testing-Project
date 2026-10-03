using Xunit;

using CalculatorApp.Services;

namespace CalculatorApp.Tests;

public class OperationServiceTests

{

    private readonly OperationService _service = new OperationService();

 

    [Theory]

    [InlineData(2, 3, 5)]

    [InlineData(-5, 5, 0)]

    [InlineData(-2, -3, -5)]

    public void Add_ReturnsCorrectResult(double a, double b, double expected)

    {

        Assert.Equal(expected, _service.Add(a, b));

    }

 

    [Theory]

    [InlineData(5, 3, 2)]

    [InlineData(3, 5, -2)]

    [InlineData(0, 0, 0)]

    public void Subtract_ReturnsCorrectResult(double a, double b, double expected)

    {

        Assert.Equal(expected, _service.Subtract(a, b));

    }

 

    [Theory]

    [InlineData(4, 3, 12)]

    [InlineData(-4, 3, -12)]

    [InlineData(5, 0, 0)]

    public void Multiply_ReturnsCorrectResult(double a, double b, double expected)

    {

        Assert.Equal(expected, _service.Multiply(a, b));

    }

 

    [Theory]

    [InlineData(10, 2, 5)]

    [InlineData(-10, 2, -5)]

    [InlineData(0, 5, 0)]

    public void Divide_ReturnsCorrectResult(double a, double b, double expected)

    {

        Assert.Equal(expected, _service.Divide(a, b));

    }

 

    [Theory]

    [InlineData(5, 0)]

    [InlineData(-5, 0)]

    [InlineData(0, 0)]

    public void Divide_ByZero_ThrowsDivideByZeroException(double a, double b)

    {

        Assert.Throws<DivideByZeroException>(() => _service.Divide(a, b));

    }

 

    [Fact]

    public void Add_Decimals_ReturnsApproximateResult()

    {

        Assert.Equal(0.3, _service.Add(0.1,

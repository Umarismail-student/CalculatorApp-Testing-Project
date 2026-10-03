using Xunit;
using Moq;
using CalculatorApp.Interfaces;
using CalculatorApp.Services;

namespace CalculatorApp.Tests;

public class CalculatorBehaviorTests
{
    private static (Calculator calc, HistoryService history) CreateRealCalculator()
    {
        var history = new HistoryService();
        var calc = new Calculator(new InputValidator(), new OperationService(), history);
        return (calc, history);
    }

    [Theory]
    [InlineData("5", "3", "-", 2)]
    [InlineData("4", "3", "*", 12)]
    [InlineData("10", "2", "/", 5)]
    [InlineData("-5", "5", "+", 0)]
    public void Calculate_AllOperators_ReturnCorrectResult(string a, string b, string op, double expected)
    {
        var (calc, _) = CreateRealCalculator();
        Assert.Equal(expected, calc.Calculate(a, b, op));
    }

    [Fact]
    public void Calculate_InvalidOperation_ThrowsArgumentException()
    {
        var (calc, _) = CreateRealCalculator();
        var ex = Assert.Throws<ArgumentException>(() => calc.Calculate("2", "3", "%"));
        Assert.Equal("Invalid operation.", ex.Message);
    }

    [Fact]
    public void Calculate_InvalidNumber_ThrowsArgumentException()
    {
        var (calc, _) = CreateRealCalculator();
        var ex = Assert.Throws<ArgumentException>(() => calc.Calculate("abc", "3", "+"));
        Assert.Equal("Invalid number input.", ex.Message);
    }

    [Fact]
    public void Calculate_SuccessfulCalculation_SavesRecordInHistory()
    {
        var (calc, history) = CreateRealCalculator();
        calc.Calculate("2", "3", "+");
        Assert.Contains("2 + 3 = 5", history.GetHistory());
    }

    [Fact]
    public void Calculate_DivideByZero_DoesNotSaveToHistory()
    {
        var validatorMock = new Mock<IInputValidator>();
        var operationMock = new Mock<IOperationService>();
        var historyMock = new Mock<IHistoryService>();

        validatorMock.Setup(v => v.ParseNumber("5")).Returns(5);
        validatorMock.Setup(v => v.ParseNumber("0")).Returns(0);
        operationMock.Setup(o => o.Divide(5, 0)).Throws<DivideByZeroException>();

        var calc = new Calculator(validatorMock.Object, operationMock.Object, historyMock.Object);

        Assert.Throws<DivideByZeroException>(() => calc.Calculate("5", "0", "/"));
        historyMock.Verify(h => h.AddRecord(It.IsAny<string>()), Times.Never);
    }
}

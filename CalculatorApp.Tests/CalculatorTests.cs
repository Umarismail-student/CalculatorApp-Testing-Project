using Xunit;
using Moq;
using CalculatorApp.Interfaces;
using CalculatorApp.Services;

namespace CalculatorApp.Tests;

public class CalculatorTests
{
    [Fact]
    public void Add_TwoNumbers_ReturnsCorrectResult()
    {
        var validator = new InputValidator();
        var operationService = new OperationService();
        var historyService = new HistoryService();

        var calculator = new Calculator(
            validator,
            operationService,
            historyService);

        double result = calculator.Calculate("2", "2", "+");

        Assert.Equal(4, result);
    }

    [Fact]
    public void Divide_ByZero_ThrowsException()
    {
        var validator = new InputValidator();
        var operationService = new OperationService();
        var historyService = new HistoryService();

        var calculator = new Calculator(
            validator,
            operationService,
            historyService);

        Assert.Throws<DivideByZeroException>(() =>
        {
            calculator.Calculate("5", "0", "/");
        });
    }

    [Fact]
    public void Calculate_UsesMockedOperationService()
    {
        var validatorMock = new Mock<IInputValidator>();
        var operationMock = new Mock<IOperationService>();
        var historyMock = new Mock<IHistoryService>();

        validatorMock.Setup(v => v.ParseNumber("2")).Returns(2);
        operationMock.Setup(o => o.Add(2, 2)).Returns(4);

        var calculator = new Calculator(
            validatorMock.Object,
            operationMock.Object,
            historyMock.Object);

        double result = calculator.Calculate("2", "2", "+");

        Assert.Equal(4, result);

        operationMock.Verify(o => o.Add(2, 2), Times.Once);
    }
}
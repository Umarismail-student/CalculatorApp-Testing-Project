using CalculatorApp.Interfaces;

namespace CalculatorApp.Services;

public class Calculator
{
    private readonly IInputValidator _inputValidator;
    private readonly IOperationService _operationService;
    private readonly IHistoryService _historyService;

    public Calculator(
        IInputValidator inputValidator,
        IOperationService operationService,
        IHistoryService historyService)
    {
        _inputValidator = inputValidator;
        _operationService = operationService;
        _historyService = historyService;
    }

    public double Calculate(string firstInput, string secondInput, string operation)
    {
        double a = _inputValidator.ParseNumber(firstInput);
        double b = _inputValidator.ParseNumber(secondInput);

        double result = operation switch
        {
            "+" => _operationService.Add(a, b),
            "-" => _operationService.Subtract(a, b),
            "*" => _operationService.Multiply(a, b),
            "/" => _operationService.Divide(a, b),
            _ => throw new ArgumentException("Invalid operation.")
        };

        _historyService.AddRecord($"{a} {operation} {b} = {result}");

        return result;
    }
}
using CalculatorApp.Services;

var inputValidator = new InputValidator();
var operationService = new OperationService();
var historyService = new HistoryService();

var calculator = new Calculator(inputValidator, operationService, historyService);

Console.WriteLine("Calculator Application");

Console.WriteLine("Enter first number:");
string first = Console.ReadLine() ?? "";

Console.WriteLine("Enter operation (+, -, *, /):");
string operation = Console.ReadLine() ?? "";

Console.WriteLine("Enter second number:");
string second = Console.ReadLine() ?? "";

try
{
    double result = calculator.Calculate(first, second, operation);
    Console.WriteLine($"Result: {result}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
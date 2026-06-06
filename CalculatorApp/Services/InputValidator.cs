using CalculatorApp.Interfaces;

namespace CalculatorApp.Services;

public class InputValidator : IInputValidator
{
    public bool IsValidNumber(string input)
    {
        return double.TryParse(input, out _);
    }

    public double ParseNumber(string input)
    {
        if (!IsValidNumber(input))
        {
            throw new ArgumentException("Invalid number input.");
        }

        return double.Parse(input);
    }
}
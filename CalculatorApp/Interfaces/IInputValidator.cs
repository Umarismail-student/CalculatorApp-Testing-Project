using CalculatorApp.Interfaces;

namespace CalculatorApp.Services;
public interface IInputValidator
{
    bool IsValidNumber(string input);
    double ParseNumber(string input);
}
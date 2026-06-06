using CalculatorApp.Interfaces;
namespace CalculatorApp.Services;

public class HistoryService : IHistoryService
{
    private readonly List<string> _history = new();

    public void AddRecord(string record)
    {
        _history.Add(record);
    }

    public List<string> GetHistory()
    {
        return _history;
    }

    public void ClearHistory()
    {
        _history.Clear();
    }
}
namespace CalculatorApp.Interfaces;

public interface IHistoryService
{
    void AddRecord(string record);
    List<string> GetHistory();
    void ClearHistory();
}
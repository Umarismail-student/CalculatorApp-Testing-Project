using Xunit;
using CalculatorApp.Services;

namespace CalculatorApp.Tests;

public class HistoryServiceTests
{
    [Fact]
    public void GetHistory_NewService_ReturnsEmptyList()
    {
        var history = new HistoryService();
        Assert.Empty(history.GetHistory());
    }

    [Fact]
    public void AddRecord_StoresRecord()
    {
        var history = new HistoryService();
        history.AddRecord("2 + 3 = 5");
        Assert.Single(history.GetHistory());
        Assert.Equal("2 + 3 = 5", history.GetHistory()[0]);
    }

    [Fact]
    public void ClearHistory_RemovesAllRecords()
    {
        var history = new HistoryService();
        history.AddRecord("2 + 3 = 5");
        history.AddRecord("4 * 3 = 12");
        history.ClearHistory();
        Assert.Empty(history.GetHistory());
    }
}

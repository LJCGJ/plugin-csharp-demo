using PluginDemo.Core;

namespace PluginDemo.Tests;

public class PluginTests
{
    [Fact]
    public void CsvPlugin_Should_Return_Column_And_Line_Info()
    {
        var plugin = new CsvPlugin();
        var result = plugin.Process("nome,idade\nAna,30\nJoao,25");

        Assert.Contains("Colunas:", result);
        Assert.Contains("Linhas:", result);
    }

    [Fact]
    public void CalculatorPlugin_Should_Return_Total()
    {
        var plugin = new CalculatorPlugin();
        var result = plugin.Process("10,20,30");

        Assert.Equal("Total calculado: 60", result);
    }
}

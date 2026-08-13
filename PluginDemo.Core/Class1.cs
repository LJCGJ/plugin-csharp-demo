namespace PluginDemo.Core;

public interface IPlugin
{
    string Name { get; }
    string Process(string input);
}

public class CsvPlugin : IPlugin
{
    public string Name => "CsvPlugin";

    public string Process(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        if (lines.Length == 0)
            return "Arquivo vazio.";

        var result = lines[0].Split(',');
        return $"Colunas: {string.Join(", ", result)} | Linhas: {lines.Length}";
    }
}

public class CalculatorPlugin : IPlugin
{
    public string Name => "CalculatorPlugin";

    public string Process(string input)
    {
        var total = 0;
        foreach (var value in input.Split(',', StringSplitOptions.RemoveEmptyEntries))
        {
            if (int.TryParse(value.Trim(), out var number))
                total += number;
        }

        return $"Total calculado: {total}";
    }
}

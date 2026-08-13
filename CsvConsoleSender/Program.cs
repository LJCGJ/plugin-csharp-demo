using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

var filePath = args.FirstOrDefault(a => a.StartsWith("--file="))?.Split('=')[1]
    ?? "sample.csv";
var endpoint = args.FirstOrDefault(a => a.StartsWith("--url="))?.Split('=')[1]
    ?? "http://localhost:5000/api/csv";

if (!File.Exists(filePath))
{
    Console.WriteLine($"Arquivo não encontrado: {filePath}");
    Console.WriteLine("Use: dotnet run -- --file=seu-arquivo.csv --url=http://localhost:5000/api/csv");
    return;
}

var lines = File.ReadAllLines(filePath)
    .Where(line => !string.IsNullOrWhiteSpace(line))
    .ToList();

if (lines.Count < 2)
{
    Console.WriteLine("CSV inválido. O arquivo precisa conter cabeçalho e pelo menos uma linha de dados.");
    return;
}

var headers = lines[0].Split(',');
var records = new List<Dictionary<string, string>>();

foreach (var line in lines.Skip(1))
{
    var values = line.Split(',');
    var item = new Dictionary<string, string>();

    for (var i = 0; i < headers.Length; i++)
    {
        var key = headers[i].Trim();
        var value = i < values.Length ? values[i].Trim() : string.Empty;
        item[key] = value;
    }

    records.Add(item);
}

var payload = new
{
    sourceFile = Path.GetFileName(filePath),
    totalRecords = records.Count,
    columns = headers,
    data = records
};

using var httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

var json = JsonSerializer.Serialize(payload);
using var content = new StringContent(json, Encoding.UTF8, "application/json");

try
{
    var response = await httpClient.PostAsync(endpoint, content);
    var responseBody = await response.Content.ReadAsStringAsync();

    Console.WriteLine($"Status: {(int)response.StatusCode} {response.StatusCode}");
    Console.WriteLine(responseBody);
}
catch (Exception ex)
{
    Console.WriteLine($"Erro ao enviar o payload: {ex.Message}");
}


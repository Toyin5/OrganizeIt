using System.Text.Json;

namespace FileOrganizer;

public class Config
{
    public required string DirectoryName { get; set; }
    public List<string> Extensions { get; set; } = [];
}

public class Configs
{
    public List<Config> Configurations { get; set; }

    public Configs? GetConfigs(FileInfo file)
    {
        try
        {
            var jsonString = File.ReadAllText(file.FullName);
            return JsonSerializer.Deserialize<Configs>(jsonString) ?? new Configs();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to load configuration: {ex.Message}");
            ExceptionHandler.CatchExceptions(ex);
            return null;
        }
    }
}
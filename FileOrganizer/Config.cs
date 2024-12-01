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

    public Configs? GetConfigs()
    {
        // Load configuration from JSON file
        string currentDir = Directory.GetCurrentDirectory();

        // Navigate up to the root of the project
        string projectRoot = Path.GetFullPath(Path.Combine(currentDir, "..", "..", ".."));

        // File path in the root
        string filePath = Path.Combine(projectRoot, "config.json");
        const string configPath = "./config.json";
        Configs configs;

        try
        {
            var jsonString = File.ReadAllText(filePath);
            configs = JsonSerializer.Deserialize<Configs>(jsonString) ?? new Configs();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to load configuration: {ex.Message}");
            ExceptionHandler.CatchExceptions(ex);
            return null;
        }

        return configs;
    }
}
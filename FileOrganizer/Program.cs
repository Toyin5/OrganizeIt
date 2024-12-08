using System.CommandLine;

namespace FileOrganizer;

class Program
{
    private static Configs _configs = default;
    static async Task<int> Main(string[] args)
    {
        var fileOption = new Option<FileInfo?>(
            name: "--file",
            description: "An option whose argument is parsed as a FileInfo",
            isDefault: true,
            parseArgument: result =>
            {
                if (result.Tokens.Count == 0)
                {
                    return new FileInfo("config.json");
                }
                string? filePath = result.Tokens.Single().Value;
                if (!File.Exists(filePath))
                {
                    result.ErrorMessage = "File does not exist";
                    return null;
                }
                else
                {
                    return new FileInfo(filePath);
                }
            });
        
        var directoryOption = new Argument<string>(
            "--dir",
            description: "The target directory(the one you wish to organize)");

        var rootCommand = new RootCommand("CLI application to organize files");
        rootCommand.AddOption(fileOption);
        rootCommand.AddArgument(directoryOption);
        
        rootCommand.SetHandler((file) => 
            { 
                ReadFile(file!); 
            },
            fileOption);
        
        rootCommand.SetHandler((dir) => Organize(dir),
            directoryOption);

        return await rootCommand.InvokeAsync(args);
    }

    static void ReadFile(FileInfo file)
    {
        _configs = new Configs().GetConfigs(file);
    }

    static void Organize(string directory)
    {
        Organizer.Organize(directory, _configs);
    }
}
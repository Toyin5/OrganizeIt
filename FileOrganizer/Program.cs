using CommandLine;
using FileOrganizer;

public static class Program
{
    static void Main(string[] args)
    {
        Parser.Default.ParseArguments<Options>(args)
            .WithParsed<Options>(o =>
            {
                if (o.Verbose)
                {
                    Console.WriteLine($"Verbose output enabled. Current Arguments: -v {o.Verbose}");
                    Console.WriteLine("Quick Start Example! App is in Verbose mode!");
                }
                else
                {
                    Console.WriteLine($"Current Arguments: -v {o.Verbose}");
                    Console.WriteLine("Quick Start Example!");
                }
            });
        // Define your configurations
        var configs = new Configs().GetConfigs();

        if (configs is null)
        {
            Console.WriteLine("Error: Failed to read config file.");
            return;
        }

// Define target directory
        const string directoryPath = @"C:\Users\TOYIN\Downloads\Testing";

        if (!Directory.Exists(directoryPath))
        {
            Console.WriteLine("Invalid directory path.");
            return;
        }

// Get all files in the directory
        var files = Directory.GetFiles(directoryPath);

        if (files.Length == 0)
        {
            Console.WriteLine("No files in this directory");
            return;
        }

        foreach (var file in files)
        {
            FileInfo fileInfo = new FileInfo(file);

            // Find matching configuration for the file extension
            var matchingConfig = configs.Configurations.Find(config =>
                config.Extensions.Contains(fileInfo.Extension.ToLower()));

            if (matchingConfig is null)
            {
                Console.WriteLine($"File {fileInfo.FullName} matches no configuration.");
                continue;
            }
            // Create the target directory if it doesn't exist
            var targetDirPath = Path.Combine(directoryPath, matchingConfig.DirectoryName);
            Directory.CreateDirectory(targetDirPath);

            // Move the file
            var targetFilePath = Path.Combine(targetDirPath, fileInfo.Name);
            File.Move(fileInfo.FullName, targetFilePath);

            Console.WriteLine($"Moved {fileInfo.Name} to {targetDirPath}");
        }

        Console.WriteLine("File organization complete.");
    }
}

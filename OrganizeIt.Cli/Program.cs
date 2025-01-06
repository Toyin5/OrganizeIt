using OrganizeIt.Core;

public static class Program
{
    public static void Main(string[] args)
    {
        string configFileString = "";
        string targetDirectory = "";

        for (int i = 0; i < args.Length; i++)
        {
            string arg = args[i];
            if (arg.StartsWith("-c") || arg.StartsWith("--config"))
            {
                if (i + 1 < args.Length)
                {
                    configFileString = args[i + 1];
                    i++;
                }
                else
                {
                    Console.WriteLine("Error: Missing config file path after -c or --config option.");
                    return;
                }
            }
            else if (arg.StartsWith("-d") || arg.StartsWith("--directory"))
            {
                if (i + 1 < args.Length)
                {
                    targetDirectory = args[i + 1];
                    i++;
                }
                else
                {
                    Console.WriteLine("Error: Missing target directory path after -d or --directory option.");
                    return;
                }
            }
            else
            {
                Console.WriteLine($"Warning: Unknown argument: {arg}");
            }
        }

        Console.WriteLine("Welcome to the OrganizeIt.Cli!");
        FileInfo? configFile = GetConfigFile(configFileString);
        if (configFile == null)
        {
            Console.WriteLine("Cannot proceed without a valid configuration file.");
            Console.ReadKey();
            return;
        }

        Configs? configs = new Configs();
        if (string.IsNullOrEmpty(targetDirectory) || targetDirectory.Equals("."))
        {
            targetDirectory = Environment.CurrentDirectory;
        }

        Console.WriteLine("Directory to organize: " + targetDirectory);
        configs = configs.GetConfigs(configFile);
        int result = Organizer.Organize(targetDirectory, configs);
        if (result >= 1) Console.WriteLine("Organizer ran successfully!"); else Console.WriteLine("Organizer failed");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
        return;
    }   
    
    private static FileInfo? GetConfigFile(string? configPath)
    {
        string? filePath = string.IsNullOrEmpty(configPath) ? $"{Environment.CurrentDirectory}/config.json" : configPath;
        var file = new FileInfo(filePath);
        var altFile = new FileInfo($"{AppDomain.CurrentDomain.BaseDirectory}/config.json");

        if (!file.Exists && !altFile.Exists)
        {
            Console.WriteLine(string.IsNullOrEmpty(configPath)
                ? "Cannot find default config file (config.json). Check your installation and try again."
                : "Invalid configuration file path.");
            return null;
        }

        return file.Exists ? file : altFile;
    }
}
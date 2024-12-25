using CommandLine;
using OrganizeIt.Cli;
using OrganizeIt.Core;

public static class Program
{
    public static void Main(string[] args)
    {
        Parser.Default.ParseArguments<Options>(args)
            .WithParsed<Options>(o =>
            {
                Console.WriteLine("Welcome to the OrganizeIt.Cli!");
                FileInfo? configFile = GetConfigFile(o.Config);
                if (configFile == null)
                {
                    Console.WriteLine("Cannot proceed without a valid configuration file.");
                    Console.ReadKey();
                    return;
                }
                Configs? configs = new Configs();
                if (string.IsNullOrEmpty(o.Directory) || o.Directory.Equals("."))
                {
                    o.Directory = Environment.CurrentDirectory;
                }
                Console.WriteLine("Directory to organize: " + o.Directory);
                configs = configs.GetConfigs(configFile);
                int result = Organizer.Organize(o.Directory, configs);
                if (result >= 1) Console.WriteLine("Organizer ran successfully!"); else Console.WriteLine("Organizer failed");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            });
        
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
using CommandLine;
using OrganizeIt.Cli;

public static class Program
{
    public static void Main(string[] args)
    {
        Parser.Default.ParseArguments<Options>(args)
            .WithParsed<Options>(o =>
            {
                Console.WriteLine("Welcome to the OrganizeIt.Cli!");
                Configs? configs = new Configs();
                FileInfo? configFile = GetConfigFile(o.Config);
                if (configFile == null)
                {
                    Console.WriteLine("Cannot proceed without a valid configuration file.");
                    return;
                }
                configs = configs.GetConfigs(configFile);
                int result = Organizer.Organize(o.Directory, configs);
                if (result >= 1) Console.WriteLine("Organizer ran successfully!"); else Console.WriteLine("Organizer failed");
                return;
            });
        
    }

    private static FileInfo? GetConfigFile(string? configPath)
    {
        string? filePath = string.IsNullOrEmpty(configPath) ? "config.json" : configPath;
        FileInfo? file = new FileInfo(filePath);

        if (!file.Exists)
        {
            Console.WriteLine(string.IsNullOrEmpty(configPath)
                ? "Cannot find default config file (config.json). Check your installation and try again."
                : "Invalid configuration file path.");
            return null;
        }

        return file;
    }
}
using CommandLine;
using FileOrganizer;

public static class Program
{
    public static void Main(string[] args)
    {
        Parser.Default.ParseArguments<Options>(args)
            .WithParsed<Options>(o =>
            {
                Console.WriteLine("Welcome to the FileOrganizer!");
                var configs = new Configs();
                FileInfo file = default;
                if (!string.IsNullOrEmpty(o.Config))
                {
                    file = new FileInfo(o.Config);
                    if (!file.Exists)
                    {
                        Console.WriteLine(("Invalid file path."));
                        return;
                    }
                    configs = configs.GetConfigs(file);
                }
                file = new FileInfo("config.json");
                if (!file.Exists)
                {
                    Console.WriteLine(("Cannot find config file. Check your installation and try again."));
                    return;
                }
                configs = configs.GetConfigs(file);
                var result = Organizer.Organize(o.Directory, configs);
                if (result >= 1) Console.WriteLine("Organizer ran successfully!"); else Console.WriteLine("Organizer failed");
                return;
            });
        
    }
}
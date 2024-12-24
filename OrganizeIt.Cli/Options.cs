using CommandLine;

namespace OrganizeIt.Cli;

public class Options
{
    [Option('c', "config", Required = false, HelpText = "Set the config file")]
    public string Config { get; set; } = string.Empty;
    
    [Option('d', "directory", Required = false, HelpText = "Set the target directory")]
    public string Directory { get; set; } = string.Empty;
}
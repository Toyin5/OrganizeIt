namespace OrganizeIt.Cli;

public static class HelpText
{
    public static string GetText()
    {
        return """
            -c, --config       Set the config file

            -d, --directory    Set the target directory

            --help             Display this help screen.

            --version          Display version information.
            """;
    }
}

namespace OrganizeIt.Cli;

public static class ExceptionHandler
{
    public static void CatchExceptions(Exception exception)
    {
        // Define log file path
        string logDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyAppLogs");
        // Ensure log directory exists
        Directory.CreateDirectory(logDirectory);
        string logFilePath = Path.Combine(logDirectory, $"{DateTime.UtcNow:yyyy-MM-dd-HH-mm-ss}-OrganizeIt.Cli.log");

        // Ensure log directory exists
        Directory.CreateDirectory(logDirectory);

        // Log exception details to the file
        string logMessage = $"{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} - {exception.GetType().Name}: {exception.Message}{Environment.NewLine}{exception.StackTrace}{Environment.NewLine}";
        File.AppendAllText(logFilePath, logMessage);

        // Optionally log to console
        Console.WriteLine("An unexpected error occurred. Please check the log file for details.");
        Console.WriteLine($"Error logged to: {logFilePath}");
    }
}
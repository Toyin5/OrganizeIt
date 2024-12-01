namespace  FileOrganizer;
class Program
{
    static void Main(string[] args)
    {
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

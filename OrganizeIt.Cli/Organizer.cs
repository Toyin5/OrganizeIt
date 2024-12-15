namespace OrganizeIt.Cli;

public static class Organizer
{
    public static int Organize(string directory, Configs? configs)
    {
        if (configs is null)
        {
            Console.WriteLine("Error: Failed to read config file.");
            return -1;
        }
        
        if (!Directory.Exists(directory))
        {
            Console.WriteLine("Invalid directory path.");
            return -1;
        }

        // Get all files in the directory
        var files = Directory.GetFiles(directory);

        if (files.Length == 0)
        {
            Console.WriteLine("No files in this directory");
            return 1;
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
            var targetDirPath = Path.Combine(directory, matchingConfig.DirectoryName);
            Directory.CreateDirectory(targetDirPath);

            // Move the file
            var targetFilePath = Path.Combine(targetDirPath, fileInfo.Name);
            File.Move(fileInfo.FullName, targetFilePath);

            Console.WriteLine($"Moved {fileInfo.Name} to {targetDirPath}");
        }

        Console.WriteLine("File organization complete.");
        return 1;
    }
}
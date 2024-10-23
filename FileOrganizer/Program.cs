// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<string> audioFiles = [".mp3"];
List<string> videoFiles = [".mp4"];
List<string> documents = [".pdf"];
List<string> softwares = [".exe"];



//string directoryPath = Directory.GetCurrentDirectory();
var directoryPath = "C:\\Users\\TOYIN\\Downloads\\Testing";
if (Directory.Exists(directoryPath))
{
    var files = Directory.GetFiles(directoryPath);
    foreach (var item in files)
    {
        FileInfo fileInfo = new FileInfo(item);

        if (audioFiles.Contains(fileInfo.Extension))
        {
            var dir = Directory.CreateDirectory(directoryPath + "\\Audios");
            dir.Create();
            File.Move(fileInfo.FullName, dir.FullName + "\\" + item);
        }

        if (videoFiles.Contains(fileInfo.Extension))
        {
            var dir = Directory.CreateDirectory(directoryPath + "\\Videos");
            dir.Create();
            File.Move(fileInfo.FullName, dir.FullName + "\\" + item);
        }

        if (documents.Contains(fileInfo.Extension))
        {
            var dir = Directory.CreateDirectory(directoryPath + "\\Documents");
            dir.Create();
            File.Move(fileInfo.FullName, dir.FullName + "\\" + fileInfo.Name);
        }

        if (softwares.Contains(fileInfo.Extension))
        {
            var dir = Directory.CreateDirectory(directoryPath + "\\Softwares");
            dir.Create();
            File.Move(fileInfo.FullName, dir.FullName + "\\" + item);
        }

    }
}
Console.WriteLine($"Current running directory: {directoryPath}");

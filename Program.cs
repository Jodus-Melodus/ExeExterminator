
class Program
{
    public static string[] GetDirectories(string path)
    {
        return Directory.GetDirectories(path);
    }

    public static string[] GetFiles(string path)
    {
        return Directory.GetFiles(path);
    }

    public static int DeleteFiles(string path, string fileExtention)
    {
        Directory.SetCurrentDirectory(path);
        string[] dirs = GetDirectories(path);
        string[] files = GetFiles(path);
        int totalDeletedFiles = 0;

        foreach (string subPath in dirs)
        {
            totalDeletedFiles += DeleteFiles(subPath, fileExtention);
        }

        foreach (string subPath in files)
        {
            if (subPath.Contains(fileExtention))
            {
                File.Delete(subPath);
                Console.WriteLine("Deleted : " + Path.GetFileName(subPath));
                totalDeletedFiles += 1;
            }
        }

        return totalDeletedFiles;
    }

    public static string? ReadLine(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    public static void Main()
    {
        string? path = ReadLine("Enter path > ");
        string? fileExtentionToDelete = ReadLine("Enter extention to exterminate > ");
        int totalDeletedFiles = 0;

        if ((fileExtentionToDelete != null) && (path != null))
        {
            totalDeletedFiles = DeleteFiles(path, fileExtentionToDelete);
        }

        Console.WriteLine("Deleted " + totalDeletedFiles + " files.");
    }
}
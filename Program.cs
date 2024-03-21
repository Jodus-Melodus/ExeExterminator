
class Program
{

    private static int TotalDeletedFiles {get; set;} = 0;

    public static string[] GetDirectories(string path)
    {
        return Directory.GetDirectories(path);
    }

    public static string[] GetFiles(string path)
    {
        return Directory.GetFiles(path);
    }

    public static void DeleteFiles(string path, string fileExtention)
    {
        Directory.SetCurrentDirectory(path);
        string[] dirs = GetDirectories(path);
        string[] files = GetFiles(path);

        foreach (string subPath in dirs)
        {
            DeleteFiles(subPath, fileExtention);
        }

        foreach (string subPath in files)
        {
            if (subPath.Contains(fileExtention))
            {
                File.Delete(subPath);
                Console.WriteLine("Deleted : " + Path.GetFileName(subPath));
                TotalDeletedFiles += 1;
            }
        }
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

        if ((fileExtentionToDelete != null) && (path != null))
        {
            DeleteFiles(path, fileExtentionToDelete);
        }

        Console.WriteLine("Deleted " + TotalDeletedFiles + "files.");
    }
}
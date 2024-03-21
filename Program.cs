
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

    public static (int, long) DeleteFiles(string path, string fileExtention)
    {
        Directory.SetCurrentDirectory(path);
        string[] dirs = GetDirectories(path);
        string[] files = GetFiles(path);
        int totalDeletedFiles = 0;
        long totalSpaceCleared = 0;

        foreach (string subPath in dirs)
        {
            (int totalFiles, long totalSpace) = DeleteFiles(subPath, fileExtention);
            totalDeletedFiles += totalFiles;
            totalSpaceCleared += totalSpace;
        }

        foreach (string subPath in files)
        {
            if (subPath.Contains(fileExtention))
            {
                Console.WriteLine("Deleted : " + Path.GetFileName(subPath));
                totalDeletedFiles += 1;
                FileInfo fileInfo = new(subPath);
                totalSpaceCleared += fileInfo.Length;
                File.Delete(subPath);
            }
        }

        return (totalDeletedFiles, totalSpaceCleared);
    }

    public static string? ReadLine(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    public static void Main()
    {
        while (true)
        {
            string? path = ReadLine("Enter path > ");
            string? fileExtentionToDelete = ReadLine("Enter extention to exterminate > ");

            if ((fileExtentionToDelete != null) && (path != null))
            {
                (int totalDeletedFiles, long totalSpaceCleared) = DeleteFiles(path, fileExtentionToDelete);
                Console.WriteLine($"Deleted {totalDeletedFiles} files. ({totalSpaceCleared / 1024.0} KB)");
            }
        }
    }
}
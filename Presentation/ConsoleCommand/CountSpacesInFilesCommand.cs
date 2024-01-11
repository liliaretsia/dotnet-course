using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingConsoleProject.Presentation.ConsoleCommand;

class CountSpacesInFilesCommand
{
    public async Task Execute(string folderPath)
    {
        var stopwatch = Stopwatch.StartNew();
        int totalSpaces = await CountSpacesInFiles(folderPath);
        stopwatch.Stop();

        Console.WriteLine($"Общее количество пробелов: {totalSpaces}");
        Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} мс");
    }
    
    static async Task<int> CountSpacesInFiles(string folderPath)
    {
        var files = Directory.GetFiles(folderPath);
        var countSpacesTasks = files.Select(file => CountSpacesInFile(file));

        var results = await Task.WhenAll(countSpacesTasks);
        return results.Sum();
    }

    static async Task<int> CountSpacesInFile(string filePath)
    {
        var text = await File.ReadAllTextAsync(filePath);
        return text.Count(c => c == ' ');
    }
}

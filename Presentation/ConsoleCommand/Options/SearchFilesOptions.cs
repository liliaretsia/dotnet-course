using CommandLine;

namespace HotelBookingConsoleProject.Presentation.ConsoleCommand.Options;

[Verb("search", HelpText = "Search Files.")]
public class SearchFilesOptions
{
    [Option('p', "path", Required = true, HelpText = "Path")]
    public string Path { get; set; }

}
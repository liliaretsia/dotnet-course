using CommandLine;

namespace HotelBookingConsoleProject.Presentation.ConsoleCommand.Options;

[Verb("countspaces", HelpText = "Count Spaces.")]
public class CountSpacesOptions
{
    [Option('p', "path", Required = true, HelpText = "Path")]
    public string Path { get; set; }

}
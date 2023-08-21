using CommandLine;

namespace HotelBookingConsoleProject.Presentation.ConsoleCommand.Options;

[Verb("add", HelpText = "Add a new hotel.")]
public class AddHotelOptions
{
    [Option('n', "name", Required = true, HelpText = "Name of the hotel.")]
    public string Name { get; set; }

    [Option('t', "type", Required = true, HelpText = "Hotel Type ID.")]
    public int TypeId { get; set; }
}
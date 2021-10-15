using MissionToMars.Service;

Console.WriteLine("Hello Mars!");
Console.WriteLine("============");

var nasaService = new NasaService();

string nasaCommand;
while ((nasaCommand = Console.ReadLine()) != null && nasaCommand != "")
{
    var validCommand = nasaService.ProcessCommand(nasaCommand);
    if (!validCommand)
        Console.WriteLine("ops.. invalid command!");
}


foreach (var rover in nasaService.RoversOnMars)
{
    var pos = rover.GetPosition();
    Console.WriteLine(pos);
}
Console.ReadKey();

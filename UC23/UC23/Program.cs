
using UC23;
using static System.Net.Mime.MediaTypeNames;

Console.WriteLine("Generating has started...");

Generator generator = new Generator();

var titlesAndCredits = generator.GetTitlesAndCredits();

Console.WriteLine("Generating has finished...");

try
{
    FileWriter.SaveTitlesCSV(titlesAndCredits.Item1);
    FileWriter.SaveCreditsCSV(titlesAndCredits.Item2);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


Console.WriteLine("Please close the program...");


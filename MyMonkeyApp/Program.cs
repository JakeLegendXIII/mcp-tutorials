using MyMonkeyApp;
using System.Globalization;

// Monkey Random Picker Console App
Console.OutputEncoding = System.Text.Encoding.UTF8;

var monkeyCount = MonkeyHelper.GetMonkeys().Count;
if (monkeyCount == 0)
{
	Console.WriteLine("🐒 Random Monkey Picker!");
	Console.WriteLine("========================");
	Console.WriteLine("No monkeys available. Add some monkeys and try again.");
	return;
}

while (true)
{
	Console.Clear();
	Console.WriteLine("🐒 Random Monkey Picker!");
	Console.WriteLine("========================");

	var selectedMonkey = MonkeyHelper.GetRandomMonkey();
	if (selectedMonkey is null)
	{
		Console.WriteLine("No monkeys available. Add some monkeys and try again.");
		return;
	}

	// Format population with thousands separators
	var populationText = selectedMonkey.Population.ToString("N0", CultureInfo.CurrentCulture);

	// Format coordinates as degrees with N/S and E/W
	static string FormatLat(double lat)
		=> $"{Math.Abs(lat):0.###}°{(lat >= 0 ? "N" : "S")}";
	static string FormatLng(double lng)
		=> $"{Math.Abs(lng):0.###}°{(lng >= 0 ? "E" : "W")}";

	Console.WriteLine($"Name: {selectedMonkey.Name}");
	Console.WriteLine($"Location: {selectedMonkey.Location}");
	Console.WriteLine($"Population: {populationText}");
	Console.WriteLine($"Details: {selectedMonkey.Details}");
	Console.WriteLine($"Coordinates: {FormatLat(selectedMonkey.Latitude)}, {FormatLng(selectedMonkey.Longitude)}");

	Console.WriteLine();
	Console.WriteLine("Press 'R' for another monkey, 'Q' to quit...");

	var key = Console.ReadKey(intercept: true).Key;
	if (key == ConsoleKey.Q)
	{
		break;
	}
	if (key != ConsoleKey.R)
	{
		// Ignore other keys and continue the loop, effectively picking another
		continue;
	}
}

Console.WriteLine("Goodbye! 👋");

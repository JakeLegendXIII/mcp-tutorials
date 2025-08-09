using MyMonkeyApp;
using System.Globalization;

// Monkey App Interactive Menu
Console.OutputEncoding = System.Text.Encoding.UTF8;

static string FormatLat(double lat) => $"{Math.Abs(lat):0.###}°{(lat >= 0 ? "N" : "S")}";
static string FormatLng(double lng) => $"{Math.Abs(lng):0.###}°{(lng >= 0 ? "E" : "W")}";

static void ShowMonkeyDetails(Monkey monkey)
{
	// ASCII art monkey face
	var art = @"
   __,__
  (o.o)
  /)  )
  ^^ ^^";

	var populationText = monkey.Population.ToString("N0", CultureInfo.CurrentCulture);

	Console.WriteLine(art);
	Console.WriteLine();
	Console.WriteLine($"Name: {monkey.Name}");
	Console.WriteLine($"Location: {monkey.Location}");
	Console.WriteLine($"Population: {populationText}");
	Console.WriteLine($"Details: {monkey.Details}");
	Console.WriteLine($"Coordinates: {FormatLat(monkey.Latitude)}, {FormatLng(monkey.Longitude)}");
	Console.WriteLine($"Accessed: {MonkeyHelper.GetAccessCount(monkey.Name)} time(s)");
}

while (true)
{
	Console.Clear();
	Console.WriteLine("🐒 Monkey App");
	Console.WriteLine("==============");
	Console.WriteLine("1) List all monkeys");
	Console.WriteLine("2) Get details by name");
	Console.WriteLine("3) Get a random monkey");
	Console.WriteLine("4) Exit");
	Console.Write("Select an option (1-4): ");

	var input = Console.ReadLine();
	if (string.IsNullOrWhiteSpace(input))
	{
		continue;
	}

	switch (input.Trim())
	{
		case "1":
		{
			Console.Clear();
			Console.WriteLine("All Monkeys:");
			Console.WriteLine("------------");
			var monkeys = MonkeyHelper.GetMonkeys();
			if (monkeys.Count == 0)
			{
				Console.WriteLine("No monkeys available.");
			}
			else
			{
				foreach (var m in monkeys)
				{
					var pop = m.Population.ToString("N0", CultureInfo.CurrentCulture);
					var access = MonkeyHelper.GetAccessCount(m.Name);
					Console.WriteLine($"- {m.Name} — {m.Location} — Pop: {pop} — Accesses: {access}");
				}
			}
			Console.WriteLine();
			Console.WriteLine("Press any key to return to menu...");
			Console.ReadKey(true);
			break;
		}
		case "2":
		{
			Console.Write("Enter monkey name: ");
			var name = Console.ReadLine();
			var monkey = MonkeyHelper.GetMonkeyByName(name ?? string.Empty);
			Console.Clear();
			if (monkey is null)
			{
				Console.WriteLine("Monkey not found.");
			}
			else
			{
				MonkeyHelper.RecordAccess(monkey);
				ShowMonkeyDetails(monkey);
			}
			Console.WriteLine();
			Console.WriteLine("Press any key to return to menu...");
			Console.ReadKey(true);
			break;
		}
		case "3":
		{
			Console.Clear();
			var monkey = MonkeyHelper.GetRandomMonkey();
			if (monkey is null)
			{
				Console.WriteLine("No monkeys available.");
			}
			else
			{
				MonkeyHelper.RecordAccess(monkey);
				ShowMonkeyDetails(monkey);
			}
			Console.WriteLine();
			Console.WriteLine("Press any key to return to menu...");
			Console.ReadKey(true);
			break;
		}
		case "4":
			Console.WriteLine("Goodbye! 👋");
			return;
		default:
			// ignore and loop
			break;
	}
}

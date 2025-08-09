namespace MyMonkeyApp;

using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Provides helper methods to access and query monkey data.
/// </summary>
public static class MonkeyHelper
{
    private const int DEFAULT_POPULATION = 0;

    private static readonly List<Monkey> monkeys = new()
    {
        new Monkey
        {
            Name = "Baboon",
            Location = "Africa & Asia",
            Details = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio.",
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/baboon.jpg",
            Population = 10000,
            Latitude = -8.783195,
            Longitude = 34.508523
        },
        new Monkey
        {
            Name = "Capuchin Monkey",
            Location = "Central & South America",
            Details = "The capuchin monkeys are New World monkeys of the subfamily Cebinae.",
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/capuchin.jpg",
            Population = 23000,
            Latitude = 12.769013,
            Longitude = -85.602364
        },
        new Monkey
        {
            Name = "Blue Monkey",
            Location = "Central and East Africa",
            Details = "The blue monkey or diademed monkey is native to Central and East Africa.",
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/bluemonkey.jpg",
            Population = 12000,
            Latitude = 1.957709,
            Longitude = 37.297204
        },
        new Monkey
        {
            Name = "Squirrel Monkey",
            Location = "Central & South America",
            Details = "Squirrel monkeys are New World monkeys of the genus Saimiri.",
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/saimiri.jpg",
            Population = 11000,
            Latitude = -8.783195,
            Longitude = -55.491477
        },
        new Monkey
        {
            Name = "Golden Lion Tamarin",
            Location = "Brazil",
            Details = "Also known as the golden marmoset; a small New World monkey.",
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/tamarin.jpg",
            Population = 19000,
            Latitude = -14.235004,
            Longitude = -51.92528
        },
        new Monkey
        {
            Name = "Howler Monkey",
            Location = "South America",
            Details = "Howler monkeys are among the largest of the New World monkeys.",
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/alouatta.jpg",
            Population = 8000,
            Latitude = -8.783195,
            Longitude = -55.491477
        },
        new Monkey
        {
            Name = "Japanese Macaque",
            Location = "Japan",
            Details = "Also known as the snow monkey; native to Japan.",
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/macasa.jpg",
            Population = 1000,
            Latitude = 36.204824,
            Longitude = 138.252924
        },
        new Monkey
        {
            Name = "Mandrill",
            Location = "Southern Cameroon, Gabon, and Congo",
            Details = "A primate of the Old World monkey family, closely related to baboons.",
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/mandrill.jpg",
            Population = 17000,
            Latitude = 7.369722,
            Longitude = 12.354722
        },
        new Monkey
        {
            Name = "Proboscis Monkey",
            Location = "Borneo",
            Details = "Reddish-brown arboreal Old World monkey endemic to Borneo.",
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/borneo.jpg",
            Population = 15000,
            Latitude = 0.961883,
            Longitude = 114.55485
        }
    };

    /// <summary>
    /// Gets all monkeys available in the repository.
    /// </summary>
    public static IReadOnlyList<Monkey> GetMonkeys() => monkeys;

    /// <summary>
    /// Gets a random monkey from the repository, or null if empty.
    /// </summary>
    public static Monkey? GetRandomMonkey()
    {
        if (monkeys.Count == 0)
        {
            return null;
        }

        var index = Random.Shared.Next(monkeys.Count);
        return monkeys[index];
    }

    /// <summary>
    /// Finds a monkey by its name (case-insensitive).
    /// </summary>
    /// <param name="name">The monkey's name.</param>
    public static Monkey? GetMonkeyByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return null;
        }

        return monkeys.FirstOrDefault(m => string.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase));
    }
}

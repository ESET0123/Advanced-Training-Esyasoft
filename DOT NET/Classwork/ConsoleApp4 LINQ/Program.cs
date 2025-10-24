using ConsoleApp4_LINQ;
using System.Runtime.CompilerServices;

var games = new List<Games>
{
    new Games { Title = "The Legend of Zelda: Breath of the Wild", Genre = "Action-adventure", ReleaseYear = 2017, Rating = 9.5, Price = 59 },
    new Games { Title = "God of War", Genre = "Action-adventure", ReleaseYear = 2018, Rating = 9.3, Price = 49 },
    new Games { Title = "Red Dead Redemption 2", Genre = "Action-adventure", ReleaseYear = 2018, Rating = 9.7, Price = 69 },
    new Games { Title = "The Witcher 3: Wild Hunt", Genre = "RPG", ReleaseYear = 2015, Rating = 9.4, Price = 39 },
    new Games { Title = "Minecraft", Genre = "Sandbox", ReleaseYear = 2011, Rating = 9.0, Price = 26 },
    new Games { Title = "Fortnite", Genre = "Battle Royale", ReleaseYear = 2017, Rating = 8.5, Price = 0 },
    new Games { Title = "Among Us", Genre = "Party", ReleaseYear = 2018, Rating = 8.0, Price = 5 },
    new Games { Title = "Cyberpunk 2077", Genre = "RPG", ReleaseYear = 2020, Rating = 7.5, Price = 59 },
    new Games { Title = "Hades", Genre = "Roguelike", ReleaseYear = 2020, Rating = 9.2, Price = 24 },
    new Games { Title = "Animal Crossing: New Horizons", Genre = "Simulation", ReleaseYear = 2020, Rating = 9.1, Price = 59 }
};

//var allGames = new List<String>();
//foreach (var game in games)
//{
//    allGames.Add(game.Title);
//}
//foreach (var title in allGames)
//{
//    Console.WriteLine(title);
//}
Console.WriteLine("----------------------------------------------------");

var allGames = games.Select(n => n.Title);      //LINQ
foreach (var title in allGames)
{
    Console.WriteLine(title);
}
Console.WriteLine("----------------------------------------------------");
//Console.WriteLine(allGames);
//Console.WriteLine("----------------------------------------------------");

var genregames = games.Where(games => games.Genre == "RPG");
foreach (var genregame in genregames)
{
    Console.WriteLine(genregame.Title);
}
Console.WriteLine("----------------------------------------------------");


var modernegames = games.Any(games => games.ReleaseYear >= 2020);
Console.WriteLine(modernegames);
Console.WriteLine("----------------------------------------------------");

var sortedgames = games.OrderBy(games => games.ReleaseYear);
foreach (var sortedgame in sortedgames)
{
    Console.WriteLine($"{sortedgame.Title} -- {sortedgame.ReleaseYear}");
}
Console.WriteLine("----------------------------------------------------");


var invertsortedgames = games.OrderByDescending(games => games.ReleaseYear);
foreach (var invertsortedgame in invertsortedgames)
{
    Console.WriteLine($"{invertsortedgame.Title} -- {invertsortedgame.ReleaseYear}");
}
Console.WriteLine("----------------------------------------------------");

var avggames = games.Average(games => games.Price);
Console.WriteLine("Average:" + avggames);
Console.WriteLine("----------------------------------------------------");

var mingames = games.Min(games => games.Price);
Console.WriteLine("Min:" + mingames);
Console.WriteLine("----------------------------------------------------");

var maxvalue = games.Max(games => games.Rating);
var firstgame = games.First(games => games.Rating == maxvalue);
Console.WriteLine($"{firstgame.Title}--{maxvalue}");
Console.WriteLine("----------------------------------------------------");

var groupByGenre = games.GroupBy(g => g.Genre);
foreach (var group in groupByGenre)
{
    Console.WriteLine($"Genre - {group.Key}");
    foreach (var game in group)
    {
        Console.WriteLine($" ---> {game.Title}");
    }

}
Console.WriteLine("----------------------------------------------------");

var multiconditions = games.Where(games => games.Genre == "RPG" && games.ReleaseYear > 2015)
    .OrderBy(games => games.ReleaseYear)
    .Select(n =>$"{ n.Title} -- {n.Price} --{n.Rating}");

foreach (var multicondition in multiconditions)
{
    Console.WriteLine($" ---> {multicondition}");
}
Console.WriteLine("----------------------------------------------------");


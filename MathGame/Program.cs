using MathGame.UI;

var menu = new Menu();
Console.Clear();
Console.Write(menu.ToString());
Console.WriteLine("------------------------------------------------");

var choice = new ConsoleMenuChoice().GetChoice();

Console.WriteLine(choice);

Console.ReadKey();
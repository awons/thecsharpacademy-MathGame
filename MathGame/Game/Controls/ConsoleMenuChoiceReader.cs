using MathGame.ConsoleWrapper;
using MathGame.UI.Menu;

namespace MathGame.Game.Controls;

public class ConsoleMenuChoiceReader(IConsoleWrapper consoleWrapper) : IMenuChoiceReader
{
    public MenuChoiceEnum GetChoice()
    {
        char choice;
        var currentPositionLeft = Console.CursorLeft;
        var currentPositionTop = Console.CursorTop;
        do
        {
            choice = consoleWrapper.ReadKey(false).KeyChar;
            Console.SetCursorPosition(currentPositionLeft, currentPositionTop);
            Console.Write(' ');
            Console.SetCursorPosition(currentPositionLeft, currentPositionTop);
        } while (!Enum.IsDefined(typeof(MenuChoiceEnum), (int)choice));

        return (MenuChoiceEnum)choice;
    }
}
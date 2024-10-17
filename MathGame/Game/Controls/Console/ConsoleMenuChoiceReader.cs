using MathGame.ConsoleWrapper;

namespace MathGame.Game.Controls.Console;

public class ConsoleMenuChoiceReader(IConsoleWrapper consoleWrapper) : IMenuChoiceReader
{
    public MenuChoiceEnum GetChoice()
    {
        char choice;
        var currentPositionLeft = System.Console.CursorLeft;
        var currentPositionTop = System.Console.CursorTop;
        do
        {
            choice = consoleWrapper.ReadKey(false).KeyChar;
            System.Console.SetCursorPosition(currentPositionLeft, currentPositionTop);
            System.Console.Write(' ');
            System.Console.SetCursorPosition(currentPositionLeft, currentPositionTop);
        } while (!Enum.IsDefined(typeof(MenuChoiceEnum), (int)choice));

        return (MenuChoiceEnum)choice;
    }
}
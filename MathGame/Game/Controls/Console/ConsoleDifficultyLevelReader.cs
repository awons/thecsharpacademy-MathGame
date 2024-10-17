using MathGame.ConsoleWrapper;

namespace MathGame.Game.Controls.Console;

public class ConsoleDifficultyLevelReader(IConsoleWrapper consoleWrapper) : IDifficultyLevelReader
{
    public DifficultyLevelEnum GetChoice()
    {
        int choice;
        var currentPositionLeft = System.Console.CursorLeft;
        var currentPositionTop = System.Console.CursorTop;
        do
        {
            System.Console.SetCursorPosition(currentPositionLeft, currentPositionTop);
            System.Console.Write(' ');
            System.Console.SetCursorPosition(currentPositionLeft, currentPositionTop);
            choice = (int)char.GetNumericValue(consoleWrapper.ReadKey(false).KeyChar);
        } while (!Enum.IsDefined(typeof(DifficultyLevelEnum), choice));

        return (DifficultyLevelEnum)choice;
    }
}
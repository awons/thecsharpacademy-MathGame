using MathGame.ConsoleWrapper;

namespace MathGame.Game.Controls;

public class ConsoleDifficultyLevelReader(IConsoleWrapper consoleWrapper) : IDifficultyLevelReader
{
    public DifficultyLevelEnum GetChoice()
    {
        int choice;
        var currentPositionLeft = Console.CursorLeft;
        var currentPositionTop = Console.CursorTop;
        do
        {
            Console.SetCursorPosition(currentPositionLeft, currentPositionTop);
            Console.Write(' ');
            Console.SetCursorPosition(currentPositionLeft, currentPositionTop);
            choice = (int)char.GetNumericValue(consoleWrapper.ReadKey(false).KeyChar);
        } while (!Enum.IsDefined(typeof(DifficultyLevelEnum), choice));

        return (DifficultyLevelEnum)choice;
    }
}
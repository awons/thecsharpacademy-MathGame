using MathGame.Game;

namespace MathGame.UI.Game;

public static class DifficultyLevelReader
{
    public static DifficultyLevelEnum GetChoice()
    {
        int choice;
        var currentPositionLeft = Console.CursorLeft;
        var currentPositionTop = Console.CursorTop;
        do
        {
            Console.SetCursorPosition(currentPositionLeft, currentPositionTop);
            Console.Write(' ');
            Console.SetCursorPosition(currentPositionLeft, currentPositionTop);
            choice = (int)char.GetNumericValue(Console.ReadKey().KeyChar);
        } while (!Enum.IsDefined(typeof(DifficultyLevelEnum), choice));

        return (DifficultyLevelEnum)choice;
    }
}
namespace MathGame.Game.Controls;

public class ConsoleDifficultyLevelReader : IDifficultyLevelReader
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
            choice = (int)char.GetNumericValue(Console.ReadKey().KeyChar);
        } while (!Enum.IsDefined(typeof(DifficultyLevelEnum), choice));

        return (DifficultyLevelEnum)choice;
    }
}
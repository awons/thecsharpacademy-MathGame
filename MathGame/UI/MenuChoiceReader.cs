namespace MathGame.UI;

public class MenuChoiceReader
{
    public MenuChoiceEnum GetChoice()
    {
        char choice;
        var currentPositionLeft = Console.CursorLeft;
        var currentPositionTop = Console.CursorTop;
        do
        {
            choice = Console.ReadKey().KeyChar;
            Console.SetCursorPosition(currentPositionLeft, currentPositionTop);
            Console.Write(' ');
            Console.SetCursorPosition(currentPositionLeft, currentPositionTop);
        } while (!Enum.IsDefined(typeof(MenuChoiceEnum), (int)choice));

        return (MenuChoiceEnum)choice;
    }
}
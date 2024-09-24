namespace MathGame.UI;

public class ConsoleMenuChoice : IMenuChoice
{
    public MenuChoiceEnum GetChoice()
    {
        char choice;
        var currentPositionLeft = Console.CursorLeft;
        var currentPositionTop = Console.CursorTop;
        do
        {
            choice = Console.ReadKey().KeyChar;
            Console.CursorLeft = currentPositionLeft;
            Console.CursorTop = currentPositionTop;
            Console.Write(' ');
            Console.CursorLeft = currentPositionLeft;
            Console.CursorTop = currentPositionTop;
        } while (!Enum.IsDefined(typeof(MenuChoiceEnum), (int)choice));

        return (MenuChoiceEnum)choice;
    }
}
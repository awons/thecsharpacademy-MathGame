namespace MathGame.Game.Controls.Console;

public class ConsoleAnswerReader : IAnswerReader
{
    public int GetAnswer()
    {
        var currentPositionTop = System.Console.CursorTop;
        var currentPositionLeft = System.Console.CursorLeft;
        do
        {
            if (!int.TryParse(System.Console.ReadLine(), out var answer))
            {
                System.Console.SetCursorPosition(currentPositionLeft, currentPositionTop);
                System.Console.Write(new string(' ', System.Console.WindowWidth));
                System.Console.SetCursorPosition(currentPositionLeft, currentPositionTop);
                continue;
            }

            return answer;
        } while (true);
    }
}
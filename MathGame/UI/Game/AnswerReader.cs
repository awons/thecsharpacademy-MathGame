namespace MathGame.UI.Game;

public static class AnswerReader
{
    public static int GetAnswer()
    {
        var currentPositionTop = Console.CursorTop;
        var currentPositionLeft = Console.CursorLeft;
        do
        {
            if (!int.TryParse(Console.ReadLine(), out int answer))
            {
                Console.SetCursorPosition(currentPositionLeft, currentPositionTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(currentPositionLeft, currentPositionTop);
                continue;
            }

            return answer;
        } while (true);
    }
}
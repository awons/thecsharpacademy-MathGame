using MathGame.Game;

namespace MathGame.UI.Game;

public static class SolvingTimeRenderer
{
    public static void RenderSolvingTime(GameResult gameResult)
    {
        Console.Write("It took you ");
        if (gameResult.TimeToSolve.Days > 0)
            Console.Write(
                $"{gameResult.TimeToSolve.Days}d {gameResult.TimeToSolve.Hours}h {gameResult.TimeToSolve.Minutes}m {gameResult.TimeToSolve.Seconds}s");
        else if (gameResult.TimeToSolve.Hours > 0)
            Console.Write(
                $"{gameResult.TimeToSolve.Hours}h {gameResult.TimeToSolve.Minutes}m {gameResult.TimeToSolve.Seconds}s");
        else if (gameResult.TimeToSolve.Minutes > 0)
            Console.Write($"{gameResult.TimeToSolve.Minutes}m {gameResult.TimeToSolve.Seconds}s");
        else
            Console.Write($"{gameResult.TimeToSolve.Seconds}s");

        Console.WriteLine(" to solve the problem");
    }
}
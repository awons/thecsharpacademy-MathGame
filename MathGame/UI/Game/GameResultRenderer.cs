using MathGame.Game;

namespace MathGame.UI.Game;

public static class GameResultRenderer
{
    public static void Render(GameResult gameResult)
    {
        Console.Clear();
        if (gameResult.Won())
        {
            Console.WriteLine("Congratulations! You won!");
        }
        else
        {
            var operationString = OperationToStringMapper.Map(gameResult.Operation);
            Console.WriteLine("Sorry, you lost.");
            Console.WriteLine(
                $"The result of {gameResult.Operation.GetLeftOperand()} {operationString} {gameResult.Operation.GetRightOperand()} is {gameResult.Operation.ExpectedResult()}");
        }

        SolvingTimeRenderer.RenderSolvingTime(gameResult);

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
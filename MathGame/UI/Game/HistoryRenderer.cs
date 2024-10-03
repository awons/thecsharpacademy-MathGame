using MathGame.Game;

namespace MathGame.UI.Game;

public class HistoryRenderer(IKeyAwaiter keyAwaiter)
{
    public void Render(GameHistory history)
    {
        Console.Clear();
        Console.WriteLine("Your previous games:");
        foreach (var gameResult in history)
        {
            var operationString = OperationToStringMapper.Map(gameResult.Operation);
            var resultString = gameResult.Won() ? "Won" : "Lost";
            Console.WriteLine(
                $"{gameResult.Operation.GetLeftOperand()} {operationString} {gameResult.Operation.GetRightOperand()} = {gameResult.Answer} [correct answer: {gameResult.Operation.ExpectedResult()}] {resultString}");
            SolvingTimeRenderer.RenderSolvingTime(gameResult);
            Console.WriteLine(new string('-', Console.WindowWidth));
        }

        keyAwaiter.Wait();
    }
}
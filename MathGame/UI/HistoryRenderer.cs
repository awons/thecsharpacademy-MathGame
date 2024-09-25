using MathGame.Game;

namespace MathGame.UI;

public class HistoryRenderer
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
                $"{gameResult.Operation.GetLeftOperand()} {operationString} {gameResult.Operation.GetRightOperand()} = {resultString}");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
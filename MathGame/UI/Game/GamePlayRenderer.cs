using MathGame.Game;

namespace MathGame.UI.Game;

public static class GamePlayRenderer
{
    public static void Render(GamePlay gamePlay)
    {
        Console.Clear();
        Console.WriteLine("What is the result of the following operation?");
        var operatorString = OperationToStringMapper.Map(gamePlay.Operation);
        Console.WriteLine(
            $"{gamePlay.Operation.GetLeftOperand()} {operatorString} {gamePlay.Operation.GetRightOperand()}");
    }
}
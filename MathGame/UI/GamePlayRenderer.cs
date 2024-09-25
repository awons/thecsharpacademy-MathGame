using MathGame.Game;
using MathGame.Operations;

namespace MathGame.UI;

public class GamePlayRenderer
{
    public void Render(GamePlay gamePlay)
    {
        Console.Clear();
        Console.WriteLine("What is the result of the following operation?");
        var operatorString = OperationToStringMapper.Map(gamePlay.Operation);
        Console.WriteLine(
            $"{gamePlay.Operation.GetLeftOperand()} {operatorString} {gamePlay.Operation.GetRightOperand()}");
    }
}
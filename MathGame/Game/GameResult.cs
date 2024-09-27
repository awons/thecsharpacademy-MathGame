using MathGame.Operations;
using Microsoft.VisualBasic;

namespace MathGame.Game;

public record GameResult(IOperation Operation, int Answer, TimeSpan TimeToSolve)
{
    public bool Won()
    {
        return Operation.IsCorrectAnswer(Answer);
    }
}
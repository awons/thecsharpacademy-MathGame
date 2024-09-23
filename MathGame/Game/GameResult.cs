using MathGame.Operations;

namespace MathGame.Game;

public record GameResult(IOperation Operation, int Answer)
{
    public bool Won()
    {
        return Operation.IsCorrectAnswer(Answer);
    }
}
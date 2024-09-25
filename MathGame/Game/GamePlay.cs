using MathGame.Operations;

namespace MathGame.Game;

public record GamePlay(IOperation Operation)
{
    public GameResult GiveAnswer(int answer)
    {
        return new GameResult(Operation, answer);
    }
}
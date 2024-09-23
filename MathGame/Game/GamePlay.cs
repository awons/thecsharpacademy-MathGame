using MathGame.Operations;

namespace MathGame.Game;

public class GamePlay(IOperation operation)
{
    public GameResult Answer(int answer)
    {
        return new GameResult(operation, answer);
    }
}
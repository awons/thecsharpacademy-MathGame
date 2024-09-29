using MathGame.Operations;

namespace MathGame.Game;

public class GamePlay(IOperation operation)
{
    private readonly DateTime _startTime = DateTime.Now;
    private DateTime _endTime;

    public GameResult GiveAnswer(int answer)
    {
        _endTime = DateTime.Now;
        return new GameResult(operation, answer, _endTime - _startTime);
    }
}
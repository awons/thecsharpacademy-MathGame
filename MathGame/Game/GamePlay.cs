using MathGame.Operations;

namespace MathGame.Game;

public class GamePlay
{
    private readonly DateTime _startTime;
    private DateTime _endTime;

    public IOperation Operation { get; }

    public GamePlay(IOperation operation)
    {
        Operation = operation;
        _startTime = DateTime.Now;
    }

    public GameResult GiveAnswer(int answer)
    {
        _endTime = DateTime.Now;
        return new GameResult(Operation, answer, _endTime - _startTime);
    }
}
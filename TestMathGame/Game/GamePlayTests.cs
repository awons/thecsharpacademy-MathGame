using FluentAssertions;
using MathGame.Game;
using MathGame.Operations;
using MathGame.Operations.Addition;

namespace TestMathGame.Game;

public class GamePlayTests
{
    private AdditionOperation _operation;

    [SetUp]
    public void SetUp()
    {
        _operation = new AdditionOperation(Augend.Next(100), Addend.Next(100));
    }

    [Test]
    public void WillDetectWinner()
    {
        var gamePlay = new GamePlay(_operation);
        var gamePlayResult = gamePlay.GiveAnswer(_operation.ExpectedResult());

        gamePlayResult.Won().Should().BeTrue();
    }

    [Test]
    public void WillDetectLoser()
    {
        var gamePlay = new GamePlay(_operation);
        var gamePlayResult = gamePlay.GiveAnswer(_operation.ExpectedResult() + 1);

        gamePlayResult.Won().Should().BeFalse();
    }
}
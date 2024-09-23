using FluentAssertions;
using MathGame.Game;
using MathGame.Operations.Addition;

namespace TestMathGame.Game;

public class GamePlayTests
{
    private Augend _augend;
    private Addend _addend;

    [SetUp]
    public void SetUp()
    {
        var random = new Random();
        _augend = Augend.Next(random);
        _addend = Addend.Next(random);
    }

    [Test]
    public void WillDetectWinner()
    {
        var gamePlay = new GamePlay(new AdditionOperation(_augend, _addend));

        var expectedResult = _augend.Value + _addend.Value;
        var gamePlayResult = gamePlay.Answer(expectedResult);

        gamePlayResult.Won().Should().BeTrue();
    }

    [Test]
    public void WillDetectLoser()
    {
        var gamePlay = new GamePlay(new AdditionOperation(_augend, _addend));

        var expectedResult = _augend.Value + _addend.Value;
        var gamePlayResult = gamePlay.Answer(expectedResult + 1);

        gamePlayResult.Won().Should().BeFalse();
    }
}
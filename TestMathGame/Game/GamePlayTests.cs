using FluentAssertions;
using MathGame.Game;
using MathGame.Operations.Addition;

namespace TestMathGame.Game;

public class GamePlayTests
{
    [Test]
    public void WillDetectWinner()
    {
        var random = new Random();
        var augend = Augend.Next(random);
        var addend = Addend.Next(random);
        var gamePlay = new GamePlay(new AdditionOperation(augend, addend));

        var expectedResult = augend.Value + addend.Value;
        var gamePlayResult = gamePlay.Answer(expectedResult);

        gamePlayResult.Won().Should().BeTrue();
    }

    [Test]
    public void WillDetectLoser()
    {
        var random = new Random();
        var augend = Augend.Next(random);
        var addend = Addend.Next(random);
        var gamePlay = new GamePlay(new AdditionOperation(augend, addend));

        var expectedResult = augend.Value + addend.Value;
        var gamePlayResult = gamePlay.Answer(expectedResult + 1);

        gamePlayResult.Won().Should().BeFalse();
    }
}
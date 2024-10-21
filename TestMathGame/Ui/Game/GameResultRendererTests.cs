using System.Text;
using FluentAssertions;
using MathGame.Game;
using MathGame.Operations.Addition;
using MathGame.UI;
using MathGame.UI.Game;
using NSubstitute;

namespace TestMathGame.Ui.Game;

public class GameResultRendererTests
{
    private IKeyAwaiter _keyAwaiter;
    private StringBuilder _consoleOutput;

    [SetUp]
    public void Setup()
    {
        _consoleOutput = new StringBuilder();
        var consoleOutputWriter = new StringWriter(_consoleOutput);
        Console.SetOut(consoleOutputWriter);

        _keyAwaiter = Substitute.For<IKeyAwaiter>();
        _keyAwaiter.When(x => x.Wait())
            .Do(x => { });
    }

    [Test]
    [CancelAfter(1000)]
    public void WillRenderGameResultWhenWon()
    {
        var renderer = new GameResultRenderer(_keyAwaiter);
        renderer.Render(new GameResult(new AdditionOperation(new Augend(2), new Addend(3)), 5, TimeSpan.Zero));

        var output = _consoleOutput.ToString().Split(Environment.NewLine);

        output[0].Should().Be("Congratulations! You won!");
        output[1].Should().Be("It took you 0s to solve the problem");
        output[2].Should().Be("");
    }

    [Test]
    [CancelAfter(1000)]
    public void WillRenderGameResultWhenLost()
    {
        var renderer = new GameResultRenderer(_keyAwaiter);
        renderer.Render(new GameResult(new AdditionOperation(new Augend(2), new Addend(3)), 4, TimeSpan.Zero));

        var output = _consoleOutput.ToString().Split(Environment.NewLine);

        output[0].Should().Be("Sorry, you lost.");
        output[1].Should().Be("The result of 2 + 3 is 5");
        output[2].Should().Be("It took you 0s to solve the problem");
        output[3].Should().Be("");
    }
}
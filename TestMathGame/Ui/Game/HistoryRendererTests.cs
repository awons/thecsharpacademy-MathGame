using System.Text;
using FluentAssertions;
using MathGame.Game;
using MathGame.Operations.Addition;
using MathGame.UI;
using MathGame.UI.Game;
using Moq;

namespace TestMathGame.Ui.Game;

public class HistoryRendererTests
{
    [Test]
    public void WillRenderGameHistory()
    {
        var consoleOutput = new StringBuilder();
        var consoleOutputWriter = new StringWriter(consoleOutput);
        Console.SetOut(consoleOutputWriter);

        var keyAwaiterMock = new Mock<IKeyAwaiter>();
        keyAwaiterMock.Setup(k => k.Wait());

        GameHistory history =
        [
            new GameResult(new AdditionOperation(new Augend(2), new Addend(3)), 5, TimeSpan.Zero),
            new GameResult(new AdditionOperation(new Augend(3), new Addend(4)), 6, TimeSpan.Zero)
        ];

        var renderer = new HistoryRenderer(keyAwaiterMock.Object);
        renderer.Render(history);

        var output = consoleOutput.ToString().Split(Environment.NewLine);

        output[0].Should().Be("Your previous games:");
        output[1].Should().Be("2 + 3 = 5 [correct answer: 5] Won");
        output[2].Should().Be("It took you 0s to solve the problem");
        output[3].Should().Be("");
        output[4].Should().Be("3 + 4 = 6 [correct answer: 7] Lost");
        output[5].Should().Be("It took you 0s to solve the problem");
        output[6].Should().Be("");
        output[7].Should().Be("");
    }
}
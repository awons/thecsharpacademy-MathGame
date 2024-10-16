using System.Text;
using FluentAssertions;
using MathGame.Game;
using MathGame.Operations.Addition;
using MathGame.UI.Game;

namespace TestMathGame.Ui.Game;

public class SolvingTimeRendererTests
{
    [Test]
    [TestCaseSource(nameof(_validCases))]
    public void WillRenderSolvigTime((GameResult gameResult, string expectedString) caseTuple)
    {
        var consoleOutput = new StringBuilder();
        var consoleOutputWriter = new StringWriter(consoleOutput);
        Console.SetOut(consoleOutputWriter);

        SolvingTimeRenderer.RenderSolvingTime(caseTuple.gameResult);

        var output = consoleOutput.ToString().Split(Environment.NewLine);

        output[0].Should().Be(caseTuple.expectedString);
    }

    private static (GameResult gameResult, string expectedString)[] _validCases =
    [
        (new GameResult(new AdditionOperation(new Augend(1), new Addend(1)), 2, new TimeSpan(1, 2, 3, 4)),
            "It took you 1d 2h 3m 4s to solve the problem"),
        (new GameResult(new AdditionOperation(new Augend(1), new Addend(1)), 2, new TimeSpan(2, 3, 4)),
            "It took you 2h 3m 4s to solve the problem"),
        (new GameResult(new AdditionOperation(new Augend(1), new Addend(1)), 2, new TimeSpan(0, 3, 4)),
            "It took you 3m 4s to solve the problem"),
        (new GameResult(new AdditionOperation(new Augend(1), new Addend(1)), 2, new TimeSpan(0, 0, 4)),
            "It took you 4s to solve the problem")
    ];
}
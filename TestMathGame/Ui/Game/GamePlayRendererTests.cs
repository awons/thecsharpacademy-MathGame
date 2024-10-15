using System.Text;
using FluentAssertions;
using MathGame.Game;
using MathGame.Operations.Addition;
using MathGame.UI.Game;

namespace TestMathGame.Ui.Game;

public class GamePlayRendererTests
{
    [Test]
    public void WillRenderGamePlay()
    {
        var consoleOutput = new StringBuilder();
        var consoleOutputWriter = new StringWriter(consoleOutput);
        Console.SetOut(consoleOutputWriter);

        GamePlayRenderer.Render(new GamePlay(new AdditionOperation(new Augend(2), new Addend(3))));

        var output = consoleOutput.ToString().Split(Environment.NewLine);

        output[0].Should().Be("What is the result of the following operation?");
        output[1].Should().Be("2 + 3");
        output[2].Should().Be("");
    }
}
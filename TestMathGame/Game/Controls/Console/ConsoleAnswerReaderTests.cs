using FluentAssertions;
using MathGame.Game.Controls.Console;
using NSubstitute;

namespace TestMathGame.Game.Controls.Console;

public class ConsoleAnswerReaderTests
{
    [Test]
    [CancelAfter(1000)]
    public void WillGetAnswerIfProvidedWithInteger()
    {
        var consoleInput = Substitute.For<TextReader>();
        consoleInput.ReadLine().Returns("12");
        System.Console.SetIn(consoleInput);

        var reader = new ConsoleAnswerReader();
        var answer = reader.GetAnswer();

        answer.Should().Be(12);
    }

    [Test]
    [CancelAfter(1000)]
    public void WillKeepOnAskingIfAnswerIsNotAnInteger()
    {
        var consoleInput = Substitute.For<TextReader>();
        consoleInput.ReadLine().Returns("ab", "bc", "123");
        ;
        System.Console.SetIn(consoleInput);

        var reader = new ConsoleAnswerReader();
        var answer = reader.GetAnswer();

        answer.Should().Be(123);
    }
}
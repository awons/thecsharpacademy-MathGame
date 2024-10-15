using FluentAssertions;
using MathGame.Game.Controls;
using Moq;

namespace TestMathGame.Game.Controls;

public class ConsoleAnswerReaderTests
{
    [Test]
    [CancelAfter(1000)]
    public void WillGetAnswerIfProvidedWithInteger()
    {
        var consoleInput = new Mock<TextReader>();
        consoleInput.Setup(x => x.ReadLine()).Returns("12");
        Console.SetIn(consoleInput.Object);

        var reader = new ConsoleAnswerReader();
        var answer = reader.GetAnswer();

        answer.Should().Be(12);
    }

    [Test]
    [CancelAfter(1000)]
    public void WillKeepOnAskingIfAnswerIsNotAnInteger()
    {
        var consoleInput = new Mock<TextReader>();
        var sequence = new MockSequence();
        consoleInput.InSequence(sequence).Setup(x => x.ReadLine()).Returns("ab");
        consoleInput.InSequence(sequence).Setup(x => x.ReadLine()).Returns("bc");
        consoleInput.InSequence(sequence).Setup(x => x.ReadLine()).Returns("123");
        Console.SetIn(consoleInput.Object);

        var reader = new ConsoleAnswerReader();
        var answer = reader.GetAnswer();

        answer.Should().Be(123);
    }
}
using FluentAssertions;
using MathGame.ConsoleWrapper;
using MathGame.Game.Controls;
using MathGame.Game.Controls.Console;
using Moq;

namespace TestMathGame.Game.Controls.Console;

public class ConsoleMenuChoiceReaderTests
{
    [Test]
    [TestCaseSource(nameof(_validCases))]
    public void WillReturnCorrectEnumBasedOnProvidedInput(
        (ConsoleKeyInfo input, MenuChoiceEnum expectedChoice) caseTuple)
    {
        var consoleWrapper = new Mock<IConsoleWrapper>();
        consoleWrapper.Setup(c => c.ReadKey(false)).Returns(caseTuple.input);
        var reader = new ConsoleMenuChoiceReader(consoleWrapper.Object);

        reader.GetChoice().Should().Be(caseTuple.expectedChoice);
    }

    private static (ConsoleKeyInfo input, MenuChoiceEnum expectedChoice)[] _validCases =
    [
        (new ConsoleKeyInfo('a', ConsoleKey.None, false, false, false), MenuChoiceEnum.Addition),
        (new ConsoleKeyInfo('s', ConsoleKey.None, false, false, false), MenuChoiceEnum.Subtraction),
        (new ConsoleKeyInfo('m', ConsoleKey.None, false, false, false), MenuChoiceEnum.Multiplication),
        (new ConsoleKeyInfo('d', ConsoleKey.None, false, false, false), MenuChoiceEnum.Division),
        (new ConsoleKeyInfo('h', ConsoleKey.None, false, false, false), MenuChoiceEnum.History),
        (new ConsoleKeyInfo('q', ConsoleKey.None, false, false, false), MenuChoiceEnum.Quit)
    ];

    [Test]
    public void WillKeepAskingForChoiceIfIncorrectInputProvided()
    {
        var consoleWrapper = new Mock<IConsoleWrapper>();
        var sequence = new MockSequence();
        consoleWrapper.InSequence(sequence).Setup(c => c.ReadKey(false))
            .Returns(new ConsoleKeyInfo('b', ConsoleKey.None, false, false, false));
        consoleWrapper.InSequence(sequence).Setup(c => c.ReadKey(false))
            .Returns(new ConsoleKeyInfo('1', ConsoleKey.None, false, false, false));
        consoleWrapper.InSequence(sequence).Setup(c => c.ReadKey(false))
            .Returns(new ConsoleKeyInfo('q', ConsoleKey.None, false, false, false));

        var reader = new ConsoleMenuChoiceReader(consoleWrapper.Object);

        reader.GetChoice().Should().Be(MenuChoiceEnum.Quit);
    }
}
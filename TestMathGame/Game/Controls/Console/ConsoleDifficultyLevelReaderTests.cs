using FluentAssertions;
using MathGame.ConsoleWrapper;
using MathGame.Game;
using MathGame.Game.Controls.Console;
using Moq;

namespace TestMathGame.Game.Controls.Console;

public class ConsoleDifficultyLevelReaderTests
{
    [Test]
    [TestCaseSource(nameof(_validCases))]
    public void WillReturnCorrectEnumBasedOnProvidedInput(
        (ConsoleKeyInfo input, DifficultyLevelEnum expectedResult) caseTuple)
    {
        var consoleWrapper = new Mock<IConsoleWrapper>();
        consoleWrapper.Setup(c => c.ReadKey(false)).Returns(caseTuple.input);
        var reader = new ConsoleDifficultyLevelReader(consoleWrapper.Object);

        reader.GetChoice().Should().Be(caseTuple.expectedResult);
    }

    private static (ConsoleKeyInfo, DifficultyLevelEnum)[] _validCases =
    [
        (new ConsoleKeyInfo('1', ConsoleKey.None, false, false, false), DifficultyLevelEnum.Level1),
        (new ConsoleKeyInfo('2', ConsoleKey.None, false, false, false), DifficultyLevelEnum.Level2),
        (new ConsoleKeyInfo('3', ConsoleKey.None, false, false, false), DifficultyLevelEnum.Level3),
        (new ConsoleKeyInfo('4', ConsoleKey.None, false, false, false), DifficultyLevelEnum.Level4),
        (new ConsoleKeyInfo('5', ConsoleKey.None, false, false, false), DifficultyLevelEnum.Level5)
    ];

    [Test]
    public void WillKeepAskingForChoiceIfIncorrectInputProvided()
    {
        var consoleWrapper = new Mock<IConsoleWrapper>();
        var sequence = new MockSequence();
        consoleWrapper.InSequence(sequence).Setup(c => c.ReadKey(false))
            .Returns(new ConsoleKeyInfo('a', ConsoleKey.None, false, false, false));
        consoleWrapper.InSequence(sequence).Setup(c => c.ReadKey(false))
            .Returns(new ConsoleKeyInfo('b', ConsoleKey.None, false, false, false));
        consoleWrapper.InSequence(sequence).Setup(c => c.ReadKey(false))
            .Returns(new ConsoleKeyInfo('1', ConsoleKey.None, false, false, false));

        var reader = new ConsoleDifficultyLevelReader(consoleWrapper.Object);

        reader.GetChoice().Should().Be(DifficultyLevelEnum.Level1);
    }
}
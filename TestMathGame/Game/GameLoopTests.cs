using System.Text;
using FluentAssertions;
using MathGame.Game;
using MathGame.Game.Controls;
using MathGame.UI;
using MathGame.UI.Game;
using MathGame.UI.Menu;
using Moq;

namespace TestMathGame.Game;

public class GameLoopTests
{
    private StringBuilder _consoleOutput;
    private Menu _menu;
    private IAnswerReader? _answerReader;
    private IDifficultyLevelReader? _difficultyLevelReader;
    private IMenuChoiceReader? _menuChoiceReader;
    private IKeyAwaiter? _keyAwaiter;

    [SetUp]
    public void Setup()
    {
        _consoleOutput = new StringBuilder();
        Console.SetOut(new StringWriter(_consoleOutput));

        _menu = new Menu();
    }

    [Test]
    [CancelAfter(1000)]
    public void WillShowMainMenuWhenStarted()
    {
        SetUpWillShowMainMenuWhenStarted();

        RunGameLoop();

        var firstLine = _consoleOutput.ToString().Split(Environment.NewLine).First();
        firstLine.Should().Contain("What game do you want to play?");
    }

    [Test]
    [CancelAfter(1000)]
    public void WillQuitTheGameIfQuitMenuItemChosen()
    {
        SetUpWillQuitTheGameIfQuitMenuItemChosen();

        RunGameLoop();

        var lastLine = _consoleOutput.ToString().Split(Environment.NewLine)[^2];
        lastLine.Should().Contain("Thank you for playing!");
    }

    [Test]
    [CancelAfter(1000)]
    public void WillLetUserChooseDifficultyLevel()
    {
        SetUpWillLetUserChooseDifficultyLevel();

        RunGameLoop();

        _consoleOutput.ToString().Should().Contain("Choose difficulty Level");
    }

    [Test]
    [CancelAfter(1000)]
    public void WillShowGameResults()
    {
        SetUpWillShowGameResults();

        RunGameLoop();

        _consoleOutput.ToString().Should().ContainAny(["Congratulations! You won!", "Sorry, you lost."]);
    }

    [Test]
    [CancelAfter(1000)]
    public void WillShowGameHistoryWhenRequested()
    {
        SetUpWillShowGameHistoryWhenRequested();

        RunGameLoop();

        _consoleOutput.ToString().Split(Environment.NewLine).Should().Contain("Your previous games:");
    }

    [Test]
    [CancelAfter(1000)]
    public void WillShotTimeItTookToSolveTheGame()
    {
        SetUpWillShotTimeItTookToSolveTheGame();

        RunGameLoop();

        _consoleOutput.ToString().Split(Environment.NewLine).Should()
            .ContainMatch("It took you *s to solve the problem");
    }

    private void RunGameLoop()
    {
        var loop = new GameLoop(_menu, _answerReader!, _difficultyLevelReader!,
            _menuChoiceReader!, new GameResultRenderer(_keyAwaiter!), new HistoryRenderer(_keyAwaiter!));
        loop.Run();
    }

    private void SetUpWillShowMainMenuWhenStarted()
    {
        var mock = new Mock<IMenuChoiceReader>();
        mock.Setup(reader => reader.GetChoice()).Returns(MenuChoiceEnum.Quit);
        _menuChoiceReader = mock.Object;
    }

    private void SetUpWillQuitTheGameIfQuitMenuItemChosen()
    {
        var mock = new Mock<IMenuChoiceReader>();
        mock.Setup(reader => reader.GetChoice()).Returns(MenuChoiceEnum.Quit);
        _menuChoiceReader = mock.Object;
    }

    private void SetUpWillLetUserChooseDifficultyLevel()
    {
        SetUpGamePlay([MenuChoiceEnum.Addition, MenuChoiceEnum.Quit]);
    }

    private void SetUpWillShowGameHistoryWhenRequested()
    {
        SetUpGamePlay([MenuChoiceEnum.Addition, MenuChoiceEnum.History, MenuChoiceEnum.Quit]);
    }

    private void SetUpWillShowGameResults()
    {
        SetUpGamePlay([MenuChoiceEnum.Addition, MenuChoiceEnum.Quit]);
    }

    private void SetUpWillShotTimeItTookToSolveTheGame()
    {
        SetUpGamePlay([MenuChoiceEnum.Addition, MenuChoiceEnum.Quit]);
    }

    private void SetUpGamePlay(List<MenuChoiceEnum> choices)
    {
        var menuChoiceReaderMock = new Mock<IMenuChoiceReader>();
        var sequence = new MockSequence();

        foreach (var choice in choices)
            menuChoiceReaderMock.InSequence(sequence).Setup(reader => reader.GetChoice()).Returns(choice);
        _menuChoiceReader = menuChoiceReaderMock.Object;

        var difficultyLevelReaderMock = new Mock<IDifficultyLevelReader>();
        difficultyLevelReaderMock.Setup(reader => reader.GetChoice()).Returns(DifficultyLevelEnum.Level1);
        _difficultyLevelReader = difficultyLevelReaderMock.Object;

        var answerReaderMock = new Mock<IAnswerReader>();
        answerReaderMock.Setup(reader => reader.GetAnswer()).Returns(0);
        _answerReader = answerReaderMock.Object;

        var keyAwaiterMock = new Mock<IKeyAwaiter>();
        keyAwaiterMock.Setup(awaiter => awaiter.Wait());
        _keyAwaiter = keyAwaiterMock.Object;
    }
}
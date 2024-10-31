using System.Text;
using FluentAssertions;
using MathGame.Game;
using MathGame.Game.Controls;
using MathGame.UI;
using MathGame.UI.Game;
using MathGame.UI.Menu;
using NSubstitute;

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
        SetUpWillQuitTheGameIfQuitMenuItemChosenOrUpWillShowMainMenuWhenStarted();

        RunGameLoop();

        var firstLine = _consoleOutput.ToString().Split(Environment.NewLine).First();
        firstLine.Should().Contain("What game do you want to play?");
    }

    [Test]
    [CancelAfter(1000)]
    public void WillQuitTheGameIfQuitMenuItemChosen()
    {
        SetUpWillQuitTheGameIfQuitMenuItemChosenOrUpWillShowMainMenuWhenStarted();

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

    private void SetUpWillQuitTheGameIfQuitMenuItemChosenOrUpWillShowMainMenuWhenStarted()
    {
        _menuChoiceReader = Substitute.For<IMenuChoiceReader>();
        _menuChoiceReader.GetChoice().Returns(MenuChoiceEnum.Quit);
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
        _menuChoiceReader = Substitute.For<IMenuChoiceReader>();
        _menuChoiceReader.GetChoice().Returns(choices.First(), choices.Skip(1).ToArray());

        _difficultyLevelReader = Substitute.For<IDifficultyLevelReader>();
        _difficultyLevelReader.GetChoice().Returns(DifficultyLevelEnum.Level1);

        _answerReader = Substitute.For<IAnswerReader>();
        _answerReader.GetAnswer().Returns(0);

        _keyAwaiter = Substitute.For<IKeyAwaiter>();
        _keyAwaiter.When(x => x.Wait())
            .Do(x => { });
    }
}
using System.Text;
using FluentAssertions;
using MathGame.Game;
using MathGame.Game.Controls;
using MathGame.Game.Randomizers;
using MathGame.Operations;
using MathGame.UI.Menu;
using Moq;

namespace TestMathGame.Game;

public class GameLoopTests
{
    private StringBuilder _consoleOutput;
    private OperationFactory _operationFactory;
    private Menu _menu;
    private IAnswerReader _answerReader;
    private IDifficultyLevelReader _difficultyLevelReader;
    private IMenuChoiceReader _menuChoiceReader;

    [SetUp]
    public void Setup()
    {
        _consoleOutput = new StringBuilder();
        Console.SetOut(new StringWriter(_consoleOutput));

        var random = new Random();
        _operationFactory = new OperationFactory(new AdditionRandomizer(random), new SubtractionRandomizer(random),
            new MultiplicationRandomizer(random), new DivisionRandomizer(random));
        _menu = new Menu();
    }

    [Test]
    [CancelAfter(1000)]
    public void WillShowMainMenuWhenStarted()
    {
        SetUpWillShowMainMenuWhenStarted();
        var loop = new GameLoop(_operationFactory, _menu, _answerReader, _difficultyLevelReader,
            _menuChoiceReader);
        loop.Run();

        var firstLine = _consoleOutput.ToString().Split(Environment.NewLine).First();
        firstLine.Should().Contain("What game do you want to play?");
    }

    [Test]
    [CancelAfter(1000)]
    public void WillQuitTheGameIfQuitMenuItemChosen()
    {
        SetUpWillQuitTheGameIfQuitMenuItemChosen();
        var loop = new GameLoop(_operationFactory, _menu, _answerReader, _difficultyLevelReader,
            _menuChoiceReader);
        loop.Run();

        var lastLine = _consoleOutput.ToString().Split(Environment.NewLine)[^2];
        lastLine.Should().Contain("Thank you for playing!");
    }

    private void SetUpWillQuitTheGameIfQuitMenuItemChosen()
    {
        var mock = new Mock<IMenuChoiceReader>();
        mock.Setup(reader => reader.GetChoice()).Returns(MenuChoiceEnum.Quit);
        _menuChoiceReader = mock.Object;
    }

    private void SetUpWillShowMainMenuWhenStarted()
    {
        var mock = new Mock<IMenuChoiceReader>();
        mock.Setup(reader => reader.GetChoice()).Returns(MenuChoiceEnum.Quit);
        _menuChoiceReader = mock.Object;
    }
}
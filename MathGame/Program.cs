using MathGame.Game;
using MathGame.Game.Randomizers;
using MathGame.Operations;
using MathGame.Operations.Addition;
using MathGame.Operations.Division;
using MathGame.Operations.Multiplication;
using MathGame.Operations.Subtraction;
using MathGame.UI;
using MathGame.UI.Game;
using MathGame.UI.Menu;

var menu = new Menu();
var random = new Random();
var operationFactory = new OperationFactory(new AdditionRandomizer(random), new SubtractionRandomizer(random),
    new MultiplicationRandomizer(random), new DivisionRandomizer(random));
var gameHistory = new GameHistory();
var answerReader = new AnswerReader();

do
{
    MenuRenderer.Render(menu);
    var menuChoice = MenuChoiceReader.GetChoice();
    if (menuChoice == MenuChoiceEnum.Quit)
    {
        break;
    }

    if (menuChoice == MenuChoiceEnum.History)
    {
        HistoryRenderer.Render(gameHistory);
        continue;
    }

    DifficultyLevelRenderer.Render();
    var difficultyLevel = DifficultyLevelReader.GetChoice();

    Console.Clear();
    var gamePlay =
        new GamePlay(operationFactory.Create(MenuChoiceToOperationMapper.Map(menuChoice), difficultyLevel));
    GamePlayRenderer.Render(gamePlay);
    var gameResult = gamePlay.GiveAnswer(answerReader.GetAnswer());
    gameHistory.Add(gameResult);
    GameResultRenderer.Render(gameResult);
} while (true);

Console.Clear();
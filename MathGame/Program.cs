using MathGame.Game;
using MathGame.Game.Randomizers;
using MathGame.Operations;
using MathGame.UI.Game;
using MathGame.UI.Menu;

var menu = new Menu();
var random = new Random();
var operationFactory = new OperationFactory(new AdditionRandomizer(random), new SubtractionRandomizer(random),
    new MultiplicationRandomizer(random), new DivisionRandomizer(random));
var gameHistory = new GameHistory();

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
    var gameResult = gamePlay.GiveAnswer(AnswerReader.GetAnswer());
    gameHistory.Add(gameResult);
    GameResultRenderer.Render(gameResult);
} while (true);

Console.Clear();
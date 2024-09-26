using MathGame.Game;
using MathGame.Game.Randomizers;
using MathGame.Operations;
using MathGame.Operations.Addition;
using MathGame.Operations.Division;
using MathGame.Operations.Multiplication;
using MathGame.Operations.Subtraction;
using MathGame.UI;

var menu = new Menu();
var random = new Random();
var operationFactory = new OperationFactory(new AdditionRandomizer(random), new SubtractionRandomizer(random),
    new MultiplicationRandomizer(random), new DivisionRandomizer(random));
var gameHistory = new GameHistory();
var answerReader = new AnswerReader();

do
{
    MenuRenderer.Render(menu);
    var menuChoice = new MenuChoiceReader().GetChoice();
    if (menuChoice == MenuChoiceEnum.Quit)
    {
        break;
    }

    if (menuChoice == MenuChoiceEnum.History)
    {
        HistoryRenderer.Render(gameHistory);
        continue;
    }

    Console.Clear();
    var gamePlay = new GamePlay(operationFactory.Create(MenuChoiceToOperationMapper.Map(menuChoice), DifficultyLevelEnum.Level1));
    GamePlayRenderer.Render(gamePlay);
    var gameResult = gamePlay.GiveAnswer(answerReader.GetAnswer());
    gameHistory.Add(gameResult);
    GameResultRenderer.Render(gameResult);
} while (true);

Console.Clear();
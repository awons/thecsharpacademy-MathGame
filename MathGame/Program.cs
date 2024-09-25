using MathGame.Game;
using MathGame.Operations;
using MathGame.Operations.Addition;
using MathGame.Operations.Division;
using MathGame.Operations.Multiplication;
using MathGame.Operations.Subtraction;
using MathGame.UI;

MenuChoiceEnum menuChoice;
var menu = new Menu();
var random = new Random();
var operationFactory = new OperationFactory(new AdditionRandomizer(random), new SubtractionRandomizer(random),
    new MultiplicationRandomizer(random), new DivisionRandomizer(random));
var gameHistory = new GameHistory();
var answerReader = new AnswerReader();
var gamePlayRenderer = new GamePlayRenderer();
var gameResultRenderer = new GameResultRenderer();
var historyRenderer = new HistoryRenderer();
GameResult gameResult;

do
{
    Console.Clear();
    Console.Write(menu.ToString());
    menuChoice = new MenuChoiceReader().GetChoice();
    if (menuChoice == MenuChoiceEnum.Quit)
    {
        break;
    }

    if (menuChoice == MenuChoiceEnum.History)
    {
        historyRenderer.Render(gameHistory);
        continue;
    }

    Console.Clear();
    var gamePlay = new GamePlay(operationFactory.Create(MenuChoiceToOperationMapper.Map(menuChoice)));
    gamePlayRenderer.Render(gamePlay);
    gameResult = gamePlay.GiveAnswer(answerReader.GetAnswer());
    gameHistory.Add(gameResult);
    gameResultRenderer.Render(gameResult);
} while (true);

Console.Clear();
Console.WriteLine("Thank you for playing the game! Press any key to exit.");
Console.ReadKey();
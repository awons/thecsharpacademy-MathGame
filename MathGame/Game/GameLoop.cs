using MathGame.Game.Controls;
using MathGame.Operations;
using MathGame.UI.Game;
using MathGame.UI.Menu;

namespace MathGame.Game;

public class GameLoop(
    OperationFactory operationFactory,
    Menu gameMenu,
    IAnswerReader answerReader,
    IDifficultyLevelReader difficultyLevelReader)
{
    public void Run()
    {
        var gameHistory = new GameHistory();
        do
        {
            MenuRenderer.Render(gameMenu);
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
            var difficultyLevel = difficultyLevelReader.GetChoice();

            Console.Clear();
            var gamePlay =
                new GamePlay(operationFactory.Create(MenuChoiceToOperationMapper.Map(menuChoice), difficultyLevel));
            GamePlayRenderer.Render(gamePlay);
            var gameResult = gamePlay.GiveAnswer(answerReader.GetAnswer());
            gameHistory.Add(gameResult);
            GameResultRenderer.Render(gameResult);
        } while (true);

        Console.Clear();
    }
}
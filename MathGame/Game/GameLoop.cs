using MathGame.Game.Controls;
using MathGame.Operations;
using MathGame.UI.Game;
using MathGame.UI.Menu;

namespace MathGame.Game;

public class GameLoop(
    Menu gameMenu,
    IAnswerReader answerReader,
    IDifficultyLevelReader difficultyLevelReader,
    IMenuChoiceReader menuChoiceReader,
    GameResultRenderer gameResultRenderer,
    HistoryRenderer historyRenderer
)
{
    public void Run()
    {
        var gameHistory = new GameHistory();
        do
        {
            MenuRenderer.Render(gameMenu);
            var menuChoice = menuChoiceReader.GetChoice();
            if (menuChoice == MenuChoiceEnum.Quit) break;

            if (menuChoice == MenuChoiceEnum.History)
            {
                historyRenderer.Render(gameHistory);
                continue;
            }

            DifficultyLevelRenderer.Render();
            var difficultyLevel = difficultyLevelReader.GetChoice();

            Console.Clear();
            var gamePlay =
                new GamePlay(OperationFactory.Create(MenuChoiceToOperationMapper.Map(menuChoice), difficultyLevel));
            GamePlayRenderer.Render(gamePlay);
            var gameResult = gamePlay.GiveAnswer(answerReader.GetAnswer());
            gameHistory.Add(gameResult);
            gameResultRenderer.Render(gameResult);
        } while (true);

        Console.Clear();
        Console.WriteLine("Thank you for playing!");
    }
}
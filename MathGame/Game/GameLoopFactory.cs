using MathGame.ConsoleWrapper;
using MathGame.Game.Controls;
using MathGame.Game.Controls.Console;
using MathGame.UI;
using MathGame.UI.Game;
using MathGame.UI.Menu;

namespace MathGame.Game;

public class GameLoopFactory(
    AnswerReaderFactory answerReaderFactory,
    IConsoleWrapper consoleWrapper,
    IKeyAwaiter keyAwaiter)
{
    public GameLoop Create(ControlsChoiceEnum controlsChoice)
    {
        return new GameLoop(new Menu(), answerReaderFactory.Create(controlsChoice),
            new ConsoleDifficultyLevelReader(consoleWrapper), new ConsoleMenuChoiceReader(consoleWrapper),
            new GameResultRenderer(keyAwaiter), new HistoryRenderer(keyAwaiter));
    }
}
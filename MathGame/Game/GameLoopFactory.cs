using MathGame.ConsoleWrapper;
using MathGame.Game.Controls;
using MathGame.Game.Controls.Console;
using MathGame.Game.Controls.Speech;
using MathGame.UI;
using MathGame.UI.Game;
using MathGame.UI.Menu;
using Microsoft.Extensions.Options;

namespace MathGame.Game;

public class GameLoopFactory(
    AnswerReaderFactory answerReaderFactory,
    IConsoleWrapper consoleWrapper,
    IKeyAwaiter keyAwaiter,
    IOptions<ControlsConfigurationOptions> controlsOptions)
{
    public GameLoop Create()
    {
        return new GameLoop(new Menu(), answerReaderFactory.Create(controlsOptions.Value.Choice),
            new ConsoleDifficultyLevelReader(consoleWrapper), new ConsoleMenuChoiceReader(consoleWrapper),
            new GameResultRenderer(keyAwaiter), new HistoryRenderer(keyAwaiter));
    }
}
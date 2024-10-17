using MathGame.Game.Controls.Console;
using MathGame.Game.Controls.Speech;

namespace MathGame.Game.Controls;

public class AnswerReaderFactory(Func<IEnumerable<IAnswerReader>> factory)
{
    public IAnswerReader Create(ControlsChoiceEnum choice)
    {
        var set = factory();
        return choice switch
        {
            ControlsChoiceEnum.Console => set.Where(x => x is ConsoleAnswerReader).First(),
            ControlsChoiceEnum.Speech => set.Where(x => x is SpeechAnswerReader).First(),
            _ => throw new NotImplementedException()
        };
    }
}
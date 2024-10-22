using MathGame.Game.Controls.Console;
using MathGame.Game.Controls.Speech;

namespace MathGame.Game.Controls;

public class AnswerReaderFactory(SpeechRecognizerFactory speechRecognizerFactory)
{
    public IAnswerReader Create(ControlsChoiceEnum choice)
    {
        return choice switch
        {
            ControlsChoiceEnum.Console => new ConsoleAnswerReader(),
            ControlsChoiceEnum.Speech => new SpeechAnswerReader(speechRecognizerFactory.Create()),
            _ => throw new NotImplementedException()
        };
    }
}
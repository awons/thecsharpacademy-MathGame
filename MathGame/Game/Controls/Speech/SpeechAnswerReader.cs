using Microsoft.CognitiveServices.Speech;

namespace MathGame.Game.Controls.Speech;

public class SpeechAnswerReader(SpeechRecognizer recognizer) : IAnswerReader
{
    public int GetAnswer()
    {
        do
        {
            var result = recognizer.RecognizeOnceAsync().Result;
            if (result.Reason == ResultReason.Canceled)
            {
                System.Console.WriteLine($"CANCELED: Reason={result.Reason}");
                continue;
            }

            if (result.Reason != ResultReason.RecognizedSpeech)
            {
                System.Console.WriteLine("Speech could not be recognized.");
                continue;
            }

            if (!int.TryParse(result.Text.Substring(0, result.Text.Length - 1), out var answer))
            {
                System.Console.WriteLine($"Answer must be an integer but got [{result.Text}]");
                continue;
            }

            return answer;
        } while (true);
    }
}
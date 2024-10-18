using Microsoft.CognitiveServices.Speech;

namespace MathGame.Game.Controls.Speech;

public class SpeechDifficultyLevelReader(SpeechRecognizer recognizer) : IDifficultyLevelReader
{
    public DifficultyLevelEnum GetChoice()
    {
        var choice = -1;

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

            if (result.Text.Length > 0)
            {
                System.Console.WriteLine($"Difficulty leve not recognized.");
                continue;
            }

            choice = (int)char.GetNumericValue(result.Text[0]);
        } while (!Enum.IsDefined(typeof(DifficultyLevelEnum), choice));

        return (DifficultyLevelEnum)choice;
    }
}
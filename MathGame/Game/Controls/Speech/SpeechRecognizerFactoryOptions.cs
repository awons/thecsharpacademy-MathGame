namespace MathGame.Game.Controls.Speech;

public record SpeechRecognizerFactoryOptions
{
    public const string SpeechRecognizer = "SpeechRecognizer";

    public string SubscriptionKey { get; init; } = string.Empty;
    public string Region { get; init; } = string.Empty;
}
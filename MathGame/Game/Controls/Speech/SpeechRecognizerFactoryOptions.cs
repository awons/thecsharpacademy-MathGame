namespace MathGame.Game.Controls.Speech;

public sealed record SpeechRecognizerFactoryOptions
{
    public const string Key = "SpeechRecognizer";

    public string SubscriptionKey { get; init; } = string.Empty;
    public string Region { get; init; } = string.Empty;
}
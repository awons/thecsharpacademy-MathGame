namespace MathGame.Game.Controls;

public sealed record ControlsConfigurationOptions
{
    public static string Key = "ControlsConfiguration";

    public string Controls { get; init; } = string.Empty;

    public ControlsChoiceEnum Choice =>
        Controls switch
        {
            "Speech" => ControlsChoiceEnum.Speech,
            _ => ControlsChoiceEnum.Console
        };
}
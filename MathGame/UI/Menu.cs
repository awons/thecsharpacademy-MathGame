namespace MathGame.UI;

public record Menu
{
    private const char ChoiceAddition = 'a';
    private const char ChoiceSubtraction = 's';
    private const char ChoiceMultiplication = 'm';
    private const char ChoiceDivision = 'd';
    private const char ChoiceHistory = 'h';
    private const char ChoiceQuit = 'q';

    public override string ToString()
    {
        return $@"What game do you want to play?
{ChoiceAddition}: Addition
{ChoiceSubtraction}: Subtraction
{ChoiceMultiplication}: Multiplication
{ChoiceDivision}: Division
{ChoiceHistory}: History
{ChoiceQuit}: Quit
";
    }
}
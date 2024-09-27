namespace MathGame.UI.Menu;

public class Menu
{
    private const char ChoiceAddition = 'a';
    private const char ChoiceSubtraction = 's';
    private const char ChoiceMultiplication = 'm';
    private const char ChoiceDivision = 'd';
    private const char ChoiceRandom = 'r';
    private const char ChoiceHistory = 'h';
    private const char ChoiceQuit = 'q';

    public override string ToString()
    {
        return $@"What game do you want to play?
{ChoiceAddition}: Addition
{ChoiceSubtraction}: Subtraction
{ChoiceMultiplication}: Multiplication
{ChoiceDivision}: Division
{ChoiceRandom}: Random
{ChoiceHistory}: History
{ChoiceQuit}: Quit
------------------------------------------------
";
    }
}
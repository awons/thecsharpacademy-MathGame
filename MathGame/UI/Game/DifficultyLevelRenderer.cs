namespace MathGame.UI.Game;

public static class DifficultyLevelRenderer
{
    public static void Render()
    {
        Console.Clear();
        Console.WriteLine("Choose difficulty Level");
        Console.WriteLine("1) Easy");
        Console.WriteLine("2) Normal");
        Console.WriteLine("3) Hard");
        Console.WriteLine("4) Expert");
        Console.WriteLine("5) Master");
    }
}
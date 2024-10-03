namespace MathGame.UI;

public class ConsoleKeyAwaiter : IKeyAwaiter
{
    public void Wait()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
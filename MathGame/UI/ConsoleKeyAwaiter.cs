using MathGame.ConsoleWrapper;

namespace MathGame.UI;

public class ConsoleKeyAwaiter(IConsoleWrapper consoleWrapper) : IKeyAwaiter
{
    public void Wait()
    {
        Console.WriteLine("Press any key to continue...");
        consoleWrapper.ReadKey(false);
    }
}
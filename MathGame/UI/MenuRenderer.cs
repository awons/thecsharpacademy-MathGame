namespace MathGame.UI;

public class MenuRenderer
{
    public static void Render(Menu menu)
    {
        Console.Clear();
        Console.Write(menu.ToString());
    }
}
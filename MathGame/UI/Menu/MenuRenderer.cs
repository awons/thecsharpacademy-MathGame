namespace MathGame.UI.Menu;

public static class MenuRenderer
{
    public static void Render(UI.Menu.Menu menu)
    {
        Console.Clear();
        Console.Write(menu.ToString());
    }
}
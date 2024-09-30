using MathGame.UI.Menu;

namespace MathGame.Game.Controls;

public interface IMenuChoiceReader
{
    public MenuChoiceEnum GetChoice();
}
using MathGame.Game.Controls;
using MathGame.Operations;

namespace MathGame.UI.Menu;

public static class MenuChoiceToOperationMapper
{
    public static OperationsEnum Map(MenuChoiceEnum menuChoice)
    {
        return menuChoice switch
        {
            MenuChoiceEnum.Addition => OperationsEnum.Addition,
            MenuChoiceEnum.Subtraction => OperationsEnum.Subtraction,
            MenuChoiceEnum.Multiplication => OperationsEnum.Multiplication,
            MenuChoiceEnum.Division => OperationsEnum.Division,
            MenuChoiceEnum.Random => GetRandomEnum(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private static OperationsEnum GetRandomEnum()
    {
        var values = Enum.GetValues(typeof(OperationsEnum));
        var randomValue = values.GetValue(Random.Shared.Next(values.Length));
        return (OperationsEnum)randomValue!;
    }
}
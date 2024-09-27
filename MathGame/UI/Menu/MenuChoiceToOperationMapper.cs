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
        Array values = Enum.GetValues(typeof(OperationsEnum));
        Random random = new Random();
        return (OperationsEnum)values.GetValue(random.Next(values.Length));
    }
}
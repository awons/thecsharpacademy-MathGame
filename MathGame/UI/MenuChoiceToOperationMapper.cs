using MathGame.Operations;

namespace MathGame.UI;

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
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
using MathGame.Operations;

namespace MathGame.UI.Game;

public static class OperationToStringMapper
{
    public static string Map(IOperation operation)
    {
        return operation.GetOperationType() switch
        {
            OperationsEnum.Addition => "+",
            OperationsEnum.Subtraction => "-",
            OperationsEnum.Division => "/",
            OperationsEnum.Multiplication => "*",
            _ => throw new NotImplementedException()
        };
    }
}
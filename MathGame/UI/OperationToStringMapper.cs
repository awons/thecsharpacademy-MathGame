using MathGame.Operations;

namespace MathGame.UI;

public class OperationToStringMapper
{
    public static string Map(IOperation operation)
    {
        return operation.GetOperationType() switch
        {
            OperationsEnum.Addition => "+",
            OperationsEnum.Subtraction => "-",
            OperationsEnum.Division => "/",
            OperationsEnum.Multiplication => "*",
        };
    }
}
namespace MathGame.Operations.Division;

public record DivisionOperation(Divident Divident, Divisor Divisor) : IOperation
{
    public int ExpectedResult()
    {
        return Divident.Value / Divisor.Value;
    }

    public OperationsEnum GetOperationType()
    {
        return OperationsEnum.Division;
    }

    public int GetLeftOperand()
    {
        return Divident.Value;
    }

    public int GetRightOperand()
    {
        return Divisor.Value;
    }
}
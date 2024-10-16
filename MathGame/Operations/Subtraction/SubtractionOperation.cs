namespace MathGame.Operations.Subtraction;

public record SubtractionOperation(Minuend Minuend, Subtrahend Subtrahend) : IOperation
{
    public int ExpectedResult()
    {
        return Minuend.Value - Subtrahend.Value;
    }

    public OperationsEnum GetOperationType()
    {
        return OperationsEnum.Subtraction;
    }

    public int GetLeftOperand()
    {
        return Minuend.Value;
    }

    public int GetRightOperand()
    {
        return Subtrahend.Value;
    }
}
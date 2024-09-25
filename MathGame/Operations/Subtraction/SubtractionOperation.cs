namespace MathGame.Operations.Subtraction;

public record SubtractionOperation(Minuend Minuend, Subtrahend Subtrahend) : IOperation
{
    public int ExpectedResult() => Minuend.Value - Subtrahend.Value;

    public OperationsEnum GetOperationType() => OperationsEnum.Subtraction;

    public int GetLeftOperand()
    {
        return Minuend.Value;
    }

    public int GetRightOperand()
    {
        return Subtrahend.Value;
    }
}
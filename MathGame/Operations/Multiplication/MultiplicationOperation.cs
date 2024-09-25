namespace MathGame.Operations.Multiplication;

public record MultiplicationOperation(Multiplier Multiplier, Multiplicand Multiplicand) : IOperation
{
    public int ExpectedResult() => Multiplier.Value * Multiplicand.Value;

    public OperationsEnum GetOperationType() => OperationsEnum.Multiplication;

    public int GetLeftOperand()
    {
        return Multiplier.Value;
    }

    public int GetRightOperand()
    {
        return Multiplicand.Value;
    }
}
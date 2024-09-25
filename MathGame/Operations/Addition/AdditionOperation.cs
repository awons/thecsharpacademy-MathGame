namespace MathGame.Operations.Addition;

public record AdditionOperation(Augend Augend, Addend Addend) : IOperation
{
    public int ExpectedResult() => Augend.Value + Addend.Value;

    public OperationsEnum GetOperationType() => OperationsEnum.Addition;

    public int GetLeftOperand()
    {
        return Augend.Value;
    }

    public int GetRightOperand()
    {
        return Addend.Value;
    }
}
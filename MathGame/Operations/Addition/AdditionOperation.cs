namespace MathGame.Operations.Addition;

public record AdditionOperation(Augend Augend, Addend Addend) : IOperation
{
    public int ExpectedResult() => Augend.Value + Addend.Value;
}
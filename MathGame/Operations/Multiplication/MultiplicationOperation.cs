namespace MathGame.Operations.Multiplication;

public record MultiplicationOperation(Multiplier Multiplier, Multiplicand Multiplicand) : IOperation
{
    public int ExpectedResult() => Multiplier.Value * Multiplicand.Value;
}
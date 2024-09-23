namespace MathGame.Operations.Subtraction;

public record SubtractionOperation(Minuend Minuend, Subtrahend Subtrahend) : IOperation
{
    public int ExpectedResult() => Minuend.Value - Subtrahend.Value;
}
namespace MathGame.Operations.Division;

public record DivisionOperation(Divident Divident, Divisor Divisor) : IOperation
{
    public int ExpectedResult() => Divident.Value / Divisor.Value;
}
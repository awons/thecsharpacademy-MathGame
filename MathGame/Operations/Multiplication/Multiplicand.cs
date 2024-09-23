namespace MathGame.Operations.Multiplication;

public record Multiplicand
{
    private const int MinValue = 1;
    private const int MaxValue = 10;

    private Multiplicand(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public static Multiplicand Next(Random random)
    {
        return new Multiplicand(random.Next(MinValue, MaxValue));
    }
}
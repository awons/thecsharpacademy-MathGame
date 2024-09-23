namespace MathGame.Operations.Subtraction;

public record Minuend
{
    private const int MinValue = 1;
    private const int MaxValue = 100;

    private Minuend(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public static Minuend Next(Random random)
    {
        return new Minuend(random.Next(MinValue, MaxValue));
    }
}
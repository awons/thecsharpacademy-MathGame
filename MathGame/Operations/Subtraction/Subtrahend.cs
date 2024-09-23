namespace MathGame.Operations.Subtraction;

public record Subtrahend
{
    private const int MinValue = 1;
    private const int MaxValue = 100;

    private Subtrahend(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public static Subtrahend Next(Random random)
    {
        return new Subtrahend(random.Next(MinValue, MaxValue));
    }
}
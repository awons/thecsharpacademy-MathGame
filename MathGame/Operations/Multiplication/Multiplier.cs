namespace MathGame.Operations.Multiplication;

public record Multiplier
{
    private const int MinValue = 1;
    private const int MaxValue = 10;

    private Multiplier(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public static Multiplier Next(Random random)
    {
        return new Multiplier(random.Next(MinValue, MaxValue));
    }
}
namespace MathGame.Operations.Division;

public record Divisor
{
    private const int MinValue = 1;
    private const int MaxValue = 100;

    private Divisor(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public static Divisor Next(Random random)
    {
        return new Divisor(random.Next(MinValue, MaxValue));
    }
}
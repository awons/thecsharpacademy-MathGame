namespace MathGame.Operations.Multiplication;

public record Multiplier
{
    private const int MinValue = 1;

    private Multiplier(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public static Multiplier Next(Random random, int maxValue)
    {
        return new Multiplier(random.Next(MinValue, maxValue));
    }
}
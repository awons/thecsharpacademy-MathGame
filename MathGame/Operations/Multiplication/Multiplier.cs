namespace MathGame.Operations.Multiplication;

public record Multiplier
{
    private Multiplier(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public static Multiplier Next(Random random, int minValue, int maxValue)
    {
        return new Multiplier(random.Next(minValue, maxValue));
    }
}
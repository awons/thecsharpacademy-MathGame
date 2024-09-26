namespace MathGame.Operations.Subtraction;

public record Subtrahend
{
    private Subtrahend(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public static Subtrahend Next(Random random, int minValue, int maxValue)
    {
        return new Subtrahend(random.Next(minValue, maxValue));
    }
}
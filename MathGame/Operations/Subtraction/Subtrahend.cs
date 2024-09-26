namespace MathGame.Operations.Subtraction;

public record Subtrahend
{
    private Subtrahend(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public static Subtrahend Next(Random random, int maxValue)
    {
        return new Subtrahend(random.Next(1, maxValue));
    }
}
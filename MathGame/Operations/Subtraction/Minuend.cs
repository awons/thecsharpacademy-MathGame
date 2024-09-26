namespace MathGame.Operations.Subtraction;

public record Minuend
{
    private Minuend(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public static Minuend Next(Random random, int maxValue)
    {
        return new Minuend(random.Next(1, maxValue));
    }
}
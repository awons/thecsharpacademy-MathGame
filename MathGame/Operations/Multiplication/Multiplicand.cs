namespace MathGame.Operations.Multiplication;

public record Multiplicand
{
    private Multiplicand(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public static Multiplicand Next(Random random, int minValue, int maxValue)
    {
        return new Multiplicand(random.Next(minValue, maxValue));
    }
}
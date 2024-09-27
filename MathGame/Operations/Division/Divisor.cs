namespace MathGame.Operations.Division;

public record Divisor
{
    private Divisor(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public static Divisor Next(Random random, int minValue, int maxValue)
    {
        return new Divisor(random.Next(minValue, maxValue));
    }
}
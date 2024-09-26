namespace MathGame.Operations.Division;

public record Divisor
{
    private Divisor(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public static Divisor Next(Random random, int maxValue)
    {
        return new Divisor(random.Next(1, maxValue));
    }
}
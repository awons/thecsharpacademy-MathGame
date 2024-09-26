namespace MathGame.Operations.Addition;

public record Addend
{
    private Addend(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public static Addend Next(Random random, int minValue, int maxValue)
    {
        return new Addend(random.Next(minValue, maxValue));
    }
}
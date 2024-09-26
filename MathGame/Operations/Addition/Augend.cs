namespace MathGame.Operations.Addition;

public record Augend
{
    private Augend(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public static Augend Next(Random random, int minValue, int maxValue)
    {
        return new Augend(random.Next(minValue, maxValue));
    }
}
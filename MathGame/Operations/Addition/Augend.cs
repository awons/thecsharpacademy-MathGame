namespace MathGame.Operations.Addition;

public record Augend
{
    private Augend(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public static Augend Next(Random random, int maxValue)
    {
        return new Augend(random.Next(1, maxValue));
    }
}
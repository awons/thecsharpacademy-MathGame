namespace MathGame.Operations.Addition;

public record Augend
{
    private const int MinValue = 1;
    private const int MaxValue = 100;

    private Augend(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public static Augend Next(Random random)
    {
        return new Augend(random.Next(MinValue, MaxValue));
    }
}
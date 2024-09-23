namespace MathGame.Operations.Addition;

public record Addend
{
    private const int MinValue = 1;
    private const int MaxValue = 100;

    private Addend(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public static Addend Next(Random random)
    {
        return new Addend(random.Next(MinValue, MaxValue));
    }
}
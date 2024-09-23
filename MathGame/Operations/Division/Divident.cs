namespace MathGame.Operations.Division;

public record Divident
{
    private const int MinValue = 0;
    private const int MaxValue = 100;

    private Divident(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public static Divident Next(Random random)
    {
        return new Divident(random.Next(MinValue, MaxValue));
    }
}
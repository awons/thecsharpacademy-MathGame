namespace MathGame.Operations.Division;

public record Divident
{
    private Divident(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public static Divident Next(Random random, int maxValue)
    {
        return new Divident(random.Next(0, maxValue));
    }
}
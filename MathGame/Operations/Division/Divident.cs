namespace MathGame.Operations.Division;

public record Divident(int Value)
{
    public static Divident Next(Random random, int minValue, int maxValue)
    {
        return new Divident(random.Next(minValue, maxValue));
    }
}
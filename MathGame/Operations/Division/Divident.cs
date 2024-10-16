namespace MathGame.Operations.Division;

public record Divident(int Value)
{
    public static Divident Next(int minValue, int maxValue)
    {
        return new Divident(Random.Shared.Next(minValue, maxValue));
    }
}
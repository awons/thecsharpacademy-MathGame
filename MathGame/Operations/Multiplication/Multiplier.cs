namespace MathGame.Operations.Multiplication;

public record Multiplier(int Value)
{
    public static Multiplier Next(int minValue, int maxValue)
    {
        return new Multiplier(Random.Shared.Next(minValue, maxValue));
    }
}
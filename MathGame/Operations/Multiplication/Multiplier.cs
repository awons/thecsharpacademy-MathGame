namespace MathGame.Operations.Multiplication;

public record Multiplier(int Value)
{
    public static Multiplier Next(Random random, int minValue, int maxValue)
    {
        return new Multiplier(random.Next(minValue, maxValue));
    }
}
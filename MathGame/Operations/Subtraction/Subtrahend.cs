namespace MathGame.Operations.Subtraction;

public record Subtrahend(int Value)
{
    public static Subtrahend Next(Random random, int maxValue)
    {
        return new Subtrahend(random.Next(1, maxValue));
    }
}
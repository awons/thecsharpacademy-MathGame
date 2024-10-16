namespace MathGame.Operations.Subtraction;

public record Subtrahend(int Value)
{
    public static Subtrahend Next(int maxValue)
    {
        return new Subtrahend(Random.Shared.Next(1, maxValue));
    }
}
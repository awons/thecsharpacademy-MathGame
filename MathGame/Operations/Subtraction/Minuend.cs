namespace MathGame.Operations.Subtraction;

public record Minuend(int Value)
{
    public static Minuend Next(int maxValue)
    {
        return new Minuend(Random.Shared.Next(1, maxValue));
    }
}
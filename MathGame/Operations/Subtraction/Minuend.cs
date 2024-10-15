namespace MathGame.Operations.Subtraction;

public record Minuend(int Value)
{
    public static Minuend Next(Random random, int maxValue)
    {
        return new Minuend(random.Next(1, maxValue));
    }
}
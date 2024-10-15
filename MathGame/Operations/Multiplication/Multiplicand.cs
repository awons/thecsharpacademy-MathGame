namespace MathGame.Operations.Multiplication;

public record Multiplicand(int Value)
{
    public static Multiplicand Next(Random random, int minValue, int maxValue)
    {
        return new Multiplicand(random.Next(minValue, maxValue));
    }
}
namespace MathGame.Operations.Multiplication;

public record Multiplicand(int Value)
{
    public static Multiplicand Next(int minValue, int maxValue)
    {
        return new Multiplicand(Random.Shared.Next(minValue, maxValue));
    }
}
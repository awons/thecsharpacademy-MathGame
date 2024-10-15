namespace MathGame.Operations.Division;

public record Divisor(int Value)
{
    public static Divisor Next(Random random, int minValue, int maxValue)
    {
        return new Divisor(random.Next(minValue, maxValue));
    }
}
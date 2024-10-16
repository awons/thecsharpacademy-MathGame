namespace MathGame.Operations.Division;

public record Divisor(int Value)
{
    public static Divisor Next(int minValue, int maxValue)
    {
        return new Divisor(Random.Shared.Next(minValue, maxValue));
    }
}
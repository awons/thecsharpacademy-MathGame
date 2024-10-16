namespace MathGame.Operations.Addition;

public record Addend(int Value)
{
    public static Addend Next(int maxValue)
    {
        return new Addend(Random.Shared.Next(1, maxValue));
    }
}
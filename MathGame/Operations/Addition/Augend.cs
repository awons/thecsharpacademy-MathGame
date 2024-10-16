namespace MathGame.Operations.Addition;

public record Augend(int Value)
{
    public static Augend Next(int maxValue)
    {
        return new Augend(Random.Shared.Next(1, maxValue));
    }
}
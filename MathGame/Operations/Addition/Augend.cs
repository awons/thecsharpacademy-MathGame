namespace MathGame.Operations.Addition;

public record Augend(int Value)
{
    public static Augend Next(Random random, int maxValue)
    {
        return new Augend(random.Next(1, maxValue));
    }
}
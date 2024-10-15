namespace MathGame.Operations.Addition;

public record Addend(int Value)
{
    public static Addend Next(Random random, int maxValue)
    {
        return new Addend(random.Next(1, maxValue));
    }
}
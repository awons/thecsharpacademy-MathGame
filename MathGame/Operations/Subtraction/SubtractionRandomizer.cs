namespace MathGame.Operations.Subtraction;

public class SubtractionRandomizer(Random random)
{
    public SubtractionOperation Next()
    {
        return new SubtractionOperation(Minuend.Next(random), Subtrahend.Next(random));
    }
}
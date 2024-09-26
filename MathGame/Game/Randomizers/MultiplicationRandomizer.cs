using MathGame.Operations.Multiplication;

namespace MathGame.Game.Randomizers;

public class MultiplicationRandomizer(Random random)
{
    public MultiplicationOperation Next()
    {
        return new MultiplicationOperation(Multiplier.Next(random), Multiplicand.Next(random));
    }
}
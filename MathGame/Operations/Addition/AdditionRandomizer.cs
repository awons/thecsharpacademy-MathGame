namespace MathGame.Operations.Addition;

public class AdditionRandomizer(Random random)
{
    public AdditionOperation Next()
    {
        return new AdditionOperation(Augend.Next(random), Addend.Next(random));
    }
}
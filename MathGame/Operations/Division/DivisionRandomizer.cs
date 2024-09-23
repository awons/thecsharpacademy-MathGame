namespace MathGame.Operations.Division;

public class DivisionRandomizer
{
    private Random _random;

    public DivisionRandomizer(Random random)
    {
        _random = random;
    }

    public DivisionOperation Next()
    {
        Divident divident;
        Divisor divisor;
        do
        {
            divident = Divident.Next(_random);
            divisor = Divisor.Next(_random);
        } while (divident.Value % divisor.Value != 0);

        return new DivisionOperation(Divident.Next(_random), Divisor.Next(_random));
    }
}
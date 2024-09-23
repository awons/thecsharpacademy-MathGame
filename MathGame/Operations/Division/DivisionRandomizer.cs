namespace MathGame.Operations.Division;

public class DivisionRandomizer(Random random)
{
    public DivisionOperation Next()
    {
        Divident divident;
        Divisor divisor;
        do
        {
            divident = Divident.Next(random);
            divisor = Divisor.Next(random);
        } while (divident.Value % divisor.Value != 0);

        return new DivisionOperation(divident, divisor);
    }
}
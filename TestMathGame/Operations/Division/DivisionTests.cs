using FluentAssertions;
using MathGame.Operations.Division;

namespace TestMathGame.Operations.Division;

public class DivisionTests
{
    [Test]
    public void WillReturnCorrectResult()
    {
        var random = new Random();
        var divident = Divident.Next(random, 100);
        var divisor = Divisor.Next(random, 100);
        var operation = new DivisionOperation(divident, divisor);

        operation.ExpectedResult().Should().Be(divident.Value / divisor.Value);
    }
}
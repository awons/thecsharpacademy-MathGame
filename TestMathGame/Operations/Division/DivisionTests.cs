using FluentAssertions;
using MathGame.Operations.Division;

namespace TestMathGame.Operations.Division;

public class DivisionTests
{
    [Test]
    public void WillReturnCorrectResult()
    {
        var divident = Divident.Next(1, 100);
        var divisor = Divisor.Next(1, 100);
        var operation = new DivisionOperation(divident, divisor);

        operation.ExpectedResult().Should().Be(divident.Value / divisor.Value);
    }
}
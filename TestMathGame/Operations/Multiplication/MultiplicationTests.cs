using FluentAssertions;
using MathGame.Operations.Multiplication;

namespace TestMathGame.Operations.Multiplication;

public class MultiplicationTests
{
    [Test]
    public void WillReturnCorrectResult()
    {
        var multiplier = Multiplier.Next(1, 10);
        var multiplicand = Multiplicand.Next(1, 10);
        var operation = new MultiplicationOperation(multiplier, multiplicand);

        operation.ExpectedResult().Should().Be(multiplier.Value * multiplicand.Value);
    }
}
using FluentAssertions;
using MathGame.Operations.Multiplication;

namespace TestMathGame.Operations.Multiplication;

public class MultiplicationTests
{
    [Test]
    public void WillReturnCorrectResult()
    {
        var random = new Random();
        var multiplier = Multiplier.Next(random);
        var multiplicand = Multiplicand.Next(random);
        var operation = new MultiplicationOperation(multiplier, multiplicand);

        operation.ExpectedResult().Should().Be(multiplier.Value * multiplicand.Value);
    }
}
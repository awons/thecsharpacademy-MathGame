using FluentAssertions;
using MathGame.Operations.Subtraction;

namespace TestMathGame.Operations.Subtraction;

public class SubtractionTests
{
    [Test]
    public void WillReturnCorrectResult()
    {
        var random = new Random();
        var minuend = Minuend.Next(random, 1, 100);
        var subtrahend = Subtrahend.Next(random, 1, 100);
        var operation = new SubtractionOperation(minuend, subtrahend);

        operation.ExpectedResult().Should().Be(minuend.Value - subtrahend.Value);
    }
}
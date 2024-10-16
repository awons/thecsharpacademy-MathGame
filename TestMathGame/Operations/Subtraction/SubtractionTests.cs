using FluentAssertions;
using MathGame.Operations.Subtraction;

namespace TestMathGame.Operations.Subtraction;

public class SubtractionTests
{
    [Test]
    public void WillReturnCorrectResult()
    {
        var minuend = Minuend.Next(100);
        var subtrahend = Subtrahend.Next(100);
        var operation = new SubtractionOperation(minuend, subtrahend);

        operation.ExpectedResult().Should().Be(minuend.Value - subtrahend.Value);
    }
}
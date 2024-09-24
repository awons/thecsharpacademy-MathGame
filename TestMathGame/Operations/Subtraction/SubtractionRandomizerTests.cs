using FluentAssertions;
using MathGame.Operations.Subtraction;

namespace TestMathGame.Operations.Subtraction;

public class SubtractionRandomizerTests
{
    [Test]
    public void WillGenerateRandomOperations()
    {
        var random = new Random(1);
        var operation1 = new SubtractionRandomizer(random).Next();

        random = new Random(2);
        var operation2 = new SubtractionRandomizer(random).Next();

        operation1.ExpectedResult().Should().NotBe(operation2.ExpectedResult());
    }

    [Test]
    public void WillGenerateOperationWithSameResultIfSeedIsTheSame()
    {
        var random = new Random(1);
        var operation1 = new SubtractionRandomizer(random).Next();

        random = new Random(1);
        var operation2 = new SubtractionRandomizer(random).Next();

        operation1.ExpectedResult().Should().Be(operation2.ExpectedResult());
    }
}
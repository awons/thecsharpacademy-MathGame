using FluentAssertions;
using MathGame.Operations.Addition;

namespace TestMathGame.Operations.Addition;

public class AdditionTests
{
    [Test]
    public void WillReturnCorrectResult()
    {
        var random = new Random();
        var augend = Augend.Next(random, 100);
        var addend = Addend.Next(random, 100);
        var operation = new AdditionOperation(augend, addend);

        operation.ExpectedResult().Should().Be(augend.Value + addend.Value);
    }
}
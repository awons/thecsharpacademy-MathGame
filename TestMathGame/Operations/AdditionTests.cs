using FluentAssertions;
using MathGame.Operations.Addition;

namespace TestMathGame.Operations;

public class AdditionTests
{
    [Test]
    public void WillReturnCorrectResult()
    {
        var random = new Random();
        var augend = Augend.Next(random);
        var addend = Addend.Next(random);
        var operation = new AdditionOperation(augend, addend);

        operation.ExpectedResult().Should().Be(augend.Value + addend.Value);
    }
}
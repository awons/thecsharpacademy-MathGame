using FluentAssertions;
using MathGame.Game;
using MathGame.Game.Randomizers;

namespace TestMathGame.Game.Randomizers;

public class MultiplicationRandomizerTests
{
    [Test]
    public void WillGenerateRandomOperations()
    {
        var random = new Random(1);
        var operation1 = new MultiplicationRandomizer(random).Next(DifficultyLevelEnum.Level1);

        random = new Random(2);
        var operation2 = new MultiplicationRandomizer(random).Next(DifficultyLevelEnum.Level1);

        operation1.ExpectedResult().Should().NotBe(operation2.ExpectedResult());
    }

    [Test]
    public void WillGenerateOperationWithSameResultIfSeedIsTheSame()
    {
        var random = new Random(1);
        var operation1 = new MultiplicationRandomizer(random).Next(DifficultyLevelEnum.Level1);

        random = new Random(1);
        var operation2 = new MultiplicationRandomizer(random).Next(DifficultyLevelEnum.Level1);

        operation1.ExpectedResult().Should().Be(operation2.ExpectedResult());
    }

    [TestCase(DifficultyLevelEnum.Level1, 25)]
    [TestCase(DifficultyLevelEnum.Level2, 100)]
    [TestCase(DifficultyLevelEnum.Level3, 255)]
    [TestCase(DifficultyLevelEnum.Level4, 400)]
    [TestCase(DifficultyLevelEnum.Level5, 625)]
    public void ResultWillBeInRangeForExpectedDifficultyLevel(DifficultyLevelEnum difficultyLevel, int maxResult)
    {
        var random = new Random();
        for (var i = 0; i < 1000; i++)
        {
            var operation = new MultiplicationRandomizer(random).Next(difficultyLevel);
            operation.ExpectedResult().Should().BeGreaterOrEqualTo(1);
            operation.ExpectedResult().Should().BeLessOrEqualTo(maxResult);
        }
    }
}
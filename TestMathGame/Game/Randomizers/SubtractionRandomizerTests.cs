using FluentAssertions;
using MathGame.Game;
using MathGame.Game.Randomizers;

namespace TestMathGame.Game.Randomizers;

public class SubtractionRandomizerTests
{
    [Test]
    public void WillGenerateRandomOperations()
    {
        var random = new Random(1);
        var operation1 = new SubtractionRandomizer(random).Next(DifficultyLevelEnum.Level1);

        random = new Random(2);
        var operation2 = new SubtractionRandomizer(random).Next(DifficultyLevelEnum.Level1);

        operation1.ExpectedResult().Should().NotBe(operation2.ExpectedResult());
    }

    [Test]
    public void WillGenerateOperationWithSameResultIfSeedIsTheSame()
    {
        var random = new Random(1);
        var operation1 = new SubtractionRandomizer(random).Next(DifficultyLevelEnum.Level1);

        random = new Random(1);
        var operation2 = new SubtractionRandomizer(random).Next(DifficultyLevelEnum.Level1);

        operation1.ExpectedResult().Should().Be(operation2.ExpectedResult());
    }

    [TestCase(DifficultyLevelEnum.Level1, -9, 9)]
    [TestCase(DifficultyLevelEnum.Level2, -19, 19)]
    [TestCase(DifficultyLevelEnum.Level3, -39, 39)]
    [TestCase(DifficultyLevelEnum.Level4, -79, 79)]
    [TestCase(DifficultyLevelEnum.Level5, -199, 199)]
    public void ResultWillBeInRangeForExpectedDifficultyLevel(DifficultyLevelEnum difficultyLevel, int minValue,
        int maxResult)
    {
        var random = new Random();
        for (var i = 0; i < 1000; i++)
        {
            var operation = new SubtractionRandomizer(random).Next(difficultyLevel);
            operation.ExpectedResult().Should().BeGreaterOrEqualTo(minValue);
            operation.ExpectedResult().Should().BeLessOrEqualTo(maxResult);
        }
    }
}
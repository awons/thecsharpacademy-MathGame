using FluentAssertions;
using MathGame.Game;
using MathGame.Game.Randomizers;

namespace TestMathGame.Game.Randomizers;

public class MultiplicationRandomizerTests
{
    [TestCase(DifficultyLevelEnum.Level1, 25)]
    [TestCase(DifficultyLevelEnum.Level2, 100)]
    [TestCase(DifficultyLevelEnum.Level3, 255)]
    [TestCase(DifficultyLevelEnum.Level4, 400)]
    [TestCase(DifficultyLevelEnum.Level5, 625)]
    public void ResultWillBeInRangeForExpectedDifficultyLevel(DifficultyLevelEnum difficultyLevel, int maxResult)
    {
        for (var i = 0; i < 1000; i++)
        {
            var operation = MultiplicationRandomizer.Next(difficultyLevel);
            operation.ExpectedResult().Should().BeGreaterOrEqualTo(1);
            operation.ExpectedResult().Should().BeLessOrEqualTo(maxResult);
        }
    }
}
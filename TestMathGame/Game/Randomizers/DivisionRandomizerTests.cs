using FluentAssertions;
using MathGame.Game;
using MathGame.Game.Randomizers;

namespace TestMathGame.Game.Randomizers;

public class DivisionRandomizerTests
{
    [TestCase(DifficultyLevelEnum.Level1, 100)]
    [TestCase(DifficultyLevelEnum.Level2, 150)]
    [TestCase(DifficultyLevelEnum.Level3, 200)]
    [TestCase(DifficultyLevelEnum.Level4, 250)]
    [TestCase(DifficultyLevelEnum.Level5, 300)]
    public void ResultWillBeInRangeForExpectedDifficultyLevel(DifficultyLevelEnum difficultyLevel, int maxResult)
    {
        for (var i = 0; i < 1000; i++)
        {
            var operation = DivisionRandomizer.Next(difficultyLevel);
            operation.ExpectedResult().Should().BeGreaterOrEqualTo(0);
            operation.ExpectedResult().Should().BeLessOrEqualTo(maxResult);
        }
    }
}
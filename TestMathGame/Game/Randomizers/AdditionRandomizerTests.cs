using FluentAssertions;
using MathGame.Game;
using MathGame.Game.Randomizers;

namespace TestMathGame.Game.Randomizers;

public class AdditionRandomizerTests
{
    [TestCase(DifficultyLevelEnum.Level1, 20)]
    [TestCase(DifficultyLevelEnum.Level2, 40)]
    [TestCase(DifficultyLevelEnum.Level3, 80)]
    [TestCase(DifficultyLevelEnum.Level4, 160)]
    [TestCase(DifficultyLevelEnum.Level5, 400)]
    public void ResultWillBeInRangeForExpectedDifficultyLevel(DifficultyLevelEnum difficultyLevel, int maxResult)
    {
        for (var i = 0; i < 1000; i++)
        {
            var operation = AdditionRandomizer.Next(difficultyLevel);
            operation.ExpectedResult().Should().BeLessOrEqualTo(maxResult);
            operation.ExpectedResult().Should().BeGreaterOrEqualTo(2);
        }
    }
}
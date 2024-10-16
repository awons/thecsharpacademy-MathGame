using FluentAssertions;
using MathGame.Game;
using MathGame.Game.Randomizers;

namespace TestMathGame.Game.Randomizers;

public class SubtractionRandomizerTests
{
    [TestCase(DifficultyLevelEnum.Level1, -9, 9)]
    [TestCase(DifficultyLevelEnum.Level2, -19, 19)]
    [TestCase(DifficultyLevelEnum.Level3, -39, 39)]
    [TestCase(DifficultyLevelEnum.Level4, -79, 79)]
    [TestCase(DifficultyLevelEnum.Level5, -199, 199)]
    public void ResultWillBeInRangeForExpectedDifficultyLevel(DifficultyLevelEnum difficultyLevel, int minValue,
        int maxResult)
    {
        for (var i = 0; i < 1000; i++)
        {
            var operation = SubtractionRandomizer.Next(difficultyLevel);
            operation.ExpectedResult().Should().BeGreaterOrEqualTo(minValue);
            operation.ExpectedResult().Should().BeLessOrEqualTo(maxResult);
        }
    }
}
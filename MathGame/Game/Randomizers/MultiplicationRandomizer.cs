using MathGame.Operations.Multiplication;

namespace MathGame.Game.Randomizers;

public static class MultiplicationRandomizer
{
    public static MultiplicationOperation Next(DifficultyLevelEnum difficultyLevel)
    {
        return new MultiplicationOperation(
            Multiplier.Next(GetMinValue(difficultyLevel), GetMaxValue(difficultyLevel)),
            Multiplicand.Next(GetMinValue(difficultyLevel), GetMaxValue(difficultyLevel)));
    }

    private static int GetMinValue(DifficultyLevelEnum difficultyLevel)
    {
        return difficultyLevel switch
        {
            DifficultyLevelEnum.Level1 => 1,
            DifficultyLevelEnum.Level2 => 3,
            DifficultyLevelEnum.Level3 => 5,
            DifficultyLevelEnum.Level4 => 10,
            DifficultyLevelEnum.Level5 => 15,
            _ => throw new ArgumentOutOfRangeException(nameof(difficultyLevel), difficultyLevel, null)
        };
    }

    private static int GetMaxValue(DifficultyLevelEnum difficultyLevel)
    {
        return difficultyLevel switch
        {
            DifficultyLevelEnum.Level1 => 6,
            DifficultyLevelEnum.Level2 => 11,
            DifficultyLevelEnum.Level3 => 16,
            DifficultyLevelEnum.Level4 => 21,
            DifficultyLevelEnum.Level5 => 26,
            _ => throw new ArgumentOutOfRangeException(nameof(difficultyLevel), difficultyLevel, null)
        };
    }
}
using MathGame.Operations.Subtraction;

namespace MathGame.Game.Randomizers;

public static class SubtractionRandomizer
{
    public static SubtractionOperation Next(DifficultyLevelEnum difficultyLevel)
    {
        return new SubtractionOperation(Minuend.Next(GetMaxValue(difficultyLevel)),
            Subtrahend.Next(GetMaxValue(difficultyLevel)));
    }

    private static int GetMaxValue(DifficultyLevelEnum difficultyLevel)
    {
        return difficultyLevel switch
        {
            DifficultyLevelEnum.Level1 => 11,
            DifficultyLevelEnum.Level2 => 21,
            DifficultyLevelEnum.Level3 => 41,
            DifficultyLevelEnum.Level4 => 81,
            DifficultyLevelEnum.Level5 => 201,
            _ => throw new ArgumentOutOfRangeException(nameof(difficultyLevel), difficultyLevel, null)
        };
    }
}
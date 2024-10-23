using MathGame.Operations.Addition;

namespace MathGame.Game.Randomizers;

public static class AdditionRandomizer
{
    public static AdditionOperation Next(DifficultyLevelEnum difficultyLevel)
    {
        return new AdditionOperation(Augend.Next(GetMaxValue(difficultyLevel)),
            Addend.Next(GetMaxValue(difficultyLevel)));
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
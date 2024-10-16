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
            DifficultyLevelEnum.Level1 => 10,
            DifficultyLevelEnum.Level2 => 20,
            DifficultyLevelEnum.Level3 => 40,
            DifficultyLevelEnum.Level4 => 80,
            DifficultyLevelEnum.Level5 => 200,
            _ => throw new ArgumentOutOfRangeException(nameof(difficultyLevel), difficultyLevel, null)
        };
    }
}
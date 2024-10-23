using MathGame.Operations.Division;

namespace MathGame.Game.Randomizers;

public static class DivisionRandomizer
{
    public static DivisionOperation Next(DifficultyLevelEnum difficultyLevel)
    {
        Divident divident;
        Divisor divisor;
        do
        {
            divident = Divident.Next(GetMinValue(difficultyLevel), GetMaxValue(difficultyLevel));
            divisor = Divisor.Next(GetMinValue(difficultyLevel), GetMaxValue(difficultyLevel));
        } while (divident.Value % divisor.Value != 0 || divident.Value == divisor.Value);

        return new DivisionOperation(divident, divisor);
    }

    private static int GetMinValue(DifficultyLevelEnum difficultyLevel)
    {
        return difficultyLevel switch
        {
            DifficultyLevelEnum.Level1 => 5,
            DifficultyLevelEnum.Level2 => 7,
            DifficultyLevelEnum.Level3 => 9,
            DifficultyLevelEnum.Level4 => 11,
            DifficultyLevelEnum.Level5 => 13,
            _ => throw new ArgumentOutOfRangeException(nameof(difficultyLevel), difficultyLevel, null)
        };
    }

    private static int GetMaxValue(DifficultyLevelEnum difficultyLevel)
    {
        return difficultyLevel switch
        {
            DifficultyLevelEnum.Level1 => 101,
            DifficultyLevelEnum.Level2 => 151,
            DifficultyLevelEnum.Level3 => 201,
            DifficultyLevelEnum.Level4 => 251,
            DifficultyLevelEnum.Level5 => 301,
            _ => throw new ArgumentOutOfRangeException(nameof(difficultyLevel), difficultyLevel, null)
        };
    }
}
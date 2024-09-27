using MathGame.Operations.Division;

namespace MathGame.Game.Randomizers;

public class DivisionRandomizer(Random random)
{
    public DivisionOperation Next(DifficultyLevelEnum difficultyLevel)
    {
        Divident divident;
        Divisor divisor;
        do
        {
            divident = Divident.Next(random, GetMinValue(difficultyLevel), GetMaxValue(difficultyLevel));
            divisor = Divisor.Next(random, GetMinValue(difficultyLevel), GetMaxValue(difficultyLevel));
        } while ((divident.Value % divisor.Value != 0) || divident.Value == divisor.Value);

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
            DifficultyLevelEnum.Level1 => 100,
            DifficultyLevelEnum.Level2 => 150,
            DifficultyLevelEnum.Level3 => 200,
            DifficultyLevelEnum.Level4 => 250,
            DifficultyLevelEnum.Level5 => 300,
            _ => throw new ArgumentOutOfRangeException(nameof(difficultyLevel), difficultyLevel, null)
        };
    }
}
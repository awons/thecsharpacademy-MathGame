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
            divident = Divident.Next(random, GetMaxValue(difficultyLevel));
            divisor = Divisor.Next(random, GetMaxValue(difficultyLevel));
        } while (divident.Value % divisor.Value != 0);

        return new DivisionOperation(divident, divisor);
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
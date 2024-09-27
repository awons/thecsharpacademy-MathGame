using MathGame.Operations.Multiplication;

namespace MathGame.Game.Randomizers;

public class MultiplicationRandomizer(Random random)
{
    public MultiplicationOperation Next(DifficultyLevelEnum difficultyLevel)
    {
        return new MultiplicationOperation(
            Multiplier.Next(random, GetMinValue(difficultyLevel), GetMaxValue(difficultyLevel)),
            Multiplicand.Next(random, GetMinValue(difficultyLevel), GetMaxValue(difficultyLevel)));
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
            DifficultyLevelEnum.Level1 => 5,
            DifficultyLevelEnum.Level2 => 10,
            DifficultyLevelEnum.Level3 => 15,
            DifficultyLevelEnum.Level4 => 20,
            DifficultyLevelEnum.Level5 => 25,
            _ => throw new ArgumentOutOfRangeException(nameof(difficultyLevel), difficultyLevel, null)
        };
    }
}
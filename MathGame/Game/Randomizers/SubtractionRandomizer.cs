using MathGame.Operations.Subtraction;

namespace MathGame.Game.Randomizers;

public class SubtractionRandomizer(Random random)
{
    public SubtractionOperation Next(DifficultyLevelEnum difficultyLevel)
    {
        return new SubtractionOperation(Minuend.Next(random, 1, GetMaxValue(difficultyLevel)),
            Subtrahend.Next(random, 1, GetMaxValue(difficultyLevel)));
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
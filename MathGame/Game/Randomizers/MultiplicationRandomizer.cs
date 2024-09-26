using MathGame.Operations.Multiplication;

namespace MathGame.Game.Randomizers;

public class MultiplicationRandomizer(Random random)
{
    public MultiplicationOperation Next(DifficultyLevelEnum difficultyLevel)
    {
        return new MultiplicationOperation(Multiplier.Next(random, GetMaxValue(difficultyLevel)),
            Multiplicand.Next(random, GetMaxValue(difficultyLevel)));
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
using MathGame.Game;
using MathGame.Game.Randomizers;
using MathGame.Operations.Addition;
using MathGame.Operations.Division;
using MathGame.Operations.Multiplication;
using MathGame.Operations.Subtraction;

namespace MathGame.Operations;

public static class OperationFactory
{
    public static IOperation Create(OperationsEnum operationType, DifficultyLevelEnum difficultyLevel)
    {
        return operationType switch
        {
            OperationsEnum.Addition => AdditionRandomizer.Next(difficultyLevel),
            OperationsEnum.Subtraction => SubtractionRandomizer.Next(difficultyLevel),
            OperationsEnum.Multiplication => MultiplicationRandomizer.Next(difficultyLevel),
            OperationsEnum.Division => DivisionRandomizer.Next(difficultyLevel),
            _ => throw new ArgumentOutOfRangeException(nameof(operationType), operationType, null)
        };
    }
}
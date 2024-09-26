using MathGame.Game;
using MathGame.Game.Randomizers;
using MathGame.Operations.Addition;
using MathGame.Operations.Division;
using MathGame.Operations.Multiplication;
using MathGame.Operations.Subtraction;

namespace MathGame.Operations;

public class OperationFactory(
    AdditionRandomizer additionRandomizer,
    SubtractionRandomizer subtractionRandomizer,
    MultiplicationRandomizer multiplicationRandomizer,
    DivisionRandomizer divisionRandomizer)
{
    public IOperation Create(OperationsEnum operationType, DifficultyLevelEnum difficultyLevel)
    {
        return operationType switch
        {
            OperationsEnum.Addition => additionRandomizer.Next(difficultyLevel),
            OperationsEnum.Subtraction => subtractionRandomizer.Next(difficultyLevel),
            OperationsEnum.Multiplication => multiplicationRandomizer.Next(difficultyLevel),
            OperationsEnum.Division => divisionRandomizer.Next(),
            _ => throw new ArgumentOutOfRangeException(nameof(operationType), operationType, null)
        };
    }
}
namespace MathGame.Operations;

public interface IOperation
{
    public int ExpectedResult();

    public bool IsCorrectAnswer(int answer)
    {
        return answer == ExpectedResult();
    }
}
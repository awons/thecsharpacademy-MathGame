using MathGame.Game.Randomizers;
using MathGame.Operations;
using MathGame.UI;

var random = new Random();
var gameLoop = new GameLoop(new OperationFactory(new AdditionRandomizer(random), new SubtractionRandomizer(random),
    new MultiplicationRandomizer(random), new DivisionRandomizer(random)));

gameLoop.Run();

Console.Clear();
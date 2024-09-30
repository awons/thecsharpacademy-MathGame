using MathGame.Game;
using MathGame.Game.Controls;
using MathGame.Game.Randomizers;
using MathGame.Operations;
using MathGame.UI.Menu;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        var random = new Random();
        services.AddSingleton<OperationFactory>();
        services.AddSingleton<AdditionRandomizer>(_ => new AdditionRandomizer(random));
        services.AddSingleton<SubtractionRandomizer>(_ => new SubtractionRandomizer(random));
        services.AddSingleton<MultiplicationRandomizer>(_ => new MultiplicationRandomizer(random));
        services.AddSingleton<DivisionRandomizer>(_ => new DivisionRandomizer(random));
        services.AddSingleton<Menu>();
        services.AddSingleton<IAnswerReader, ConsoleAnswerReader>();
        services.AddTransient<GameLoop>();
    })
    .Build();

var loop = ActivatorUtilities.CreateInstance<GameLoop>(host.Services);
loop.Run();
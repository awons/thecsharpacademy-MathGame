using MathGame.Game.Randomizers;
using MathGame.Operations;
using MathGame.UI;
using MathGame.UI.Menu;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        var random = new Random();
        services.AddTransient<OperationFactory>();
        services.AddTransient<AdditionRandomizer>(_ => new AdditionRandomizer(random));
        services.AddTransient<SubtractionRandomizer>(_ => new SubtractionRandomizer(random));
        services.AddTransient<MultiplicationRandomizer>(_ => new MultiplicationRandomizer(random));
        services.AddTransient<DivisionRandomizer>(_ => new DivisionRandomizer(random));
        services.AddTransient<GameLoop>();
        services.AddTransient<Menu>();
    })
    .Build();

var loop = ActivatorUtilities.CreateInstance<GameLoop>(host.Services);
loop.Run();
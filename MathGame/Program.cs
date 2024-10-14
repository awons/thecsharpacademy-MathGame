using MathGame.ConsoleWrapper;
using MathGame.Game;
using MathGame.Game.Controls;
using MathGame.Game.Randomizers;
using MathGame.Operations;
using MathGame.UI;
using MathGame.UI.Game;
using MathGame.UI.Menu;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        var random = new Random();
        services.AddSingleton<IConsoleWrapper, ConsoleWrapper>();
        services.AddSingleton<OperationFactory>();
        services.AddSingleton<AdditionRandomizer>(_ => new AdditionRandomizer(random));
        services.AddSingleton<SubtractionRandomizer>(_ => new SubtractionRandomizer(random));
        services.AddSingleton<MultiplicationRandomizer>(_ => new MultiplicationRandomizer(random));
        services.AddSingleton<DivisionRandomizer>(_ => new DivisionRandomizer(random));
        services.AddSingleton<Menu>();
        services.AddSingleton<IAnswerReader, ConsoleAnswerReader>();
        services.AddSingleton<IDifficultyLevelReader, ConsoleDifficultyLevelReader>();
        services.AddSingleton<IMenuChoiceReader, ConsoleMenuChoiceReader>();
        services.AddSingleton<IKeyAwaiter, ConsoleKeyAwaiter>();
        services.AddSingleton<GameResultRenderer>();
        services.AddSingleton<HistoryRenderer>();
        services.AddTransient<GameLoop>();
    })
    .Build();

var loop = ActivatorUtilities.CreateInstance<GameLoop>(host.Services);
loop.Run();
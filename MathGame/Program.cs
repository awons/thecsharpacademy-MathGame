using MathGame.ConsoleWrapper;
using MathGame.Game;
using MathGame.Game.Controls;
using MathGame.Game.Controls.Console;
using MathGame.UI;
using MathGame.UI.Game;
using MathGame.UI.Menu;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = new ConfigurationBuilder();
BuildConfig(builder);
builder.Build();

var host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddAnswerReaderFactory();
        services.AddSingleton<IConsoleWrapper, ConsoleWrapper>();
        services.AddSingleton<IDifficultyLevelReader, ConsoleDifficultyLevelReader>();
        services.AddSingleton<IMenuChoiceReader, ConsoleMenuChoiceReader>();
        services.AddSingleton<IKeyAwaiter, ConsoleKeyAwaiter>();
        services.AddTransient<GameLoopFactory>();
    })
    .Build();

var loopFactory = ActivatorUtilities.CreateInstance<GameLoopFactory>(host.Services);
loopFactory.Create(ControlsChoiceEnum.Console).Run();

static void BuildConfig(IConfigurationBuilder builder)
{
    builder.SetBasePath(Directory.GetCurrentDirectory())
        .AddEnvironmentVariables();
}
using MathGame.ConsoleWrapper;
using MathGame.Game;
using MathGame.Game.Controls;
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
        services.AddSingleton<IConsoleWrapper, ConsoleWrapper>();
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

static void BuildConfig(IConfigurationBuilder builder)
{
    builder.SetBasePath(Directory.GetCurrentDirectory())
        .AddEnvironmentVariables();
}
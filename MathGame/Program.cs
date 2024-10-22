using MathGame.ConsoleWrapper;
using MathGame.Game;
using MathGame.Game.Controls;
using MathGame.Game.Controls.Speech;
using MathGame.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var configurationBuilder = new ConfigurationBuilder();
BuildConfig(configurationBuilder);
configurationBuilder.Build();

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<IConsoleWrapper, ConsoleWrapper>();
        services.AddSingleton<IKeyAwaiter, ConsoleKeyAwaiter>();
        services.Configure<SpeechRecognizerFactoryOptions>(
            context.Configuration.GetSection(SpeechRecognizerFactoryOptions.SpeechRecognizer));
        services.AddSingleton<SpeechRecognizerFactory>();
        services.AddSingleton<AnswerReaderFactory>();
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
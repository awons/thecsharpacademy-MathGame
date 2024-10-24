using MathGame.ConsoleWrapper;
using MathGame.Game;
using MathGame.Game.Controls;
using MathGame.Game.Controls.Speech;
using MathGame.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(configurationBuilder =>
    {
        configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["ControlsConfiguration:Controls"] = "Console"
            })
            .AddUserSecrets<Program>()
            .AddEnvironmentVariables();
        if (args is { Length: > 0 }) configurationBuilder.AddCommandLine(args);
    })
    .ConfigureServices((context, services) =>
    {
        services.Configure<SpeechRecognizerFactoryOptions>(
            context.Configuration.GetSection(SpeechRecognizerFactoryOptions.Key));
        services.Configure<ControlsConfigurationOptions>(
            context.Configuration.GetSection(ControlsConfigurationOptions.Key));
        services.AddSingleton<IConsoleWrapper, ConsoleWrapper>();
        services.AddSingleton<IKeyAwaiter, ConsoleKeyAwaiter>();
        services.AddSingleton<SpeechRecognizerFactory>();
        services.AddSingleton<AnswerReaderFactory>();
        services.AddSingleton<GameLoopFactory>();
    })
    .Build();

var loopFactory = ActivatorUtilities.CreateInstance<GameLoopFactory>(host.Services);
loopFactory.Create().Run();
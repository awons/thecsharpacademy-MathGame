using MathGame.Game.Controls.Console;
using MathGame.Game.Controls.Speech;
using Microsoft.Extensions.DependencyInjection;

namespace MathGame.Game.Controls;

public static class AnswerReaderFactoryExtension
{
    public static void AddAnswerReaderFactory(this IServiceCollection services)
    {
        services.AddTransient<IAnswerReader, ConsoleAnswerReader>();
        services.AddTransient<IAnswerReader, SpeechAnswerReader>();
        services.AddSingleton<Func<IEnumerable<IAnswerReader>>>(x => () => x.GetService<IEnumerable<IAnswerReader>>()!);
        services.AddSingleton<AnswerReaderFactory, AnswerReaderFactory>();
    }
}
using AudioRecognition.Core.Commands;
using AudioRecognition.Core.Commands.Repositories;
using AudioRecognition.Core.Config;
using AudioRecognition.Core.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AudioRecognition.Core.Infrastructure
{
    public static class CoreExtension
    {
        public static IServiceCollection AddCore(this IServiceCollection services,
            IConfiguration configuration)
        {
            var telegramSettings = new TelegramSettings();
            configuration.Bind("TelegramSettings", telegramSettings);

            services.AddSingleton(telegramSettings);
            services.AddSingleton<TelegramBot>();
            services.AddScoped(typeof(IEfRepository<>), typeof(EfRepository<>));
            services.AddSingleton<ICommandExecutor, CommandExecutor>();

            services.AddSingleton<BaseCommand, StartCommand>();
            services.AddSingleton<BaseCommand, DecodeVoiceCommand>();

            return services;
        }
    }
}

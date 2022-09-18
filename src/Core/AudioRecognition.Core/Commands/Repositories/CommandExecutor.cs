using AudioRecognition.Core.Commands.Names;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace AudioRecognition.Core.Commands.Repositories
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly List<BaseCommand> _commands;
        private BaseCommand _сommand;

        public CommandExecutor(IServiceProvider serviceProvider)
        {
            _commands = serviceProvider.GetServices<BaseCommand>().ToList();
        }

        public async Task Execute(Update update)
        {
            if (update?.Message?.Chat == null && update?.CallbackQuery == null)
                return;

            if (update.Type == UpdateType.Message)
            {
                switch (update.Message?.Text)
                {
                    case "Decode Voice":
                        await ExecuteCommand(CommandNames.DecodeVoice, update);
                        return;
                }
            }

            if (update.Message != null && update.Message.Text.Contains(CommandNames.StartCommand))
            {
                await ExecuteCommand(CommandNames.StartCommand, update);
                return;
            }
        }

        private async Task ExecuteCommand(string commandName, Update update)
        {
            _сommand = _commands.First(x => x.Name == commandName);
            await _сommand.ExecuteAsync(update);
        }
    }
}

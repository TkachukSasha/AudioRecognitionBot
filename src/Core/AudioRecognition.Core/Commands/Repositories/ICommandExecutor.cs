using Telegram.Bot.Types;

namespace AudioRecognition.Core.Commands.Repositories
{
    public interface ICommandExecutor
    {
        Task Execute(Update update);
    }
}

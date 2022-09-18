using Telegram.Bot;
using Telegram.Bot.Types;

namespace AudioRecognition.Core.Commands.Repositories
{
    public interface IDecodeRepository
    {
        Task DecodeVoiceAsync(TelegramBotClient botClient, Update update);
    }
}

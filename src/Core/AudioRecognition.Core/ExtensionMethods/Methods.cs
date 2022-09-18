using Telegram.Bot;
using Telegram.Bot.Types;

namespace AudioRecognition.Core.ExtensionMethods
{
    public static class Methods
    {
        public static async Task<string> GetFilePath(this Update update, TelegramBotClient client)
        {
            var fileId = update.Message.Voice.FileId;

            var fileInfo = await client.GetFileAsync(fileId);

            return fileInfo.FilePath;
        }
    }
}

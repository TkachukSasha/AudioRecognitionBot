using AudioRecognition.Core.Config;
using Google.Cloud.Speech.V1;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace AudioRecognition.Core.Commands.Repositories
{
    public class DecodeRepository : IDecodeRepository
    {
        private readonly TelegramSettings _settings = new();

        public async Task DecodeVoiceAsync(TelegramBotClient botClient, Update update)
        {
            var sb = new StringBuilder();

            var message = update.Message;

            if (message == null)
                return;

            var voice = message.Voice;

            if (voice == null)
            {
                await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: "Send voice message please ..."
                );

                return;
            }

            var fileInfo = await botClient.GetFileAsync(voice.FileId);
            var requestUri = "https://api.telegram.org/file/bot" + _settings.Token + $"/{fileInfo.FilePath}";

            var speech = SpeechClient.Create();

            var response = speech.Recognize(new RecognitionConfig()
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                SampleRateHertz = 16000,
                LanguageCode = LanguageCodes.Ukrainian.Ukraine,
            }, RecognitionAudio.FromFile(requestUri));

            foreach (var result in response.Results)
            {
                foreach (var alternative in result.Alternatives)
                {
                    sb.Append(alternative);
                }
            }

            await botClient.SendTextMessageAsync(
                  chatId: message.Chat.Id,
                  text: sb.ToString());
        }
    }
}

using Telegram.Bot;

namespace AudioRecognition.Core.Config
{
    public class TelegramBot
    {
        private readonly TelegramSettings _settings;
        private TelegramBotClient _client;

        public TelegramBot(TelegramBotClient client,
                           TelegramSettings settings)
        {
            _client = client;
            _settings = settings;
        }

        public async Task<TelegramBotClient> GetBot()
        {
            if(_client != null)
                return _client;

            _client = new TelegramBotClient(_settings.Token);

            var hook = $"{_settings.Url}api/message/voice_decode";
            await _client.SetWebhookAsync(hook);

            return _client;
        }
    }
}

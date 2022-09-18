using AudioRecognition.Core.Commands.Names;
using Telegram.Bot.Types;

namespace AudioRecognition.Core.Commands
{
    public class DecodeVoiceCommand : BaseCommand
    {
        public override string Name => CommandNames.DecodeVoice;

        public override Task ExecuteAsync(Update update)
        {
            throw new NotImplementedException();
        }
    }
}

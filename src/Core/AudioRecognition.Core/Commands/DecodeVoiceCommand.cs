using AudioRecognition.Core.Commands.Names;
using AudioRecognition.Core.Commands.Repositories;
using AudioRecognition.Core.Config;
using AudioRecognition.Core.Entities;
using AudioRecognition.Core.Repositories;
using AutoMapper;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace AudioRecognition.Core.Commands
{
    public class DecodeVoiceCommand : BaseCommand
    {
        private readonly IEfRepository<VoiceMessage> _voiceRepository;
        private readonly IDecodeRepository _decodeRepository;
        private readonly IMapper _mapper;
        private readonly TelegramBotClient _client;

        public DecodeVoiceCommand(IEfRepository<VoiceMessage> voiceRepository,
                                  IDecodeRepository decodeRepository,
                                  IMapper mapper,
                                  TelegramBot telegramBot)
        {
            _voiceRepository = voiceRepository;
            _decodeRepository = decodeRepository;
            _mapper = mapper;
            _client = telegramBot.GetBot().Result;
        }

        public override string Name => CommandNames.DecodeVoice;

        public override async Task ExecuteAsync(Update update)
        {
            var voiceMessage = _mapper.Map<VoiceMessage>(update);

            await _voiceRepository.AddAsync(voiceMessage);

            await _decodeRepository.DecodeVoiceAsync(_client, update);
        }
    }
}

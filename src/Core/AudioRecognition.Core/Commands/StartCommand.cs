using AudioRecognition.Core.Commands.Names;
using AudioRecognition.Core.Config;
using AudioRecognition.Core.Entities;
using AudioRecognition.Core.Repositories;
using AutoMapper;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace AudioRecognition.Core.Commands
{
    public class StartCommand : BaseCommand
    {
        private readonly IEfRepository<AppUser> _userRepository;
        private readonly IMapper _mapper;
        private readonly TelegramBotClient _client;

        public StartCommand(IEfRepository<AppUser> userRepository,
                            IMapper mapper,
                            TelegramBot telegramBot)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _client = telegramBot.GetBot().Result;
        }

        public override string Name => CommandNames.StartCommand;

        public override async Task ExecuteAsync(Update update)
        {
            var user = _mapper.Map<AppUser>(update);

            await _userRepository.AddAsync(user);

            var inlineKeyboard = new ReplyKeyboardMarkup(new[]
           {
                new[]
                {
                    new KeyboardButton("Decode_voice")
                }
            });

            await _client.SendTextMessageAsync(user.ChatId, "Welcome! Choose a command that you need!",
                ParseMode.Markdown, replyMarkup: inlineKeyboard);
        }
    }
}

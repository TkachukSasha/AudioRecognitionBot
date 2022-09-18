using AudioRecognition.Core.Commands.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Telegram.Bot.Types;

namespace AudioRecognition.Presentation.Controllers
{
    [ApiController]
    [Route("api/message/voice_decode")]
    public class TelegramBotController : ControllerBase
    {
        private readonly ICommandExecutor _commandExecutor;

        public TelegramBotController(ICommandExecutor commandExecutor)
        {
            _commandExecutor = commandExecutor;
        }

        [HttpPost]
        public async Task<IActionResult> BotAction([FromBody] object update)
        {
            var action = JsonConvert.DeserializeObject<Update>(update.ToString());

            if (action?.Message?.Chat == null && action?.CallbackQuery == null)
            {
                return Ok();
            }

            await _commandExecutor.Execute(action);

            return Ok();
        }
    }
}

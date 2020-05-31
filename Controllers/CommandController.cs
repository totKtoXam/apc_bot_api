using System.Threading.Tasks;
using apc_bot_api.Constants;
using apc_bot_api.Models.Base;
using apc_bot_api.Models.Content;
using apc_bot_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace apc_bot_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommandController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly ICommandRepository _command;
        private readonly IBotRepository _bot;
        public CommandController(AppDbContext dbContext,
            ICommandRepository command,
            IBotRepository bot
            )
        {
            _dbContext = dbContext;
            _command = command;
            _bot = bot;
        }

        // [HttpGet("check/{command}")]
        // public async Task<IActionResult> CheckCommandExists([FromQuery] GeneralQuery gnrlQrData, string command)
        // {
        //     return Ok();
        // }

        [HttpGet]
        public async Task<IActionResult> GetCommandList([FromQuery] GeneralQuery gnrlQrData)
        {
            var result = await _command.GetCommandListAsync(gnrlQrData);
            return Ok(result);
        }

        [HttpGet("{commandName}")]
        public async Task<IActionResult> GetCommand([FromQuery] GeneralQuery generalQuery, string commandName)
        {
            var result = await _command.GetCommandAsync(generalQuery, commandName);
            return Ok(result);
        }

        // [HttpPost("{commandName}")]
        // public async Task<IActionResult> CommandApply([FromQuery] GeneralQuery generalQuery, [FromBody] object commingData, string commandName)
        // {
        //     var result = await _command.ApplyCommandAsync(generalQuery, commandName, commingData);
        //     return Ok(result);
        // }
    }
}
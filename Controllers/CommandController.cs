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
        public CommandController(AppDbContext dbContext,
            ICommandRepository command)
        {
            _dbContext = dbContext;
            _command = command;
        }

        // [HttpGet("check/{command}")]
        // public async Task<IActionResult> CheckCommandExists([FromQuery] GeneralQuery gnrlQrData, string command)
        // {
        //     return Ok();
        // }

        [HttpGet]
        public async Task<IActionResult> GetCommands([FromQuery] GeneralQuery gnrlQrData)
        {
            var result = await _command.GetCommandListAsync(gnrlQrData);
            return Ok(result);
        }

        [HttpPost("{commandName}")]
        public async Task<IActionResult> ExecuteCommand([FromQuery] GeneralQuery generalQuery, string commandName)
        {
            var result = await _command.ExecuteCommandAsync(generalQuery, commandName);
            return Ok(result);
        }
    }
}
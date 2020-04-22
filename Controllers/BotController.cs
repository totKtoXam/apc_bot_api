using System.Threading.Tasks;
using apc_bot_api.Models.Base;
using apc_bot_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace apc_bot_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BotController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IBotRepository _botRepos;

        public BotController(
                AppDbContext dbContext,
                IBotRepository botRepos
            )
        {
            _dbContext = dbContext;
            _botRepos = botRepos;
        }

        [HttpGet("actions/{stepCode}")]
        public async Task<IActionResult> GetBotActionsAsync(string stepCode)
        {
            var botActionsViewModel =  await _botRepos.GetBotActionsAsync(stepCode);
            return Ok(botActionsViewModel);
        }

        [HttpGet("stepWithActions/{actCode}")]
        public async Task<IActionResult> GetStepWithActionsByActionCode(string actCode)
        {
            var step = await _botRepos.GetStepWithActionsByActionCode(actCode);
            return Ok(step);
        }
    }
}
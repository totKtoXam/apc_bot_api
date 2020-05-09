using System.Linq;
using System.Threading.Tasks;
using apc_bot_api.Models.Base;
using apc_bot_api.Models.Bots;
using apc_bot_api.Models.Content;
using apc_bot_api.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apc_bot_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BotController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IBotRepository _botRepos;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;

        public BotController(
                AppDbContext dbContext,
                IBotRepository botRepos,
                IMapper mapper,
                RoleManager<IdentityRole> roleManager
            )
        {
            _dbContext = dbContext;
            _botRepos = botRepos;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        [HttpGet("actions/{stepCode}")]
        public async Task<IActionResult> GetBotActionsAsync(string stepCode)
        {
            var currentStep = await _dbContext.Steps
                                                .Where(x => x.Code == stepCode)
                                                .Select(x => _mapper.Map<StepViewModel>(x))
                                                .SingleOrDefaultAsync();
            if (currentStep == null)
                return NotFound("STEP_NOT_FOUND");
            var actViewModeList = await _botRepos.GetBotActionsByPrevStepCodeAsync(stepCode);
            currentStep.ActionList = actViewModeList;
            return Ok(currentStep);
        }

        [HttpGet("command/{commandCode}")]
        public IActionResult ExecuteCommand(string commandCode)
        {
            return Ok();
        }

        [HttpGet("checkStep/{stepCode}")]
        public IActionResult CheckStep(string stepCode)
        {
            if (_dbContext.Steps.Any(x => x.Code == stepCode))
                return Ok("STEP_EXISTS");
            else
                return NotFound("STEP_NOT_EXISTS");
        }

        [HttpPost("sendler/botChannel")]
        public IActionResult PostSendler(string botChannel)
        {
            return Ok();
        }

        // [HttpPost("execAction/{actCode}")]
        // public async Task<IActionResult> PostClientAsync([FromBody] ClientBotForm clientForm, string actCode = null)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         var result = await _botRepos.PostClientAsync(clientForm, actCode);

        //         if (result.RESULT_CODE == "ACTION_NOT_FOUND" || result.RESULT_CODE == "ACTION_NOT_EXISTS")
        //             return NotFound(result.RESULT_CODE);
        //         if (result.RESULT_CODE == "CHAT_ID_IS_EMPTY" || result.RESULT_CODE == "CHANNEL_IS_UNKNOWN")
        //             return BadRequest(result.RESULT_CODE);

        //         return Ok(result);
        //     }
        //     else
        //         return BadRequest("WRONG_BODY");
        // }

        [HttpPost("createClient")]
        public async Task<IActionResult> CreateBotClient([FromBody] ClientBotForm clientBotForm)
        {
            // if (!ModelState.IsValid)
            // {
                var resultModel = await _botRepos.CreateBotClientAsync(clientBotForm);
                // if (resultModel.RESULT_CODE == 200)
                    return Ok(resultModel);
                // else if (resultModel.RESULT_CODE == 404)
                    // return NotFound(resultModel.RESULT_NAME);
                // else
                    // return BadRequest(resultModel.RESULT_NAME);
            // }
            // else
            //     return BadRequest("INVALID_DATA");
        }

        // [HttpGet("stepWithActions/{actCode}")]
        // public async Task<IActionResult> GetStepWithActionsByActionCode(string actCode)
        // {
        //     var step = await _botRepos.GetStepWithActionsByActionCode(actCode);
        //     return Ok(step);
        // }
    }
}
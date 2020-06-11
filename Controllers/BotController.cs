using System.Linq;
using System.Threading.Tasks;
using apc_bot_api.Helpers;
using apc_bot_api.Models.Base;
using apc_bot_api.Models.Bots;
using apc_bot_api.Models.Content;
using apc_bot_api.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static apc_bot_api.Delegates;

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
        private readonly UserManager<AppUser> _userManager;

        public BotController(
                AppDbContext dbContext,
                IBotRepository botRepos,
                IMapper mapper,
                RoleManager<IdentityRole> roleManager,
                UserManager<AppUser> userManager
            )
        {
            _dbContext = dbContext;
            _botRepos = botRepos;
            _mapper = mapper;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet("actions/{commandCode}")]
        public async Task<IActionResult> GetBotActionsAsync(string commandCode)
        {
            var currentCommand = await _dbContext.Commands
                                                .Where(x => x.Code == commandCode)
                                                .Select(x => _mapper.Map<CommandViewModel>(x))
                                                .SingleOrDefaultAsync();
            if (currentCommand == null)
                return NotFound("STEP_NOT_FOUND");
            var actViewModeList = await _botRepos.GetBotActionsByPrevCommandCodeAsync(commandCode);
            currentCommand.ActionList = actViewModeList;
            return Ok(currentCommand);
        }

        [HttpGet("command/{commandCode}")]
        public IActionResult ExecuteCommand(string commandCode)
        {
            return Ok();
        }

        [HttpGet("checkCommand/{commandCode}")]
        public IActionResult CheckCommand(string commandCode)
        {
            if (_dbContext.Commands.Any(x => x.Code == commandCode))
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
        public async Task<IActionResult> CreateBotClient([FromQuery] GeneralQuery generalQuery, [FromBody] ClientBotForm clientBotForm)
        {
            var resultModel = await _botRepos.CreateBotClientAsync(generalQuery, clientBotForm);

            if (resultModel.Code == 200)
            {
                var foundUser = await _userManager.FindByNameAsync(resultModel.Data.Email);
                if (foundUser != null)
                {
                    string code = await _userManager.GenerateEmailConfirmationTokenAsync(foundUser);
                    string callbackUrl = Url.Action("ConfirmEmail", "Bot", new { userId = foundUser.Id, code = code }, protocol: HttpContext.Request.Scheme);

                    EmailHelper _emailHelper = new EmailHelper();
                    string userFullName = (string.IsNullOrEmpty(foundUser.LastName) ? "" : foundUser.LastName + " ") +
                                            (string.IsNullOrEmpty(foundUser.FirstName) ? "" : foundUser.FirstName + " ") +
                                            (string.IsNullOrEmpty(foundUser.MiddleName) ? "" : foundUser.MiddleName);
                    string messageText = $"Вы зарегистрировались в \"APC BOT SERVICE\". Для получения рассылки необходимо подтвердить свою электронную почту перейдя по <a href='{callbackUrl}'>ссылке</a>";

                    await _emailHelper.SendEmailAsync(foundUser.Email, userFullName, messageText);
                }
            }
            return Ok(resultModel);
        }

        // [HttpGet("commandWithActions/{actCode}")]
        // public async Task<IActionResult> GetCommandWithActionsByActionCode(string actCode)
        // {
        //     var command = await _botRepos.GetCommandWithActionsByActionCode(actCode);
        //     return Ok(command);
        // }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return BadRequest("не верный код или идентификатор");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("Пользователь не найден");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
                return Ok("Электронная почта подтверждена");
            else
                return NotFound("Действие ссылки истекла. Обратитесь к администратору");
        }
    }
}
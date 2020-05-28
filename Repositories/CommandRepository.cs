using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using apc_bot_api.Constants;
using apc_bot_api.Models.Base;
using apc_bot_api.Models.Bots;
using apc_bot_api.Models.Content;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace apc_bot_api.Repositories
{
    public interface ICommandRepository
    {
        // Task<bool> CheckCommandExistsAsync(string command);
        Task<Result<List<CommandViewModel>>> GetCommandListAsync(GeneralQuery gnrlQueryData);
        Task<Result<CommandViewModel>> ExecuteCommandAsync(GeneralQuery generalQuery, string commandName);
    }

    public class CommandRepository : ICommandRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public CommandRepository(
            AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        IQueryable<Command> Commands => _dbContext.Commands
                                                .Include(x => x.Type)
                                                .Include(x => x.BotActions);
        // private async Task<BotActionViewModel> BotActionModelByCode(string actCode) =>
        //                 await this.BotActions
        //                             .Select(x => _mapper.Map<BotActionViewModel>(x))
        //                             .FirstOrDefaultAsync(x => x.Code == actCode);

        private async Task<ClientBot> ClientBotAsync(string userId) =>
                        await _dbContext.ClientBots.Include(x => x.User).FirstOrDefaultAsync(x => x.User.Id == userId);

        private async Task<Command> GetCommandAsync(string command) =>
                        await _dbContext.Commands.Include(x => x.BotActions).FirstOrDefaultAsync(x => x.Code.ToUpper() == command.ToUpper());

        // private Task<bool> CheckComandAccessByRole(Command model)
        // {

        // }

        public async Task<Result<List<CommandViewModel>>> GetCommandListAsync(GeneralQuery gnrlQueryData)
        {
            var commandList = await this.Commands.Select(x => _mapper.Map<CommandViewModel>(x)).ToListAsync();

            return new Result<List<CommandViewModel>>(commandList);
        }

        /// <summary>
        /// Метод выполнения комманды
        /// </summary>
        /// <param name="generalQuery">Источник бота и идентификатор чата с пользователем</param>
        /// <param name="commandName">выполняемая команда</param>
        /// <returns>
        /// Возвращает модель команды вместе с BotActions/ActionsList
        /// </returns>
        public async Task<Result<CommandViewModel>> ExecuteCommandAsync(GeneralQuery generalQuery, string commandName)
        {
            if (string.IsNullOrEmpty(commandName))
                return new Result<CommandViewModel>(400, "command_is_null", "команда пуста", "Введённая Вами комманда является пустой");

            var commandData = await this.GetCommandAsync(commandName);
            if (commandData == null)
                return new Result<CommandViewModel>(404, "command_not_found", "команда не найдена", "Введённая Вами команда не найдена");

            var commandViewModel = _mapper.Map<CommandViewModel>(commandData);

            var result = new Result<CommandViewModel>(commandViewModel);
            return result;
        }
    }
}
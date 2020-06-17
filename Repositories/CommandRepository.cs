using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apc_bot_api.Constants;
using apc_bot_api.Helpers;
using apc_bot_api.Models.AssignedTasks;
using apc_bot_api.Models.Base;
using apc_bot_api.Models.Bots;
using apc_bot_api.Models.Content;
using apc_bot_api.Models.Users;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace apc_bot_api.Repositories
{
    public interface ICommandRepository
    {
        // Task<bool> CheckCommandExistsAsync(string command);
        Task<Result<List<CommandViewModel>>> GetCommandListAsync(GeneralQuery gnrlQueryData);
        Task<Result<CommandViewModel>> GetCommandAsync(GeneralQuery generalQuery, string commandName);
        // Task<Result<object>> ApplyCommandAsync(GeneralQuery generalQuery, string commandName, object commingData);
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
        IQueryable<Command> IQCommands => _dbContext.Commands
                                                .Include(x => x.Type)
                                                .Include(x => x.BotActions)
                                                .AsQueryable();
        // private async Task<BotActionViewModel> BotActionModelByCode(string actCode) =>
        //                 await this.BotActions
        //                             .Select(x => _mapper.Map<BotActionViewModel>(x))
        //                             .FirstOrDefaultAsync(x => x.Code == actCode);
        IQueryable<ClientBot> IQClientBots => _dbContext.ClientBots.Include(x => x.User).AsQueryable();
        IQueryable<AssignedTask> IQAssignedTasks => _dbContext.AssignedTasks
                                                        .Include(x => x.SetBy)
                                                        .ThenInclude(x => x.ClientBot)
                                                        .ThenInclude(x => x.User)
                                                        .AsQueryable();

        private async Task<ClientBot> GetClientBotAsync(string userId = null, string chatId = null, string channel = null) =>
                        await this.IQClientBots.FirstOrDefaultAsync(x =>
                                                    string.IsNullOrEmpty(userId)
                                                        ?
                                                        x.User.Id == userId
                                                        :
                                                        string.IsNullOrEmpty(chatId)
                                                            ?
                                                        FunctionsHelper.CheckChatIdByChannel(x, channel, chatId)
                                                            // (
                                                            //         channel == BotConstants.Channels.Telegram ? x.TeleChatId == chatId
                                                            //             :
                                                            //         channel == BotConstants.Channels.VKontakte ? x.VkChatId == chatId
                                                            //             :
                                                            //         channel == BotConstants.Channels.WhatsApp ? x.WhatsAppChatId == chatId
                                                            //             :
                                                            //         false
                                                            //     )
                                                            :
                                                        false
                                                );

        private async Task<Teacher> GetClientTeacherByChatIdAsync(string iin = null, string chatId = null, string channel = null) =>
                        await _dbContext.Teachers
                                        .Include(x => x.ClientBot).ThenInclude(x => x.User)
                                        .FirstOrDefaultAsync(x =>
                                                string.IsNullOrEmpty(iin)
                                                    ?
                                                FunctionsHelper.CheckChatIdByChannel(x.ClientBot, channel, chatId)
                                                    //     channel == BotConstants.Channels.Telegram ? x.ClientBot.TeleChatId == chatId
                                                    //         :
                                                    //     channel == BotConstants.Channels.VKontakte ? x.ClientBot.VkChatId == chatId
                                                    //         :
                                                    //     channel == BotConstants.Channels.WhatsApp ? x.ClientBot.WhatsAppChatId == chatId
                                                    //         :
                                                    //     false
                                                    :
                                                x.IIN == iin
                                            );

        private async Task<Student> GetClientStudentByChatIdAsync(string ticketNum = null, string chatId = null, string channel = null) =>
                        await _dbContext.Students
                                        .Include(x => x.ClientBot).ThenInclude(x => x.User)
                                        .FirstOrDefaultAsync(x =>
                                                string.IsNullOrEmpty(ticketNum)
                                                    ?
                                                FunctionsHelper.CheckChatIdByChannel(x.ClientBot, channel, chatId)
                                                   // channel == BotConstants.Channels.Telegram ? x.ClientBot.TeleChatId == chatId
                                                   //     :
                                                   // channel == BotConstants.Channels.VKontakte ? x.ClientBot.VkChatId == chatId
                                                   //     :
                                                   // channel == BotConstants.Channels.WhatsApp ? x.ClientBot.WhatsAppChatId == chatId
                                                   //     :
                                                   // false
                                                   :
                                                x.TicketNumber == ticketNum
                                            );

        private async Task<Command> GetCommandAsync(string command) =>
                        await this.IQCommands.FirstOrDefaultAsync(x => x.Code == command);
        private async Task<List<Speciality>> GetSpecialitiesAsync() => await _dbContext.Specialities.ToListAsync();

        // private Task<bool> CheckComandAccessByRole(Command model)
        // {

        // }

        public async Task<Result<List<CommandViewModel>>> GetCommandListAsync(GeneralQuery gnrlQueryData)
        {
            var commandList = await this.IQCommands.Select(x => _mapper.Map<CommandViewModel>(x)).ToListAsync();

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
        public async Task<Result<CommandViewModel>> GetCommandAsync(GeneralQuery generalQuery, string commandName)
        {
            if (FunctionsHelper.StringsIsNull(generalQuery.ChatId, generalQuery.Channel))
                return new Result<CommandViewModel>(400, "CHANNEL_OR_CHAT_ID_IS_EMPTY", "данные некорректны", "Ошибка со стороны сервера. Просим прощения за предоставленные нами неудобства");

            if (string.IsNullOrEmpty(commandName))
                return new Result<CommandViewModel>(400, "command_is_null", "команда пуста", "Введённая Вами комманда является пустой");

            var commandData = await this.GetCommandAsync(commandName);
            if (commandData == null)
                return new Result<CommandViewModel>(404, "command_not_found", "команда не найдена", "Введённая Вами команда не найдена");

            var commandViewModel = _mapper.Map<CommandViewModel>(commandData);

            switch (commandViewModel.Code)
            {
                case CommandConstants.Commands.Help:
                    commandViewModel.Message = await GetHelpMessageAsync();
                    break;
                case CommandConstants.Commands.Start:
                    var foundUser = await GetClientBotAsync(channel: generalQuery.Channel, chatId: generalQuery.ChatId);
                    if (foundUser != null)
                    {
                        if (foundUser.User.EmailConfirmed)
                            return new Result<CommandViewModel>(400, "USER_IS_EXISTS", "Пользователь существует.", "Просим прощения, но Вы уже зарегистрировались в системе");
                        else
                            return new Result<CommandViewModel>(400, "USER_IS_EXISTS", "Пользователь существует.", "Просим прощения, но Вы уже зарегистрировались в системе, но Вы не подтвердили свою эл. почту: " + foundUser.User.UserName);
                    }
                    break;
                case CommandConstants.Commands.Specs:
                    commandViewModel.Message = await GetSpecMessageAsync();
                    break;
                case CommandConstants.Commands.ActiveTasks:
                    commandViewModel.Message = await GetActiveTasksAsync();
                    break;
                default:
                    break;
            }

            Result<CommandViewModel> result = new Result<CommandViewModel>(commandViewModel);
            // var result = new Result<CommandViewModel>(commandViewModel);
            return result;
        }

        // private async Task<>

        private async Task<string> GetActiveTasksAsync()
        {
            string message = "", divider = "\n============\n";
            List<AssignedTask> taskList = await this.IQAssignedTasks.Where(x => x.IsActive || x.FinishDate < DateTime.Now).ToListAsync();
            foreach (AssignedTask taskItem in taskList)
            {
                message += $"{(taskItem != taskList[0] ? divider : "")}Номер: {taskItem.Id}\nОписание: {taskItem.Text}\nДата начало (от): {taskItem.StartDate}\nСрок выполнения (до): {taskItem.FinishDate}";
            }
            return message;
        }

        private async Task<string> GetHelpMessageAsync()
        {
            string message = "";
            var commandList = await this.IQCommands.ToListAsync();
            foreach (Command command in commandList)
            {
                message += $"/{command.Code} - {command.Description}\n";
            }
            return message;
        }

        private async Task<string> GetSpecMessageAsync()
        {
            string message = "Чтобы получить подробное описание о специальности введите её сокращённое название с символом #ВТиПО. Например: #\nСписок специальностей:";

            List<Speciality> specialityList = await GetSpecialitiesAsync();
            for (int i = 0; i < specialityList.Count; i++)
            {
                message += "\n▬▬▬▬▬▬▬▬▬▬▬▬\n\t" + (i + 1).ToString() + ". " + specialityList[i].Short + " - " + (specialityList[i]?.SpecialtyNum ?? "") + specialityList[i].SpecialtyName;
            }
            return message;
        }

        // public async Task<Result<object>> ApplyCommandAsync(GeneralQuery generalQuery, string commandName, object commingData)
        // {
        //     if (FunctionsHelper.StringsIsNull(generalQuery.ChatId, generalQuery.Channel))
        //         return new Result<object>(401, "CHANNEL_OR_CHAT_ID_IS_EMPTY", "данные некорректны", "Ошибка со стороны сервера. Просим прощения за предоставленные нами неудобства");

        //     switch (commandName)
        //     {
        //         case CommandConstants.Commands.Start:
        //             var foundUser = GetClientBotAsync(channel: generalQuery.Channel, chatId: generalQuery.ChatId);
        //             if (foundUser != null)
        //             {

        //             }
        //             break;
        //         default:
        //             break;
        //     }
        // }

        // private async Task<ClientBot> CreateClientBot(object commingData)
        // {

        // }
    }
}
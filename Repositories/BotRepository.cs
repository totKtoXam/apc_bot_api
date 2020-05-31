using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apc_bot_api.Constants;
using apc_bot_api.Models.Base;
using apc_bot_api.Models.Bots;
using apc_bot_api.Models.Content;
using apc_bot_api.Models.Users;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace apc_bot_api.Repositories
{
    public interface IBotRepository
    {
        Task<List<BotActionViewModel>> GetBotActionsByPrevCommandCodeAsync(string commandCode);
        // Task<ClientBotViewModel> PostClientAsync(ClientBotForm clientForm, string actCode = null);
        Task<Result<ClientBotViewModel>> CreateBotClientAsync(GeneralQuery generalQuery, ClientBotForm clientBotForm);
    }
    public class BotRepository : IBotRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public BotRepository(
            AppDbContext dbContext, IMapper mapper, RoleManager<IdentityRole> roleManager,
            UserManager<AppUser> userManager)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        private IQueryable<BotAction> BotActions => _dbContext.BotActions
                                                            .Include(x => x.PrevCommand)
                                                            .Include(x => x.NextCommand);

        private async Task<BotActionViewModel> BotActionModelByCode(string actCode) =>
                        await this.BotActions
                                    .Select(x => _mapper.Map<BotActionViewModel>(x))
                                    .FirstOrDefaultAsync(x => x.Code == actCode);

        public async Task<List<BotActionViewModel>> GetBotActionsByPrevCommandCodeAsync(string commandCode)
        {
            var botActionModelList = await this.BotActions
                                        // .Include(x => x)
                                        .Where(x => x.PrevCommand != null && x.PrevCommand.Code == commandCode)
                                        .Select(x => _mapper.Map<BotActionViewModel>(x))
                                        .ToListAsync();

            return botActionModelList;
        }

        public async Task<Result<ClientBotViewModel>> CreateBotClientAsync(GeneralQuery generalQuery, ClientBotForm clientBotForm)
        {
            if (string.IsNullOrEmpty(generalQuery.ChatId))
                return new Result<ClientBotViewModel>(400, "CHAT_ID_IS_NULL");

            // if (clientBotForm.BotChannel == BotChannelConstants.Telegram)
            //     newClient = await _dbContext.ClientBots.FirstOrDefaultAsync(x => x.TeleChatId == clientBotForm.ChatId);
            // if (clientBotForm.BotChannel == BotChannelConstants.VKontakte)
            //     newClient = await _dbContext.ClientBots.FirstOrDefaultAsync(x => x.VkChatId == clientBotForm.ChatId);
            // if (clientBotForm.BotChannel == BotChannelConstants.WhatsApp)
            //     newClient = await _dbContext.ClientBots.FirstOrDefaultAsync(x => x.WhatsAppChatId == clientBotForm.ChatId);

            if (await CheckExistsClientAsync(clientBotForm, generalQuery))
                return new Result<ClientBotViewModel>(400, "CLIENT_EXISTS");

            if (await _userManager.FindByEmailAsync(clientBotForm.Email) != null)
                return new Result<ClientBotViewModel>(400, "USER_EXISTS");

            AppUser newUser = new AppUser();
            newUser.UserName = clientBotForm.Email;
            newUser.Email = clientBotForm.Email;
            newUser.PhoneNumber = clientBotForm.Phone;
            newUser.LastName = clientBotForm.LastName;
            newUser.FirstName = clientBotForm.FirstName;
            newUser.MiddleName = clientBotForm.MiddleName;

            IdentityResult result = new IdentityResult();
            while (!result.Succeeded)
            {
                var randomNewPass = RandomPasswordGenerate();
                result = await _userManager.CreateAsync(newUser, randomNewPass);
            }

            if (await AddRoleByActionCodeAsync(newUser, clientBotForm.RoleCode))
            {

                ClientBot newClient = new ClientBot();
                newClient.User = newUser;
                newClient = SetChatIdByChannel(newClient, clientBotForm, generalQuery);
                await _dbContext.ClientBots.AddAsync(newClient);

                switch (clientBotForm.RoleCode)
                {
                    case BotConstants.Actions.ROLE_IS_STUDENT:
                        Student newStudent = new Student(newClient);
                        newStudent.TicketNumber = clientBotForm.TicketNumber;
                        newStudent.Group = clientBotForm.Group;
                        await _dbContext.Students.AddAsync(newStudent);
                        break;
                    case BotConstants.Actions.ROLE_IS_TEACHER:
                        Teacher newTeacher = new Teacher(newClient);
                        newTeacher.Group = clientBotForm.Group;
                        newTeacher.IIN = clientBotForm.IIN;
                        await _dbContext.Teachers.AddAsync(newTeacher);
                        break;
                    default:
                        break;
                }


                await _dbContext.SaveChangesAsync();

                var resultClientModel = new Result<ClientBotViewModel>(200, "CREATE_SUCCESS");
                resultClientModel.Data.ClientBotId = newClient.Id;
                return resultClientModel;
            }
            else
                return new Result<ClientBotViewModel>(400, "CREATE_ERROR");
        }

        private ClientBot SetChatIdByChannel(ClientBot clientBot, ClientBotForm clientBotForm, GeneralQuery generalQuery)
        {
            if (generalQuery.Channel == BotConstants.Channels.Telegram)
                clientBot.TeleChatId = generalQuery.ChatId;
            if (generalQuery.Channel == BotConstants.Channels.VKontakte)
                clientBot.VkChatId = generalQuery.ChatId;
            if (generalQuery.Channel == BotConstants.Channels.WhatsApp)
                clientBot.WhatsAppChatId = generalQuery.ChatId;

            return clientBot;
        }

        private string RandomPasswordGenerate()
        {
            int[] arr = new int[50]; // сделаем длину пароля в 16 символов
            Random rnd = new Random();
            string password = "";

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(33, 125);
                password += (char)arr[i];
            }
            return password;
        }

        private async Task<bool> CheckExistsClientAsync(ClientBotForm clientBotForm, GeneralQuery generalQuery)
        {
            switch (clientBotForm.RoleCode)
            {
                case BotConstants.Actions.ROLE_IS_STUDENT:
                    if (await _dbContext.Students.AnyAsync(x => x.TicketNumber == clientBotForm.TicketNumber))
                        return true;
                    break;
                case BotConstants.Actions.ROLE_IS_ENROLLEE:
                    if (await _userManager.FindByEmailAsync(clientBotForm.Email) == null)
                    {
                        if (generalQuery.Channel == BotConstants.Channels.Telegram)
                            if (await _dbContext.ClientBots.AnyAsync(x => x.TeleChatId == generalQuery.ChatId))
                                return true;
                        if (generalQuery.Channel == BotConstants.Channels.VKontakte)
                            if (await _dbContext.ClientBots.AnyAsync(x => x.VkChatId == generalQuery.ChatId))
                                return true;
                        if (generalQuery.Channel == BotConstants.Channels.WhatsApp)
                            if (await _dbContext.ClientBots.AnyAsync(x => x.WhatsAppChatId == generalQuery.ChatId))
                                return true;
                    }
                    else
                        return true;
                    break;
                case BotConstants.Actions.ROLE_IS_TEACHER:
                    if (await _dbContext.Teachers.AnyAsync(x => x.IIN == clientBotForm.IIN))
                        return true;
                    break;
                default:
                    break;
            }

            return false;
        }

        private async Task<bool> AddRoleByActionCodeAsync(AppUser user, string actCode)
        {
            IdentityResult result = new IdentityResult();
            switch (actCode)
            {
                case BotConstants.Actions.ROLE_IS_STUDENT:
                    result = await _userManager.AddToRoleAsync(user, "student");
                    break;
                case BotConstants.Actions.ROLE_IS_ENROLLEE:
                    result = await _userManager.AddToRoleAsync(user, "enrollee");
                    break;
                case BotConstants.Actions.ROLE_IS_TEACHER:
                    result = await _userManager.AddToRoleAsync(user, "teacher");
                    break;
                default:
                    break;
            }

            if (result.Succeeded)
                return true;
            else
                return false;
        }

        // public async Task<ClientBotViewModel> PostClientAsync(ClientBotForm clientForm, string actCode = null)
        // {
        //     var action = await _dbContext.BotActions.Include(x => x.PrevCommand).FirstOrDefaultAsync(x => x.Code == actCode);
        //     ClientBot foundClient = new ClientBot();

        //     if (action.PrevCommand.Code == CommandConstants._START_)
        //     {

        //     }

        //     if (clientForm.BotChannel == BotChannelConstants.Telegram)
        //     {
        //         foundClient = await _dbContext.ClientBots.Include(x => x.User).FirstOrDefaultAsync(x => x.TeleChatId == clientForm.ChatId);
        //         if (foundClient == null)
        //             return new ClientBotViewModel("CLIENT_NOT_FOUND");
        //     }


        //     if (action == null)
        //         return new ClientBotViewModel("ACTION_NOT_FOUND");

        //     if (string.IsNullOrEmpty(clientForm.BotChannel))
        //         return new ClientBotViewModel("CHANNEL_IS_UNKNOWN");

        //     if (string.IsNullOrEmpty(clientForm.ChatId))
        //         return new ClientBotViewModel("CHAT_ID_IS_EMPTY");

        //     var client = new ClientBot();
        //     if (clientForm.BotChannel == BotChannelConstants.Telegram)
        //         client.TeleChatId = clientForm.ChatId;
        //     if (clientForm.BotChannel == BotChannelConstants.VKontakte)
        //         client.VkChatId = clientForm.ChatId;
        //     if (clientForm.BotChannel == BotChannelConstants.WhatsApp)
        //         client.WhatsAppChatId = clientForm.ChatId;

        //     client = await ExecuteActionAsync(client, clientForm, actCode);



        //     if (client == null)
        //         return new ClientBotViewModel("ACTION_NOT_EXISTS");

        //     await _dbContext.SaveChangesAsync();
        //     return _mapper.Map<ClientBotViewModel>(client);
        // }

        private async Task<ClientBot> ExecuteActionAsync(ClientBot client, ClientBotForm clientForm, string actCode)
        {
            var actionList = await this.BotActions.ToListAsync();

            // switch (actCode)
            // {
            //     case ActionConstants.ROLE_IS_STUDENT:
            //         client.ClientRole = await _roleManager.FindByNameAsync("student");
            //         break;
            //     case ActionConstants.ROLE_IS_TEACHER:
            //         client.ClientRole = await _roleManager.FindByNameAsync("teacher");
            //         break;
            //     case ActionConstants.ROLE_IS_ENROLLEE:
            //         client.ClientRole = await _roleManager.FindByNameAsync("enrollee");
            //         break;
            //     default:
            //         return null;
            // }

            return client;
        }
    }
}
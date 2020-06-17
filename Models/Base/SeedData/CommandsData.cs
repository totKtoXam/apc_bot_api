using System.Linq;
using apc_bot_api.Constants;
using apc_bot_api.Models.Bots;
using apc_bot_api.Models.Content;
using Microsoft.AspNetCore.Identity;

namespace apc_bot_api.Models.Base.SeedData
{
    public static class CommandsData
    {
        public static void AddSeedData(AppDbContext _dbContext, RoleManager<IdentityRole> _roleManager)
        {
            var actionType = _dbContext.CommandTypes.FirstOrDefault(x => x.Code == CommandConstants.Types.Action);
            var infoType = _dbContext.CommandTypes.FirstOrDefault(x => x.Code == CommandConstants.Types.Information);
            var actionSelectorType = _dbContext.CommandTypes.FirstOrDefault(x => x.Code == CommandConstants.Types.ActionSelector);


            var enrolleeRole = _roleManager.FindByNameAsync(RoleConstants.Enrollee).GetAwaiter().GetResult();
            var adminRole = _roleManager.FindByNameAsync(RoleConstants.Admin).GetAwaiter().GetResult();
            var teacherRole = _roleManager.FindByNameAsync(RoleConstants.Teacher).GetAwaiter().GetResult();
            var studentRole = _roleManager.FindByNameAsync(RoleConstants.Student).GetAwaiter().GetResult();

            #region  Start
            var startCommand = _dbContext.Commands.FirstOrDefault(x => x.Code == CommandConstants.Commands.Start);
            if (startCommand == null)
            {
                startCommand = new Command
                {
                    Name = "Процесс регистрации клиента",
                    Code = CommandConstants.Commands.Start,
                    Condition = "on_start_to_reg",
                    Description = "процесс регистрации",
                    Message = "Здравствуйте! \n\n Выберите одну из перечисленных ролей: студент, преподаватель и абитуриент. \n\n Вы можете воспользоваться одной из предоставленных Вам кнопок.",
                    Type = actionSelectorType
                };
                _dbContext.Commands.Add(startCommand);
            };
            #endregion

            #region AboutUs
            var aboutUsCommand = _dbContext.Commands.FirstOrDefault(x => x.Code == CommandConstants.Commands.Help);
            if (aboutUsCommand == null)
            {
                aboutUsCommand = new Command
                {
                    Name = "О нас",
                    Code = CommandConstants.Commands.AboutUs,
                    Condition = "about_us",
                    Description = "краткая информация об учебном заведении",
                    Message = "",
                    Type = infoType
                };
                _dbContext.Commands.Add(startCommand);
            }
            #endregion

            #region SendAppealByEnrollee
            var sendAppealByEnrolleeCommand = _dbContext.Commands.FirstOrDefault(x => x.Code == CommandConstants.Commands.SendAppeal);
            if (sendAppealByEnrolleeCommand == null)
            {
                sendAppealByEnrolleeCommand = new Command
                {
                    Name = "предварительная подача заявки на поступление",
                    Code = CommandConstants.Commands.SendAppeal,
                    Condition = "on_send_appeal_by_enrolle",
                    Description = "предварительная подача заявки на поступление",
                    Message = "предварительная подача заявки на поступление. Подаются лишь копии, после подачи необходимо посетить учебное заведение, чтобы передать подлинники из перечня документов",
                    Type = actionType
                };
                _dbContext.Commands.Add(sendAppealByEnrolleeCommand);

                var enrolleeRoleAccessToSendAppel = new CommandRole(sendAppealByEnrolleeCommand, enrolleeRole);
                _dbContext.CommandRoles.Add(enrolleeRoleAccessToSendAppel);
            }
            #endregion

            #region specialities
            var specsCommand = _dbContext.Commands.FirstOrDefault(x => x.Code == CommandConstants.Commands.Specs);
            if (specsCommand == null)
            {
                specsCommand = new Command
                {
                    Name = "специальности",
                    Code = CommandConstants.Commands.Specs,
                    Condition = "",
                    Description = "список всех специальностей",
                    Type = infoType
                };
                _dbContext.Commands.Add(specsCommand);
            }
            #endregion

            #region NewTask
            var newTask = _dbContext.Commands.FirstOrDefault(x => x.Code == CommandConstants.Commands.NewTask);
            if (newTask == null)
            {
                newTask = new Command
                {
                    Name = "новая задача",
                    Code = CommandConstants.Commands.NewTask,
                    Condition = "",
                    Description = "указание новой задачи для студентов",
                    Message = "Опишите задачу:\n",
                    Type = actionType
                };
                _dbContext.Commands.Add(newTask);
            }
            #endregion

            #region ActiveTasks
            var activeTasks = _dbContext.Commands.FirstOrDefault(x => x.Code == CommandConstants.Commands.ActiveTasks);
            if (activeTasks == null)
            {
                activeTasks = new Command
                {
                    Name = "задачи",
                    Code = CommandConstants.Commands.ActiveTasks,
                    Condition = "",
                    Description = "получение списка активных задач",
                    Type = infoType
                };
                _dbContext.Commands.Add(activeTasks);
            }
            #endregion

            #region SendAppeal
            var sendAppeal = _dbContext.Commands.FirstOrDefault(x => x.Code == CommandConstants.Commands.SendAppeal);
            if (sendAppeal == null)
            {
                sendAppeal = new Command
                {
                    Name = "заявка",
                    Code = CommandConstants.Commands.SendAppeal,
                    Condition = "",
                    Description = "подача заявки на поступление",
                    Message = "Укажите свой ИИН:",
                    Type = infoType
                };
                _dbContext.Commands.Add(sendAppeal);
            }
            #endregion

            #region Help
            var helpCommand = _dbContext.Commands.FirstOrDefault(x => x.Code == CommandConstants.Commands.Help);
            if (helpCommand == null)
            {
                helpCommand = new Command
                {
                    Name = "помощь",
                    Code = CommandConstants.Commands.Help,
                    Condition = "help",
                    Description = "вывод всех комманд и возможностей",
                    Type = infoType
                };
                _dbContext.Commands.Add(helpCommand);
            }
            #endregion
            _dbContext.SaveChanges();
        }
    }
}
using System.Linq;
using apc_bot_api.Constants;
using apc_bot_api.Models.Bots;
using apc_bot_api.Models.Content;
using Microsoft.AspNetCore.Identity;

namespace apc_bot_api.Models.Base.SeedData
{
    public static class StepsData
    {
        public static void AddSeedData(AppDbContext _dbContext, RoleManager<IdentityRole> _roleManager)
        {
            var actionType = _dbContext.StepTypes.FirstOrDefault(x => x.Code == StepConstants.Types.Action);
            var infoType = _dbContext.StepTypes.FirstOrDefault(x => x.Code == StepConstants.Types.Information);
            var actionSelectorType = _dbContext.StepTypes.FirstOrDefault(x => x.Code == StepConstants.Types.ActionSelector);


            var enrolleeRole = _roleManager.FindByNameAsync(RoleConstants.Enrollee).GetAwaiter().GetResult();
            var adminRole = _roleManager.FindByNameAsync(RoleConstants.Admin).GetAwaiter().GetResult();
            var teacherRole = _roleManager.FindByNameAsync(RoleConstants.Teacher).GetAwaiter().GetResult();
            var studentRole = _roleManager.FindByNameAsync(RoleConstants.Student).GetAwaiter().GetResult();


            #region  Start
            var startStep = _dbContext.Steps.FirstOrDefault(x => x.Code == StepConstants.Steps.Start);
            if (startStep == null)
            {
                startStep = new Step
                {
                    Name = "Процесс регистрации клиента",
                    Code = StepConstants.Steps.Start,
                    Condition = "on_start_to_reg",
                    Description = "процесс регистрации",
                    Message = "Здравствуйте! \n\n Выберите одну из перечисленных ролей: студент, преподаватель и абитуриент. \n\n Вы можете воспользоваться одной из предоставленных Вам кнопок.",
                    Type = actionSelectorType
                };
                _dbContext.Steps.Add(startStep);
            };
            #endregion

            #region AboutUs
            var aboutUsStep = _dbContext.Steps.FirstOrDefault(x => x.Code == StepConstants.Steps.Help);
            if (aboutUsStep == null)
            {
                aboutUsStep = new Step
                {
                    Name = "О нас",
                    Code = StepConstants.Steps.AboutUs,
                    Condition = "about_us",
                    Description = "краткая информация об учебном заведении",
                    Message = "",
                    Type = infoType
                };
                _dbContext.Steps.Add(startStep);
            }
            #endregion

            #region SendAppealByEnrollee
            var sendAppealByEnrolleeStep = _dbContext.Steps.FirstOrDefault(x => x.Code == StepConstants.Steps.SendAppeal);
            if (sendAppealByEnrolleeStep == null)
            {
                sendAppealByEnrolleeStep = new Step
                {
                    Name = "предварительная подача заявки на поступление",
                    Code = StepConstants.Steps.SendAppeal,
                    Condition = "on_send_appeal_by_enrolle",
                    Description = "предварительная подача заявки на поступление",
                    Message = "предварительная подача заявки на поступление. Подаются лишь копии, после подачи необходимо посетить учебное заведение, чтобы передать подлинники из перечня документов",
                    Type = actionType
                };
                _dbContext.Steps.Add(sendAppealByEnrolleeStep);

                var enrolleeRoleAccessToSendAppel = new StepRole(sendAppealByEnrolleeStep, enrolleeRole);
            }
            #endregion

            #region Help
            var helpStep = _dbContext.Steps.FirstOrDefault(x => x.Code == StepConstants.Steps.Help);
            if (helpStep == null)
            {
                helpStep = new Step
                {
                    Name = "помощь",
                    Code = StepConstants.Steps.Help,
                    Condition = "help",
                    Description = "вывод всех комманд и возможностей",
                    Type = infoType
                };
                _dbContext.Steps.Add(helpStep);
            }
            #endregion
            _dbContext.SaveChanges();
        }
    }
}
using System.Linq;
using apc_bot_api.Constants;
using apc_bot_api.Models.Bots;

namespace apc_bot_api.Models.Base.SeedData
{
    public class BotActionsData
    {
        public static void AddSeedData(AppDbContext _dbContext)
        {
            #region StartStepRolesActions
            var startStep = _dbContext.Steps.FirstOrDefault(x => x.Code == StepConstants.Steps.Start);

            var studentRoleSelectAction = _dbContext.BotActions.FirstOrDefault(x => x.Code == BotConstants.Actions.ROLE_IS_STUDENT);
            if (studentRoleSelectAction == null)
            {
                studentRoleSelectAction = new BotAction
                {
                    Name = "студент",
                    Code = BotConstants.Actions.ROLE_IS_STUDENT,
                    Condition = BotConstants.Actions.ROLE_IS_STUDENT,
                    CurrnetStep = startStep,
                    IsEdit = true
                };
                _dbContext.BotActions.Add(studentRoleSelectAction);
            }

            var teacherRoleSelectAction = _dbContext.BotActions.FirstOrDefault(x => x.Code == BotConstants.Actions.ROLE_IS_TEACHER);
            if (teacherRoleSelectAction == null)
            {
                teacherRoleSelectAction = new BotAction
                {
                    Name = "преподаватель",
                    Code = BotConstants.Actions.ROLE_IS_TEACHER,
                    Condition = BotConstants.Actions.ROLE_IS_TEACHER,
                    CurrnetStep = startStep,
                    IsEdit = true
                };
                _dbContext.BotActions.Add(teacherRoleSelectAction);
            }

            var enrolleeRoleSelectAction = _dbContext.BotActions.FirstOrDefault(x => x.Code == BotConstants.Actions.ROLE_IS_ENROLLEE);
            if (enrolleeRoleSelectAction == null)
            {
                enrolleeRoleSelectAction = new BotAction
                {
                    Name = "абитуриент",
                    Code = BotConstants.Actions.ROLE_IS_ENROLLEE,
                    Condition = BotConstants.Actions.ROLE_IS_ENROLLEE,
                    CurrnetStep = startStep,
                    IsEdit = true
                };
                _dbContext.BotActions.Add(enrolleeRoleSelectAction);
            }
            #endregion

            _dbContext.SaveChanges();
        }
    }
}
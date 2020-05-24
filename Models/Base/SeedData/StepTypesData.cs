using System.Linq;
using apc_bot_api.Constants;
using apc_bot_api.Models.Types;
using Microsoft.AspNetCore.Identity;

namespace apc_bot_api.Models.Base.SeedData
{
    public static class StepTypesData
    {
        public static void AddSeedData(AppDbContext _dbContext)
        {
            var action = _dbContext.StepTypes.FirstOrDefault(x => x.Code == StepConstants.Types.Action);
            if (action == null)
            {
                action = new StepType
                    (
                        "действие",
                        StepConstants.Types.Action,
                        "action",
                        "тип, указывающий что шаг является действием бот-клиента"
                    );
                _dbContext.StepTypes.Add(action);
            }

            var information = _dbContext.StepTypes.FirstOrDefault(x => x.Code == StepConstants.Types.Information);
            if (information == null)
            {
                information = new StepType
                    (
                        "информация",
                        StepConstants.Types.Information,
                        "information",
                        "шаг является информативным, не выполняющий какого-либо изменения в данных"
                    );
                _dbContext.StepTypes.Add(information);
            }

            var actionSelector = _dbContext.StepTypes.FirstOrDefault(x => x.Code == StepConstants.Types.ActionSelector);
            if (actionSelector == null)
            {
                actionSelector = new StepType
                    (
                        "действие с выбором",
                        StepConstants.Types.ActionSelector,
                        "action with selector",
                        "действие с последующей выборкой данных"
                    );
                _dbContext.StepTypes.Add(actionSelector);
            }
        }
    }
}
using System.Linq;
using apc_bot_api.Constants;
using apc_bot_api.Models.Types;
using Microsoft.AspNetCore.Identity;

namespace apc_bot_api.Models.Base.SeedData
{
    public static class CommandTypesData
    {
        public static void AddSeedData(AppDbContext _dbContext)
        {
            var action = _dbContext.CommandTypes.FirstOrDefault(x => x.Code == CommandConstants.Types.Action);
            if (action == null)
            {
                action = new CommandType
                    (
                        "действие",
                        CommandConstants.Types.Action,
                        "action",
                        "тип, указывающий что шаг является действием бот-клиента"
                    );
                _dbContext.CommandTypes.Add(action);
            }

            var information = _dbContext.CommandTypes.FirstOrDefault(x => x.Code == CommandConstants.Types.Information);
            if (information == null)
            {
                information = new CommandType
                    (
                        "информация",
                        CommandConstants.Types.Information,
                        "information",
                        "шаг является информативным, не выполняющий какого-либо изменения в данных"
                    );
                _dbContext.CommandTypes.Add(information);
            }

            var actionSelector = _dbContext.CommandTypes.FirstOrDefault(x => x.Code == CommandConstants.Types.ActionSelector);
            if (actionSelector == null)
            {
                actionSelector = new CommandType
                    (
                        "действие с выбором",
                        CommandConstants.Types.ActionSelector,
                        "action with selector",
                        "действие с последующей выборкой данных"
                    );
                _dbContext.CommandTypes.Add(actionSelector);
            }
        }
    }
}
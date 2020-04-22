using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apc_bot_api.Models.Base;
using apc_bot_api.Models.Bots;
using apc_bot_api.Models.Content;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace apc_bot_api.Repositories
{
    public interface IBotRepository
    {
        Task<List<BotActionViewModel>> GetBotActionsAsync(string stepCode);
        Task<List<StepWithActionsViewModel>> GetStepWithActionsByActionCode(string actCode);
    }
    public class BotRepository : IBotRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public BotRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        private IQueryable<BotAction> BotActions => _dbContext.BotActions
                                                            .Include(x => x.PrevStep)
                                                            .Include(x => x.NextStep);

        private async Task<BotActionViewModel> BotActionModelByCode(string actCode) =>
                        await this.BotActions
                                    .Select(x => _mapper.Map<BotActionViewModel>(x))
                                    .FirstOrDefaultAsync(x => x.Code == actCode);

        private IQueryable<StepWithActionsViewModel> GetQStepWithActionsByPrevStep(BotActionViewModel actionModel)
        {
            var stepWithActions = from step in _dbContext.Steps
                                  join action in _dbContext.BotActions
                                  on step.Id equals action.PrevStep.Id
                                  where actionModel.PrevStepId == step.Id.ToString()
                                  select new StepWithActionsViewModel()
                                  {
                                      StepId = step.Id.ToString(),
                                      StepName = step.Name,
                                      StepCode = step.Code,
                                      StepCondition = step.Condition,
                                      ActionList = this.BotActions
                                                    .Where(x => x.PrevStep != null && x.PrevStep.Id == step.Id)
                                                    .Select(x => _mapper.Map<BotActionViewModel>(x))
                                                    .ToList()
                                  };

            return stepWithActions;
        }

        public async Task<List<BotActionViewModel>> GetBotActionsAsync(string stepCode)
        {
            var botActionModelList = await this.BotActions
                                        .Where(x => x.PrevStep != null && x.PrevStep.Code == stepCode)
                                        .Select(x => _mapper.Map<BotActionViewModel>(x))
                                        .ToListAsync();

            return botActionModelList;
        }

        public async Task<List<StepWithActionsViewModel>> GetStepWithActionsByActionCode(string actCode)
        {
            var botActionModel = await this.BotActionModelByCode(actCode);
            var step = GetQStepWithActionsByPrevStep(botActionModel);

            return await step.ToListAsync();
        }
    }
}
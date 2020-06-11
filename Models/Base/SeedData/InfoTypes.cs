using System.Linq;
using apc_bot_api.Constants;
using apc_bot_api.Models.Types;

namespace apc_bot_api.Models.Base.SeedData
{
    public class InfoTypes
    {
        public static void AddSeedData(AppDbContext _dbContext)
        {
            var specsType = _dbContext.InfoTypes.FirstOrDefault(x => x.Code == InfoConstants.Types.Specialities);
            if (specsType == null)
            {
                specsType = new InfoType("специальности", "on_specs_exec", "описание специальности", "");
                _dbContext.InfoTypes.Add(specsType);
            }

            _dbContext.SaveChanges();
        }
    }
}
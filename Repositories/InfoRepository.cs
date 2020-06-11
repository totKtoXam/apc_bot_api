using System.Linq;
using System.Threading.Tasks;
using apc_bot_api.Models.Base;
using apc_bot_api.Models.Content;
using Microsoft.EntityFrameworkCore;

namespace apc_bot_api.Repositories
{
    public interface IInfoRepository
    {
        Task<Result<SpecialityViewModel>> GetSpecByShortNameAsync(string shortName);
    }
    public class InfoRepository : IInfoRepository
    {
        private readonly AppDbContext _dbContext;
        public InfoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        IQueryable<Speciality> Specialities => _dbContext.Specialities.AsQueryable();

        public async Task<Result<SpecialityViewModel>> GetSpecByShortNameAsync(string shortName)
        {
            shortName = shortName.Trim();
            var spec = await this.Specialities.FirstOrDefaultAsync(x => x.Short.ToUpper() == shortName.ToUpper());

            if (spec == null)
                return new Result<SpecialityViewModel>(404, "SPECIALITY_NOT_FOUND", "", "Извините, но указанная Вами специальность не найдена.");

            var viewModel = new SpecialityViewModel();
            viewModel.Id = spec.Id;
            viewModel.Short = spec.Short;
            viewModel.Message = $"{spec.SpecialtyNum} - {spec.SpecialtyName}\n\nКлассификации: {spec.ClassificName}\nСтоимость: {spec.Price}\n" +
                                $"Языки обучения: {spec.Languages}\nФорма обучения: {spec.StudyType}\nПериод обучения: {spec.StudyPeriod}";
            return new Result<SpecialityViewModel>(viewModel);
        }
    }
}
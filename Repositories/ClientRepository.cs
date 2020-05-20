using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apc_bot_api.Models.Base;
using apc_bot_api.Models.Users;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace apc_bot_api.Repositories
{
    public interface IClientRepository
    {
        List<T> GetUserModelList<T>(string usersName);
    }

    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public ClientRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<T> GetUserModelList<T>(string usersName)
        {
            List<T> list = new List<T>();
            if (string.IsNullOrEmpty(usersName))
                return null;

            switch (usersName)
            {
                case "teachers":
                    list = _dbContext.Teachers
                            .Include(x => x.ClientBot)
                            .ThenInclude(x => x.User)
                            .Select(x => _mapper.Map<T>(x))
                            .ToList();
                    break;
                case "students":
                    list = _dbContext.Students
                                .Include(x => x.ClientBot)
                                .ThenInclude(x => x.User)
                                .Select(x => _mapper.Map<T>(x))
                                .ToList();
                    break;
                case "enrollees":
                    break;
            }

            return list;
        }
    }
}
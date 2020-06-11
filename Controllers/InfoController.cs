using System.Threading.Tasks;
using apc_bot_api.Models.Base;
using apc_bot_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace apc_bot_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InfoController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IInfoRepository _info;
        public InfoController(AppDbContext dbContext, IInfoRepository info)
        {
            _dbContext = dbContext;
            _info = info;
        }

        [HttpGet("spec/{shortName}")]
        public async Task<IActionResult> GetSpec(string shortName)
        {
            var result = await _info.GetSpecByShortNameAsync(shortName);
            return Ok(result);
        }
    }
}
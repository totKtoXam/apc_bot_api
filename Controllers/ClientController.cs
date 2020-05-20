using System.Threading.Tasks;
using apc_bot_api.Models.Base;
using apc_bot_api.Models.Users;
using apc_bot_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace apc_bot_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IClientRepository _client;
        public ClientController(AppDbContext dbContext, IClientRepository client)
        {
            _dbContext = dbContext;
            _client = client;
        }

        [HttpGet("teacher")]
        public IActionResult GetTeacherList()
        {
            var result = _client.GetUserModelList<TeacherViewModel>("teachers");
            return Ok(result);
        }

        [HttpGet("student")]
        public IActionResult GetStudentList()
        {
            var result = _client.GetUserModelList<StudentViewModel>("students");
            return Ok(result);
        }

        [HttpGet("enrollee")]
        public IActionResult GetEnrolleeList()
        {
            var result = _client.GetUserModelList<TeacherViewModel>("enrollees");
            return Ok(result);
        }

    }
}
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using apc_bot_api.Helpers;
using apc_bot_api.Models.Base;
using apc_bot_api.Models.Sendler;
using apc_bot_api.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace apc_bot_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SendlerController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IBotRepository _botRepos;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        
        //// REPOSITORIES
        private readonly ISendlerRepository _sendler;

        public SendlerController(
                AppDbContext dbContext,
                IBotRepository botRepos,
                IMapper mapper,
                RoleManager<IdentityRole> roleManager,
                //// REPOSITORIES
                ISendlerRepository sendler
            )
        {
            _dbContext = dbContext;
            _botRepos = botRepos;
            _mapper = mapper;
            _roleManager = roleManager;
            _sendler = sendler;
        }

        [HttpPost]
        public IActionResult GetGroups (CheckSendler checkSendler)
        {
            var groups = SendlerHelper.GetHashtagTextFromPost(checkSendler.Text);

            return Ok(groups);
        }

        [HttpPost("vkpost")]
        public IActionResult CallSendler(SendlerPostForm sendlerForm)
        {
            var result = _sendler.GetStudentReceivers(sendlerForm);
            return Ok(result);
            
            // var imageUrl = "https://sun9-11.userapi.com/c840329/v840329318/cdeb/dHft4lHtLao.jpg";/
            // byte[] imageBytes = null;
            // using (WebClient webClient = new WebClient())
            // {
            //     imageBytes = webClient.DownloadData(imageUrl);
            // }

            // WebClient webClient = new WebClient();
            // var bytes = default(byte[]);
            // var results = "";
            // Uri imgUrl = new Uri("https://sun9-11.userapi.com/c840329/v840329318/cdeb/dHft4lHtLao.jpg");
            // using (Stream stream = webClient.OpenRead(imgUrl))
            // {
            //     using (StreamReader reader = new StreamReader(stream))
            //     {
            //         var result = "";
            //         results = Convert.ToByte(reader.ReadLine());
            //         while((result = reader.ReadLine()) != null) 
            //         {
            //             Console.WriteLine(result);
            //         }
            //     }
            // }
            // WebRequest request = WebRequest.Create("https://sun9-11.userapi.com/c840329/v840329318/cdeb/dHft4lHtLao.jpg");
            // WebResponse response = await request.GetResponseAsync();
            
            // Image image = Image.FromFile(@"https://sun9-11.userapi.com/c840329/v840329318/cdeb/dHft4lHtLao.jpg");
            // System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            // image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            // byte[] b = memoryStream.ToArray();
        }
    }
}
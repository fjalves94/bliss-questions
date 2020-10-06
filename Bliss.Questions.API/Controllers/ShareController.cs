using System.Net;
using System.Threading.Tasks;
using Bliss.Questions.API.DTO;
using Bliss.Questions.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bliss.Questions.API.Controllers
{

    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    public class ShareController
    {
        private readonly IShareService _shareService;

        public ShareController(IShareService shareService) 
        {
            _shareService = shareService;
        }

        [HttpPost]
        public async Task<ShareDTO> Post([FromQuery] string destination_email, [FromQuery] string content_url) 
        {
            var error = "Bad Request. Either destination_email not valid or empty content_url";
            if (content_url == null) 
            {
                return new ShareDTO 
                {
                    status = error
                };
            }

            var response = await _shareService.Share(content_url, destination_email);
            if (response.StatusCode != HttpStatusCode.Accepted) 
            {
                return new ShareDTO 
                {
                    status = error
                };
            }

            return new ShareDTO 
            {
                status = "OK"
            };
        }
    }
}
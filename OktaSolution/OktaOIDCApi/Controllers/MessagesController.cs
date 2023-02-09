using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OktaOIDCApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;
            var message = new Messages { Name = userId, Date = DateTime.Now };

            return Ok(message);
        }
    }

    public class Messages
    {
        public string? Name { get; set; }
        public DateTime Date { get; set; }
    }
}

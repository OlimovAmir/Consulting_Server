using Consulting_Server.Models;
using Consulting_Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace Consulting_Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageFromUserController : BaseController<MessageFromUser>
    {
        public MessageFromUserController(ILogger<MessageFromUserController> logger, IMessageFromUserService service) : base(logger, service)
        {
        }
    }
}

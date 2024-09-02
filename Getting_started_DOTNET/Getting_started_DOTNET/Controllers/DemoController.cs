using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Getting_started_DOTNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpGet]
        public string SayHelloAPI()
        {
            return "Hello to API";
        }
    }
}

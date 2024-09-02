using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Getting_started_DOTNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Demo2Controller : ControllerBase
    {
        [HttpGet]

        public string PrintMyNameAPI()
        {
            return "My name is Steve Ondieki";
        }
    }
}

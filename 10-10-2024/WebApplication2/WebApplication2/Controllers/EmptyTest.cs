using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmptyTest : ControllerBase
    {
        [HttpGet]
        public string Get() { 
            return "value";
        }
        [HttpGet]
        public string Getre()
        {
            return "this";
        }

    }
}

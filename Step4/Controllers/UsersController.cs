using Microsoft.AspNetCore.Mvc;

namespace Step4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        [Route("TestGetUsers")]
        public async Task<IActionResult> TestGetUsers()
        {
            var data = new List<string>() { "John", "Robert" };
            return Ok(data);
        }



        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {


            // Request represents the incoming HTTP request from the client.
            var request = HttpContext.Request;


            var schemeName = request.Scheme;

            var protocolName   = request.Protocol;

            var pathName = request.Path;


            //http , https , mailTo , Tel

            //var data = new List<string>() { "John", "Robert" };


            var details = new
            {
                schemeName = schemeName,
                protocal = protocolName,
                paname = pathName,
            };
            return Ok(details);
        }


    }
}

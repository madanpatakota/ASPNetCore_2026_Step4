using Microsoft.AspNetCore.Mvc;
using Step4.Services;

namespace Step4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly UsersService _userService;

        public UsersController(UsersService userService)  //= //new UserService();
        {
            _userService = userService;
        }



        [HttpGet]
        [Route("TestGetUsers")]
        public async Task<IActionResult> TestGetUsers()
        {
            var data = new List<string>() { "John", "Robert" };
            return Ok(data);
        }



        [HttpGet]
        [Route("GetUsers_Test")]
        public async Task<IActionResult> GetUsers_Test()
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





        //what i understand in this endpoint .
        // My data thats the Users Data available in My machine.  - correct 

        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();   // OK good

            // Returns users as JSON with HTTP 200 OK
            return Ok(users);


           //https://dummyjson.com/users    - api to get the users
        }



        [HttpGet]
        [Route("DummyGetUsers")]
        public async Task<IActionResult> DummyGetUsers()
        {
            //var users = _userService.GetUsers();   // OK good

            // Returns users as JSON with HTTP 200 OK

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("https://dummyjson.com/users");

            ////https://localhost:4356/api/users/getAllusersList - you can do that  - 4 pm.

            HttpContent content = response.Content;

            string result       = await content.ReadAsStringAsync();

            return Content(result, "application/json");


            //    - api to get the users
        }



    }
}

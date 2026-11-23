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
        [Route("GetUsersFromExternalAPI")]
        public async Task<IActionResult> DummyGetUsers()
        {
            //var users = _userService.GetUsers();   // OK good

            // Returns users as JSON with HTTP 200 OK

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("https://dummyjson.com/users");
            //what does mean which i do't have in my control

            ////https://localhost:4356/api/users/getAllusersList - you can do that  - 4 pm.

            HttpContent content = response.Content;

            string result       = await content.ReadAsStringAsync();

            return Content(result, "application/json");


            //    - api to get the users
        }



        //https://localhost:7259/api/UsersData/GetUsers

        //what i did Last - 10 mins 

        [HttpGet]
        [Route("GetUsersFromLocalHost")]
        public async Task<IActionResult> GetUsersFromLocalHost()
        {
            //var users = _userService.GetUsers();   // OK good

            // Returns users as JSON with HTTP 200 OK

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("https://localhost:7259/api/UsersData/GetUsers");
            //what does mean which i do't have in my control

            ////https://localhost:4356/api/users/getAllusersList - you can do that  - 4 pm.

            HttpContent content = response.Content;

            string result = await content.ReadAsStringAsync();

            return Content(result, "application/json");


            //    - api to get the users
        }





        //from the ________________ 
        // i need to communicate method i need the UserId=1&UserName=madan these deeal
        //https://localhost:7259/api/UsersData/GetUsersByQuery?UserId=1&UserName=madan



        //GetUsersFromLocalHostQuery

        [HttpGet]
        [Route("GetUsersFromLocalHostQuery")]
        public async Task<IActionResult> GetUsersFromLocalHostQuery(
            [FromQuery] int uid , [FromQuery] string uname)
        {
            //var users = _userService.GetUsers();   // OK good

            // Returns users as JSON with HTTP 200 OK

            HttpClient client = new HttpClient();

            string url = $"https://localhost:7259/api/UsersData/GetUsersByQuery?UserId={uid}&UserName={uname}";

            HttpResponseMessage response = await client.GetAsync(url);
            //what does mean which i do't have in my control

            ////https://localhost:4356/api/users/getAllusersList - you can do that  - 4 pm.

            HttpContent content = response.Content;

            string result = await content.ReadAsStringAsync();

            return Content(result, "application/json");


            //    - api to get the users
        }





    }
}

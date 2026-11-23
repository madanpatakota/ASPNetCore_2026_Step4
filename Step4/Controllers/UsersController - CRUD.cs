using Microsoft.AspNetCore.Mvc;
using Step4.Models;
using Step4.Services;
using static System.Net.WebRequestMethods;

namespace Step4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersDataCRUDController : ControllerBase
    {

        private readonly UsersService _userService;

        public UsersDataCRUDController(UsersService userService)  //= //new UserService();
        {
            _userService = userService;
        }


        [HttpPost]
        [Route("CreateUserFromLocalHostAPI")]

        public async Task<IActionResult> CreateUserFromLocalHostAPI(
            [FromBody] User user)
        {

            HttpClient client = new HttpClient();


            //how to create the new user?

            //i want to give my details - hard coded 
            //var userdetails = new User()
            //{
            //    user
            //};


            string url = "https://localhost:7259/api/UsersData/CreateUser";

            // i need to give the user data

            //NY.com -->  register the themselves 

            //JSON  Datatype

            //home work 






        }
    }
}

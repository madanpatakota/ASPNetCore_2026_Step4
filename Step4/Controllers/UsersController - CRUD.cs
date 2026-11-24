using Microsoft.AspNetCore.Mvc;
using Step4.Models;
using Step4.Services;
using System.Net;
using System.Text;
using System.Text.Json;
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
        public async Task<IActionResult> CreateUserFromLocalHostAPI()
        {
            var userDetails = new
            {
                Id = 1,
                FirstName = "Madan"
            };

            string jsonDAta = JsonSerializer.Serialize(userDetails);

            StringContent content = new StringContent(jsonDAta,  Encoding.UTF8 ,  "application/json");

            string url = "https://localhost:7259/api/UsersData/CreateUser";

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.PostAsync(url, content);
            
            string result = await response.Content.ReadAsStringAsync();

            NewUser? nuser = JsonSerializer.Deserialize<NewUser>(result); 

            // you can write code for nuser
            return Content(result, "application/json");

        }



        [HttpPut]
        [Route("UpdateUserFromLocalHostAPI")]
        public async Task<IActionResult> UpdateUserFromLocalHostAPI()
        {
            var userDetails = new
            {
                Id = 1,
                FirstName = "Madan"
            };

            var UserID = 1;

            string jsonDAta = JsonSerializer.Serialize(userDetails);

            StringContent content = new StringContent(jsonDAta, Encoding.UTF8, "application/json");

            string url = $"https://localhost:7259/api/UsersData/UpdateUser?UserId={UserID}";

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("ApiKey", "MISARD123");

            HttpResponseMessage response = await client.PutAsync(url, content);

            string result = await response.Content.ReadAsStringAsync();

            HttpStatusCode code =  response.StatusCode;   //201 , 200 , 500 , 401 ,

            int code1 = (int)response.StatusCode;         //type converstion

            NewUser? nuser = JsonSerializer.Deserialize<NewUser>(result);

            // you can write code for nuser
            return Content(result, "application/json");
        }




        // Calls another Web API to delete a user based on UserId
        [HttpDelete]
        [Route("UpdateDeleteFromLocalHostAPI")]
        public async Task<IActionResult> DeleteUserFromLocalHostAPI(
            [FromQuery] int UserId)
        {
            // Create HttpClient
            using HttpClient client = new HttpClient();

            // Prepare API URL with query parameter
            string url = $"https://localhost:7002/api/Users/DeleteUser?UserId={UserId}";

            // Add authentication key to HTTP request headers
            client.DefaultRequestHeaders.Add("ApiKey", "MISARD123");

            // Send DELETE request to another Web API
            using HttpResponseMessage response =
                await client.DeleteAsync(url);

            // Read response content as string
            string result =
                await response.Content.ReadAsStringAsync();

            // Return error if the API request fails
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, result);
            }

            // Set the HTTP status code received from the Users API
            Response.StatusCode = (int)response.StatusCode;

            // Return JSON text to the client
            return Content(result, "application/json");
        }

















    }
}

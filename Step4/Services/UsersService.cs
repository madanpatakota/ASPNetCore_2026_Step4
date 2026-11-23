using Step4.Models;

namespace Step4.Services
{
    public class UsersService
    {
        // 3 Users
        public List<User> GetUsers()
        {
            return new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "Emily",
                    LastName = "Johnson",
                    Age = 29,
                    Gender = "Female",
                    Email = "emily.johnson@x.dummyjson.com",
                    Phone = "+81 965-431-3024",
                    City = "Phoenix",
                    Department = "Engineering",
                    Role = "Admin"
                },
                new User
                {
                    Id = 2,
                    FirstName = "Michael",
                    LastName = "Williams",
                    Age = 36,
                    Gender = "Male",
                    Email = "michael.williams@x.dummyjson.com",
                    Phone = "+49 258-627-6644",
                    City = "Houston",
                    Department = "Support",
                    Role = "User"
                },
                new User
                {
                    Id = 3,
                    FirstName = "Sophia",
                    LastName = "Brown",
                    Age = 27,
                    Gender = "Female",
                    Email = "sophia@example.com",
                    Phone = "+1 555-123-4567",
                    City = "New York",
                    Department = "HR",
                    Role = "User"
                }
            };
        }





        // Find a user by UserId
        public User? GetUserById(int userId)
        {
            var users = GetUsers();

            return users.FirstOrDefault(x => x.Id == userId);
        }






    }
}

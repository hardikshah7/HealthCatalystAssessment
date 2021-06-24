using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HealthCatalystAssessment.Models;
using HealthCatalystAssessment.Providers;

namespace HealthCatalystAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserProvider _userProvider;

        public UserController(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }

        [HttpGet("search")]
        public async Task<List<User>> GetUsers(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                throw new ArgumentException("Search term cannot be empty. Please provide a valid search term.");
            }
            return await _userProvider.FindUsersByFirstOrLastNameAsync(searchTerm);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(UserCreation user)
        {
            if (user == null)
            {
                throw new ArgumentException("User object cannot be null. Please provide a valid user.");
            }

            var userId = await _userProvider.CreateUserAsync(user);
            return CreatedAtAction("CreateUser", new {userId, user.FirstName, user.LastName});
        }
    }
}

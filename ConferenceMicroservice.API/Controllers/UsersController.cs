using ConferenceMicroservice.API.Contracts;
using ConferenceMicroservice.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceMicroservice.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsersResponse>>> GetUsers()
        {
            var users = await usersService.GetAllUsers();

            var response = users.Select(u => new UsersResponse(u.Id, u.Email, u.FirstName, u.SecondName, u.ThirdName, u.PhoneNumber));

            return Ok(response);
        }
    }
}

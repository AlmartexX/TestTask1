using Microsoft.AspNetCore.Mvc;
using TestTask.Services.Interfaces;

namespace TestTask.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Route("selected-users")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await this.userService.GetUsers();
            return this.Ok(result);
        }
        
        [HttpGet]
        [Route("selected-user")]
        public async Task<IActionResult> GetUser()
        {
            var result = await this.userService.GetUser();
            return this.Ok(result);
        }
    }
}

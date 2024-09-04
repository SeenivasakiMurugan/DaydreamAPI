using Daydream.BAL.Model;
using Daydream.BAL.Service.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Daydream.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("AddUpdateUser")]
        public async Task<IActionResult> AddUpdateUser(User user)
        {
            JsonResponse response= await _userService.AddUpdateUser(user);
            return Ok(response);
        }

        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> Login(string? username , string? password)
        {
            var response = await _userService.Login(username, password);
            return Ok(response);
        }
    }
}

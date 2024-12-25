using Microsoft.AspNetCore.Mvc;
using YangiHayot.Data;
using YangiHayot.Requests;
using YangiHayot.Models;
using YangiHayot.Password;

namespace YangiHayot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext dbContext;
        public AuthController(DataContext dataContext)
        {
            this.dbContext = dataContext;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginRequest request)
        {
            User? user = dbContext.Users.FirstOrDefault(u => u.Email == request.Email);

            if(user is null)
            {
                return BadRequest("Email xato");
            }

            bool passwordCheck = PasswordHelper.CkeckPassword(request.Password, user.PasswordHash, user.PasswordSalt);
            if(passwordCheck == false)
            {
                return BadRequest("Password xato");
            }

            return Ok("Email va parol to`g`ri");
        }


    }
}

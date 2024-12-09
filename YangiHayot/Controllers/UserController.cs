using YangiHayot.Interfaces;
using YangiHayot.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace YangiHayot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create(string firstName, string lastName, string phoneNumber, string email, string password, DateTime createdAt, int roleId)
        {
            User userNumber = this.userService.GetByPhoneNumber(phoneNumber);
            if (userNumber is not null)
            {
                return BadRequest("Bu telifon raqamli foydalanuvchi bazada bor!");
            }

            User userEmail = this.userService.GetByEmail(email);
            if (userEmail is not null)
            {
                return BadRequest("Bu pochta orqali foydalanuvchi bazada bor!");
            }

            User userPassword = this.userService.GetByPassword(password);
            if (userPassword is not null)
            {
                return BadRequest("Bu parol orqali foydalanuvchi bazada bor!");
            }

            User user = this.userService.Create(firstName, lastName, phoneNumber, email, password, createdAt, roleId);
            return Ok(user);
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<User> users = this.userService.GetAll();

            return Ok(users);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var user = this.userService.GetById(id);
            if (user is null)
            {
                return NotFound("Bazadan topilmadi!");
            }

            return Ok(user);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, string firstName, string lastName, string phoneNumber, string email, string password, int roleId)
        {
            var userId = this.userService.GetById(id);
            if (userId is null)
            {
                return NotFound("Bazadan topilmadi!");
            }

            User userPhoneNumber = this.userService.GetByPhoneNumber(phoneNumber);
            if (userPhoneNumber is not null)
            {
                return BadRequest("Bu telifon raqam bazada bor!");
            }

            User userEmail = this.userService.GetByEmail(email);
            if (userEmail is not null)
            {
                return BadRequest("Bu pochta bazada bor!");
            }

            User userPassword = this.userService.GetByPassword(password);
            if (userPassword is not null)
            {
                return BadRequest("Bu parol bazada bor!");
            }

            User user = this.userService.Update(id, firstName, lastName, phoneNumber, email, password, roleId);
            return Ok(user);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            User user = this.userService.GetById(id);
            if(user is not null)
            {
                this.userService.Delete(user);
            }

            return NoContent();
        }

    }
}

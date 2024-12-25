using YangiHayot.Interfaces;
using YangiHayot.Models;
using Microsoft.AspNetCore.Mvc;
using YangiHayot.Requests;
using YangiHayot.Responses;
using YangiHayot.Services;

namespace YangiHayot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        public UserController(IUserService userService, IRoleService roleService)
        {
            this.userService = userService;
            this.roleService = roleService;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create([FromBody] UserRequest request)
        {
            User userNumber = this.userService.GetByPhoneNumber(request.PhoneNumber);
            if (userNumber is not null)
            {
                return BadRequest("Bu telifon raqamli foydalanuvchi bazada bor!");
            }

            User userEmail = this.userService.GetByEmail(request.Email);
            if (userEmail is not null)
            {
                return BadRequest("Bu pochta orqali foydalanuvchi bazada bor!");
            }

            User user = this.userService.Create(request);

            var role = this.roleService.GetById(user.RoleId);

            UserResponse response = new UserResponse()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                RoleId = user.RoleId,
                RoleName = role.Name
            };

            return Ok(response);
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
        public IActionResult Update(int id, [FromBody] UserRequest request)
        {
            var userId = this.userService.GetById(id);
            if (userId is null)
            {
                return NotFound("Bazadan topilmadi!");
            }

            User userPhoneNumber = this.userService.GetByPhoneNumber(request.PhoneNumber);
            if (userPhoneNumber is not null)
            {
                return BadRequest("Bu telifon raqam bazada bor!");
            }

            User userEmail = this.userService.GetByEmail(request.Email);
            if (userEmail is not null)
            {
                return BadRequest("Bu pochta bazada bor!");
            }

            //User userPassword = this.userService.GetByPassword(request.Password);

            User user = this.userService.Update(id, request);
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

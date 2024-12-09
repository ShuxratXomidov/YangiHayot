using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YangiHayot.Models;
using YangiHayot.Services;

namespace YangiHayot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create(string roleName)
        {
            Role role = this.roleService.GetByName(roleName);
            if (role == null)
            {
                Role newrole = this.roleService.Create(roleName);
                return Ok(newrole);
            }

            return BadRequest("Bu bazada bor!");
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Role> roles = this.roleService.GetAll();

            return Ok(roles);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var role =this.roleService.GetById(id);
            if (role is null)
            {
                return NotFound();
            }

            return Ok(role);
        }


        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, string roleName)
        {
            var role = this.roleService.GetById(id);
            if(role is null)
            {
                return NotFound("Bazadan topilmadi!");
            }

            var role1 = this.roleService.GetByName(roleName);
            if(role1 is null)
            {
                Role newrole = this.roleService.Update(id, roleName);
                return Ok(newrole);
            }

            return BadRequest("Bu malumot bazada bor!");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            Role role = this.roleService.GetById(id);
            if(role is not null)
            {
                this.roleService.Delete(role);
            }

            return NoContent();
        }
    }
}

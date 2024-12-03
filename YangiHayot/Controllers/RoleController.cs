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
            Role role = this.roleService.Create(roleName);
            if(role.Name == roleName)
            {
                return BadRequest("Bu ma`lumot bazada bor!");
            }
            else
            {
                Role roleCreate = this.roleService.Create(roleName);

                return Ok(roleCreate);
            }   
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
            Role role = this.roleService.Update(id, roleName);
            if (role is null || role.Name == roleName)
            {
                return BadRequest("Oldin ham yuklangan");
            }
            else
            {
                var updateRole = this.roleService.Update(id, roleName);

                return Ok(updateRole);
            }
            
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            this.roleService.Delete(id);
            return NoContent();
        }
    }
}

using YangiHayot.Models;

namespace YangiHayot.Services
{
    public interface IRoleService
    {
        public List<Role> GetAll();
        public Role? GetById(int id);
        public  Role? GetByName(string name);
        public Role Create(string roleName);
        public Role Update(int id, string roleName);
        public void Delete(Role role);
    }
}

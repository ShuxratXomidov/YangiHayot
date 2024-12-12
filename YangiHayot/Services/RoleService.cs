using YangiHayot.Data;
using YangiHayot.Models;


namespace YangiHayot.Services
{
    public class RoleService : IRoleService
    {
        private readonly DataContext dbContext;

        public RoleService(DataContext dataContext)
        {
            this.dbContext = dataContext;
        }

        public Role Create(string roleName)
        {
            Role role = new Role();
            role.Name = roleName;

            dbContext.Roles.Add(role);
            dbContext.SaveChanges();

            return role;
        }

        public List<Role> GetAll()
        {
            List<Role> roles = dbContext.Roles.OrderBy(r => r.Id).ToList();
            return roles;
        }

        public Role GetById(int id)
        {
            var role = dbContext.Roles.FirstOrDefault(r => r.Id == id);

            return role;
        }
        public Role GetByName(string name)
        {
            var role = dbContext.Roles.FirstOrDefault(r => r.Name == name);

            return role;
        }

        public Role Update(int id, string roleName)
        {
            var role = dbContext.Roles.FirstOrDefault(r => r.Id == id);
            role.Name = roleName;

            dbContext.SaveChanges();

            return role;
        }
        public void Delete(Role role)
        {   
            dbContext.Roles.Remove(role);
            dbContext.SaveChanges();
        }
    }
        
}

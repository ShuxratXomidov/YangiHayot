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
            var roles = dbContext.Roles.ToList();
            return roles;
        }

        public Role GetById(int id)
        {
            var role = dbContext.Roles.FirstOrDefault(r => r.Id == id);

            return role;
        }
        public Role GetByName(string name)
        {
            Role role = dbContext.Roles.SingleOrDefault(r => r.Name == name);

            return role;
        }

        public Role Update(int id, string roleName)
        {
            var role = dbContext.Roles.FirstOrDefault(r => r.Id == id);
            role.Name = roleName;

            dbContext.SaveChanges();

            return role;
        }
        public Role Delete(int id)
        {
            var role = dbContext.Roles.FirstOrDefault(r => r.Id == id);
            
            dbContext.Roles.Remove(role);
            dbContext.SaveChanges();

            return role;
        }
    }
        
}

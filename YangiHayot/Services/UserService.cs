using Microsoft.EntityFrameworkCore;
using YangiHayot.Data;
using YangiHayot.Interfaces;
using YangiHayot.Models;

namespace YangiHayot.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext dbContext;
        public UserService(DataContext dataContext)
        {
            this.dbContext = dataContext;
        }
        public User Create(string firstName, string lastName, string phoneNumber, string email, string password, int roleId)
        {
            User user = new User();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.PhoneNumber = phoneNumber;
            user.Email = email;
            user.Password = password;
            user.RoleId = roleId;

            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            return user;
        }
        public List<User> GetAll()
        {
            List<User> users = dbContext.Users.ToList();
            return users;
        }
        public User GetById(int id)
        {
           var user = dbContext.Users.FirstOrDefault(u => u.Id == id);
            return user;
        }
        public User GetByPhoneNumber(string phoneNumber)
        {
            var user = dbContext.Users.FirstOrDefault(u => u.PhoneNumber == phoneNumber);
            return user;
        }
        public User GetByEmail(string email)
        {
            var user = dbContext.Users.FirstOrDefault(u => u.Email == email);
            return user;
        }
        public User GetByPassword(string password)
        {
            var user = dbContext.Users.FirstOrDefault(u => u.Password == password);
            return user;
        }
        public User Update(int id,string firstName, string lastName, string phoneNumber, string email, string password, int roleId)
        {
            var user = dbContext.Users.FirstOrDefault(u => u.Id == id);
            user.FirstName = firstName;
            user.LastName = lastName;
            user.PhoneNumber = phoneNumber;
            user.Email = email;
            user.Password = password;
            user.RoleId = roleId;

            dbContext.Users.Update(user);
            dbContext.SaveChanges();

            return user;
        }
        public void Delete(User user)
        {
            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
        }
    }
}

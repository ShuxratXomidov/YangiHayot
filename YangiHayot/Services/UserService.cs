using Microsoft.EntityFrameworkCore;
using YangiHayot.Data;
using YangiHayot.Interfaces;
using YangiHayot.Models;
using YangiHayot.Requests;

namespace YangiHayot.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext dbContext;
        public UserService(DataContext dataContext)
        {
            this.dbContext = dataContext;
        }
        public User Create(UserRequest newUser)
        {
            User user = new User();
            user.FirstName = newUser.FirstName;
            user.LastName = newUser.LastName; ;
            user.PhoneNumber = newUser.PhoneNumber;
            user.Email = newUser.Email;
            user.Password = newUser.Password;
            user.RoleId = newUser.RoleId;

            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            return user;
        }
        public List<User> GetAll()
        {
            List<User> users = dbContext.Users.OrderBy(u =>u.Id).ToList();
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
        public User Update(int id, UserRequest newUser)
        {
            var user = dbContext.Users.FirstOrDefault(u => u.Id == id);
            user.FirstName = newUser.FirstName;
            user.LastName = newUser.LastName;
            user.PhoneNumber = newUser.PhoneNumber;
            user.Email = newUser.Email;
            user.Password = newUser.Password;
            user.RoleId = newUser.RoleId;

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

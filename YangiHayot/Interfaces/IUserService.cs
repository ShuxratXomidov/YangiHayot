using YangiHayot.Models;
using YangiHayot.Requests;

namespace YangiHayot.Interfaces
{
    public interface IUserService
    {
        public List<User> GetAll();
        public User GetById(int id);
        public User GetByPhoneNumber(string phoneNumber);
        public User GetByEmail(string email);
        public User GetByPassword(string password);
        public User Create(UserRequest newUser);
        public User Update(int id, UserRequest request);
        public void Delete(User user);
    }
}

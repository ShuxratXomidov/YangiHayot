using YangiHayot.Models;

namespace YangiHayot.Interfaces
{
    public interface IOrderService
    {
       public List<Order> GetAll();
       public Order? GetById(int id);
       public Order Create(decimal price, int userId);
       public Order Update(decimal price, Order order);
       public void Delete(Order order);
    }
}

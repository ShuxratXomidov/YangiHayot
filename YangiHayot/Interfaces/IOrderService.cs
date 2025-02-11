using YangiHayot.Models;

namespace YangiHayot.Interfaces
{
    public interface IOrderService
    {
       public List<Order> GetAll();
       public Order? GetById(int id);
       public Order Create(int userId);
       public void Delete(Order order);
       public decimal GetTotalSum(Order order);

    }
}

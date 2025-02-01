using YangiHayot.Data;
using YangiHayot.Interfaces;
using YangiHayot.Models;

namespace YangiHayot.Services
{
    public class OrderService : IOrderService
    {
        private readonly DataContext dbContext;
        public OrderService(DataContext dataContext)
        {
           this.dbContext = dataContext;
        }
        public Order Create(decimal price, int userId)
        {
            Order order = new Order()
            {
                Price = price,
                UserId = userId
            };

            dbContext.Orders.Add(order);
            dbContext.SaveChanges();

            return order;
        }
        public List<Order> GetAll()
        {
            return dbContext.Orders.ToList();
        }
        public Order? GetById(int id)
        {
            return dbContext.Orders.FirstOrDefault(order => order.Id == id);
        }
        public Order Update(decimal price, Order order)
        {
                order.Price = price;
                dbContext.SaveChanges();

                return order;
        }
        public void Delete(Order order)
        {
            dbContext.Orders.Remove(order);
            dbContext.SaveChanges();
        }
    }
}

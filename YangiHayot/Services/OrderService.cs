using Microsoft.AspNetCore.Http.HttpResults;
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
        public Order Create(int userId)
        {
            Order order = new Order()
            {
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
        public void Delete(Order order)
        {
            dbContext.Orders.Remove(order);
            dbContext.SaveChanges();
        }
        public decimal GetTotalSum(Order order)
        {
            //List<OrderDetail> listOfOrderDetails = orderDetailService.GetOrderDetails(order);

            //decimal totalSum = 0;

            //foreach (OrderDetail orderDetail1 in listOfOrderDetails)
            //{
            //    totalSum += orderDetail1.Price;
            //}

            decimal totalSum = dbContext.OrderDetails.Where(OrderDetail => OrderDetail.OrderId == order.Id).Sum(orderDetail => orderDetail.Price);

            return totalSum;
        }
    }
}

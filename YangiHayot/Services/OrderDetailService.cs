using YangiHayot.Data;
using YangiHayot.Interfaces;
using YangiHayot.Models;

namespace YangiHayot.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly DataContext dbContext;
        public OrderDetailService(DataContext dataContext)
        {
            this.dbContext = dataContext;
        }
        public void Create(Order order, Product product)
        {
            OrderDetail orderDetail = new OrderDetail()
            {
                Order = order,
                Price = product.Price,
                Product = product,
            };

            this.dbContext.OrderDetails.Add(orderDetail);
            dbContext.SaveChanges();
        }
        public List<OrderDetail> GetOrderDetails(Order order)
        {
            return dbContext.OrderDetails.Where(orderDetail => orderDetail.OrderId == order.Id).ToList();
        }
        public void Update(decimal price, OrderDetail orderDetail)
        {
            orderDetail.Price = price;
            dbContext.SaveChanges();
        }
    }
}

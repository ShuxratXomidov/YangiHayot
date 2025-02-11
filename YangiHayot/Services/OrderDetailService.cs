using Microsoft.EntityFrameworkCore;
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
        public void Update(decimal price, OrderDetail orderDetail,Product product)
        {
            orderDetail.Price = price;

            if(orderDetail.ProductId != product.Id)
            {
                orderDetail.Price = product.Price;
                orderDetail.ProductId = product.Id;
            }
            
            dbContext.SaveChanges();
        }
        public OrderDetail? GetById(int id)
        {
            return dbContext.OrderDetails
                .Include(od => od.Order)
                .FirstOrDefault(od => od.Id == id);
        }
    }
}

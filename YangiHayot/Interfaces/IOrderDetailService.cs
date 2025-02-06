using YangiHayot.Models;
namespace YangiHayot.Interfaces
{
    public interface IOrderDetailService
    {
        public List<OrderDetail> GetOrderDetails(Order order);
        public void Create(Order order, Product product);
        public void Update(decimal price, OrderDetail orderDetail, Product product);
        OrderDetail? GetById(int id);
    }
}

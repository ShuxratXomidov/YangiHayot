using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YangiHayot.Models;
using YangiHayot.Interfaces;

namespace YangiHayot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IOrderDetailService orderDetailService;
        private readonly IOrderService orderService;
        public OrderDetailController(IProductService productService, IOrderDetailService orderDetailService, IOrderService orderService)
        {
            this.productService = productService;
            this.orderDetailService = orderDetailService;
            this.orderService = orderService;
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, int productId, decimal price)
        {
            Product? product = this.productService.GetById(productId);
            if (product is null)
            {
                return BadRequest("Product is not found!");
            }


            OrderDetail? orderDetail = this.orderDetailService.GetById(id);
            if(orderDetail is null)
            {
                return BadRequest("Orderdetail is not found");
            }
            
            this.orderDetailService.Update(price, orderDetail, product);
        
            Order? order = this.orderService.GetById(orderDetail.OrderId);

            orderService.Update(100, order);

            decimal totalSum = 0;
            List<OrderDetail> listOfOrderDetails = orderDetailService.GetOrderDetails(order);

            foreach (OrderDetail orderDetail1 in listOfOrderDetails)
            {
                totalSum += orderDetail1.Price;
            }

            for (int i = 0; i < orderDetailService.GetOrderDetails(order).Count(); i++) 
            { 

            }

            return Ok();
        }
    }
}

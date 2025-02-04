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
        public OrderDetailController(IProductService productService, IOrderDetailService orderDetailService)
        {
            this.productService = productService;
            this.orderDetailService = orderDetailService;
        }

        [HttpPut]
        [Route("{id}")]
        //public IActionResult Update(int id,int productId, decimal price)
        //{
        //    Product? product = this.productService.GetById(productId);
        //    OrderDetail? orderDetail = this.orderDetailService.
        //}
    }
}

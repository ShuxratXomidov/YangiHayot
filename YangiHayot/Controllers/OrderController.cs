using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YangiHayot.Interfaces;
using YangiHayot.Models;
using YangiHayot.Requests;
using YangiHayot.Responses;

namespace YangiHayot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IUserService userService;
        private readonly IOrderDetailService orderDetailService;
        private readonly IProductService productService;
        public OrderController(IOrderService orderService, IUserService userService, IOrderDetailService orderDetailService, IProductService productService)
        {
            this.orderService = orderService;
            this.userService = userService;
            this.orderDetailService  = orderDetailService;
            this.productService = productService;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create([FromBody] CreateOrderRequest request)
        {
            User? user = this.userService.GetById(request.UserId);
            if (user is null)
            {
                return BadRequest($"User is not found with id {request.UserId}");
            }

            foreach (int productId in request.ProductIds)
            {
                Product? product = this.productService.GetById(productId);
                if(product is null)
                {
                    return BadRequest($"Product is not found with id {productId}!");
                }
            }

            Order order = this.orderService.Create(request.UserId);

            foreach (int productId in request.ProductIds)
            {
                Product? product = this.productService.GetById(productId);
                this.orderDetailService.Create(order, product);            
            }

            OrderResponse response = new OrderResponse()
            {
                Id = order.Id,
                CreatedAt = order.CreatedAt,
                UserId = order.UserId,
            };

            return Ok(response);  
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Order> orders = this.orderService.GetAll();

            List<OrderResponse> response = new List<OrderResponse>();
            foreach(Order order in orders)
            {
                OrderResponse orderResponse = new OrderResponse()
                {
                    Id = order.Id,
                    CreatedAt = order.CreatedAt,
                    UserId = order.UserId,
                    TotalSum = orderService.GetTotalSum(order),
                };
                

                response.Add(orderResponse);
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Show(int id)
        {
            Order? order = this.orderService.GetById(id);
            if (order is null)
            {
                return NotFound($"Order is not found with id {id}");
            }

            decimal totalSum = orderService.GetTotalSum(order);

            var response = new OrderResponse()
            {
                Id = order.Id,
                CreatedAt = order.CreatedAt,
                UserId = order.UserId,
                TotalSum = totalSum,
            };
           
            return Ok(response);
        }

        //[HttpPut]
        //[Route("{id}")]
        //public IActionResult Update(int id, decimal price)
        //{
        //    Order? order = this.orderService.GetById(id);
        //    if (order is null)
        //    {
        //        return BadRequest($"Order is not found with id {id}");
        //    }

        //   Order newOrder = this.orderService.Update(price, order);

        //    return Ok(newOrder);
        //}

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            Order? order = this.orderService.GetById(id);
            if (order is not null)
            {
                this.orderService.Delete(order);
            }

            return NoContent();
        }
    }
}

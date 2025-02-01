using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YangiHayot.Interfaces;
using YangiHayot.Models;
using YangiHayot.Responses;

namespace YangiHayot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IUserService userService;
        public OrderController(IOrderService orderService, IUserService userService)
        {
            this.orderService = orderService;
            this.userService = userService;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create(decimal price, int userId)
        {
            User? user = this.userService.GetById(userId);
            if (user is null)
            {
                return BadRequest($"User is not found with id {userId}");
            }

            Order order = this.orderService.Create(price, userId);

            OrderResponse response = new OrderResponse()
            {
                Id = order.Id,
                CreatedAt = order.CreatedAt,
                Price = order.Price,
                UserId = order.UserId,
            };

            return Ok(response);
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Order> orders = this.orderService.GetAll();
            return Ok(orders);
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
            return Ok(order);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, decimal price)
        {
            Order? order = this.orderService.GetById(id);
            if (order is null)
            {
                return BadRequest($"Order is not found with id {id}");
            }

           Order newOrder = this.orderService.Update(price, order);

            return Ok(newOrder);
        }

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

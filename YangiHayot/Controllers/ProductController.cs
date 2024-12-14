using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YangiHayot.Interfaces;
using YangiHayot.Requests;
using YangiHayot.Models;


namespace YangiHayot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create([FromBody] ProductRequest request)
        {
            var product = this.productService.GetByName(request.Name);
            if (product is null)
            {
                var productNew = this.productService.Create(request);
                return Ok(productNew);
            }

            return BadRequest("Bu mahsulot bazada bor!");
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Product> products = this.productService.GetAll();

            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetId(int id)
        {
            var product = this.productService.GetById(id);
            if (product is null)
            {
                return BadRequest("Bunaqa mahsulot yo'q!");
            }

            return Ok(product);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, [FromBody] ProductRequest request)
        {
            var productId = this.productService.GetById(id);
            if(productId is null)
            {
                return NotFound("Bu mahsulot bazada yo'q!");
            }

            var productName = this.productService.GetByName(request.Name);
            if(productName is null)
            {
                Product product = this.productService.Update(id, request);

                return Ok(product);
            }

            return BadRequest("Bu mahsulot bazada bor!");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
           var product = this.productService.GetById(id);
            if(product is not null)
            {
                this.productService.Delete(product);
            }

            return NoContent();
        }
        
    }
}

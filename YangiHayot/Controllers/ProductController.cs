using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YangiHayot.Interfaces;
using YangiHayot.Requests;
using YangiHayot.Models;
using YangiHayot.Responses;


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
        public IActionResult Create([FromForm] ProductRequest request)
        {
            var product = this.productService.GetByName(request.Name);
            if (product is not null)
            {
                return BadRequest("Bu mahsulot bazada bor!");
            }

            var productNew = this.productService.Create(request);

            FileStream fs = new FileStream("wwwroot/" + request.Photo.FileName, FileMode.Create);
            request.Photo.CopyTo(fs);
            fs.Dispose();

            ProductResponse response = new ProductResponse();
            response.Id = productNew.Id;
            response.Name = productNew.Name;
            response.Price = productNew.Price;
            response.Quantity = productNew.Quantity;
            response.Size = productNew.Size.ToString();
            response.Photo = productNew.Photo;

            return Ok(response);

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

            ProductResponse response = new ProductResponse();
            response.Id = product.Id;
            response.Name = product.Name;
            response.Price = product.Price;
            response.Quantity = product.Quantity;
            response.Size = product.Size.ToString();

            return Ok(response);
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
            if(productName is not null)
            {
                return BadRequest("Bu mahsulot bazada bor!");
            }

            Product product = this.productService.Update(id, request);

            ProductResponse response = new ProductResponse();
            response.Id = product.Id;
            response.Name = product.Name;
            response.Price = product.Price;
            response.Quantity = product.Quantity;
            response.Size = product.Size.ToString();

            return Ok(response);

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

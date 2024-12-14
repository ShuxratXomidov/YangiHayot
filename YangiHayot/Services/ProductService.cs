using Microsoft.AspNetCore.Mvc;
using YangiHayot.Data;
using YangiHayot.Interfaces;
using YangiHayot.Models;
using YangiHayot.Requests;

namespace YangiHayot.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext dbContext;

        public ProductService(DataContext dataContext)
        {
            this.dbContext = dataContext;
        }
        public Product Create([FromBody] ProductRequest request)
        {
            Product product = new Product();
            product.Name = request.Name;
            product.Price = request.Price;
            product.Size = request.Size;
            product.Quantity = request.Quantity;

            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            return product;
        }
        public List<Product> GetAll()
        {
            List<Product> products = dbContext.Products.OrderBy(p => p.Id).ToList();
            return products;
        }
        public Product GetById(int id)
        {
            var product = dbContext.Products.FirstOrDefault(p => p.Id == id);
            return product;
        }
        public Product GetByName(string name)
        {
            var product = dbContext.Products.FirstOrDefault(p => p.Name == name);
            return product;
        }
        
        public Product Update(int id, [FromBody] ProductRequest request)
        {
            var product = dbContext.Products.FirstOrDefault(p => p.Id == id);
            product.Name = request.Name;
            product.Price = request.Price;
            product.Size = request.Size;
            product.Quantity = request.Quantity;

            dbContext.Products.Update(product);
            dbContext.SaveChanges();

            return product;
        }
        public void Delete(Product product)
        {
            dbContext.Products.Remove(product);
            dbContext.SaveChanges();
        }
    }
}

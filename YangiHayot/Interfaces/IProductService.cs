using YangiHayot.Models;
using YangiHayot.Requests;
namespace YangiHayot.Interfaces
{
    public interface IProductService
    {
        public List<Product> GetAll();
        public Product? GetById(int id);
        public Product? GetByName(string name);
        public Product Create(ProductRequest request);
        public Product Update(int id, ProductRequest request);
        public void Delete(Product product);
    }
}

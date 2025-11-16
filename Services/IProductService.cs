using BlazorApp1.Models;

namespace BlazorApp1.Services
{
    public interface IProductService
    {
        public Product Get(int id);
        public List<Product> GetAll();
        public Product? Put(int id, Product product);
        public Product Post(Product product);
        public bool Delete(int id);
    }
}

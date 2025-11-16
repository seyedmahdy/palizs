using BlazorApp1.Models;

namespace BlazorApp1.Repository
{
    public interface IProductRepository
    {
        public Task<Product> GetProduct(int id);
        public  Task<Product> AddProduct(Product product);
        public Task<Product> UpdateProduct(Product product);
        public Task DeleteProduct(int id);
        public  Task<List<Product>> GetAll();
    }
}

using BlazorApp1.Models;

namespace BlazorApp1.Services
{
    public interface IProductBackService
    {
        public Task<List<Product>> GetAll();
        public  Task<Product> Get(int id);
        public  Task<Product> Add(Product product);
        public  Task<Product> Update(Product product);
        public Task Delete(int id);
    }
}

using BlazorApp1.Models;
using BlazorApp1.Repository;

namespace BlazorApp1.Services
{
    public class ProductBackService(IProductRepository _productRepository) : IProductBackService
    {
        public async Task<List<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }
        public async Task<Product> Get(int id)
        {
            return await _productRepository.GetProduct(id);
        }
        public async Task<Product> Add(Product product)
        {
            return await _productRepository.AddProduct(product);
        }
        public async Task<Product> Update(Product product)
        {
            return await _productRepository.UpdateProduct(product);
        }
        public async Task Delete(int id) 
        {
            await _productRepository.DeleteProduct(id);
        }
    }
}

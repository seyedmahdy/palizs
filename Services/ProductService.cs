
using BlazorApp1.Models;

namespace BlazorApp1.Services
{
    public class ProductService : ServiceBase, IProductService
    {
        private string Apiurl => CreateApiUrl("Product");
        public Product Get(int id)
        {
            return GetJson<Product>($"{Apiurl}/show/{id}");
        }
        public List<Product> GetAll()
        {
            return GetJson<List<Product>>($"{Apiurl}/default");
        }
        public Product Put(int id, Product product)
        {
            return PutJson<Product, Product>($"{Apiurl}/edit/{id}", product);
        }
        public Product Post(Product product)
        {
            return PostJson<Product, Product>($"{Apiurl}/add", product);
        }
        public bool Delete(int id)
        {
            return Delete($"{Apiurl}/delete/{id}");
        }
    }
}

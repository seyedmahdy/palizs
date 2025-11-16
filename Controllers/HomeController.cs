using BlazorApp1.Models;
using BlazorApp1.Services;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static BlazorApp1.Components.Pages.Commodity;


namespace BlazorApp1.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class ProductController(IProductBackService _productBackService) : ControllerBase
    {
        //private static List<Product> products = new List<Product>
        //{
        //    new Product { Id = 1, ProductName = "Laptop", Price = 30000, CategoryName = "Electronics" },
        //    new Product { Id = 2, ProductName = "Mouse", Price = 700, CategoryName = "Accessories" }
        //};

        [HttpGet("default")]
        public async Task<IActionResult> GetProduct()
        {
            return Ok(await _productBackService.GetAll());
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddProduct([FromBody] Product newProduct)
        {
            await _productBackService.Add(newProduct);
            return Ok(newProduct);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productBackService.Delete(id);
            return Ok("محصول حذف شد.");
        }
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> EditProduct(int id, [FromBody] Product updatedProduct)
        {
            await _productBackService.Update(updatedProduct);
            return Ok(updatedProduct);
        }
        [HttpGet("show/{id}")]
        public async Task<IActionResult> ShowProduct(int id)
        {
            return Ok(await _productBackService.Get(id));
        }


    }
}

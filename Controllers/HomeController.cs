using BlazorApp1.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using static BlazorApp1.Components.Pages.Commodity;


namespace BlazorApp1.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, ProductName = "Laptop", Price = 30000, CategoryName = "Electronics" },
            new Product { Id = 2, ProductName = "Mouse", Price = 700, CategoryName = "Accessories" }
        };

        [HttpGet("default")]
        public IActionResult GetProduct()
        {
            
            return Ok(products);
        }
        [HttpPost("add")]
        public IActionResult AddProduct([FromBody] Product newProduct)
        {
   
            newProduct.Id = products.Any() ? products.Max(p => p.Id) + 1 : 1;

            products.Add(newProduct);
            return Ok(newProduct);
        }
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound("محصول پیدا نشد.");

            products.Remove(product);

            return Ok("محصول حذف شد.");
        }
        [HttpPut("edit/{id}")]
        public IActionResult EditProduct(int id, [FromBody] Product updatedProduct)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound("محصول پیدا نشد.");
            product.ProductName = updatedProduct.ProductName;
            product.SupplierName = updatedProduct.SupplierName;
            product.BrandName = updatedProduct.BrandName;
            product.Email = updatedProduct.Email;
            product.CategoryName = updatedProduct.CategoryName;
            product.Supply = updatedProduct.Supply;
            product.Price = updatedProduct.Price;
            product.StartDate = updatedProduct.StartDate;
            product.EndDate = updatedProduct.EndDate;
            product.ImageName = updatedProduct.ImageName;
            product.CatalogueName = updatedProduct.CatalogueName;
            product.Color = updatedProduct.Color;

            return Ok(product);
        }
        [HttpGet("show/{id}")]
        public IActionResult ShowProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound($"محصول با آیدی {id} یافت نشد.");

            return Ok(product);
        }


    }
}

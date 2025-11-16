using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string? SupplierName { get; set; }
        public string BrandName { get; set; }
        public string? Email { get; set; }
        public string CategoryName { get; set; }
        public int? Supply { get; set; }
        public int? Price { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ImageName { get; set; }
        public string? CatalogueName { get; set; }
        //public IBrowserFile? Image { get; set; }
        //public IBrowserFile? Catalogue { get; set; }
        public string? Color { get; set; }
    }
}

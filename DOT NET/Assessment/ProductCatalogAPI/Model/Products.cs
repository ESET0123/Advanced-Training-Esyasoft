using System.ComponentModel.DataAnnotations;

namespace ProductCatalogAPI.Model
{
    public class Products
    {
        [Required]
        public int ProductID { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        public string Category { get; set; }
        [Range(1,1000)]
        public decimal Price { get; set; }
        [Range(0, 100000)]
        public int StockQuantity { get; set; }
    }
}

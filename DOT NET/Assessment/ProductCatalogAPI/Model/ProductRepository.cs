//namespace ProductCatalogAPI.Model
//{
//    public class ProductRepository
//    {
//    }
//}

//using ProductCatalogAPI.Models;
//using System.Collections.Generic;
 
namespace ProductCatalogAPI.Model
{
    public static class ProductRepository
    {
        public static List<Products> Products { get; set; } = new List<Products>
        {
            new Products
            {
                ProductID = 1,
                Name = "Apple iPhone 15",
                Category = "Electronics",
                Price = 999.99m,
                StockQuantity = 50
            },
            new Products
            {
                ProductID = 2,
                Name = "Samsung Galaxy S23",
                Category = "Electronics",
                Price = 899.99m,
                StockQuantity = 35
            },
            new Products
            {
                ProductID = 3,
                Name = "Nike Running Shoes",
                Category = "Footwear",
                Price = 120.50m,
                StockQuantity = 100
            },
            new Products
            {
                ProductID = 4,
                Name = "Sony WH-1000XM5 Headphones",
                Category = "Electronics",
                Price = 350.00m,
                StockQuantity = 20
            },
            new Products
            {
                ProductID = 5,
                Name = "Levi's Denim Jeans",
                Category = "Clothing",
                Price = 60.00m,
                StockQuantity = 75
            }
        };
    }
}
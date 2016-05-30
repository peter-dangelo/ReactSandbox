using System.Collections.Generic;

namespace ReactSandbox.Models
{
    public class ProductsModel
    {
        public List<ProductModel> Products { get; set; } 
    }

    public class ProductModel
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public bool Stocked { get; set; }
    }
}
using System.Collections.Generic;

namespace Bridge.Domain.Entities
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }

        public string ProductCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public ICollection<Product> Products { get; private set; }
    }
}

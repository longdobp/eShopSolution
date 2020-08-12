using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class ProductInCategory
    {
        public int product_id { get; set; }
        public int category_id { get; set; }
        public Product product { get; set; }
        public Category category { get; set; }
    }
}

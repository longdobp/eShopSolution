using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class ProductImage
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public string image_path { get; set; }
        public string caption { get; set; }
        public bool is_default { get; set; }
        public DateTime date_created { get; set; }
        public int sort_order { get; set; }
        public long file_size { get; set; }
        public Product Product { get; set; }
    }
}

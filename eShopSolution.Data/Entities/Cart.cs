using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class Cart
    {
        public int id { set; get; }
        public int product_id { set; get; }
        public int quantity { set; get; }
        public decimal price { set; get; }
        public Guid user_id { get; set; }
        public Product Product { get; set; }
        public DateTime date_created { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class OrderDetail
    {
        public int order_id { set; get; }
        public int product_id { set; get; }
        public int quantity { set; get; }
        public decimal price { set; get; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}

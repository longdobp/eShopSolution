using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class Product
    {
        public int id { set; get; }
        public decimal price { set; get; }
        public decimal original_price { set; get; }
        public int stock { set; get; }
        public int view_count { set; get; }
        public DateTime date_created { set; get; }
        public List<Cart> Carts { get; set; }
        public List<ProductInCategory> ProductInCategories { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<ProductTranslation> ProductTranslations { get; set; }
    }
}

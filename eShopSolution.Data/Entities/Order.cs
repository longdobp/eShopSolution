using eShopSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class Order
    {
        public int id { set; get; }
        public Guid user_id { set; get; }
        public DateTime order_date { set; get; }
        public string ship_name { set; get; }
        public string ship_address { set; get; }
        public string ship_email { set; get; }
        public string ship_phone_number { set; get; }
        public OrderStatus status { set; get; }
        public List<OrderDetail> OrderDetails { get; set; }
        
    }
}

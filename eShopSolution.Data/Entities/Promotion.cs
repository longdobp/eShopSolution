using eShopSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class Promotion
    {
        public int id { set; get; }
        public string product_ids { set; get; }
        public string product_category_ids { set; get; }
        public string name { set; get; }
        public DateTime from_date { set; get; }
        public DateTime to_date { set; get; }
        public bool apply_for_all { set; get; }
        public int? discount_percent { set; get; }
        public decimal? discount_amount { set; get; }
        public Status status { set; get; }

    }
}

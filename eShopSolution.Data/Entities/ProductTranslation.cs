using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class ProductTranslation
    {
        public int id { set; get; }
        public int product_id { set; get; }
        public string language_id { set; get; }
        public string name { set; get; }
        public string description { set; get; }
        public string details { set; get; }
        public string seo_description { set; get; }
        public string seo_title { set; get; }
        public string seo_alias { set; get; }
        public Product product { get; set; }
        public Language language { get; set; }
    }
}
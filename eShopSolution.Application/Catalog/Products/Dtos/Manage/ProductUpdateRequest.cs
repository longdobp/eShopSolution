using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Catalog.Products.Dtos.Manage
{
    public class ProductUpdateRequest
    {
        public int id { set; get; }
        public string languege_id { set; get; }
        public string name { set; get; }
        public string description { set; get; }
        public string details { set; get; }
        public string seo_description { set; get; }
        public string seo_title { set; get; }
        public string seo_alias { set; get; }
    }
}

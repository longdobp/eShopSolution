using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.Catalog.Products
{
    public class ProductCreateRequest
    {
        public decimal price { set; get; }
        public decimal original_price { set; get; }
        public int stock { set; get; }
        public string languege_id { set; get; }
        public string name { set; get; }
        public string description { set; get; }
        public string details { set; get; }
        public string seo_description { set; get; }
        public string seo_title { set; get; }
        public string seo_alias { set; get; }
        public IFormFile thumbnail_image { get; set; }
    }
}

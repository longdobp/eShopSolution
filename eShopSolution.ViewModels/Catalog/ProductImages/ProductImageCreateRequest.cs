using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.Catalog.ProductImages
{
    public class ProductImageCreateRequest
    {
        public int product_id { get; set; }
        public string caption { get; set; }
        public bool is_default { get; set; }
        public int sort_order { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}

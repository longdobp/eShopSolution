using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace eShopSolution.ViewModels.Catalog.Products
{
    public class ProductCreateRequest
    {
        public decimal price { set; get; }
        public decimal original_price { set; get; }
        public int stock { set; get; }
        public string language_id { set; get; }

        [Required(ErrorMessage = "Bạn phải nhập tên sản phẩm")]
        public string name { set; get; }

        public string description { set; get; }
        public string details { set; get; }
        public string seo_description { set; get; }
        public string seo_title { set; get; }
        public string seo_alias { set; get; }
        public IFormFile thumbnail_image { get; set; }
    }
}
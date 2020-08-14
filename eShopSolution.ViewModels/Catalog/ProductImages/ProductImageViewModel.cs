using Microsoft.AspNetCore.Http;

namespace eShopSolution.ViewModels.Catalog.ProductImages
{
    public class ProductImageViewModel
    {
        public int Id { get; set; }

        public string FilePath { get; set; }

        public bool IsDefault { get; set; }

        public long FileSize { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}

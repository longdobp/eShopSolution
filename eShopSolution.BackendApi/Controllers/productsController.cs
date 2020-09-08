using eShopSolution.Application.Catalog.Products;
using eShopSolution.ViewModels.Catalog.ProductImages;
using eShopSolution.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class productsController : ControllerBase
    {
        private readonly IProductService _productService;

        public productsController(IProductService productService)
        {
            _productService = productService;
        }

        // http://localhost:port/api/product/vi-VN?LanguageId=vi-VN&PageIndex=1&Pagesize=2
        [HttpPost("all")]
        public async Task<IActionResult> GetListProductPaging(string languageId, [FromQuery] GetPublicProductPagingRequest request)
        {
            var products = await _productService.GetAll(languageId, request);
            return Ok(products);
        }

        // http://localhost:port/api/product/public-paging
        [HttpPost("{languageId}")]
        public async Task<IActionResult> GetListProductByCategoryPaging(string languageId, [FromBody] GetPublicProductPagingRequest request)
        {
            var products = await _productService.GetAllByCategoryId(languageId, request);
            return Ok(products);
        }

        //http://localhost:port/product/1
        [HttpGet("{languageId}/{id}")]
        public async Task<IActionResult> GetById(int id, string languageId)
        {
            var products = await _productService.GetById(id, languageId);
            if (products == null)
                return BadRequest("Connot find product");

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = await _productService.Create(request);
            if (productId == 0)
                return BadRequest();

            var product = await _productService.GetById(productId, request.languege_id);

            return CreatedAtAction(nameof(GetById), new { id = productId }, product);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            var affectedResult = await _productService.Update(request);
            if (affectedResult == 0)
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var affectedResult = await _productService.Delete(id);
            if (affectedResult == 0)
                return BadRequest();

            return Ok();
        }

        [HttpPatch("{id}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int id, decimal newPrice)
        {
            var isSuccessful = await _productService.UpdatePrice(id, newPrice);
            if (isSuccessful)
                return Ok();

            return BadRequest();
        }

        //Images
        [HttpPost("{productId}/images")]
        public async Task<IActionResult> CreateImage(int productId, [FromForm] ProductImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageId = await _productService.AddImage(productId, request);
            if (imageId == 0)
                return BadRequest();

            var image = await _productService.GetImageById(imageId);

            return CreatedAtAction(nameof(GetImageById), new { id = imageId }, image);
        }

        [HttpPut("{productId}/images/{imageId}")]
        public async Task<IActionResult> UpdateImage(int imageId, [FromForm] ProductImageUpdateRequest request)
        {
            var isSuccessful = await _productService.UpdateImage(imageId, request);
            if (isSuccessful == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{productId}/images/{imageId}")]
        public async Task<IActionResult> RemoveImage(int imageId)
        {
            var affectedResult = await _productService.RemoveImage(imageId);
            if (affectedResult == 0)
                return BadRequest();

            return Ok();
        }

        [HttpGet("{productId}/images/{imageId}")]
        public async Task<IActionResult> GetImageById(int productId, int imageId)
        {
            var image = await _productService.GetImageById(imageId);
            if (image == null)
                return BadRequest("Connot find image");

            return Ok(image);
        }

        [HttpGet("{productId}/images")]
        public async Task<IActionResult> GetListImageByProductId(int productId)
        {
            var images = await _productService.GetListImages(productId);
            return Ok(images);
        }
    }
}
using eShopSolution.Application.Common;
using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using eShopSolution.Utilities.Exceptions;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly EShopDbContext _context;
        private readonly IStorageService _storageService;
        public ManageProductService(EShopDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public Task<int> AddImages(int productId, List<IFormFile> files)
        {
            throw new NotImplementedException();
        }

        public async Task AddViewCount(int product_id)
        {
            var product = await _context.Products.FindAsync(product_id);
            product.view_count += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                price = request.price,
                original_price = request.original_price,
                stock = request.stock,
                view_count = 0,
                date_created = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        name = request.name,
                        description = request.description,
                        details = request.details,
                        seo_description = request.seo_description,
                        seo_alias = request.seo_alias,
                        seo_title = request.seo_title,
                        languege_id = request.languege_id
                    }
                }
            };
            //Save image
            if (request.thumbnail_image != null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        caption = "Thumbnail image",
                        date_created = DateTime.Now,
                        file_size = request.thumbnail_image.Length,
                        image_path = await this.SaveFile(request.thumbnail_image),
                        is_default = true,
                        sort_order = 1
                    }
                };
            }
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new EShopException($"Cannot find a product: {productId}");

            var images = _context.ProductImages.Where(i => i.product_id == productId);
            foreach (var image in images)
            {
                await _storageService.DeleteFileAsync(image.image_path);
            }

            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.Products
                        join pt in _context.ProductTransactions on p.id equals pt.product_id
                        join pic in _context.ProductInCategories on p.id equals pic.product_id
                        join c in _context.Categories on pic.category_id equals c.id
                        select new { p, pt, pic };
            //2. filter
            if (!string.IsNullOrEmpty(request.Keywork))
                query = query.Where(x => x.pt.name.Contains(request.Keywork));

            if (request.CategoryIds.Count > 0)
            {
                query = query.Where(p => request.CategoryIds.Contains(p.pic.category_id));
            }
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.Pagesize)
                .Take(request.Pagesize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.id,
                    Name = x.pt.name,
                    DateCreated = x.p.date_created,
                    Description = x.pt.description,
                    Details = x.pt.details,
                    LanguageId = x.pt.languege_id,
                    OriginalPrice = x.p.original_price,
                    Price = x.p.price,
                    SeoAlias = x.pt.seo_alias,
                    SeoDescription = x.pt.seo_description,
                    SeoTitle = x.pt.seo_title,
                    Stock = x.p.stock,
                    ViewCount = x.p.view_count
                }).ToListAsync();


            //4. Select and projection
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }

        public Task<List<ProductImageViewModel>> GetListImage(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveImages(int imageId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.id);
            var productTranslation = await _context.ProductTransactions.FirstOrDefaultAsync(x => x.product_id == request.id && x.languege_id == request.languege_id);
            if(product == null || productTranslation == null) throw new EShopException($"Cannot find a product: {request.id}");

            productTranslation.name = request.name;
            productTranslation.seo_alias = request.seo_alias;
            productTranslation.seo_description = request.seo_description;
            productTranslation.seo_title = request.seo_title;
            productTranslation.description = request.description;
            productTranslation.details = request.details;

            //Save image
            if (request.thumbnail_image != null)
            {
                var thumbnailImage = await _context.ProductImages.FirstOrDefaultAsync(x => x.is_default == true && x.product_id == request.id);
                if(thumbnailImage != null)
                {
                    thumbnailImage.file_size = request.thumbnail_image.Length;
                    thumbnailImage.image_path = await this.SaveFile(request.thumbnail_image);
                    _context.ProductImages.Update(thumbnailImage);
                };
            }

            return await _context.SaveChangesAsync();
        }

        public Task<int> UpdateImage(int imageId, string caption, bool isDefault)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdatePrice(int product_id, decimal new_price)
        {
            var product = await _context.Products.FindAsync(product_id);
            if (product == null) throw new EShopException($"Cannot find a product: {product_id}");
            product.price = new_price;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(int product_id, int addedQuantity)
        {
            var product = await _context.Products.FindAsync(product_id);
            if (product == null) throw new EShopException($"Cannot find a product: {product_id}");
            product.stock += addedQuantity;
            return await _context.SaveChangesAsync() > 0;
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}

using eShopSolution.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;

namespace eShopSolution.Application.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        private readonly EShopDbContext _context;
        public PublicProductService(EShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            var query = from p in _context.Products
                        join pt in _context.ProductTransactions on p.id equals pt.product_id
                        join pic in _context.ProductInCategories on p.id equals pic.product_id
                        join c in _context.Categories on pic.category_id equals c.id
                        select new { p, pt, pic };

            var data = await query.Select(x => new ProductViewModel()
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
            return data;

        }

        public async Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.Products
                        join pt in _context.ProductTransactions on p.id equals pt.product_id
                        join pic in _context.ProductInCategories on p.id equals pic.product_id
                        join c in _context.Categories on pic.category_id equals c.id
                        select new { p, pt, pic };
            //2. filter
            if (request.CategoryId.HasValue && request.CategoryId.Value > 0)
            {
                query = query.Where(p => p.pic.category_id == request.CategoryId);
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
    }
}

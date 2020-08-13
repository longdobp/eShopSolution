using eShopSolution.Application.Catalog.Products.Dtos;
using eShopSolution.Application.Catalog.Products.Dtos.Manage;
using eShopSolution.Application.Dtos;
using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using eShopSolution.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly EShopDbContext _context;
        public ManageProductService(EShopDbContext context)
        {
            _context = context;
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
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int product_id)
        {
            var product = await _context.Products.FindAsync(product_id);
            if (product == null) throw new EShopException($"Cannot find a product: {product_id}");
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
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
                    id = x.p.id,
                    name = x.pt.name,
                    date_created = x.p.date_created,
                    description = x.pt.description,
                    details = x.pt.details,
                    languege_id = x.pt.languege_id,
                    original_price = x.p.original_price,
                    price = x.p.price,
                    seo_alias = x.pt.seo_alias,
                    seo_description = x.pt.seo_description,
                    seo_title = x.pt.seo_title,
                    stock = x.p.stock,
                    view_count = x.p.view_count
                }).ToListAsync();


            //4. Select and projection
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
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

            return await _context.SaveChangesAsync();
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
    }
}

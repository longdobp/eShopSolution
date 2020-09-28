using eShopSolution.Data.EF;
using eShopSolution.ViewModels.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly EShopDbContext _context;

        public CategoryService(EShopDbContext context)
        {
            _context = context;
        }

        public Task<List<CategoryVm>> GetAll(string languageId)
        {
            throw new NotImplementedException();
        }

        //public async Task<List<CategoryVm>> GetAll(string languageId)
        //{
        //    var query = from c in _context.Categories
        //                join ct in _context.CategoryTransactions on c.id equals ct.category_id
        //                where ct.LanguageId == languageId
        //                select new { c, ct };
        //    return await query.Select(x => new CategoryVm()
        //    {
        //        Id = x.c.Id,
        //        Name = x.ct.Name
        //    }).ToListAsync();
        //}
    }
}
using eShopSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class Category
    {
        public int id { set; get; }
        public int? parent_id { set; get; }
        public int sort_order { set; get; }
        public bool is_show_on_home { set; get; }
        public Status status { set; get; }
        public List<ProductInCategory> ProductInCategories { get; set; }
        public List<CategoryTranslation> CategoryTranslations { get; set; }
    }
}

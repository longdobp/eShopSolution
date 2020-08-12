using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class CategoryTranslation
    {
        public int id { set; get; }
        public int category_id { set; get; }
        public string language_id { set; get; }
        public string name { set; get; }
        public string seo_description { set; get; }
        public string seo_title { set; get; }
        public string seo_alias { set; get; }
        public Category category { get; set; }
        public Language language { get; set; }
    }
}

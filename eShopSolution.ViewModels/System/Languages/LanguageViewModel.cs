using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.System.Languages
{
    public class LanguageViewModel
    {
        public string id { set; get; }
        public string name { set; get; }
        public bool IsDefault { get; set; }
    }
}
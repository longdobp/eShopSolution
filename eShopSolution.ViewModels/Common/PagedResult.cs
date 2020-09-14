using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.Common
{
    public class PagedResult<T> : PagingResultBase
    {
        public List<T> Items { set; get; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.Common
{
    public class PagingResultBase
    {
        public int PageIndex { get; set; }
        public int Pagesize { get; set; }
        public int TotalRecords { get; set; }

        public int PageCount
        {
            get
            {
                var pageCount = (double)TotalRecords / Pagesize;
                return (int)Math.Ceiling(pageCount);
            }
        }
    }
}
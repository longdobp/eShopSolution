using eShopSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class Contact
    {
        public int id { set; get; }
        public string name { set; get; }
        public string email { set; get; }
        public string phone_number { set; get; }
        public string massage { set; get; }
        public Status status { set; get; }

    }
}

using eShopSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class Transaction
    {
        public int id { set; get; }
        public string external_transaction_id { set; get; }
        public DateTime transaction_date { set; get; }
        public decimal amount { set; get; }
        public decimal fee { set; get; }
        public string result { set; get; }
        public string message { set; get; }
        public string provider { set; get; }
        public TransactionStatus status { set; get; }

    }
}

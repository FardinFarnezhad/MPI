using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AccountingNavid.DataLayer.Models
{
    public class Transactions
    {
        [PrimaryKey, AutoIncrement, NotNull]
        public int TransactionId { get; set; }
        [NotNull]
        public int ContactId { get; set; }
        [NotNull]
        public int TransactionType{ get; set; }
        [NotNull]
        public int BankId { get; set; }
        [NotNull]
        public decimal Amount { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }
        public string TrackingNumber { set; get; }
        public string ImagePath { get; set; }
        [NotNull]
        public DateTime Date { get; set; }

    }
}

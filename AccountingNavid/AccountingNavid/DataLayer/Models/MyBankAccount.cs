using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace AccountingNavid.DataLayer.Models
{
    public class MyBankAccount
    {
        [PrimaryKey,AutoIncrement,NotNull]
        public int BankId { get; set; }
        [MaxLength(30)]
        public string AccountNumber { get; set; }
        [NotNull]
        [MaxLength(20)]
        public string BankName { get; set; }
        [NotNull]
        [MaxLength(30)]
        public string CardNumber { get; set; }
        [NotNull]
        [MaxLength(30)]
        public decimal AccountBalance { set; get; }
    }
}

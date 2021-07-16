using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AccountingNavid.DataLayer.Models
{
    public class Contact
    {
        [PrimaryKey,AutoIncrement,NotNull]
        public int ContactId { get; set; }
        [MaxLength(50),NotNull]
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string Phone2 { get; set; }
        public string PhoneSocial { get; set; }
        [NotNull]
        public string Phone1 { get; set; }
    }
}

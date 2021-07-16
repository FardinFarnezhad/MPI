using Paperboy.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingNavid.ViewModel
{
    public class TransactionFilterObservableModel : ObservableBase
    {
        private int _transactionId;
        public int TransactionId
        {
            get { return this._transactionId; }
            set { this.SetProperty(ref this._transactionId, value); }
        }
        private string _name;
        public string Name
        {
            get { return this._name; }
            set { this.SetProperty(ref this._name, value); }
        }
        private string _transactionType;
        public string TransactionType
        {
            get { return this._transactionType; }
            set { this.SetProperty(ref this._transactionType, value); }
        }
        private decimal _amount;
        public decimal Amount
        {
            get { return this._amount; }
            set { this.SetProperty(ref this._amount, value); }
        }
        private string _date;
        public string Date
        {
            get { return this._date; }
            set { this.SetProperty(ref this._date, value); }
        }
        private string _cardNumber;
        public string CardNumber
        {
            get { return this._cardNumber; }
            set { this.SetProperty(ref this._cardNumber, value); }
        }

        private string _bankName;
        public string BankName
        {
            get { return this._bankName; }
            set { this.SetProperty(ref this._bankName, value); }
        }
    }
}



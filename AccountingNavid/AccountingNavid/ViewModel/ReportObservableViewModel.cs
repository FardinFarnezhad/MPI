using Paperboy.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingNavid.ViewModel
{
    public class ReportObservableViewModel : ObservableBase
    {
        private decimal _balance;
        public decimal Balance
        {
            get { return this._balance; }
            set { this.SetProperty(ref this._balance, value); }
        }
        private decimal _income;
        public decimal Income
        {
            get { return this._income; }
            set { this.SetProperty(ref this._income, value); }
        }
        private decimal _pay;
        public decimal Pay
        {
            get { return this._pay; }
            set { this.SetProperty(ref this._pay, value); }
        }
        private int _contactCount;
        public int ContactCount
        {
            get { return this._contactCount; }
            set { this.SetProperty(ref this._contactCount, value); }
        }
        private int _bankAccountCount;
        public int BankAccountCount
        {
            get { return this._bankAccountCount; }
            set { this.SetProperty(ref this._bankAccountCount, value); }
        }
    }
}

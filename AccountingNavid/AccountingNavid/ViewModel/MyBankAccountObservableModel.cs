using AccountingNavid.DataLayer.Models;
using Paperboy.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace AccountingNavid.ViewModel
{
    public class MyBankAccountObservableCollection : ObservableCollection<MyBankAccountObservableModel>
    {
        public async Task AddAsync(MyBankAccountObservableModel myBankAccount)
        {
            var item = new MyBankAccount()
            {
                AccountNumber = myBankAccount.AccountNumber,
                BankName = myBankAccount.BankName,
                AccountBalance = myBankAccount.AccountBalance,
                CardNumber = myBankAccount.CardNumber
            };
            await App.Database.SaveMyBankAccountAsync(item);
            this.Add(myBankAccount);
        }
            public async Task EditAsync(MyBankAccountObservableModel myBankAccount)
            {
                var item = new MyBankAccount()
                {
                    AccountNumber = myBankAccount.AccountNumber,
                    BankName = myBankAccount.BankName,
                    BankId = myBankAccount.BankId,
                    AccountBalance = myBankAccount.AccountBalance,
                    CardNumber = myBankAccount.CardNumber
                };
                await App.Database.SaveMyBankAccountAsync(item);
                this.Add(myBankAccount);
            }
            public async Task<int> RemoveAsync(int id)
        {
            var mybankaccount = await App.Database.GetContactAsync(id);
            id = await App.Database.DeleteContactAsync(mybankaccount);
            return id;
        }
    }
    public class MyBankAccountObservableModel : ObservableBase
    {
        private int _bankId;
        public int BankId
        {
            get { return this._bankId; }
            set { this.SetProperty(ref this._bankId, value); }
        }
        private string _accountNumber;
        public string AccountNumber
        {
            get { return this._accountNumber; }
            set { this.SetProperty(ref this._accountNumber, value); }
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
        private decimal _accountBalance;
        public decimal AccountBalance
        {
            get { return this._accountBalance; }
            set { this.SetProperty(ref this._accountBalance, value); }
        }
    }
}

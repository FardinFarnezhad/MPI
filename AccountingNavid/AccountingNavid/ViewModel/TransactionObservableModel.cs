using AccountingNavid.DataLayer.Models;
using Paperboy.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace AccountingNavid.ViewModel
{
    public class TransactionsObservableCollection : ObservableCollection<TransactionObservableModel>
    {
        public async Task AddAsync(TransactionObservableModel transaction)
        {
            var item = new Transactions()
            {
                Amount = transaction.Amount,
                BankId = transaction.BankId,
                ContactId = transaction.ContactId,
                Date = transaction.Date,
                Description = transaction.Description,
                ImagePath = transaction.ImagePath,
                TransactionType = transaction.TransactionType,
                TrackingNumber = transaction.TrackingNumber
            };
            await App.Database.SaveTransactionsAsync(item);
            this.Add(transaction);
        }
        public async Task EditAsync(TransactionObservableModel transaction)
        {
            var item = new Transactions()
            {
                Amount = transaction.Amount,
                BankId = transaction.BankId,
                ContactId = transaction.ContactId,
                Date = transaction.Date,
                Description = transaction.Description,
                ImagePath = transaction.ImagePath,
                TransactionType = transaction.TransactionType,
                TransactionId = transaction.TransactionId,
                TrackingNumber = transaction.TrackingNumber
            };
            await App.Database.SaveTransactionsAsync(item);
            this.Add(transaction);
        }
        public async Task<int> RemoveAsync(int id)
        {
            var transaction = await App.Database.GetContactAsync(id);
            id = await App.Database.DeleteContactAsync(transaction);
            return id;
        }
    }
    public class TransactionObservableModel : ObservableBase
    {
        private int _transactionId;
        public int TransactionId
        {
            get { return this._transactionId; }
            set { this.SetProperty(ref this._transactionId, value); }
        }
        private int _contactId;
        public int ContactId
        {
            get { return this._contactId; }
            set { this.SetProperty(ref this._contactId, value); }
        }
        private int _bankId;
        public int BankId
        {
            get { return this._bankId; }
            set { this.SetProperty(ref this._bankId, value); }
        }
        private int _transactionType;
        public int TransactionType
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

        private string _description;
        public string Description
        {
            get { return this._description; }
            set { this.SetProperty(ref this._description, value); }
        }

        private string _trackingNumber;
        public string TrackingNumber
        {
            get { return this._trackingNumber; }
            set { this.SetProperty(ref this._trackingNumber, value); }
        }

        private string _imagePath;
        public string ImagePath
        {
            get { return this._imagePath; }
            set { this.SetProperty(ref this._imagePath, value); }
        }

        private DateTime _date;
        public DateTime Date
        {
            get { return this._date; }
            set { this.SetProperty(ref this._date, value); }
        }
    }
}


using AccountingNavid.DataLayer.Models;
using Paperboy.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Accounting.Utility.Convertor;
using System.Globalization;
namespace AccountingNavid.ViewModel
{
    public class MainViewModel : ObservableBase
    {
        public MainViewModel()
        {
            this.Report = new ReportObservableViewModel();
            this.DateModel = new BitDateTimePickerViewModel();
            this.Contact = new ContactObservableModel();
            this.Transaction = new TransactionObservableModel();
            this.MyBankAccount = new MyBankAccountObservableModel();
            this.ContactListAsync = new ContactsObservableCollection();
            this.TransactionsListAsync = new TransactionsObservableCollection();
            this.MyBankAccountsAsync = new MyBankAccountObservableCollection();
            this.TransactionsFilterListAsync = new ObservableCollection<TransactionFilterObservableModel>();
        }
        private ContactsObservableCollection _contactListAsync;
        public ContactsObservableCollection ContactListAsync
        {
            get { return _contactListAsync; }
            set { this.SetProperty(ref this._contactListAsync, value); }
        }
        private TransactionsObservableCollection _transactionsListAsync;
        public TransactionsObservableCollection TransactionsListAsync
        {
            get { return _transactionsListAsync; }
            set { this.SetProperty(ref this._transactionsListAsync, value); }
        }
        private ObservableCollection<TransactionFilterObservableModel> _transactionsFilterListAsync;
        public ObservableCollection<TransactionFilterObservableModel> TransactionsFilterListAsync
        {
            get { return _transactionsFilterListAsync; }
            set { this.SetProperty(ref this._transactionsFilterListAsync, value); }
        }
        private MyBankAccountObservableCollection _myBankAccountsAsync;
        public MyBankAccountObservableCollection MyBankAccountsAsync
        {
            get { return _myBankAccountsAsync; }
            set { this.SetProperty(ref this._myBankAccountsAsync, value); }
        }
        private ContactObservableModel _contact;
        public ContactObservableModel Contact
        {
            get { return _contact; }
            set { this.SetProperty(ref this._contact, value); }
        }
        private TransactionFilterObservableModel _transactionFilterObservable;
        public TransactionFilterObservableModel TransactionFilterObservable
        {
            get { return _transactionFilterObservable; }
            set { this.SetProperty(ref this._transactionFilterObservable, value); }
        }
        private ReportObservableViewModel _report;
        public ReportObservableViewModel Report
        {
            get { return _report; }
            set { this.SetProperty(ref this._report, value); }
        }
        private BitDateTimePickerViewModel _dateModel;
        public BitDateTimePickerViewModel DateModel
        {
            get { return _dateModel; }
            set { this.SetProperty(ref this._dateModel, value); }
        }
        private TransactionObservableModel _transaction;
        public TransactionObservableModel Transaction
        {
            get { return _transaction; }
            set { this.SetProperty(ref this._transaction, value); }
        }
        private MyBankAccountObservableModel _myBankAccount;
        public MyBankAccountObservableModel MyBankAccount
        {
            get { return _myBankAccount; }
            set { this.SetProperty(ref this._myBankAccount, value); }
        }
        private bool _isBusy;
        public bool isBusy
        {
            get { return _isBusy; }
            set { this.SetProperty(ref this._isBusy, value); }
        }
        public async Task GetItemsAsync()
        {
            this.isBusy = true;
            await GetTransactionsItemsAsync();
            await GetContactsItemsAsync();
            await GetMyBankAccountsItemsAsync();
            this.isBusy = false;
        }
        public async Task GetContactsItemsAsync()
        {
            this.isBusy = true;
            this.ContactListAsync.Clear();
            var contacts = await App.Database.GetContactsAsync();
            foreach (var contact in contacts.ToList())
            {
                ContactObservableModel contactObservableModel = new ContactObservableModel
                {
                    AccountNumber = contact.AccountNumber,
                    Phone1 = contact.Phone1,
                    Phone2 = contact.Phone2,
                    Name = contact.Name,
                    PhoneSocial = contact.PhoneSocial,
                    ContactId = contact.ContactId
                };
                this.ContactListAsync.Add(contactObservableModel);
            }
            this.isBusy = false;
        }
        public async Task GetTransactionsItemsAsync()
        {
            this.isBusy = true;
            this.TransactionsListAsync.Clear();
            var transactions = await App.Database.GetTransactionsAsync();
            foreach (var transaction in transactions)
            {
                TransactionObservableModel transactionObservableModel = new TransactionObservableModel
                {
                    Amount = transaction.Amount,
                    BankId = transaction.BankId,
                    ContactId = transaction.ContactId,
                    Date = transaction.Date,
                    Description = transaction.Description,
                    ImagePath = transaction.ImagePath,
                    TransactionType = transaction.TransactionType,
                    TransactionId = transaction.TransactionId
                };
                this.TransactionsListAsync.Add(transactionObservableModel);
            }
            this.isBusy = false;
        }
        public async Task SetMyTransactionFilterAsync(IEnumerable<TransactionObservableModel> transactions)
        {
            this.isBusy = true;
            this.TransactionsListAsync.Clear();
            foreach (var transaction in transactions)
            {
                TransactionObservableModel transactionObservableModel = new TransactionObservableModel
                {
                    Amount = transaction.Amount,
                    BankId = transaction.BankId,
                    ContactId = transaction.ContactId,
                    Date = transaction.Date,
                    Description = transaction.Description,
                    ImagePath = transaction.ImagePath,
                    TransactionType = transaction.TransactionType,
                    TransactionId = transaction.TransactionId
                };
                this.TransactionsListAsync.Add(transactionObservableModel);
            }
            this.TransactionsFilterListAsync.Clear();
            var transactionFilters = from t in TransactionsListAsync
                                    join c in ContactListAsync on t.ContactId equals c.ContactId
                                    join m in MyBankAccountsAsync on t.BankId equals m.BankId
                                    select new { t.Amount, t.Date, t.TransactionId, t.TransactionType, c.Name, m.BankName, m.CardNumber };
            foreach(var transactionFilter in transactionFilters)
            {
                TransactionFilterObservableModel transactionFilterObservableModel = new TransactionFilterObservableModel
                {
                    CardNumber = transactionFilter.CardNumber,
                    Amount = transactionFilter.Amount,
                    BankName = transactionFilter.BankName,
                    Date = transactionFilter.Date.ToShamsi(),
                    Name = transactionFilter.Name,
                    TransactionId = transactionFilter.TransactionId,
                    TransactionType = (transactionFilter.TransactionType == 0) ? "پرداختی" : "دریافتی"
                };
                this.TransactionsFilterListAsync.Add(transactionFilterObservableModel);
            }
            this.isBusy = false;
        }
        public async Task GetMyBankAccountsItemsAsync()
        {
            this.isBusy = true;
            this.MyBankAccountsAsync.Clear();
            var mybankaccounts = await App.Database.GetMyBankAccountsAsync();
            foreach (var mybankaccount in mybankaccounts.ToList())
            {
                MyBankAccountObservableModel myBankAccountObservableModel = new MyBankAccountObservableModel
                {
                    AccountNumber = mybankaccount.AccountNumber,
                    BankId = mybankaccount.BankId,
                    BankName = mybankaccount.BankName,
                    AccountBalance = mybankaccount.AccountBalance,
                    CardNumber = mybankaccount.CardNumber
                };
                this.MyBankAccountsAsync.Add(myBankAccountObservableModel);
            }
            this.isBusy = false;
        }
        public async Task GetContactAsync(int Id)
        {
            this.isBusy = true;
            var contact = await App.Database.GetContactAsync(Id);
            ContactObservableModel contactObservableModel = new ContactObservableModel
            {
                AccountNumber = contact.AccountNumber,
                Phone1 = contact.Phone1,
                Phone2 = contact.Phone2,
                Name = contact.Name,
                PhoneSocial = contact.PhoneSocial,
                ContactId = contact.ContactId
            };
            this.Contact = contactObservableModel;
            this.isBusy = false;
        }
        public async Task GetTransactionAsync(int Id)
        {
            this.isBusy = true;
            var transaction = await App.Database.GetTransactionAsync(Id);
            TransactionObservableModel transactionObservableModel = new TransactionObservableModel
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
            this.Transaction = transactionObservableModel;
            this.isBusy = false;
        }
        public async Task GetMyBankAccountAsync(int Id)
        {
            this.isBusy = true;
            var mybankaccount = await App.Database.GetMyBankAccountAsync(Id);
            MyBankAccountObservableModel myBankAccountObservableModel = new MyBankAccountObservableModel
            {
                AccountNumber = mybankaccount.AccountNumber,
                BankId = mybankaccount.BankId,
                BankName = mybankaccount.BankName,
                AccountBalance = mybankaccount.AccountBalance,
                CardNumber = mybankaccount.CardNumber
            };
            this.MyBankAccount = myBankAccountObservableModel;
            this.isBusy = false;
        }
    }
}

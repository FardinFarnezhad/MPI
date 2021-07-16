using AccountingNavid.DataLayer.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AccountingNavid.DataLayer.Services
{
    public class AppDatabase
    {
        readonly SQLiteAsyncConnection database;
        public AppDatabase (string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            //database.DropTableAsync<Contact>().Wait();
            //database.DropTableAsync<Transactions>().Wait();
            //database.DropTableAsync<MyBankAccount>().Wait();
            database.CreateTableAsync<Contact>().Wait();
            database.CreateTableAsync<Transactions>().Wait();
            database.CreateTableAsync<MyBankAccount>().Wait();
        }
        public Task<List<Contact>> GetContactsAsync()
        {
            return database.Table<Contact>().ToListAsync();
        }
        public Task<List<MyBankAccount>> GetMyBankAccountsAsync()
        {
            return database.Table<MyBankAccount>().ToListAsync();
        }
        public Task<List<Transactions>> GetTransactionsAsync()
        {
            return database.Table<Transactions>().ToListAsync();
        }
        public Task<List<Transactions>> GetTransactionsForDeleteAsync(int id)
        {
            return database.Table<Transactions>().Where(n=>n.ContactId == id).ToListAsync();
        }
        public Task<int> DeleteContactsTable()
        {
            return database.DeleteAllAsync<Contact>();
        }
        public Task<int> DeleteBankAccountsTable()
        {
            return database.DeleteAllAsync<MyBankAccount>();
        }
        public void DeleteAllTable()
        {
            database.DeleteAllAsync<Transactions>();
            database.DeleteAllAsync<MyBankAccount>();
            database.DeleteAllAsync<Contact>();
        }
        public Task<int> SaveContactAsync(Contact contact)
        {
            if(contact.ContactId == 0)
            {
                return database.InsertAsync(contact);
            }
            else
            {
                return database.UpdateAsync(contact);
            }
        }
        public Task<int> SaveTransactionsAsync(Transactions transactions)
        {
            if(transactions.TransactionId == 0)
            {
                return database.InsertAsync(transactions);
            }
            else
            {
                return database.UpdateAsync(transactions);
            }
        }
        public Task<int> SaveMyBankAccountAsync(MyBankAccount mybankaccount)
        {
            if (mybankaccount.BankId == 0)
            {
                return database.InsertAsync(mybankaccount);
            }
            else
            {
                return database.UpdateAsync(mybankaccount);
            }
        }
        public Task<int> DeleteContactAsync(Contact contact)
        {
            return database.DeleteAsync(contact);
        }
        public Task<int> DeleteTransactionsAsync(Transactions transactions)
        {
            return database.DeleteAsync(transactions);
        }
        public Task<int> DeleteMyBankAccountAsync(MyBankAccount myBankAccount)
        {
            return database.DeleteAsync(myBankAccount);
        }
        public Task<Contact> GetContactAsync(int id)
        {
            return database.Table<Contact>().Where(n => n.ContactId == id).FirstOrDefaultAsync();
        }
        public Task<Transactions> GetTransactionAsync(int id)
        {
            return database.Table<Transactions>().Where(n => n.TransactionId == id).FirstOrDefaultAsync();
        }
        public Task<MyBankAccount> GetMyBankAccountAsync(int id)
        {
            return database.Table<MyBankAccount>().Where(n => n.BankId == id).FirstOrDefaultAsync();
        }
    }
}

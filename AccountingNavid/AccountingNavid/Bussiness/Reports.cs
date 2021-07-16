using Accounting.Utility.Convertor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingNavid.Bussiness
{
    public static class Reports
    {
        public async static Task MonthlyReport()
        {
            DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01);
            DateTime endDate = startDate.AddDays(30);
            await ReportCalculator(startDate, endDate);
        }
        public async static Task GetTheMostUsedContact()
        {
            var contactIdList = App.ViewModel.TransactionsListAsync.Select(n => n.ContactId).ToList();
            var mostRepeatedId = contactIdList.GroupBy(i => i).OrderByDescending(n => n.Count()).Select(n => n.Key).First();
            await App.ViewModel.GetContactAsync(mostRepeatedId);
        }
        public async static Task GetTheMostUsedBankAccount()
        {
            var bankIdList = App.ViewModel.TransactionsListAsync.Select(n => n.BankId).ToList();
            var mostRepeatedId = bankIdList.GroupBy(i => i).OrderByDescending(n => n.Count()).Select(n => n.Key).First();
            await App.ViewModel.GetMyBankAccountAsync(mostRepeatedId);
        }
        public async static Task YearlyReport()
        {
            DateTime startDate = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime endDate = new DateTime(DateTime.Now.Year, 12, 31);
            await ReportCalculator(startDate, endDate);
        }
        public async static Task DailyReport()
        {
            DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            DateTime endDate = startDate.AddDays(1);
            await ReportCalculator(startDate, endDate);
        }
        public async static Task WeeklyReport()
        {
            DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).StartOfWeek(DayOfWeek.Saturday);
            DateTime endDate = startDate.AddDays(7);
            await ReportCalculator(startDate, endDate);
        }

        public async static Task ReportCalculator(DateTime startDate, DateTime endDate)
        {
            App.ViewModel.Contact.ContactId = 0;
            App.ViewModel.MyBankAccount.BankId = 0;
            var income = App.ViewModel.TransactionsListAsync.Where(n => n.TransactionType == 1 && startDate <= n.Date && n.Date <= endDate).Select(n => n.Amount).ToList();
            var pay = App.ViewModel.TransactionsListAsync.Where(n => n.TransactionType == 0 && startDate <= n.Date && n.Date <= endDate).Select(n => n.Amount).ToList();
            App.ViewModel.Report.Income = income.Sum();
            App.ViewModel.Report.Pay = pay.Sum();
            App.ViewModel.Report.Balance = (income.Sum() - pay.Sum());
            var contactIdList = App.ViewModel.TransactionsListAsync.Where(n=> startDate <= n.Date && n.Date <= endDate).Select(n => n.ContactId).ToList();
            var mostRepeatedContactId = contactIdList.GroupBy(i => i).OrderByDescending(n => n.Count()).Select(n => n.Key).FirstOrDefault();
            if(mostRepeatedContactId != 0)
            {
                await App.ViewModel.GetContactAsync(mostRepeatedContactId);
            }
            App.ViewModel.Report.ContactCount = App.ViewModel.TransactionsListAsync.Where(n => n.ContactId == App.ViewModel.Contact.ContactId && startDate <= n.Date && n.Date <= endDate).Count();
            var bankIdList = App.ViewModel.TransactionsListAsync.Where(n => startDate <= n.Date && n.Date <= endDate).Select(n => n.BankId).ToList();
            var mostRepeatedBankId = bankIdList.GroupBy(i => i).OrderByDescending(n => n.Count()).Select(n => n.Key).FirstOrDefault();
            if(mostRepeatedBankId != 0)
            {
                await App.ViewModel.GetMyBankAccountAsync(mostRepeatedBankId);
            }
            App.ViewModel.Report.BankAccountCount = App.ViewModel.TransactionsListAsync.Where(n => n.BankId == App.ViewModel.MyBankAccount.BankId && startDate <= n.Date && n.Date <= endDate).Count();
        }
        public static void ContactReport()
        {
            App.ViewModel.Report.ContactCount = App.ViewModel.TransactionsListAsync.Where(n => n.ContactId == App.ViewModel.Contact.ContactId).Count();
            var income = App.ViewModel.TransactionsListAsync.Where(n => n.ContactId == App.ViewModel.Contact.ContactId && n.TransactionType == 1).Select(n => n.Amount).ToList();
            var pay = App.ViewModel.TransactionsListAsync.Where(n => n.ContactId == App.ViewModel.Contact.ContactId && n.TransactionType == 0).Select(n => n.Amount).ToList();
            App.ViewModel.Report.Income = income.Sum();
            App.ViewModel.Report.Pay = pay.Sum();
            App.ViewModel.Report.Balance = (income.Sum() - pay.Sum());
        }

        public static void BankAccountReport()
        {
            App.ViewModel.Report.BankAccountCount = App.ViewModel.TransactionsListAsync.Where(n => n.BankId == App.ViewModel.MyBankAccount.BankId).Count();
            var income = App.ViewModel.TransactionsListAsync.Where(n => n.BankId == App.ViewModel.MyBankAccount.BankId && n.TransactionType == 1).Select(n => n.Amount).ToList();
            var pay = App.ViewModel.TransactionsListAsync.Where(n => n.BankId == App.ViewModel.MyBankAccount.BankId && n.TransactionType == 0).Select(n => n.Amount).ToList();
            App.ViewModel.Report.Income = income.Sum();
            App.ViewModel.Report.Pay = pay.Sum();
            App.ViewModel.Report.Balance = (income.Sum() - pay.Sum());
        }
        public static void BankAccountReport(int BankId)
        {
            var income = App.ViewModel.TransactionsListAsync.Where(n => n.BankId == BankId && n.TransactionType == 1).Select(n => n.Amount).ToList();
            var pay = App.ViewModel.TransactionsListAsync.Where(n => n.BankId == BankId && n.TransactionType == 0).Select(n => n.Amount).ToList();
            App.ViewModel.Report.Income = income.Sum();
            App.ViewModel.Report.Pay = pay.Sum();
            App.ViewModel.Report.Balance = (income.Sum() - pay.Sum());
        }
    }
}

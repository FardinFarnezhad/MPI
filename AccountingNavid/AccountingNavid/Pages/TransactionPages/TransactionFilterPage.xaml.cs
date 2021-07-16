using Accounting.Utility.Convertor;
using AccountingNavid.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using AccountingNavid.DataLayer.Cummon.Helpers;
using System.Globalization;

namespace AccountingNavid.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransactionFilterPage : ContentPage
    {
        private int TransactionTypeId;
        public TransactionFilterPage()
        {
            TransactionTypeId = -1;
            InitializeComponent();
            YearFromDatePicker.SelectedItem = DateTime.Now.ToShamsiDate().Year;
            YearToDatePicker.SelectedItem = DateTime.Now.ToShamsiDate().Year;
            MonthFromDatePicker.SelectedIndex = DateTime.Now.ToShamsiDate().Month - 1;
            MonthToDatePicker.SelectedIndex = DateTime.Now.ToShamsiDate().Month - 1;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (TransactionTypeId == -1)
            {
                IncomeSwitch.IsToggled = false;
                PaySwitch.IsToggled = false;
            }
            if (App.ViewModel.Contact.ContactId != 0)
            {
                ContactName.Text = App.ViewModel.Contact.Name;
            }
            if (App.ViewModel.MyBankAccount.BankId != 0)
            {
                MyBankAccountNumber.Text = App.ViewModel.MyBankAccount.CardNumber;
            }
            BindingContext = App.ViewModel.DateModel;
        }
        private void BtnFilter(object sender, EventArgs e)
        {
            Filter();
        }
        public async void Filter()
        {
            await App.ViewModel.GetTransactionsItemsAsync();
            IEnumerable<TransactionObservableModel> transactionlist;
            try
            {
                if (MonthToDatePicker.SelectedItem != null && YearToDatePicker.SelectedItem != null && DayToDatePicker.SelectedItem != null)
                {
                    string toDate = $" {(int)YearToDatePicker.SelectedItem}/{MonthToDatePicker.SelectedIndex + 1}/{ DayToDatePicker.SelectedIndex + 1}";
                    var toDateTime = toDate.PersianDateStringToDateTime();
                    App.ViewModel.DateModel.ToDate = new DateTime(toDateTime.Year, toDateTime.Month, toDateTime.Day,
                        ToTimePicker.Time.Hours, ToTimePicker.Time.Minutes, ToTimePicker.Time.Seconds);
                }
                if (MonthFromDatePicker.SelectedItem != null && YearToDatePicker.SelectedItem != null && DayToDatePicker.SelectedItem != null)
                {
                    string fromDate = $" {(int)YearFromDatePicker.SelectedItem}/{MonthFromDatePicker.SelectedIndex + 1}/{DayFromDatePicker.SelectedIndex + 1}";
                    var fromDateTime = fromDate.PersianDateStringToDateTime();
                    App.ViewModel.DateModel.FromDate = new DateTime(fromDateTime.Year, fromDateTime.Month, fromDateTime.Day,
                        FromTimePicker.Time.Hours, FromTimePicker.Time.Minutes, FromTimePicker.Time.Seconds);
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {
                await DisplayAlert("خطا", "لطفا تاریخ را درست وارد کنید", "بستن");
                return;
            }
            if (IncomeSwitch.IsToggled)
            {
                TransactionTypeId = 1;
            }
            if (PaySwitch.IsToggled)
            {
                TransactionTypeId = 0;
            }
            if (await Validation())
            {
                if (PaySwitch.IsToggled && IncomeSwitch.IsToggled)
                {
                    transactionlist = App.ViewModel.TransactionsListAsync.ToList();
                }
                else
                {
                    transactionlist = App.ViewModel.TransactionsListAsync.Where(n => n.TransactionType == TransactionTypeId).ToList();
                }
                if (App.ViewModel.Contact.ContactId != 0)
                {
                    transactionlist = transactionlist.Where(n => n.ContactId == App.ViewModel.Contact.ContactId).ToList();
                }
                if (App.ViewModel.MyBankAccount.BankId != 0)
                {
                    transactionlist = transactionlist.Where(n => n.BankId == App.ViewModel.MyBankAccount.BankId).ToList();
                }
                if (App.ViewModel.DateModel.ToDate != null)
                {
                    transactionlist = transactionlist.Where(n => n.Date <= App.ViewModel.DateModel.ToDate).ToList();
                }
                if (App.ViewModel.DateModel.FromDate != null)
                {
                    transactionlist = transactionlist.Where(n => n.Date >= App.ViewModel.DateModel.FromDate).ToList();
                }
                transactionlist = transactionlist.OrderByDescending(n => n.Date).ToList();
                await App.ViewModel.SetMyTransactionFilterAsync(transactionlist);
                new DataLayer.Cummon.Commands.NavigateToTransactionListPageCommand().Execute("");
            }
            else
            {
                return;
            }
        }
        private async Task<bool> Validation()
        {
            if (!IncomeSwitch.IsToggled && !PaySwitch.IsToggled)
            {
                await DisplayAlert("خطا", "نوع تراکنش را انتخاب کنید", "بستن");
                return false;
            }
            return true;
        }

        private void GoToContactListEvent(object sender, EventArgs e)
        {
            App.ViewModel.Contact.ContactId = 0;
            new DataLayer.Cummon.Commands.NavigateToContactListCommand().Execute(1);
        }

        private void GoToBankAccountListEvent(object sender, EventArgs e)
        {
            App.ViewModel.MyBankAccount.BankId = 0;
            new DataLayer.Cummon.Commands.NavigateToBankAccountListPageCommand().Execute(1);
        }

        private void ClearContact(object sender, EventArgs e)
        {
            if(App.ViewModel.Contact.ContactId != 0)
            {
                App.ViewModel.Contact = new ContactObservableModel();
                ContactName.Text = "لطفا طرف حساب را انتخاب کنید.";
            }
        }

        private void ClearBankAccount(object sender, EventArgs e)
        {
            if(App.ViewModel.MyBankAccount.BankId != 0)
            {
                App.ViewModel.MyBankAccount = new MyBankAccountObservableModel();
                MyBankAccountNumber.Text = "لطفا حساب بانکی خود را انتخاب کنید.";
            }
        }
    }
}
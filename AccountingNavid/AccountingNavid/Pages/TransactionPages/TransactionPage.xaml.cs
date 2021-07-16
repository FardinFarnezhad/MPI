using Accounting.Utility.Convertor;
using AccountingNavid.DataLayer.Cummon.Helpers;
using AccountingNavid.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace AccountingNavid.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransactionPage : ContentPage
    {
        private TransactionObservableModel _transaction;
        public TransactionPage()
        {
            InitializeComponent();
            _transaction = App.ViewModel.Transaction;
        }
        protected async override void OnAppearing()
        {
            await SetContactViewModel();
            await SetMyBankAccountViewModel();
            contactName.Text = App.ViewModel.Contact.Name;
            MyBankAccountNumber.Text = App.ViewModel.MyBankAccount.CardNumber;
            if (_transaction.TransactionType == 0)
            {
                TransactionType.Text = "پرداختی";
            }
            else
            {
                TransactionType.Text = "دریافتی";
            }
            TransactionDate.Text = _transaction.Date.ToShamsi().ToString();
            if (_transaction != null)
            {
                BindingContext = _transaction;
            }
            base.OnAppearing();
        }
        private async void BtnDelte(object sender, EventArgs e)
        {
            var target = BindingContext as TransactionObservableModel;
            if (await DisplayAlert("هشدار", $"  آیا از حذف این تراکنش  اطمینان دارید؟", "بله", "خیر"))
            {
                App.ViewModel.TransactionsFilterListAsync.Remove(App.ViewModel.TransactionFilterObservable);
                new DataLayer.Cummon.Commands.DeleteTransactionCommand().Execute(target.TransactionId);
            }
        }
        private async Task SetContactViewModel()
        {
            await App.ViewModel.GetContactAsync(_transaction.ContactId);
        }
        private async Task SetMyBankAccountViewModel()
        {
            await App.ViewModel.GetMyBankAccountAsync(_transaction.BankId);
        }
        private async void CopyText(object sender, EventArgs e)
        {
            var stackLayout = (StackLayout)sender;
            var label = (Label)stackLayout.Children[1];
            if (label.Text != "" && label.Text != null)
            {
                await Clipboard.SetTextAsync(label.Text);
                await DisplayAlert("موفقیت", "متن مورد نظر کپی شد", "بستن");
            }
        }
        private async void SharePhoto(object sender, EventArgs e)
        {
            await SharePhotoAsync();
        }
        private async Task SharePhotoAsync()
        {
            if (_transaction.ImagePath != null)
            {
                await Share.RequestAsync(new ShareFileRequest
                {
                    Title = Title,
                    File = new ShareFile(_transaction.ImagePath)
                });
            }
        }
    }
}
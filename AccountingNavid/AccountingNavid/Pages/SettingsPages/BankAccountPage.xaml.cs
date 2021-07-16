using AccountingNavid.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AccountingNavid.Pages.SettingsPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BankAccountPage : ContentPage
    {
        private MyBankAccountObservableModel _myBankAccount;
        public BankAccountPage()
        {
            InitializeComponent();
            _myBankAccount = App.ViewModel.MyBankAccount;
            if (_myBankAccount.AccountBalance != 0)
            {
                Bussiness.Reports.BankAccountReport(_myBankAccount.BankId);
                MyBankAccountBalance.Text = (_myBankAccount.AccountBalance + App.ViewModel.Report.Balance).ToString("#,0;#,0-") + " ریال ";
            }
        }
        protected override void OnAppearing()
        {
            if(_myBankAccount != null)
            {
                BindingContext = _myBankAccount;
            }
            base.OnAppearing();
        }
        private async void BtnDelete(object sender, EventArgs e)
        {
            var target = BindingContext as MyBankAccountObservableModel;
            if (await DisplayAlert("هشدار", $"  آیااز حذف شماره حساب{target.AccountNumber}  اطمینان دارید؟ " +
                $"(هشدار!! اگر این شماره کارت را حذف کنید تمام تراکنش های مرتبط بااین طرف حساب پاک خواهد شد)", "بله", "خیر"))
            {
                new DataLayer.Cummon.Commands.DeleteMyBankAccountsCommand().Execute(target.BankId);
            }
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
    }
}
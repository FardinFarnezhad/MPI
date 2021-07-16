using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AccountingNavid.Pages.ReportPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportFilterBankAccountDetailPage : ContentPage
    {
        public ReportFilterBankAccountDetailPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            if (App.ViewModel.Report.Balance == 0)
            {
                TransactionsBalance.Text = "0" + " ریال ";
            }
            Bussiness.Reports.BankAccountReport();
            if (App.ViewModel.Report.Balance != 0)
            {
                TransactionsBalance.Text = App.ViewModel.Report.Balance.ToString("#,0;#,0-") + " ریال ";
            }
            if (App.ViewModel.MyBankAccount.BankId != 0)
            {
                BankAccountNumber.Text = App.ViewModel.MyBankAccount.CardNumber;
            }
            if(App.ViewModel.MyBankAccount.AccountBalance != 0)
            {
                AfterBalance.Text = (App.ViewModel.MyBankAccount.AccountBalance + App.ViewModel.Report.Balance).ToString("#,0;#,0-") + " ریال ";
                BeforeBalance.Text = App.ViewModel.MyBankAccount.AccountBalance.ToString("#,0;#,0-") + " ریال ";
            }
            BindingContext = App.ViewModel.Report;
            base.OnAppearing();
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
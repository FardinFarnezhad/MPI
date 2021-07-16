using AccountingNavid.DataLayer.Cummon.Helpers;
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
    public partial class ReportPage : ContentPage
    {
        public ReportPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            if (App.ViewModel.Report.Balance == 0)
            {
                Balance.Text = "0" + " ریال ";
            }
            BindingContext = App.ViewModel.Report;
            base.OnAppearing();
        }
        private async void ReportPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            await GettingReport();
        }

        private async Task GettingReport()
        {
            switch (ReportPicker.SelectedIndex)
            {
                case 0:
                    await Bussiness.Reports.DailyReport();
                    break;
                case 1:
                    await Bussiness.Reports.WeeklyReport();
                    break;
                case 2:
                    await Bussiness.Reports.MonthlyReport();
                    break;
                case 3:
                    await Bussiness.Reports.YearlyReport();
                    break;
            }
            if (App.ViewModel.Report.Balance != 0)
            {
                Balance.Text = App.ViewModel.Report.Balance.ToString("#,0;#,0-") + " ریال ";
            }
            else
            {
                Balance.Text = "0" + " ریال ";
            }
            if (App.ViewModel.Contact.ContactId != 0)
            {
                ContactName.Text = App.ViewModel.Contact.Name;
            }
            else
            {
                ContactName.Text = null;
            }
            if (App.ViewModel.MyBankAccount.BankId != 0)
            {
                BankAccount.Text = App.ViewModel.MyBankAccount.CardNumber;
            }
            else
            {
                BankAccount.Text = null;
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
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
    public partial class ReportFilterDetailPage : ContentPage
    {
        public ReportFilterDetailPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            if (App.ViewModel.Report.Balance == 0)
            {
                Balance.Text = "0" + " ریال ";
            }
            Bussiness.Reports.ContactReport();
            if (App.ViewModel.Report.Balance != 0)
            {
                Balance.Text = App.ViewModel.Report.Balance.ToString("#,0;#,0-") + " ریال ";
            }
            if(App.ViewModel.Contact.ContactId != 0)
            {
                ContactName.Text = App.ViewModel.Contact.Name;
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
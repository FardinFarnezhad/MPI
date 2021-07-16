using Accounting.Utility.Convertor;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AccountingNavid.Pages.TransactionPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransactionFilterDatePage : ContentPage
    {
        public TransactionFilterDatePage()
        {
            InitializeComponent();
            YearFromDatePicker.SelectedItem = DateTime.Now.ToShamsiDate().Year;
            YearToDatePicker.SelectedItem = DateTime.Now.ToShamsiDate().Year;
            MonthFromDatePicker.SelectedIndex = DateTime.Now.ToShamsiDate().Month - 1;
            MonthToDatePicker.SelectedIndex = DateTime.Now.ToShamsiDate().Month - 1;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = App.ViewModel.DateModel;
        }
        private async void BtnFilter(object sender, EventArgs e)
        {
            if (MonthToDatePicker.SelectedItem == null && YearToDatePicker.SelectedItem == null && DayToDatePicker.SelectedItem == null 
                || MonthFromDatePicker.SelectedItem == null && YearToDatePicker.SelectedItem == null && DayToDatePicker == null)
            {
                await DisplayAlert("خطا", "لطفا بازه زمانی را مشخص کنید", "بستن");
                return;
            }
            else
            {
                try
                {
                    string fromDate = $" {(int)YearFromDatePicker.SelectedItem}/{MonthFromDatePicker.SelectedIndex + 1}/{DayFromDatePicker.SelectedIndex + 1}";
                    string toDate = $" {(int)YearToDatePicker.SelectedItem}/{MonthToDatePicker.SelectedIndex + 1}/{ DayToDatePicker.SelectedIndex + 1}";
                    var fromDateTime = fromDate.PersianDateStringToDateTime();
                    var toDateTime = toDate.PersianDateStringToDateTime();
                    App.ViewModel.DateModel.FromDate = new DateTime(fromDateTime.Year,fromDateTime.Month, fromDateTime.Day,
                        FromTimePicker.Time.Hours, FromTimePicker.Time.Minutes, FromTimePicker.Time.Seconds);
                    App.ViewModel.DateModel.ToDate = new DateTime(toDateTime.Year, toDateTime.Month, toDateTime.Day,
                        ToTimePicker.Time.Hours, ToTimePicker.Time.Minutes, ToTimePicker.Time.Seconds);
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    await DisplayAlert("خطا", "لطفا تاریخ را درست وارد کنید", "بستن");
                    return;
                }
                await Bussiness.Reports.ReportCalculator(App.ViewModel.DateModel.FromDate.GetValueOrDefault(), App.ViewModel.DateModel.ToDate.GetValueOrDefault());
                await App.MainNavigation.PopAsync();
                new DataLayer.Cummon.Commands.NavigateToReportFilterDateDetailPageCommand().Execute("");
            }
        }
    }
}
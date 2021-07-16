using AccountingNavid.DataLayer.Cummon.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AccountingNavid.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

        }

        protected async override void OnAppearing()
        {
            if (App.ViewModel == null)
            {
                App.ViewModel = new ViewModel.MainViewModel();
            }
            await App.ViewModel.GetItemsAsync();
            if (App.ViewModel.Contact != null)
            {
                App.ViewModel.Contact.ContactId = 0;
            }
            if (App.ViewModel.Transaction != null)
            {
                App.ViewModel.Transaction.TransactionId = 0;
            }
            if(App.ViewModel.MyBankAccount != null)
            {
                App.ViewModel.MyBankAccount.BankId = 0;
            }
            if(App.ViewModel.DateModel != null)
            {
                App.ViewModel.DateModel.FromDate = null;
                App.ViewModel.DateModel.ToDate = null;
            }
            if(App.ViewModel.Report != null)
            {
                App.ViewModel.Report.Balance = 0;
                App.ViewModel.Report.Pay = 0;
                App.ViewModel.Report.Income = 0;
                App.ViewModel.Report.ContactCount = 0;
                App.ViewModel.Report.BankAccountCount = 0;
            }
            App.MainNavigation = Navigation;
            base.OnAppearing();
        }

        private void ScrollToEnd(object sender, EventArgs e)
        {
            HomeScrollView.ScrollToAsync(EndStackLayout, ScrollToPosition.End, true);
        }
        private void BtnInfo(object sender, EventArgs e)
        {
            DisplayAlert("راهنما", "نحوه اسنفاده از برنامه :" + "\n" +
                "- ابتدا باید از صفحه اصلی و در صفحه‌ی طرف حساب ها، طرف حساب خود را اضافه کنید." + "\n" +
                "- از صفحه‌ی مدیریت کارت ها در صفحه‌ی تنظیمات، حساب های بانکی خود را اضافه کنید." + "\n" +
                "- می توانید از صفحه‌ی افزودن تراکنش، تراکنش های خود را وارد برنامه کنید." + "\n" +
                "- برای دیدن تراکنش های خود وارد صفحه ی تراکنش ها شوید و فیلتر های دلخواه خود را اعمال کنید." + "\n" +
                "- برای دیدن آمار تراکنش های خود وارد صفحه‌ی آمار تراکنش ها شوید و برای دیدن فیلتر های بیشتر با زدن دکمه بالا سمت راست، وارد صفحه‌ی مورد نظر خود می شوید." + "\n" +
                "نکات ریز و درشت :" + "\n" +
                "- در صفحه تراکنش ها اگر هر دو فیلتر پرداختی و دریافتی انتخاب شود؛ میتوانید هر دو نوع تراکنش را در لیست تراکنش ها مشاهده کنید." + "\n" +
                "- میتوانید با افزودن یک طرف حساب با نام متفرقه، تراکنش های کوچک خود را مدیریت کنید." + "\n" +
                "- میتوانید با افزودن یک کارت با عنوان تراکنش های نقدی خود را مدیریت کنید." + "\n" +
                "- با دو بار زدن روی هر کدام از فیلد ها، میتوانید محتوای داخل آن را کپی کنید." + "\n" +
                "- با دو بار زدن روی عکس تراکنش، میتوانید عکس را به اشتراک بگذارید." + "\n" +
                "- وارد کردن اطلاعات در فیلد های ستاره دار الزامی است.", "بستن");
        }
    }
}
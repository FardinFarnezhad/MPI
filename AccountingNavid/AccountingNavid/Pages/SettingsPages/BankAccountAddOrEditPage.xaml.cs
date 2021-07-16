using AccountingNavid.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AccountingNavid.Pages.SettingsPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BankAccountAddOrEditPage : ContentPage
    {
        private bool _isEdit;
        private MyBankAccountObservableModel _myBankAccount;
        public BankAccountAddOrEditPage()
        {
            InitializeComponent();
            if (App.ViewModel.MyBankAccount.BankId != 0 && App.ViewModel.MyBankAccount != null)
            {
                _isEdit = true;
                _myBankAccount = App.ViewModel.MyBankAccount;
            }
            else
            {
                _isEdit = false;
            }
            MyBankAccountAccountBalance.IsReadOnly = false;
        }
        protected override void OnAppearing()
        {
            if (_isEdit)
            {
                this.Title = "ویرایش حساب بانکی";
                MyBankAccountAccountBalance.IsReadOnly = true;
                MyBankAccountAccountBalance.Text = (_myBankAccount.AccountBalance + App.ViewModel.Report.Balance).ToString("#,0;#,0-");
            } 
            if (_myBankAccount != null)
            {
                BindingContext = _myBankAccount;
            }
            base.OnAppearing();
        }

        private async void ButtonAddOrEdit(object sender, EventArgs e)
        {
            if (await Validation())
            {
                if (!_isEdit)
                {
                    MyBankAccountObservableModel target = new MyBankAccountObservableModel()
                    {
                        AccountNumber = MyBankAccountNumber.Text,
                        BankName = MyBankAccountName.Text,
                        AccountBalance = Convert.ToDecimal(MyBankAccountAccountBalance.Text),
                        CardNumber = MyBankCardNumber.Text
                    };
                    new DataLayer.Cummon.Commands.AddToMyBankAccountCommand().Execute(target);
                }
                else
                {
                    MyBankAccountObservableModel target = new MyBankAccountObservableModel()
                    {
                        AccountNumber = MyBankAccountNumber.Text,
                        BankName = MyBankAccountName.Text,
                        BankId = _myBankAccount.BankId,
                        AccountBalance = Convert.ToDecimal(MyBankAccountAccountBalance.Text),
                        CardNumber = MyBankCardNumber.Text
                    };
                    new DataLayer.Cummon.Commands.EditMyBankAccountCommand().Execute(target);
                }
            }
            else
            {
                return;
            }
        }
        private async Task<bool> Validation()
        {
            if (MyBankCardNumber.Text == null || MyBankCardNumber.Text == "")
            {
                await DisplayAlert("خطا", "لطفا شماره کارت خود را وارد کنید.", "بستن");
                return false;
            }
            if (MyBankAccountName.Text == null || MyBankAccountNumber.Text == "")
            {
                await DisplayAlert("خطا", "لطفا نام بانک صادر کننده بانک را وارد کنید.", "بستن");
                return false;
            }
            if(MyBankAccountAccountBalance.Text == null || MyBankAccountAccountBalance.Text == "")
            {
                await DisplayAlert("خطا", "لطفا موجودی کارت خود را وارد کنید.", "بستن");
                return false;
            }
            return true;
        }

        private void MyBankAccountAccountBalance_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;
            if (entry.Text != "")
            {
                try
                {
                    MyBankAccountAccountBalance.Text = Convert.ToDecimal(entry.Text).ToString(("N0"));
                }
                catch (System.OverflowException)
                {
                    DisplayAlert("خطا", "مبلغ بیش از 27 رقم نمی تواند باشد", "بستن");
                }
            }
        }
    }
}
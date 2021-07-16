using Accounting.Utility.Convertor;
using AccountingNavid.DataLayer.Models;
using AccountingNavid.ViewModel;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AccountingNavid.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransactionAddOrEdit : ContentPage
    {
        private int TransactionTypeId;
        private TransactionObservableModel _transcation;
        private string _imagePath;
        private bool _isEdit;
        public TransactionAddOrEdit()
        {
            InitializeComponent();
            if(App.ViewModel.Transaction.TransactionId != 0 && App.ViewModel.Transaction != null)
            {
                _isEdit = true;
                _transcation = App.ViewModel.Transaction;
                YearDatePicker.SelectedItem = _transcation.Date.ToShamsiDate().Year;
                MonthDatePicker.SelectedIndex = _transcation.Date.ToShamsiDate().Month - 1;
                DayDatePicker.SelectedIndex = _transcation.Date.ToShamsiDate().Day - 1;
                TimePicker.Time = new TimeSpan(_transcation.Date.Hour, _transcation.Date.Minute, _transcation.Date.Second);
            }
            else
            {
                _isEdit = false;
                YearDatePicker.SelectedItem = DateTime.Now.ToShamsiDate().Year;
                MonthDatePicker.SelectedIndex = DateTime.Now.ToShamsiDate().Month - 1;
                DayDatePicker.SelectedIndex = DateTime.Now.ToShamsiDate().Day - 1;
            }
        }
        protected override void OnAppearing()
        {
            if (_isEdit)
            {
                if (_transcation.TransactionType == 1)
                {
                    IncomeSwitch.IsToggled = true;
                    PaySwitch.IsToggled = false;
                }
                if (_transcation.TransactionType == 0)
                {
                    PaySwitch.IsToggled = true;
                    IncomeSwitch.IsToggled = false;
                }
                if (_transcation != null)
                {
                    BindingContext = _transcation;
                }
                this.Title = "ویرایش تراکنش";
            }
            if (App.ViewModel.Contact.ContactId != 0)
            {
                ContactName.Text = App.ViewModel.Contact.Name;
            }
            if (App.ViewModel.MyBankAccount.BankId != 0)
            {
                MyBankAccountNumber.Text = App.ViewModel.MyBankAccount.CardNumber;
            }
            base.OnAppearing();
        }
        private async void ButtonAddOrEdit(object sender, EventArgs e)
        {
            if (IncomeSwitch.IsToggled)
            {
                TransactionTypeId = 1;
            }
            if(PaySwitch.IsToggled)
            {
                TransactionTypeId = 0;
            }
            if (await Validation()) 
            {
                if (!_isEdit)
                {
                    TransactionObservableModel target = new TransactionObservableModel()
                    {
                        Amount = Convert.ToDecimal(TransactionAmount.Text),
                        BankId = App.ViewModel.MyBankAccount.BankId,
                        ContactId = App.ViewModel.Contact.ContactId,
                        Date = new DateTime((int)YearDatePicker.SelectedItem, MonthDatePicker.SelectedIndex + 1, DayDatePicker.SelectedIndex + 1,
                        TimePicker.Time.Hours, TimePicker.Time.Minutes, TimePicker.Time.Seconds).ToMiladi(),
                        Description = TransactionDescription.Text,
                        ImagePath = _imagePath,
                        TransactionType = TransactionTypeId,
                        TrackingNumber = TrackingNumber.Text
                    };
                    new DataLayer.Cummon.Commands.AddToTransactionsCommand().Execute(target);
                }
                else
                {
                    TransactionObservableModel target = new TransactionObservableModel()
                    {
                        Amount = Convert.ToDecimal(TransactionAmount.Text),
                        BankId = App.ViewModel.MyBankAccount.BankId,
                        ContactId = App.ViewModel.Contact.ContactId,
                        Description = TransactionDescription.Text,
                        ImagePath = _imagePath,
                        TransactionType = TransactionTypeId,
                        TransactionId = _transcation.TransactionId,
                        Date = new DateTime((int)YearDatePicker.SelectedItem, MonthDatePicker.SelectedIndex + 1, DayDatePicker.SelectedIndex + 1,
                        TimePicker.Time.Hours, TimePicker.Time.Minutes, TimePicker.Time.Seconds).ToMiladi(),
                        TrackingNumber = TrackingNumber.Text
                    };
                    TransactionFilterObservableModel transactionFilter = App.ViewModel.TransactionsFilterListAsync.First(n => n.TransactionId == App.ViewModel.Transaction.TransactionId);
                    transactionFilter.Amount = Convert.ToDecimal(TransactionAmount.Text);
                    transactionFilter.BankName = App.ViewModel.MyBankAccount.BankName;
                    transactionFilter.CardNumber = App.ViewModel.MyBankAccount.CardNumber;
                    transactionFilter.Date = App.ViewModel.Transaction.Date.ToShamsi().ToString();
                    transactionFilter.Name = App.ViewModel.Contact.Name;
                    transactionFilter.TransactionId = App.ViewModel.Transaction.TransactionId;
                    transactionFilter.TransactionType = (TransactionTypeId == 0) ? "پرداختی" : "دریافتی";
                    new DataLayer.Cummon.Commands.EditTransactionCommand().Execute(target);
                }
            }
            else
            {
                return;
            }
        }
        private async void ButtonTakeImage(object sender, EventArgs e)
        {
            if (TransactionImage.Source != null)
            {
                await DisplayAlert("خطا", "تنها یک عکس میتوانید در تراکنش داشته باشید. " +
                    "عکس پایین را پاک کنید و دوباره عکس بگیرید.", "بستن");
                return;
            }
            await Take_Image();
        }
        private async Task Take_Image()
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("خطا", "دسترسی به دوربین داده نشده است.", "بستن");
                return;
            }
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                AllowCropping = true,
                PhotoSize = PhotoSize.Medium,
                Directory = "حسابدار شخصی من",
                Name = Guid.NewGuid().ToString() + ".jpg",
                SaveToAlbum = true,
                RotateImage = false
            }) ;
            if (file == null)
                return;
            _imagePath = file.Path;
            TransactionImage.Source = _imagePath;
        }
        private void ButtonDeletePicture(object sender, EventArgs e)
        {
            _imagePath = null;
            TransactionImage.Source = null;
        }

        private void TransactionAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;
            if (entry.Text != "")
            {
                try
                {
                    TransactionAmount.Text = Convert.ToDecimal(entry.Text).ToString(("N0"));
                }
                catch (System.OverflowException) 
                {
                    DisplayAlert("خطا", "مبلغ بیش از 27 رقم نمی تواند باشد", "بستن");
                }
            }
        }
        private async Task<bool> Validation()
        {
            if(ContactName.Text == "لطفا طرف حساب را انتخاب کنید")
            {
                await DisplayAlert("خطا", "لطفا طرف حساب را انتخاب کنید.", "بستن");
                return false;
            }
            if(TransactionAmount.Text == null || TransactionAmount.Text == "")
            {
                await DisplayAlert("خطا", "لطفا مبلغ تراکنش را وارد کنید.", "بستن");
                return false;
            }
            if(MyBankAccountNumber.Text == "لطفا کارت بانکی خود را انتخاب کنید")
            {
                await DisplayAlert("خطا", "لطفا حساب بانکی خود را انتخاب کنید.", "بستن");
                return false;
            }
            if (IncomeSwitch.IsToggled && PaySwitch.IsToggled)
            {
                await DisplayAlert("خطا", "تراکنش فقط میتواند پرداختی یا دریافتی باشد.", "بستن");
                return false;
            }
            if (!IncomeSwitch.IsToggled && !PaySwitch.IsToggled)
            {
                await DisplayAlert("خطا", "نوع تراکنش را انتخاب کنید", "بستن");
                return false;
            }
            if (MonthDatePicker.SelectedItem == null && YearDatePicker.SelectedItem == null && DayDatePicker.SelectedItem == null)
            {
                await DisplayAlert("خطا", "لطفا بازه زمانی را مشخص کنید", "بستن");
                return false;
            }
            return true;
        }

        private void GoToContactListEvent(object sender, EventArgs e)
        {
            new DataLayer.Cummon.Commands.NavigateToContactListCommand().Execute(1);
        }

        private void GoToBankAccountListEvent(object sender, EventArgs e)
        {
            new DataLayer.Cummon.Commands.NavigateToBankAccountListPageCommand().Execute(1);
        }

        private async void BtnPickImage(object sender, EventArgs e)
        {
            if (TransactionImage.Source != null)
            {
                await DisplayAlert("خطا", "تنها یک عکس میتوانید در تراکنش داشته باشید. " +
                    "عکس پایین را پاک کنید و دوباره عکس بگیرید.", "بستن");
                return;
            }
            await PickImage();
        }

        private async Task PickImage()
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("خطا", "دسترسی به گالری داده نشده است.", "بستن");
                return;
            }
            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                RotateImage = false,
            });
            if (file == null)
                return;
            _imagePath = file.Path;
            TransactionImage.Source = _imagePath;
        }
    }
}
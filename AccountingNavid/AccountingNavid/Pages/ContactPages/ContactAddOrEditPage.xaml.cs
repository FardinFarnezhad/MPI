using AccountingNavid.DataLayer.Models;
using AccountingNavid.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AccountingNavid.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactAddOrEditPage : ContentPage
    {
        private bool _isEdit;
        private ContactObservableModel _contact;
        public ContactAddOrEditPage()
        {
            if(App.ViewModel.Contact != null && App.ViewModel.Contact.ContactId != 0)
            {
                _isEdit = true;
                _contact = App.ViewModel.Contact;
            }
            else
            {
                _isEdit = false;
            }
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            if (_isEdit)
            {
                this.Title = "ویرایش طرف حساب";
            }
            if(_contact != null)
            {
                BindingContext = _contact;
            }
            base.OnAppearing();
        }
        private async void AddOrEditButton(object sender, EventArgs e)
        {
            if (await Validation())
            {
                if (!_isEdit)
                {
                    ContactObservableModel target = new ContactObservableModel()
                    {
                        Name = contactName.Text,
                        Phone1 = contactPhone1.Text,
                        Phone2 = contactPhone2.Text,
                        AccountNumber = contactAccountNumber.Text,
                        PhoneSocial = contactPhone2.Text
                    };
                    new DataLayer.Cummon.Commands.AddToContactsCommand().Execute(target);
                }
                else
                {
                    ContactObservableModel target = new ContactObservableModel()
                    {
                        Name = contactName.Text,
                        Phone1 = contactPhone1.Text,
                        Phone2 = contactPhone2.Text,
                        AccountNumber = contactAccountNumber.Text,
                        PhoneSocial = contactPhone2.Text,
                        ContactId = _contact.ContactId
                    };
                    new DataLayer.Cummon.Commands.EditContactCommand().Execute(target);
                }
            }
            else
            {
                return;
            }
        }
        private async Task<bool> Validation()
        {
            if (contactName.Text == "" || contactName.Text == null)
            {
                await DisplayAlert("خطا", "لطفا طرف حساب را انتخاب کنید.", "بستن");
                return false;
            }
            if(contactPhone1.Text == "" || contactPhone1.Text == null)
            {
                await DisplayAlert("خطا", "لطفا یک شماره موبایل از طرف حساب وارد کنید.", "بستن");
                return false;
            }
            return true;
        }
    }
}
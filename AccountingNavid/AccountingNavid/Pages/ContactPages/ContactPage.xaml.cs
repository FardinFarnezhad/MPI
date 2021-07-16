using AccountingNavid.DataLayer.Models;
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
    public partial class ContactPage : ContentPage
    {
        private ContactObservableModel _contact;
        public ContactPage()
        {
            InitializeComponent();
            _contact = App.ViewModel.Contact;
        }
        protected override void OnAppearing()
        {
            if(_contact != null)
            {
                BindingContext = _contact;
            }
            base.OnAppearing();
        }
        private async void BtnDelete(object sender, EventArgs e)
        {
            var target = BindingContext as ContactObservableModel;
            if(await DisplayAlert("هشدار", $"  آیا از حذف {target.Name}  اطمینان دارید؟" +
                $" (هشدار!! اگر این طرف حساب را حذف کنید تمام تراکنش های مربوط به این طرف حساب حذف خواهد شد)", "بله", "خیر"))
            {
                new DataLayer.Cummon.Commands.DeleteContactCommand().Execute(target.ContactId);
            }
        }

        private async void CopyText(object sender, EventArgs e)
        {
            var stackLayout = (StackLayout) sender;
            var label = (Label)stackLayout.Children[1];
            if (label.Text != "" && label.Text != null)
            {
                await Clipboard.SetTextAsync(label.Text);
                await DisplayAlert("موفقیت", "متن مورد نظر کپی شد", "بستن");
            }
        }
    }
}
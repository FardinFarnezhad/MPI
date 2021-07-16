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
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }
        private async void DeleteTransactionsTable(object sender, EventArgs e)
        {
            if (await DisplayAlert("هشدار", "آیا از حذف تمامی اطلاعات اطمینان دارید؟", "بله", "خیر"))
            {
                new DataLayer.Cummon.Commands.DeleteAllCommand().Execute("");
            }
        }
    }
}
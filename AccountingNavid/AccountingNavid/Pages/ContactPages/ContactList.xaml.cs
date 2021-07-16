using AccountingNavid.DataLayer.Models;
using AccountingNavid.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace AccountingNavid.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactList : ContentPage
    {
        private readonly ContactListGroupingViewModel _contacts;
        private bool _myContactListItemSourceIsBound;
        public int _isPicking;
        public ICommand RefreshCommand { get { return new Command(async() => await RefreshList()); } }

        public ContactList()
        {
            InitializeComponent();
            _contacts = new ContactListGroupingViewModel();
            MyContactRefreshView.Command = RefreshCommand;
            MyContactRefreshView.IsRefreshing = App.ViewModel.isBusy;
            _myContactListItemSourceIsBound = false;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.ViewModel.Contact.ContactId = 0;
            MyContactRefreshView.IsRefreshing = true;
        }
        private void ContactItemTapped(object sender, ItemTappedEventArgs e)
        {
            switch (_isPicking)
            {
                case 0:
                    App.ViewModel.Contact = e.Item as ContactObservableModel;
                    new DataLayer.Cummon.Commands.NavigateToContactCommand().Execute("");
                    break;
                case 1:
                    App.ViewModel.Contact = e.Item as ContactObservableModel;
                    MyContactList.ItemsSource = null;
                    App.MainNavigation.PopAsync();
                    break;
                case 2:
                    App.ViewModel.Contact = e.Item as ContactObservableModel;
                    MyContactList.ItemsSource = null;
                    App.MainNavigation.PopAsync();
                    new DataLayer.Cummon.Commands.NavigateToReportFilterContactDetailPageCommand().Execute("");
                    break;
            }
        }
        public async Task RefreshList()
        {
            MyContactRefreshView.IsRefreshing = true;
            MyContactList.SelectedItem = null;
            await Task.Delay(350);
            await _contacts.RefreshList();
            if (_myContactListItemSourceIsBound == false)
            {
                MyContactList.ItemsSource = _contacts.GroupedData;
                _myContactListItemSourceIsBound = true;
            }
            MyContactRefreshView.IsRefreshing = false;
        }
    }
}

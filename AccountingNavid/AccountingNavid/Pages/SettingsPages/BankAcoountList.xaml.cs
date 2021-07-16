using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using AccountingNavid.ViewModel;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;

namespace AccountingNavid.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BankAcoountList : ContentPage
    {
        public int _isPicking;
        private bool _myBankAccountItemSourceIsBound;
        public ICommand RefreshCommand { get { return new Command(async () => await RefreshList()); } }

        public BankAcoountList()
        {
            InitializeComponent();
            _myBankAccountItemSourceIsBound = false;
            MyBankAccountRefreshView.Command = RefreshCommand;
            MyBankAccountRefreshView.IsRefreshing = App.ViewModel.isBusy;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.ViewModel.MyBankAccount.BankId = 0;
            MyBankAccountRefreshView.IsRefreshing = true;
        }

        private void MyBankAccountList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            switch (_isPicking)
            {
                case 0:
                    App.ViewModel.MyBankAccount = e.Item as MyBankAccountObservableModel;
                    new DataLayer.Cummon.Commands.NavigateToBankAccountDetailCommand().Execute("");
                    break;
                case 1:
                    App.ViewModel.MyBankAccount = e.Item as MyBankAccountObservableModel;
                    MyBankAccountList.ItemsSource = null;
                    App.MainNavigation.PopAsync();
                    break;
                case 2:
                    App.ViewModel.MyBankAccount = e.Item as MyBankAccountObservableModel;
                    MyBankAccountList.ItemsSource = null;
                    App.MainNavigation.PopAsync();
                    new DataLayer.Cummon.Commands.NavigateToReportFilterBankAccountDetailPageCommand().Execute("");
                    break;
            }
        }
        public async Task RefreshList()
        {
            MyBankAccountRefreshView.IsRefreshing = true;
            MyBankAccountList.SelectedItem = null;
            await Task.Delay(350);
            await App.ViewModel.GetMyBankAccountsItemsAsync();
            if (_myBankAccountItemSourceIsBound == false)
            {
                MyBankAccountList.ItemsSource = App.ViewModel.MyBankAccountsAsync;
                _myBankAccountItemSourceIsBound = true;
            }
            MyBankAccountRefreshView.IsRefreshing = false;
        }
    }
}

using AccountingNavid.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AccountingNavid.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransactionListPage : ContentPage
    {
        private bool _myTransactionListItemSourceIsBound;
        public ICommand RefreshCommand { get { return new Command(()=> RefreshList()); } }
        public TransactionListPage()
        {
            InitializeComponent();
            TransactionRefreshView.Command = RefreshCommand;
            TransactionRefreshView.IsRefreshing = App.ViewModel.isBusy;
            _myTransactionListItemSourceIsBound = false;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            TransactionRefreshView.IsRefreshing = true;
        }
        private async void MyTransactionList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            App.ViewModel.TransactionFilterObservable = e.Item as TransactionFilterObservableModel;
            await App.ViewModel.GetTransactionAsync(App.ViewModel.TransactionFilterObservable.TransactionId);
            new DataLayer.Cummon.Commands.NavigateToTransactionPageCommand().Execute("");
        }
        public void RefreshList()
        {
            TransactionRefreshView.IsRefreshing = true;
            MyTransactionList.SelectedItem = null;
            if (!_myTransactionListItemSourceIsBound && App.ViewModel.TransactionsFilterListAsync.Count != 0)
            {
                MyTransactionList.ItemsSource = App.ViewModel.TransactionsFilterListAsync;
                _myTransactionListItemSourceIsBound = true;
            }
            if(App.ViewModel.TransactionsFilterListAsync.Count == 0)
            {
                MyTransactionList.ItemsSource = null;
                _myTransactionListItemSourceIsBound = false;
            }
            TransactionRefreshView.IsRefreshing = false;
        }
    }
}
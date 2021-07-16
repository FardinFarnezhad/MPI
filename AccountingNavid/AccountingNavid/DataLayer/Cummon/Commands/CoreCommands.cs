using AccountingNavid.Pages.ReportPage;
using AccountingNavid.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace AccountingNavid.DataLayer.Cummon.Commands
{
    public class NavigateToSettingsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void Execute(object parameter)
        {
            NavigateAsync();
        }
        public async void NavigateAsync()
        {
            await App.MainNavigation.PushAsync(new Pages.SettingsPage(), true);
        }
    }
    public class NavigateToTransactionAddOrEditPageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void Execute(object parameter)
        {
            NavigateAsync();
        }
        public async void NavigateAsync()
        {
            await App.MainNavigation.PushAsync(new Pages.TransactionAddOrEdit(), true);
        }
    }
    public class NavigateToTransactionPageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void Execute(object parameter)
        {
            NavigateAsync();
        }
        public async void NavigateAsync()
        {
            await App.MainNavigation.PushAsync(new Pages.TransactionPage(), true);
        }
    }
    public class NavigateToTransactionListPageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
        public void Execute(object parameter)
        {
            NavigateAsync();
        }
        public async void NavigateAsync()
        {
            await App.MainNavigation.PushAsync(new Pages.TransactionListPage(), true);
        }
    }
    public class NavigateToTransitionFilterPageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void Execute(object parameter)
        {
            NavigateAsync();
        }
        public async void NavigateAsync()
        {
            await App.MainNavigation.PushAsync(new Pages.TransactionFilterPage(), true);
        }
    }
    public class NavigateToBankAccountListPageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void Execute(object parameter)
        {
            NavigateAsync(Convert.ToInt32(parameter));
        }
        public async void NavigateAsync(int isPicking)
        {
            Pages.BankAcoountList bankAcoountList = new Pages.BankAcoountList
            {
                _isPicking = isPicking
            };
            await App.MainNavigation.PushAsync(bankAcoountList , true);
        }
    }
    public class NavigateToContactCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void Execute(object parameter)
        {
            NavigateAsync();
        }
        public async void NavigateAsync()
        {
            await App.MainNavigation.PushAsync(new Pages.ContactPage(), true);
        }
    }
    public class NavigateToContactListCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
        public void Execute(object parameter)
        {
            NavigateAsync(Convert.ToInt32(parameter));
        }
        public async void NavigateAsync(int isPickingContact)
        {
            Pages.ContactList contactList = new Pages.ContactList
            {
                _isPicking = isPickingContact
            };
            await App.MainNavigation.PushAsync(contactList, true);
        }
    }
    public class NavigateToContactAddOrEditPageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void Execute(object parameter)
        {
            NavigateAsync();
        }
        public async void NavigateAsync()
        {
            await App.MainNavigation.PushAsync(new Pages.ContactAddOrEditPage(), true);
        }
    }
    public class NavigateToReportFilterPageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void Execute(object parameter)
        {
            NavigateAsync();
        }
        public async void NavigateAsync()
        {
            await App.MainNavigation.PushAsync(new ReportFilterPage(), true);
        }
    }
    public class NavigateToReportFilterContactDetailPageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void Execute(object parameter)
        {
            NavigateAsync();
        }
        public async void NavigateAsync()
        {
            await App.MainNavigation.PushAsync(new ReportFilterDetailPage(), true);
        }
    }
    public class NavigateToReportFilterBankAccountDetailPageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void Execute(object parameter)
        {
            NavigateAsync();
        }
        public async void NavigateAsync()
        {
            await App.MainNavigation.PushAsync(new ReportFilterBankAccountDetailPage(), true);
        }
    }
    public class NavigateToReportFilterDateDetailPageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void Execute(object parameter)
        {
            NavigateAsync();
        }
        public async void NavigateAsync()
        {
            await App.MainNavigation.PushAsync(new ReportFilterDateDetailPage(), true);
        }
    }
    public class NavigateToReportPageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void Execute(object parameter)
        {
            NavigateAsync();
        }
        public async void NavigateAsync()
        {
            await App.MainNavigation.PushAsync(new ReportPage(), true);
        }
    }
    public class NavigateToBankAccountDetailCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void Execute(object parameter)
        {
            NavigateAsync();
        }
        public async void NavigateAsync()
        {
            await App.MainNavigation.PushAsync(new Pages.SettingsPages.BankAccountPage(), true);
        }
    }
    public class NavigateToBankAccountAddOrEditPageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void Execute(object parameter)
        {
            NavigateAsync();
        }
        public async void NavigateAsync()
        {
            await App.MainNavigation.PushAsync(new Pages.SettingsPages.BankAccountAddOrEditPage(), true);
        }
    }
    public class NavigateToTransactionFilterDatePageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void Execute(object parameter)
        {
            NavigateAsync();
        }
        public async void NavigateAsync()
        {
            await App.MainNavigation.PushAsync(new Pages.TransactionPages.TransactionFilterDatePage(), true);
        }
    }

    public class AddToContactsCommand : ICommand
    {
        private bool _isBusy = false;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !_isBusy;
        }
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void Execute(object parameter)
        {
            AddToContacts(parameter as ContactObservableModel);
            App.MainNavigation.PopAsync();
        }
        public async void AddToContacts(ContactObservableModel contact)
        {
            this._isBusy = true;
            this.RaiseCanExecuteChanged();
            App.ViewModel.isBusy = true;
            await App.ViewModel.ContactListAsync.AddAsync(contact);
            this._isBusy = false;
            this.RaiseCanExecuteChanged();
            App.ViewModel.isBusy = false;
        }
    }
    public class AddToTransactionsCommand : ICommand
    {
        private bool _isBusy = false;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !_isBusy;
        }
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public async void Execute(object parameter)
        {
            AddToTransactions(parameter as TransactionObservableModel);
            await App.MainNavigation.PopAsync();
        }
        public async void AddToTransactions(TransactionObservableModel transaction)
        {
            this._isBusy = true;
            this.RaiseCanExecuteChanged();
            App.ViewModel.isBusy = true;
            await App.ViewModel.TransactionsListAsync.AddAsync(transaction);
            this._isBusy = false;
            this.RaiseCanExecuteChanged();
            App.ViewModel.isBusy = false;
        }
    }
    public class AddToMyBankAccountCommand : ICommand
    {
        private bool _isBusy = false;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !_isBusy;
        }
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public async void Execute(object parameter)
        {
            AddToMyBankAccount(parameter as MyBankAccountObservableModel);
            await App.MainNavigation.PopAsync();
        }
        public async void AddToMyBankAccount(MyBankAccountObservableModel myBankAccount)
        {
            this._isBusy = true;
            this.RaiseCanExecuteChanged();
            App.ViewModel.isBusy = true;
            await App.ViewModel.MyBankAccountsAsync.AddAsync(myBankAccount);
            this._isBusy = false;
            this.RaiseCanExecuteChanged();
            App.ViewModel.isBusy = false;
        }
    }

    public class DeleteContactCommand : ICommand
    {
        private bool _isBusy = false;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !_isBusy;
        }
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public async void Execute(object parameter)
        {
            DeleteContact((int)parameter);
            await App.MainNavigation.PopAsync();
        }
        public async void DeleteContact(int Id)
        {
            this._isBusy = true;
            this.RaiseCanExecuteChanged();
            App.ViewModel.isBusy = true;
            var transactionList = await App.Database.GetTransactionsForDeleteAsync(Id);
            foreach (var transaction in transactionList)
            {
                await App.Database.DeleteTransactionsAsync(transaction);
            }
            var contact = await App.Database.GetContactAsync(Id);
            await App.Database.DeleteContactAsync(contact);
            this._isBusy = false;
            this.RaiseCanExecuteChanged();
            App.ViewModel.isBusy = false;
        }
    }
    public class DeleteAllCommand : ICommand
    {
        private bool _isBusy = false;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !_isBusy;
        }
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void Execute(object parameter)
        {
            DeleteTransactionsTable();
        }
        public void DeleteTransactionsTable()
        {
            this._isBusy = true;
            this.RaiseCanExecuteChanged();
            App.ViewModel.isBusy = true;
            App.Database.DeleteAllTable();
            this._isBusy = false;
            this.RaiseCanExecuteChanged();
            App.ViewModel.isBusy = false;
        }
    }
    public class DeleteTransactionCommand : ICommand
    {
        private bool _isBusy = false;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !_isBusy;
        }
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public async void Execute(object parameter)
        {
            DeleteContact((int)parameter);
            await App.MainNavigation.PopAsync();
        }
        public async void DeleteContact(int Id)
        {
            this._isBusy = true;
            this.RaiseCanExecuteChanged();
            App.ViewModel.isBusy = true;
            var transactions = await App.Database.GetTransactionAsync(Id);
            await App.Database.DeleteTransactionsAsync(transactions);
            this._isBusy = false;
            this.RaiseCanExecuteChanged();
            App.ViewModel.isBusy = false;
        }
    }
    public class DeleteMyBankAccountsCommand : ICommand
    {
        private bool _isBusy = false;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !_isBusy;
        }
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public async void Execute(object parameter)
        {
            DeleteBankAccount((int)parameter);
            await App.MainNavigation.PopAsync();
        }
        public async void DeleteBankAccount(int Id)
        {
            this._isBusy = true;
            this.RaiseCanExecuteChanged();
            App.ViewModel.isBusy = true;
            var transactionList = await App.Database.GetTransactionsForDeleteAsync(Id);
            foreach (var transaction in transactionList)
            {
                await App.Database.DeleteTransactionsAsync(transaction);
            }
            var mybankaccount = await App.Database.GetMyBankAccountAsync(Id);
            await App.Database.DeleteMyBankAccountAsync(mybankaccount);
            this._isBusy = false;
            this.RaiseCanExecuteChanged();
            App.ViewModel.isBusy = false;
        }
    }

    public class EditMyBankAccountCommand : ICommand
    {
        private bool _isBusy = false;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !_isBusy;
        }
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public async void Execute(object parameter)
        {
            AddToMyBankAccount(parameter as MyBankAccountObservableModel);
            await App.MainNavigation.PopAsync();
        }
        public async void AddToMyBankAccount(MyBankAccountObservableModel myBankAccount)
        {
            this._isBusy = true;
            this.RaiseCanExecuteChanged();
            App.ViewModel.isBusy = true;
            await App.ViewModel.MyBankAccountsAsync.EditAsync(myBankAccount);
            this._isBusy = false;
            this.RaiseCanExecuteChanged();
            App.ViewModel.isBusy = false;
        }
    }
    public class EditContactCommand : ICommand
    {
        private bool _isBusy = false;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !_isBusy;
        }
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public async void Execute(object parameter)
        {
            AddToMyBankAccount(parameter as ContactObservableModel);
            await App.MainNavigation.PopAsync();
        }
        public async void AddToMyBankAccount(ContactObservableModel contact)
        {
            this._isBusy = true;
            this.RaiseCanExecuteChanged();
            App.ViewModel.isBusy = true;
            await App.ViewModel.ContactListAsync.EditAsync(contact);
            this._isBusy = false;
            this.RaiseCanExecuteChanged();
            App.ViewModel.isBusy = false;
        }
    }
    public class EditTransactionCommand : ICommand
    {
        private bool _isBusy = false;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !_isBusy;
        }
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public async void Execute(object parameter)
        {
            AddToMyBankAccount(parameter as TransactionObservableModel);
            await App.MainNavigation.PopAsync();
        }
        public async void AddToMyBankAccount(TransactionObservableModel transaction)
        {
            this._isBusy = true;
            this.RaiseCanExecuteChanged();
            App.ViewModel.isBusy = true;
            await App.ViewModel.TransactionsListAsync.EditAsync(transaction);
            this._isBusy = false;
            this.RaiseCanExecuteChanged();
            App.ViewModel.isBusy = false;
        }
    }
}

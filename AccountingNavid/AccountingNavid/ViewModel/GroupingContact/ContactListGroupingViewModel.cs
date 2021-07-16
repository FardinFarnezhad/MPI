using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccountingNavid.DataLayer.Models;
using AccountingNavid.DataLayer;
using System.Threading.Tasks;
using Paperboy.Common;
using System.Collections.ObjectModel;

namespace AccountingNavid.ViewModel
{
    class ContactListGroupingViewModel : ObservableBase
    {
        public ContactListGroupingViewModel()
        {
            Items = new ObservableCollection<ContactObservableModel>();
            GroupedData = new ObservableCollection<ObservableGroupCollection<string, ContactObservableModel>>();
        }
        public async Task RefreshList()
        {
            this.Items.Clear();
            this.GroupedData.Clear();
            await App.ViewModel.GetContactsItemsAsync();
            var contacts = App.ViewModel.ContactListAsync.OrderBy(n => n.Name).ToList();
            foreach (var contact in contacts)
            {
                this.Items.Add(contact);
            }
            var groupedContacts = Items.OrderBy(p => p.Name)
               .GroupBy(p => p.Name[0].ToString())
               .Select(p => new ObservableGroupCollection<string, ContactObservableModel>(p)).ToList();
            foreach (var contact in groupedContacts)
            {
                this.GroupedData.Add(contact);
            }
        }
        private ObservableCollection<ContactObservableModel> _items;
        public ObservableCollection<ContactObservableModel> Items
        {
            get { return _items; }
            set { this.SetProperty(ref this._items, value); }
        }
        private ObservableCollection<ObservableGroupCollection<string, ContactObservableModel>> _groupedData;
        public ObservableCollection<ObservableGroupCollection<string, ContactObservableModel>> GroupedData
        {
            get { return _groupedData; }
            set { this.SetProperty(ref this._groupedData, value); }
        }
    }
}

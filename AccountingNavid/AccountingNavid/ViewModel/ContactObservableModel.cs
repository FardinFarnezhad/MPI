using AccountingNavid.DataLayer.Models;
using Paperboy.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace AccountingNavid.ViewModel
{
    public class ContactsObservableCollection: ObservableCollection<ContactObservableModel>
    {
        public async Task AddAsync(ContactObservableModel contact)
        {
            var item = new Contact()
            {
                Name = contact.Name,
                Phone1 = contact.Phone1,
                Phone2 = contact.Phone2,
                AccountNumber = contact.AccountNumber,
                PhoneSocial = contact.PhoneSocial
            };
            await App.Database.SaveContactAsync(item);
            this.Add(contact);
        }
        public async Task EditAsync(ContactObservableModel contact)
        {
            var item = new Contact()
            {
                Name = contact.Name,
                Phone1 = contact.Phone1,
                Phone2 = contact.Phone2,
                AccountNumber = contact.AccountNumber,
                PhoneSocial = contact.PhoneSocial,
                ContactId = contact.ContactId
            };
            await App.Database.SaveContactAsync(item);
            this.Add(contact);
        }
        public async Task<int> RemoveAsync(int id)
        {
            var contact = await App.Database.GetContactAsync(id);
            id = await App.Database.DeleteContactAsync(contact);
            return id;
        }
    }
    public class ContactObservableModel : ObservableBase
    {
        private int _contactId;
        public int ContactId
        {
            get { return this._contactId; }
            set { this.SetProperty(ref this._contactId, value); }
        }

        private string _name;
        public string Name
        {
            get { return this._name; }
            set { this.SetProperty(ref this._name, value); }
        }

        private string _accountnumber;
        public string AccountNumber
        {
            get { return this._accountnumber; }
            set { this.SetProperty(ref this._accountnumber, value); }
        }

        private string _phone2;
        public string Phone2
        {
            get { return this._phone2; }
            set { this.SetProperty(ref this._phone2, value); }
        }

        private string _phonesocial;
        public string PhoneSocial
        {
            get { return this._phonesocial; }
            set { this.SetProperty(ref this._phonesocial, value); }
        }

        private string _phone1;
        public string Phone1
        {
            get { return this._phone1; }
            set { this.SetProperty(ref this._phone1, value); }
        }
    }
}

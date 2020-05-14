using DSW03A1.Models;
using DSW03A1.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSW03A1.ViewModel
{
    class ContactsViewModel
    {
        private readonly DataStore _dataStore;
        public ContactsViewModel()
        {
            _dataStore = new DataStore();
        }
        public Contact DisplayContactById(int id)
        {
            DataStore dataStore = new DataStore();
            var contact = dataStore.GetContactById(id);
            if (contact != null)
            {
                return contact;
            }

            return new Contact();
        }

        public List<Contact> DisplaySearchResults(string username)
        {
            var contacts = _dataStore.SearchByName(username);

            if (contacts != null)
            {
                return contacts;
            }
            else
            {
                return contacts = new List<Contact>();
            }

        }

        public List<Contact> DisplayAllContacts()
        {
     
            return _dataStore.GetAllContacts();

        
        }
    }
}

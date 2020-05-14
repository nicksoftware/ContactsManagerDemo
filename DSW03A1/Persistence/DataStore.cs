using DSW03A1.Core;
using DSW03A1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSW03A1.Persistence
{

    /// <summary>
    /// Class is used for application persistance ,the only class communicating with the Database
    /// </summary>
    class DataStore
    {
        private List<Contact> _contacts;

        #region Constructors

        /// <summary>
        /// Generates contacts List
        /// </summary>
        public DataStore()
        {
            
            _contacts = new List<Contact>();
            var rand = new Random();
            ContactGenerator contactGenerator = new ContactGenerator();
            for(var x = 0;x < 20; x++)
            {
                _contacts.Add(contactGenerator.CreateContact(rand.Next(0,7), rand.Next(0, 7)));
            }
 
        }
        #endregion


        #region Methods

        //Retrieve all contacts
        public List<Contact> GetAllContacts()
        {
            return _contacts.ToList();
        }


        //retrieve contact by First name 
        public List<Contact> SearchByName(string firstName)
        {
            List<Contact> contacts = _contacts.Where(c => c.FirstName
            .ToLower()
            .Contains(firstName
            .ToLower())).ToList();

            return contacts;
        }


        public Contact GetContactById(int id)
        {
            Contact contact = _contacts.SingleOrDefault(c => c.Id == id);
            return contact;
        }


        public void UpdateContact(int id, Contact contact)
        {
            ///Add Code to update item

        }


        public bool DeleteContact(int id)
        {
            var oldContactCount = _contacts.Count;

            var item = _contacts.SingleOrDefault(i => i.Id == id);

            if (item != null)
            {
                _contacts.Remove(item);

                var newContactsCount = _contacts.Count;
                return (newContactsCount < oldContactCount);

            }
            else
            {
                return false;
            }
        }



        #endregion


    }
}

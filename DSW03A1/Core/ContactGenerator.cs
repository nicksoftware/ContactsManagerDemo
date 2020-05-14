using DSW03A1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSW03A1.Core
{
    class ContactGenerator
    {
        List<string> _firstNames;
        List<string> _lastNames;
        public ContactGenerator()
        {
            _lastNames = new List<string> { "Clark", "Zwane" , "Hlungwane", "Moyo", "Chauke", "Maluleke", "Maclayin", "Mabunda" };
            _firstNames = new List<string> { "John", "Millicent", "Koketso", "Nkululeko", "Thabang", "Zweli", "Lerato", "Sylvestar" };

        }
        public Contact CreateContact(int firstNameIndex,int lastnameIndex)
        {
            var contact = new Contact
            {
                FirstName = _firstNames[firstNameIndex],
                LastName = _lastNames[lastnameIndex],
                TelephoneNumber = GenerateTelephoneNumber(),

            };

            return contact;

        }

        string GenerateTelephoneNumber()
        {
            var random = new Random();
            string cellphoneNumber = "+27"; 
            for(var x= 0; x < 8; x++)
            {
                cellphoneNumber += random.Next(0, 9);
            }

            return cellphoneNumber;
        }
    }
}

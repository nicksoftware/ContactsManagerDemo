using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSW03A1.Models
{

    class Contact
    {
        public static int Count = 0;
        public Contact()
        {
            Count++;
            Id = Count;
            CreatedDate = DateTime.Now;
        }
        public int Id { get;private set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }

        [MaxLength(10)]
        public string TelephoneNumber { get; set; }

        public string GetInitials()
        {
            string initials = string.Empty;
            if (FirstName != null && LastName != null)
            {
                initials = string.Format("{0}.{1}", FirstName[0], LastName[0]);
            }
            return initials;
        }
    }
}

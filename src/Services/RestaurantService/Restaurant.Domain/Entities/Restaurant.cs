using Restaurant.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Entities
{
    public class Restaurant : EntityBase
    {
        public string Name { get; set; }
        public string EmailContact { get; set; }
        public string PhoneContact { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Branch> Branches { get; set; }

        public Restaurant()
        {
            
        }
        public Restaurant(string name, string emailContact, string phoneContact, string country)
        {
            Name = name;
            EmailContact = emailContact;
            PhoneContact = phoneContact;
            Country = country;
        }
    }
}

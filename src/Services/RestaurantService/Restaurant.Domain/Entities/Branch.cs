using Restaurant.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Entities
{
    public class Branch : EntityBase
    {
        public Guid RestaurantId { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public Branch()
        {

        }

        public Branch(Guid restaurantId, string city, string district, string address, string email, string phone)
        {
            RestaurantId = restaurantId;
            City = city;
            District = district;
            Address = address;
            Email = email;
            Phone = phone;
        }
    }
}

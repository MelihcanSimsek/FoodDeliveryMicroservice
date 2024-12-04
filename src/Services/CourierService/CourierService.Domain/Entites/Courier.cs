using CourierService.Domain.Common;
using CourierService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Domain.Entites
{
    public class Courier : EntityBase
    {
        public Guid UserId { get; set; }
        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string BusinessEmail { get; set; }
        public string PlateNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public bool IsWorking { get; set; }
        public CourierStatus Status { get; set; }

        public Courier()
        {
            
        }

        public Courier(Guid userId, string identityNumber, string phoneNumber, string businessEmail, string plateNumber, DateTime birthDate, string country, string city, string district, bool isWorking, CourierStatus status)
        {
            UserId = userId;
            IdentityNumber = identityNumber;
            PhoneNumber = phoneNumber;
            BusinessEmail = businessEmail;
            PlateNumber = plateNumber;
            BirthDate = birthDate;
            Country = country;
            City = city;
            District = district;
            IsWorking = isWorking;
            Status = status;
        }
    }
}

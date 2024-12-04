using CourierService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Application.Features.Couriers.Queries.GetAllCourier
{
    public class GetAllCourierQueryResponse
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
        public string Status { get; set; }
    }
}

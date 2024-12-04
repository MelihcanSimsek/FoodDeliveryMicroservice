using CourierService.Application.Interfaces.Authorization;
using CourierService.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Application.Features.Couriers.Commands.CreateCourier
{
    public class CreateCourierCommandRequest : IRequest<Unit>,ISecuredRequest
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
        public string[] Roles => ["admin"];
    }
}

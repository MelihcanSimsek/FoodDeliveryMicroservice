using Restaurant.Application.Features.Branches.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Branches.Queries.GetAllBranch
{
    public class GetAllBranchQueryResponse
    {
        public Guid Id { get; set; }
        public Guid RestaurantId { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public RestaurantDto Restaurant { get; set; }
    }
}

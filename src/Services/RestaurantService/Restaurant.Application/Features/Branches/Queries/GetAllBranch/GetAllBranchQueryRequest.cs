using MediatR;
using Restaurant.Application.Interfaces.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Branches.Queries.GetAllBranch
{
    public class GetAllBranchQueryRequest:IRequest<IList<GetAllBranchQueryResponse>>,ISecuredRequest
    {
        public Guid RestaurantId { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public string[] Roles => ["user"];
    }
}

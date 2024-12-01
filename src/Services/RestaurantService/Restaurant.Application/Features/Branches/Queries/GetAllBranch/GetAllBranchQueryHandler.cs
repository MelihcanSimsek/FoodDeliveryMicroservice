using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Bases;
using Restaurant.Application.Features.Branches.DTOs;
using Restaurant.Application.Interfaces.Mapper;
using Restaurant.Application.Interfaces.UnitOfWorks;
using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Branches.Queries.GetAllBranch
{
    public class GetAllBranchQueryHandler : BaseHandler, IRequestHandler<GetAllBranchQueryRequest, IList<GetAllBranchQueryResponse>>
    {
        public GetAllBranchQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }

        public async Task<IList<GetAllBranchQueryResponse>> Handle(GetAllBranchQueryRequest request, CancellationToken cancellationToken)
        {
            var branchList = await unitOfWork.GetReadRepository<Branch>()
                .GetAllByPagingAsync(predicate: p => p.RestaurantId == request.RestaurantId && !p.IsDeleted,
                include: c => c.Include(p => p.Restaurant),
                pageSize: request.Size, currentPage: request.Page);

            mapper.Map<RestaurantDto, Restaurant.Domain.Entities.Restaurant>(new Restaurant.Domain.Entities.Restaurant());
            IList<GetAllBranchQueryResponse> response = mapper.Map<GetAllBranchQueryResponse, Branch>(branchList);

            return response;
        }
    }
}

using MediatR;
using Menu.Application.Bases;
using Menu.Application.Interfaces.CustomMapper;
using Menu.Application.Interfaces.Repositories;
using Menu.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Application.Features.Liquids.Queries.GetAllLiquid
{
    public class GetAllLiquidQueryHandler : BaseHandler,IRequestHandler<GetAllLiquidQueryRequest, IList<GetAllLiquidQueryResponse>>
    {
        private readonly ILiquidRepository liquidRepository;
        public GetAllLiquidQueryHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper, ILiquidRepository liquidRepository) : base(httpContextAccessor, mapper)
        {
            this.liquidRepository = liquidRepository;
        }

        public async Task<IList<GetAllLiquidQueryResponse>> Handle(GetAllLiquidQueryRequest request, CancellationToken cancellationToken)
        {
            IList<Liquid> liquidList = await liquidRepository.GetAllByPagingAsync(predicate:p=>p.RestaurantId == request.RestaurantId && p.BranchId == request.BranchId,
                currentPage:request.Page,pageSize:request.Size);

            var response = mapper.Map<GetAllLiquidQueryResponse, Liquid>(liquidList);

            return response;
        }
    }
}

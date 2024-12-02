using MediatR;
using Microsoft.AspNetCore.Http;
using Restaurant.Application.Bases;
using Restaurant.Application.Extensions;
using Restaurant.Application.Features.Branches.Rules;
using Restaurant.Application.Interfaces.Mapper;
using Restaurant.Application.Interfaces.UnitOfWorks;
using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Branches.Commands.BranchCreate
{
    public class BranchCreateCommandHandler : BaseHandler, IRequestHandler<BranchCreateCommandRequest, Unit>
    {
        private readonly BranchRules branchRules;
        public BranchCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, BranchRules branchRules) : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.branchRules = branchRules;
        }

        public async Task<Unit> Handle(BranchCreateCommandRequest request, CancellationToken cancellationToken)
        {
            Guid userId = httpContextAccessor.HttpContext.User.GetUserId();
            var checkRestaurant = await unitOfWork.GetReadRepository<Restaurant.Domain.Entities.Restaurant>()
                .GetAsync(p => p.UserId == userId && !p.IsDeleted);
            await branchRules.ShouldRestaurantExists(checkRestaurant);

            Branch? checkbranch = await unitOfWork.GetReadRepository<Branch>()
                .GetAsync(p => p.Address == request.Address && p.City == request.City && p.District == request.District && p.RestaurantId == request.RestaurantId);

            await branchRules.ShouldBranchCanNotBeDuplicated(checkbranch);

            Branch branch = mapper.Map<Branch, BranchCreateCommandRequest>(request);

            await unitOfWork.GetWriteRepository<Branch>().AddAsync(branch);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}

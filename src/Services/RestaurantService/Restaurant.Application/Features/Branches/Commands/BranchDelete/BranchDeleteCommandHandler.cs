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

namespace Restaurant.Application.Features.Branches.Commands.BranchDelete
{
    public class BranchDeleteCommandHandler : BaseHandler, IRequestHandler<BranchDeleteCommandRequest, Unit>
    {
        private readonly BranchRules branchRules;

        public BranchDeleteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, BranchRules branchRules) : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.branchRules = branchRules;
        }

        public async Task<Unit> Handle(BranchDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            Guid restaurantId = httpContextAccessor.HttpContext.User.GetUserId();
            Branch? branch = await unitOfWork.GetReadRepository<Branch>().GetAsync(p => p.Id == request.Id && p.RestaurantId == restaurantId);

            await branchRules.ShouldBranchExists(branch);

            branch.IsDeleted = true;
            await unitOfWork.GetWriteRepository<Branch>().UpdateAsync(branch);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}

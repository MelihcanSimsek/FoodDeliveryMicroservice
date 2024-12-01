using MediatR;
using Menu.Application.Bases;
using Menu.Application.Features.Liquids.Rules;
using Menu.Application.Interfaces.CustomMapper;
using Menu.Application.Interfaces.Repositories;
using Menu.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Menu.Application.Features.Liquids.Commands.DeleteLiquid
{
    public class DeleteLiquidCommandHandler : BaseHandler,IRequestHandler<DeleteLiquidCommandRequest, Unit>
    {
        private readonly ILiquidRepository liquidRepository;
        private readonly LiquidRules liquidRules;
        public DeleteLiquidCommandHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper, ILiquidRepository liquidRepository, LiquidRules liquidRules) : base(httpContextAccessor, mapper)
        {
            this.liquidRepository = liquidRepository;
            this.liquidRules = liquidRules;
        }

        public async Task<Unit> Handle(DeleteLiquidCommandRequest request, CancellationToken cancellationToken)
        {
            Liquid? liquid = await liquidRepository.GetAsync(p => p.Id == request.Id && !p.IsDeleted);
            await liquidRules.ShouldLiquidExists(liquid);

            liquid.IsDeleted = true;
            await liquidRepository.UpdateAsync(liquid);

            return Unit.Value;
        }
    }
}

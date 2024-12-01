using MediatR;
using Menu.Application.Bases;
using Menu.Application.Features.Liquids.Rules;
using Menu.Application.Interfaces.CustomMapper;
using Menu.Application.Interfaces.Repositories;
using Menu.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Application.Features.Liquids.Commands.UpdateLiquid
{
    public class UpdateLiquidCommandHandler : BaseHandler, IRequestHandler<UpdateLiquidCommandRequest, Unit>
    {
        private readonly ILiquidRepository liquidRepository;
        private readonly LiquidRules liquidRules;
        public UpdateLiquidCommandHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper, LiquidRules liquidRules, ILiquidRepository liquidRepository) : base(httpContextAccessor, mapper)
        {
            this.liquidRules = liquidRules;
            this.liquidRepository = liquidRepository;
        }

        public async Task<Unit> Handle(UpdateLiquidCommandRequest request, CancellationToken cancellationToken)
        {
            Liquid? liquid = await liquidRepository.GetAsync(p => p.Id == request.Id && !p.IsDeleted);
            await liquidRules.ShouldLiquidExists(liquid);

            liquid = mapper.Map<Liquid, UpdateLiquidCommandRequest>(request);
            await liquidRepository.UpdateAsync(liquid);

            return Unit.Value;
        }
    }
}

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

namespace Menu.Application.Features.Liquids.Commands.CreateLiquid
{
    public class CreateLiquidCommandHandler : BaseHandler, IRequestHandler<CreateLiquidCommandRequest, Unit>
    {
        private readonly ILiquidRepository liquidRepository;
        public CreateLiquidCommandHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper, ILiquidRepository liquidRepository) : base(httpContextAccessor, mapper)
        {
            this.liquidRepository = liquidRepository;
        }

        public async Task<Unit> Handle(CreateLiquidCommandRequest request, CancellationToken cancellationToken)
        {
            Liquid liquid = mapper.Map<Liquid, CreateLiquidCommandRequest>(request);
            await liquidRepository.AddAsync(liquid);
            return Unit.Value;
        }
    }
}

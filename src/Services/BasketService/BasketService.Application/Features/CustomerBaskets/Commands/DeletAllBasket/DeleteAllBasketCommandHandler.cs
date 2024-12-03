using BasketService.Application.Extensions;
using BasketService.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Application.Features.CustomerBaskets.Commands.DeletAllBasket
{
    public class DeleteAllBasketCommandHandler : IRequestHandler<DeleteAllBasketCommandRequest, Unit>
    {
        private readonly ICustomerBasketRepository customerBasketRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public DeleteAllBasketCommandHandler(ICustomerBasketRepository customerBasketRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.customerBasketRepository = customerBasketRepository;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<Unit> Handle(DeleteAllBasketCommandRequest request, CancellationToken cancellationToken)
        {
            string userId = httpContextAccessor.HttpContext.User.GetUserId().ToString();
            await customerBasketRepository.DeleteBasketAsync(userId);

            return Unit.Value;
        }
    }
}

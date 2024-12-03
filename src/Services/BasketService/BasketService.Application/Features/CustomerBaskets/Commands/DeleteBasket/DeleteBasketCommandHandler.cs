using BasketService.Application.Extensions;
using BasketService.Application.Interfaces.Repositories;
using BasketService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Application.Features.CustomerBaskets.Commands.DeleteBasket
{
    public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommandRequest, Unit>
    {
        private readonly ICustomerBasketRepository customerBasketRepository;
        private readonly IHttpContextAccessor httpContextAccesor;

        public DeleteBasketCommandHandler(ICustomerBasketRepository customerBasketRepository)
        {
            this.customerBasketRepository = customerBasketRepository;
        }

        public async Task<Unit> Handle(DeleteBasketCommandRequest request, CancellationToken cancellationToken)
        {
            string userId = httpContextAccesor.HttpContext.User.GetUserId().ToString();
            CustomerBasket customerBasket = await customerBasketRepository.GetBasketAsync(userId);

            BasketItem basketItem =  customerBasket.BasketItems.FirstOrDefault(p => p.Id == request.Id);
            customerBasket.BasketItems.Remove(basketItem);

            await customerBasketRepository.UpdateBasketAsync(userId, customerBasket);

            return Unit.Value;
        }
    }
}

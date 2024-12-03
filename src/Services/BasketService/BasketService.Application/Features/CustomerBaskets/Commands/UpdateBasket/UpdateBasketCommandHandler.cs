using BasketService.Application.Extensions;
using BasketService.Application.Interfaces.Repositories;
using BasketService.Domain.Entities;
using BasketService.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Application.Features.CustomerBaskets.Commands.UpdateBasket
{
    public class UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommandRequest, Unit>
    {
        private readonly ICustomerBasketRepository customerBasketRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        public UpdateBasketCommandHandler(ICustomerBasketRepository customerBasketRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.customerBasketRepository = customerBasketRepository;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<Unit> Handle(UpdateBasketCommandRequest request, CancellationToken cancellationToken)
        {
            BasketItem basketItem = new BasketItem()
            {
                MenuName = request.MenuName,
                BranchId = request.BranchId,
                PictureUrl = request.PictureUrl,
                UnitPrice = request.UnitPrice,
                Quantity = request.Quantity,
                RestaurantId = request.RestaurantId,
                Type = (MenuType)request.Type
            };
            string userId = httpContextAccessor.HttpContext.User.GetUserId().ToString();
            CustomerBasket customerBasket = await customerBasketRepository.GetBasketAsync(userId);

            customerBasket.UserId = Guid.NewGuid();
            customerBasket.BasketItems.Add(basketItem);
            await customerBasketRepository.UpdateBasketAsync(userId.ToString(), customerBasket);

            return Unit.Value;
        }
    }
}

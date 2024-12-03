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

namespace BasketService.Application.Features.CustomerBaskets.Queries.GetAllUserBasket
{
    public class GetAllUserBasketQueryHandler : IRequestHandler<GetAllUserBasketQueryRequest, IList<BasketItem>>
    {
        private readonly ICustomerBasketRepository customerBasketRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public GetAllUserBasketQueryHandler(ICustomerBasketRepository customerBasketRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.customerBasketRepository = customerBasketRepository;
            this.httpContextAccessor = httpContextAccessor;
        }

        public  async Task<IList<BasketItem>> Handle(GetAllUserBasketQueryRequest request, CancellationToken cancellationToken)
        {
            string userId = httpContextAccessor.HttpContext.User.GetUserId().ToString();
            CustomerBasket customerBasket = await customerBasketRepository.GetBasketAsync(userId.ToString());

            return customerBasket.BasketItems;
        }
    }
}

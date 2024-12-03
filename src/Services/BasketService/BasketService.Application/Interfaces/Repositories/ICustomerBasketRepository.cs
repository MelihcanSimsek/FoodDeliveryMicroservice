using BasketService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Application.Interfaces.Repositories
{
    public interface ICustomerBasketRepository 
    {
        Task<CustomerBasket> GetBasketAsync(string customerId);

        Task<CustomerBasket> UpdateBasketAsync(string userId,CustomerBasket basket);

        Task<bool> DeleteBasketAsync(string id);
    }
}

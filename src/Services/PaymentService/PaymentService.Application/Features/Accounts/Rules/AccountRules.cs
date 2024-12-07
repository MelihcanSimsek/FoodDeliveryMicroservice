using PaymentService.Application.Bases;
using PaymentService.Application.Features.Accounts.Exceptions;
using PaymentService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Accounts.Rules
{
    public class AccountRules : BaseRules
    {
        public async Task ShouldAccountNotExists(Account? account)
        {
            if (account is not null) throw new AccountAlreadyExistsException();
        }
        public async Task ShouldAccountExists(Account? account)
        {
            if (account is null) throw new AccountNotFoundException();
        }

        public async Task ShouldAccountBalanceEnoughForOrderPrice(Account account, decimal totalPrice)
        {
            if (account.Balance < totalPrice) throw new AccountBalanceNotEnoughException();
        }

        public async Task ShouldPaymentMethodValid(PaymentCard? paymentCard)
        {
            if (paymentCard is null) throw new PaymentMethodIsNotValidException();
        }

        public async Task ShouldCardValid(bool validity)
        {
            if(!validity) throw new PaymentMethodIsNotValidException();
        }

        public async Task ShouldPaymentSuccess(bool success)
        {
            if (!success) throw new PaymentSuccessException();
        }
    }
        

}

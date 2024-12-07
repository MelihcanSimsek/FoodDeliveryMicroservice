using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Accounts.Constants
{
    public static class Messages
    {
        public static string AccountDoesNotExists = "Account does not exists";
        public static string AccountBalanceNotEnoughForOrderPrice = "Account balance not enough for order price";
        public static string AccountAlreadyExists = "Account already exists";
        public static string PaymentMethodIsNotValid = "Payment method is not valid";
        public static string CanNotTakeAnyPayment = "Can not take any payment";
        public static string PaymentProccessUnSuccesfull = "An error occured in payment proccess";
    }
}

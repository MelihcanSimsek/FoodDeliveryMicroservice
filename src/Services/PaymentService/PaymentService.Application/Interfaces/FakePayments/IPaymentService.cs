using PaymentService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Interfaces.FakePayments
{
    public interface IPaymentService
    {
        Task<bool> TakePayment(PaymentCard payment,decimal amount);
        Task<bool> RefundPayment(PaymentCard payment,decimal amount);
        Task<bool> CheckCardValid(PaymentCard payment);
    }
}

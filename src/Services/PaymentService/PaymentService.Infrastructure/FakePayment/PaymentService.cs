using Microsoft.Extensions.Logging;
using PaymentService.Application.Interfaces.FakePayments;
using PaymentService.Domain.Entities;
using PaymentService.Domain.Enums;

namespace PaymentService.Infrastructure.FakePayment
{
    public class PaymentService : IPaymentService
    {
        private readonly ILogger<PaymentService> logger;

        public PaymentService(ILogger<PaymentService> logger)
        {
            this.logger = logger;
        }

        public async Task<bool> CheckCardValid(PaymentCard payment)
        {
            await Task.Delay(100);
            return true;
        }

        public async Task<bool> RefundPayment(PaymentCard payment, decimal amount)
        {
            await Task.Delay(100); 

            switch (payment.Type)
            {
                case PaymentType.MASTERCARD:
                case PaymentType.VISA:
                case PaymentType.AMERICAN_EXPRESS:
                case PaymentType.DISCOVER:
                    logger.LogInformation(
                        "Refund processed for {PaymentType}, UserId: {UserId}, CardName: {CardName}, Amount: {Amount} refunded.",
                        payment.Type, payment.UserId, payment.Name, amount);
                    return true;

                default:
                    logger.LogWarning(
                        "Refund failed: Unsupported PaymentType. UserId: {UserId}, CardName: {CardName}, Amount: {Amount}",
                        payment.UserId, payment.Name, amount);
                    return false;
            }
        }

        public async Task<bool> TakePayment(PaymentCard payment, decimal amount)
        {
            await Task.Delay(100);

            switch (payment.Type)
            {
                case PaymentType.MASTERCARD:
                case PaymentType.VISA:
                case PaymentType.AMERICAN_EXPRESS:
                case PaymentType.DISCOVER:
                    logger.LogInformation(
                        "Payment taken for {PaymentType}, UserId: {UserId}, CardName: {CardName}, CardNumber: ****{LastFourDigits}, Amount: {Amount}",
                        payment.Type, payment.UserId, payment.Name, payment.Number[^4..], amount);
                    return true;

                default:
                    logger.LogWarning(
                        "Payment failed: Unsupported PaymentType. UserId: {UserId}, CardName: {CardName}, Amount: {Amount}",
                        payment.UserId, payment.Name, amount);
                    return false;
            }
        }
    }
}

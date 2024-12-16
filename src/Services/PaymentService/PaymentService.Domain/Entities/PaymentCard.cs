using PaymentService.Domain.Common;
using PaymentService.Domain.Enums;
using PaymentService.Domain.Helpers;

namespace PaymentService.Domain.Entities
{
    public class PaymentCard : EntityBase
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string CCV { get; set; }
        public DateTime ExpiryDate { get; set; }
        public PaymentType Type { get; set; }

        public PaymentCard() { }

        public PaymentCard(Guid userId, string name, DateTime expiryDate, PaymentType type, string number, string ccv)
        {
            UserId = userId;
            Name = name;
            ExpiryDate = expiryDate;
            Type = type;
            Number = number;
            CCV = ccv;
        }

    }

}

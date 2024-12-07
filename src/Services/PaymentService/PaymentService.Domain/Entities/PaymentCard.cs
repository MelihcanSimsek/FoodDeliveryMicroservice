using PaymentService.Domain.Common;
using PaymentService.Domain.Enums;
using PaymentService.Domain.Helpers;

namespace PaymentService.Domain.Entities
{
    public class PaymentCard : EntityBase
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        private string EncryptedNumber { get; set; }
        private string EncryptedCCV { get; set; }
        public DateTime ExpiryDate { get; set; }
        public PaymentType Type { get; set; }

        public string Number
        {
            get => EncryptionHelper.Decrypt(EncryptedNumber);
            set => EncryptedNumber = EncryptionHelper.Encrypt(value); 
        }

        public string CCV
        {
            get => EncryptionHelper.Decrypt(EncryptedCCV);
            set => EncryptedCCV = EncryptionHelper.Encrypt(value);
        }

        public PaymentCard()
        {
            
        }

        public PaymentCard(Guid userId, string name, DateTime expiryDate, PaymentType type, string number, string cCV)
        {
            UserId = userId;
            Name = name;
            ExpiryDate = expiryDate;
            Type = type;
            Number = number;
            CCV = cCV;
        }
    }
}

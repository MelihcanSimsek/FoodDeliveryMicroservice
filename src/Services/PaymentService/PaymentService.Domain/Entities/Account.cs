using PaymentService.Domain.Common;


namespace PaymentService.Domain.Entities
{
    public class Account : EntityBase
    {
        public Guid UserId { get; set; }
        public decimal Balance { get; set; } = Decimal.Zero;
        public DateTime? LastUpdateDate { get; set; }

        public Account()
        {
            
        }
        public Account(Guid userId, decimal balance, DateTime? lastUpdateDate)
        {
            UserId = userId;
            Balance = balance;
            LastUpdateDate = lastUpdateDate;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Persistence.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<PaymentCard>
    {
        public void Configure(EntityTypeBuilder<PaymentCard> builder)
        {
        }
    }
}

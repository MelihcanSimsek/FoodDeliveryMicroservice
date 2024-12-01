using Menu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Persistence.Configurations
{
    public class LiquidConfiguration : IEntityTypeConfiguration<Liquid>
    {
        public void Configure(EntityTypeBuilder<Liquid> builder)
        {
            builder.ToCollection("Liquids");
        }
    }
}

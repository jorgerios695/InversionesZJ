using InversionesZJ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InversionesZJ.Infrastructure.Data.Configurations.TableConfiguration
{
    public class PaymentConfig : IEntityTypeConfiguration<Payment>
    {
       

        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments", schema: "OPE");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Amount).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.PaymentType).HasConversion<int>().IsRequired();
            builder.Property(x => x.PaymentDate).IsRequired();
            builder.Property(x => x.Notes).HasMaxLength(500);

            builder.HasOne(x => x.Loan)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.LoanId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

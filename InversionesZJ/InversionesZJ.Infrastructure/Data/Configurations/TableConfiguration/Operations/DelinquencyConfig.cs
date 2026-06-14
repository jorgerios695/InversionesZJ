using InversionesZJ.Domain.Entities.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InversionesZJ.Infrastructure.Data.Configurations.TableConfiguration.Operations
{
    public class DelinquencyConfig : IEntityTypeConfiguration<Delinquency>
    {
        public void Configure(EntityTypeBuilder<Delinquency> builder)
        {
            builder.ToTable("Delinquencies", schema: "OPE");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DaysOverdue).IsRequired();
            builder.Property(x => x.PenaltyAmount).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.CalculatedAt).IsRequired();
            builder.Property(x => x.IsResolved).HasDefaultValue(false);

            builder.HasOne(x => x.Loan)
                .WithMany(x => x.Delinquencies)
                .HasForeignKey(x => x.LoanId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

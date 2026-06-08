using InversionesZJ.Domain.Entities;
using InversionesZJ.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InversionesZJ.Infrastructure.Data.Configurations.TableConfiguration
{
    public class LoanConfig : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.ToTable("Loans", schema: "OPE");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Capital).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.DailyRate).HasColumnType("decimal(10,4)").IsRequired();
            builder.Property(x => x.StartDatee).IsRequired();
            builder.Property(x => x.StartDatee).IsRequired();
            builder.Property(x => x.Status).HasConversion<int>().HasSentinel(LoanStatus.Active);
            builder.Property(x => x.Observations).HasMaxLength(500);

            builder.HasOne(x => x.Client)
                .WithMany(x => x.Loans)
                .HasForeignKey(x => x.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Responsible)
                .WithMany(x => x.loans)
                .HasForeignKey(x => x.ResponsibleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.LoanType)
                .WithMany(x => x.loans)
                .HasForeignKey(x => x.loanTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

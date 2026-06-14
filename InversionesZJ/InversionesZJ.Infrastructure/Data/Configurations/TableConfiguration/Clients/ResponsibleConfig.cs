using Azure;
using InversionesZJ.Domain.Entities.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InversionesZJ.Infrastructure.Data.Configurations.TableConfiguration.Clients
{
    public class ResponsibleConfig : IEntityTypeConfiguration<Responsible>
    {
        public void Configure(EntityTypeBuilder<Responsible> builder)
        {
            builder.ToTable("Responsibles", schema: "CLI");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FullName).IsRequired().HasMaxLength(150);
            builder.Property(x => x.PhoneNumber).HasMaxLength(20);
            builder.Property(x => x.Email).HasMaxLength(100);
        }
    }
}

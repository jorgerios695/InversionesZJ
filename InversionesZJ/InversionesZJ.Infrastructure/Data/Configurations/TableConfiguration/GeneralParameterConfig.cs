using InversionesZJ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InversionesZJ.Infrastructure.Data.Configurations.TableConfiguration
{
    public class GeneralParameterConfig : IEntityTypeConfiguration<GeneralParameter>
    {
        public void Configure(EntityTypeBuilder<GeneralParameter> builder)
        {
            builder.ToTable("GeneralParameters", schema: "PAR");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Key).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Value).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Description).HasMaxLength(250);

            builder.HasIndex(x => x.Key).IsUnique();
        }
    }
}

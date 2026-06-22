using InversionesZJ.Domain.Entities.Parameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InversionesZJ.Infrastructure.Data.Configurations.TableConfiguration.Parameters;

public class GeneralParameterConfig : IEntityTypeConfiguration<GeneralParameter>
{
    public void Configure(EntityTypeBuilder<GeneralParameter> builder)
    {
        builder.ToTable("GeneralParameters", schema: "PAR");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
        builder.Property(x => x.Description).HasMaxLength(250);

        builder.HasIndex(x => x.Code).IsUnique();
    }
}
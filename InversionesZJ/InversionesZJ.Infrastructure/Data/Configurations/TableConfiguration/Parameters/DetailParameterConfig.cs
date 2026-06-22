using InversionesZJ.Domain.Entities.Parameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InversionesZJ.Infrastructure.Data.Configurations.TableConfiguration.Parameters;

public class DetailParameterConfig : IEntityTypeConfiguration<DetailParameter>
{
    public void Configure(EntityTypeBuilder<DetailParameter> builder)
    {
        builder.ToTable("DetailParameters", schema: "PAR");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Value).IsRequired().HasMaxLength(250);
        builder.Property(x => x.Order).HasDefaultValue(0);

        builder.HasOne(x => x.GeneralParameter)
            .WithMany(x => x.Details)
            .HasForeignKey(x => x.GeneralParameterId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
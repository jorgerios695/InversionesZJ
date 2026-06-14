using InversionesZJ.Domain.Entities.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InversionesZJ.Infrastructure.Data.Configurations.TableConfiguration.Security
{
    public class PasswordResetTokenConfig : IEntityTypeConfiguration<PasswordResetToken>
    {
        public void Configure(EntityTypeBuilder<PasswordResetToken> builder)
        {
            builder.ToTable("PasswordResetTokens", schema: "SEC");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Token).IsRequired().HasMaxLength(200);
            builder.Property(x => x.ExpiresAt).IsRequired();
            builder.Property(x => x.IsUsed).HasDefaultValue(false);

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.Token);
        }
    }
}

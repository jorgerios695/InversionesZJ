using InversionesZJ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InversionesZJ.Infrastructure.Data.Configurations.TableConfiguration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users", schema: "SEC");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.FullName).IsRequired().HasMaxLength(150);
            builder.Property(t => t.Email).IsRequired().HasMaxLength(100);
            builder.Property(t => t.PasswordHash).IsRequired();
            builder.Property(t => t.FailedAttempts).HasDefaultValue(0);

            builder.HasIndex(x => x.Email).IsUnique();

            builder.HasData(Build());
        }
        /// Construye los datos iniciales de usuarios del sistema.
        /// 
        private List<User> Build()
        {
            return new List<User>()
            {
                new User()
                {
                    Id = 1,
                    FullName = "Administrator",
                    Email = "jorge.rios@excellentiam.co",
                    PasswordHash = "pending",
                    FailedAttempts = 0,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedBy = "System"

                }
            };
        }

    }

}

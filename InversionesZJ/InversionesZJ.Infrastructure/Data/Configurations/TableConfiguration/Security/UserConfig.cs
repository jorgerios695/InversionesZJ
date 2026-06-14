using InversionesZJ.Domain.Entities.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InversionesZJ.Infrastructure.Data.Configurations.TableConfiguration.Security
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", schema: "SEC");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.FullName).IsRequired().HasMaxLength(150);
            builder.Property(t => t.Email).HasMaxLength(100);
            builder.HasIndex(x => x.Username).IsUnique();
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
                    Username = "admin",
                    Email = "admin@inversioneszj.com",
                    PasswordHash = "$2a$11$ZMbZrOo3wFK5Ym8p3V3HJOxQ9Kz8mN2vL5r7Y4tX1wP6sU0cE9Dei",
                    FailedAttempts = 0,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedBy = "System"
                }
            };
        }

    }

}

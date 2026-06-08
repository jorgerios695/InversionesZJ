using InversionesZJ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InversionesZJ.Infrastructure.Data.Configurations.TableConfiguration
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles", schema: "SEC");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.NameRole).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(200);

            builder.HasData(Build());
        }

        private List<Role> Build()
        {
            return new List<Role>()
            {
                    new Role()
                    {
                        Id = 1,
                        NameRole = "Administrator",
                        Description = "Full system access",
                        IsActive = true,
                        CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                        CreatedBy = "System"
                    },
                    new Role()
                    {
                        Id = 2,
                        NameRole = "Responsible",
                        Description = "Loan manager",
                        IsActive = true,
                        CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                        CreatedBy = "System"
                    },
                    new Role()
                    {
                        Id = 3,
                        NameRole = "Consultant",
                        Description = "Read only",
                        IsActive = true,
                        CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                        CreatedBy = "System"
                    }
                 
            };
        }
    }
}
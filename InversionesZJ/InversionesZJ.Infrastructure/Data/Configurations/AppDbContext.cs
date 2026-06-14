using InversionesZJ.Domain.Entities.Clients;
using InversionesZJ.Domain.Entities.Operations;
using InversionesZJ.Domain.Entities.Parameters;
using InversionesZJ.Domain.Entities.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InversionesZJ.Infrastructure.Data.Configurations;

public  class AppDbContext : DbContext
{
    public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    // Shemas SEC
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<PasswordResetToken> PasswordResetTokens => Set<PasswordResetToken>();

    // Shema CLI
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Responsible> Responsibles => Set<Responsible>();

    // shema OPE
    public DbSet<Loan> Loans => Set<Loan>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<Delinquency> Delinquencies => Set<Delinquency>();

    // shema PAR
    public DbSet<LoanType> LoanTypes => Set<LoanType>();
    public DbSet<GeneralParameter> GeneralParameters => Set<GeneralParameter>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}

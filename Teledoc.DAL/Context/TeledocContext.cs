using Microsoft.EntityFrameworkCore;
using Teledoc.DAL.Models;

namespace Teledoc.DAL.Context;

public sealed class TeledocContext : DbContext
{
    public TeledocContext(DbContextOptions<TeledocContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClientType>().HasData(new List<ClientType>
        {
            new() { Id = 1, Name = "ИП" },
            new() { Id = 2, Name = "ЮЛ" }
        });
        
        //Далеко не лучшая идея, тут небольшая зависимость от субд...
        modelBuilder.Entity<Client>()
            .Property(c => c.AddAt)
            .HasDefaultValueSql("NOW()");
        
        modelBuilder.Entity<Client>()
            .Property(c => c.UpdateAt)
            .HasDefaultValueSql("NOW()");

        modelBuilder.Entity<Founder>()
            .Property(f => f.AddAt)
            .HasDefaultValueSql("NOW()");
        
        modelBuilder.Entity<Founder>()
            .Property(f => f.UpdateAt)
            .HasDefaultValueSql("NOW()");
    }

    #region TableDefinition

    public DbSet<Client> Clients { get; set; }
    public DbSet<ClientType> ClientTypes { get; set; }
    public DbSet<Founder> Founders { get; set; }

    #endregion
}
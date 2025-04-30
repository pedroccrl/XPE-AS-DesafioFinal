using ASDesafioFinal.Domain.Products.Entities;
using ASDesafioFinal.Infra.Data.EF.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ASDesafioFinal.Infra.Data.EF;

public class DesafioFinalDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
    }

    public DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
    {
        return Set<TEntity>();
    }
}

using ASDesafioFinal.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace ASDesafioFinal.Infra.Data.EF.Repositories;

public class EFRepository<TEntity>(DesafioFinalDbContext dbContext) : IRepository<TEntity> where TEntity : Entity
{
    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        dbContext.GetDbSet<TEntity>().Add(entity);

        await dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var rowsDeleted = await dbContext
            .GetDbSet<TEntity>()
            .Where(x => x.Id == id)
            .ExecuteDeleteAsync();

        return rowsDeleted > 0;
    }

    public Task<TEntity> GetAsync(Guid id)
    {
        var entity = dbContext
            .GetDbSet<TEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        return (entity ?? throw new KeyNotFoundException($"Entity with id {id} not found."))!;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        dbContext.GetDbSet<TEntity>().Update(entity);

        await dbContext.SaveChangesAsync();

        return entity;
    }
}

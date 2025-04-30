namespace ASDesafioFinal.Domain.Common;

public interface IRepository<TEntity> where TEntity : Entity
{
    Task<TEntity> CreateAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(Guid id);
    Task<TEntity> GetAsync(Guid id);
}

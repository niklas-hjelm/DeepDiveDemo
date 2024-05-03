namespace CommonInterfaces.DataAccess;

public interface IRepository<TEntity, in TId> where TEntity : IEntity<TId>
{
	Task<TEntity?> GetByIdAsync(TId id);
	Task<IEnumerable<TEntity>?> GetMultipleAsync(int start, int count);
	Task<TEntity?> AddAsync(TEntity entity);
	Task<TEntity?> UpdateAsync(TEntity entity);
	Task DeleteAsync(TId id);
}
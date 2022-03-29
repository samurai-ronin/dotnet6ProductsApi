namespace ProductsApi.Interfaces.Repositories;
public interface IRepository<TEntity> where TEntity :class
{
    Task<bool> Delete(TEntity entity);
    Task<TEntity> Insert(TEntity entity);
    Task<bool> Update(TEntity entity);
    IQueryable<TEntity> GetAll();
    Task<TEntity?> GetById(object id);
}

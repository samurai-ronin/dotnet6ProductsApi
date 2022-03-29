using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using ProductsApi.Interfaces.Repositories;

namespace ProductsApi.Repositories;
public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
{
    private readonly ProductContext _context;
    public Repository(ProductContext context)
    {
        _context = context;
    }
    public async Task<bool> Delete(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException($" entity must not be null");
        }

        try
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception)
        {
            throw new Exception($"{nameof(entity)} could not be delete");
        }
    }

    public IQueryable<TEntity> GetAll()
    {
        return  _context.Set<TEntity>().AsNoTracking();
    }

    public async Task<TEntity?> GetById(object id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity> Insert(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException($"{nameof(entity)} must not be null");
        }

        try
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception)
        {
            throw new Exception($"{nameof(entity)} could not be saved");
        }
    }

    public async Task<bool> Update(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException($"{nameof(entity)} must not be null");
        }

        try
        {
            _context.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception)
        {
            throw new Exception($"{nameof(entity)} could not be updated");
        }
    }
}
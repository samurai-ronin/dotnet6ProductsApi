using ProductsApi.Dtos;
using ProductsApi.Entities;

namespace ProductsApi.Interfaces.Repositories;
public interface IProductRepository:IRepository<Product>
{
    Task<Product> Create(ProductInputModel entity);
}
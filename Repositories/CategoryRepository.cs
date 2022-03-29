using ProductsApi.Data;
using ProductsApi.Entities;
using ProductsApi.Interfaces.Repositories;

namespace ProductsApi.Repositories;
public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(ProductContext context) : base(context)
    {
    }
}
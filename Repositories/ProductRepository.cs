using ProductsApi.Data;
using ProductsApi.Dtos;
using ProductsApi.Entities;
using ProductsApi.Interfaces.Repositories;

namespace ProductsApi.Repositories;
public class ProductRepository : Repository<Product>, IProductRepository
{
    private readonly ProductContext _context;
    public ProductRepository(ProductContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Product> Create(ProductInputModel productInputModel)
    {
        if (productInputModel == null)
        {
            throw new ArgumentNullException($"{nameof(productInputModel)} must not be null");
        }
        try
        {
            Product product = new(
                productInputModel.Name,
                productInputModel.Description,
                productInputModel.Price,
                productInputModel.Image,
                productInputModel.Color,
                productInputModel.CategoryId);
            _context.Add(product);
            foreach (var item in productInputModel.Sizes)
            {
                Size size = new(product.Id,item.TypeNumber);
                _context.Add(size);
            }
            await _context.SaveChangesAsync();
            return product;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
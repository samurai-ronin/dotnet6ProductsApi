using System.Collections.ObjectModel;

namespace ProductsApi.Dtos;
public class ProductOutputModel
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? Image { get; set; }
    public string? Color { get; set; }
    public Collection<SizeOutputModel>? Sizes { get; set; }
    public CategoryOutputModel? Category { get; set; }
}
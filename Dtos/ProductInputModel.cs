using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ProductsApi.Dtos;
public class ProductInputModel
{
    [Required]
    public string? Name { get; set; }
    public string? Description { get; set; }
    [Required]
    public decimal Price { get; set; }
    public string? Image { get; set; }
    public string? Color { get; set; }
    [Required]
    public Collection<SizeInputModel>? Sizes { get; set; }
    [Required]
    public Guid CategoryId { get; set; }
}
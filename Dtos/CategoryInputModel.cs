using System.ComponentModel.DataAnnotations;

namespace ProductsApi.Dtos;
public class CategoryInputModel
{
    [Required]
    public string? Name { get; set; }
}
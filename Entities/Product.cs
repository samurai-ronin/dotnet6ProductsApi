using System.Collections.ObjectModel;

namespace ProductsApi.Entities;
public class Product
{
    public Guid Id { get; private set; }
    public string? Name { get; private set; }
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public string? Image { get; private set; }
    public string? Color { get; private set; }
    public Collection<Size>? Sizes { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category? Category { get; private set; }
    public Product()
    {
        Id = new Guid();
    }
    public Product(string? name, string? description, decimal price, string? image, string? color, Guid categoryId)
    {
        Id = new Guid();
        Name = name;
        Description = description;
        Price = price;
        Image = image;
        Color = color;
        CategoryId = categoryId;
    }
}
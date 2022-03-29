namespace ProductsApi.Entities;
public class Category
{
    public Guid Id { get; private set; }
    public String? Name { get; private set; }
    public Category()
    {
        Id = new Guid();
    }
    public Category(string? name)
    {
        Id = new Guid();
        Name = name;
    }
}
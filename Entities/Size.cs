namespace ProductsApi.Entities;
public class Size
{
    public Guid Id { get; private set; }
    public Guid ProductId { get; private set; }
    public string? TypeNumber { get; private set; }
}
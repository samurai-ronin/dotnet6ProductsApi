namespace ProductsApi.Entities;
public class Size
{
    public Guid Id { get; private set; }
    public Guid ProductId { get; private set; }
    public string? TypeNumber { get; private set; }
    public Size()
    {
        
    }
    public Size(Guid productId, string? typeNumber)
    {
        Id = new Guid();
        ProductId = productId;
        TypeNumber = typeNumber;
    }
}
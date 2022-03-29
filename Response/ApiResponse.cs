namespace ProductsApi.Response;
public class ApiResponse
{
    public bool success { get; set; } = true;
    public string? message { get; set; }
    public object? data { get; set; }
}
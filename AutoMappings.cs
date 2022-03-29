using AutoMapper;
using ProductsApi.Dtos;
using ProductsApi.Entities;

namespace ProductsApi;
public class AutoMapping:Profile
{
    public AutoMapping()
    {
        CreateMap<Category,CategoryOutputModel>();
        CreateMap<Product,ProductOutputModel>();
        CreateMap<Size,SizeOutputModel>();
    }
}
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Dtos;
using ProductsApi.Entities;
using ProductsApi.Interfaces.Repositories;
using ProductsApi.Response;

namespace ProductsApi.Controllers;

[ApiController]
[Route("api/v1/[Controller]")]
public class ProductsController:ControllerBase
{
        private readonly IProductRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(IProductRepository repository,IMapper mapper,ILogger<ProductsController> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpPost()]
    public async Task<ActionResult<ApiResponse>> add([FromBody]ProductInputModel productInputModel)
    {
        ApiResponse response = new();
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            response.data = _mapper.Map<ProductOutputModel>(await _repository.Create(productInputModel));
            response.message = "Product created";
            _logger.LogInformation(response.message);
            return Created("nameof(GetById)",response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            response.message = ex.Message;
            response.success = false;
            return response;
        }
    }
}
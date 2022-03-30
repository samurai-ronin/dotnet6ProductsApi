using System.Collections.ObjectModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    [HttpGet()]
    public async Task<ActionResult<ApiResponse>> GetAll()
    {
        ApiResponse response = new();
        try
        {
            response.data = _mapper.Map<Collection<ProductOutputModel>>(await _repository.GetAll().Include(x=>x.Category).Include(x=>x.Sizes).ToListAsync());
            return  Ok(response);
        } 
        catch (Exception ex)
        {
            response.message = ex.Message;
            response.success = false;
            return response;
        }
    }

    [HttpGet("category/{categoryId}")]
    public async Task<ActionResult<ApiResponse>> GetAllByCategoryId(Guid categoryId)
    {
        ApiResponse response = new();
        try
        {
            response.data = _mapper.Map<Collection<ProductOutputModel>>(await _repository.GetAll()
            .Where(x=>x.CategoryId==categoryId)
            .Include(x=>x.Category)
            .Include(x=>x.Sizes)
            .ToListAsync());
            return  Ok(response);
        } 
        catch (Exception ex)
        {
            response.message = ex.Message;
            response.success = false;
            return response;
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse>> GetById(Guid id)
    {
        ApiResponse response = new();
        try
        {
            var product = _mapper.Map<ProductOutputModel>(await _repository.GetAll().Include(x=>x.Category).Include(x=>x.Sizes).FirstOrDefaultAsync(x=>x.Id==id));
            if (product is null)
            {
                return NotFound();
            }
            response.data = product;
            return  Ok(response);
        }
        catch (Exception ex)
        {
            response.message = ex.Message;
            response.success = false;
            return response;
        }
    }
}
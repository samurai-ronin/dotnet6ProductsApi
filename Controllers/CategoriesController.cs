using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Dtos;
using ProductsApi.Entities;
using ProductsApi.Interfaces.Repositories;
using ProductsApi.Response;

namespace ProductsApi.Controllers;

[ApiController]
[Route("api/v1/[Controller]")]
public class CategoriesController:ControllerBase
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<CategoriesController> _logger;

    public CategoriesController(ICategoryRepository repository,IMapper mapper,ILogger<CategoriesController> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpPost()]
    public async Task<ActionResult<ApiResponse>> add([FromBody]CategoryInputModel categoryInputModel)
    {
        ApiResponse response = new();
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Category category = new(categoryInputModel.Name);
            response.data = _mapper.Map<CategoryOutputModel>(await _repository.Insert(category));
            response.message = "Category created";
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

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse>> Edit(Guid id,[FromBody]CategoryInputModel categoryInputModel)
    {
        ApiResponse response = new();
        try
        {
            Category? category = await _repository.GetById(id);
            if (category is null)
            {
                return NotFound();
            }
            await _repository.Update(category);
            response.message = "Category updated";
            _logger.LogInformation(response.message);
            return Ok(response);
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
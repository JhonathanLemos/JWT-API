using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreAPI.Dtos;
using NetCoreAPI.Models;
using NetCoreAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IRepository<User> _repository;
    public UserController(IRepository<User> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAll input)
    {
        var query = _repository.GetAll();

        if (input.Search != null)
            query = query.Where(x => x.UserName.Contains(input.Search));

        int totalItems = query.Count();

        int skip = input.PageIndex * input.PageSize;

        var items = query.Skip(skip).Take(input.PageSize).ToList();
        var itemsDto = _mapper.Map<List<UserDto>?>(items);
        var result = new
        {
            TotalItems = totalItems,
            Items = itemsDto
        };

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _repository.GetById(id);
        if (result == null)
            return NotFound("Entidade não encontrada");

        return Ok(_mapper.Map<UserDto>(result));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        return Ok(await _repository.Add(user));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UserDto userDto)
    {
        var entity = await _repository.GetById(id);
        if (entity == null)
            return NotFound("Nenhum entidade encontrada!");

        _mapper.Map(userDto, entity);
        return Ok(await _repository.Update(entity));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _repository.GetById(id);
        if (result == null)
            return NotFound("Entidade nao encontrada");

        await _repository.Delete(result);
        return Ok();
    }
}

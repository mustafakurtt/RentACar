using Application.Features.Brands.Commands.Create;
using Application.Features.Models.Commands.Create;
using Application.Features.Models.Commands.CreateRange;
using Application.Features.Models.Queries.GetById;
using Application.Features.Models.Queries.GetList;
using Application.Features.Models.Queries.GetListByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ModelsController : BaseController
{
    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CreateModelCommand command)
    {
        var response = await Mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("addRange")]
    public async Task<IActionResult> AddRange([FromBody] CreateModelRangeCommand command)
    {
        var response = await Mediator.Send(command);
        return Ok(response);
    }

    [HttpGet("get/{id}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var query = new GetByIdModelQuery { Id = id };
        var response = await Mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("getList")]
    public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
    {
        var query = new GetListModelQuery { PageRequest = pageRequest };
        var response = await Mediator.Send(query);
        return Ok(response);
    }

    [HttpPost("getList/ByDynamic")]
    public async Task<IActionResult> GetAllByDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery dynamicQuery)
    {
        var query = new GetListByDynamicQuery { PageRequest = pageRequest, DynamicQuery = dynamicQuery };
        var response = await Mediator.Send(query);
        return Ok(response);
    }
}

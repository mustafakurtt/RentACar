using Application.Features.Types.Commands.Create;
using Application.Features.Types.Commands.CreateRange;
using Application.Features.Types.Queries.GetList;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Type = Domain.Entities.Type;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TypesController : BaseController
{
    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CreateTypeCommand createTypeCommand)
    {
        var response = await Mediator.Send(createTypeCommand);
        return Ok(response);
    }

    [HttpPost("addRange")]
    public async Task<IActionResult> AddRange([FromBody] CreateTypeRangeCommand createTypeRangeCommand)
    {
        var response = await Mediator.Send(createTypeRangeCommand);
        return Ok(response);
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetTypes([FromQuery] PageRequest pageRequest)
    {
        GetListTypeQuery getListTypeQuery = new GetListTypeQuery()
        {
            PageRequest = pageRequest
        };
        var response = await Mediator.Send(getListTypeQuery);
        return Ok(response);
    }
}

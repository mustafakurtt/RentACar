using Application.Features.Brands.Queries.GetList;
using Application.Features.Colors.Commands.Create;
using Application.Features.Colors.Commands.CreateRange;
using Application.Features.Colors.Queries.GetList;
using Application.Features.Fuels.Commands.Create;
using Application.Features.Fuels.Commands.CreateRange;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ColorsController : BaseController
{
    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CreateColorCommand createColorCommand)
    {
        var response = await Mediator.Send(createColorCommand);
        return Ok(response);
    }

    [HttpPost("addRange")]
    public async Task<IActionResult> AddRange([FromBody] CreateColorRangeCommand createColorRangeCommand)
    {
        var response = await Mediator.Send(createColorRangeCommand);
        return Ok(response);
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetColors([FromQuery] PageRequest pageRequest)
    {
        GetListColorQuery getListColorQuery= new GetListColorQuery()
        {
            PageRequest = pageRequest
        };
        var response = await Mediator.Send(getListColorQuery);
        return Ok(response);
    }
}


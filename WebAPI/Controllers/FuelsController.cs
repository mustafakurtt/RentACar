using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.CreateRange;
using Application.Features.Fuels.Queries.GetList;
using Application.Features.Fuels.Commands.Create;
using Application.Features.Fuels.Commands.CreateRange;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuelsController : BaseController
{
    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CreateFuelCommand createFuelCommand)
    {
        var response = await Mediator.Send(createFuelCommand);
        return Ok(response);
    }

    [HttpPost("addRange")]
    public async Task<IActionResult> AddRange([FromBody] CreateFuelRangeCommand createFuelRangeCommand)
    {
        var response = await Mediator.Send(createFuelRangeCommand);
        return Ok(response);
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetFuels([FromQuery] PageRequest pageRequest)
    {
        GetListFuelQuery getListFuelQuery = new GetListFuelQuery()
        {
            PageRequest = pageRequest
        };
        var response = await Mediator.Send(getListFuelQuery);
        return Ok(response);
    }
}
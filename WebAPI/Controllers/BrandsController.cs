using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.CreateRange;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Brands.Queries.GetList;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : BaseController
{

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
    {
        var response = await Mediator.Send(createBrandCommand);
        return Ok(response);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateBrandCommand updateBrandCommand)
    {
        var response = await Mediator.Send(updateBrandCommand);
        return Ok(response);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteBrandCommand deleteBrandCommand = new() { Id = id };
        var response = await Mediator.Send(deleteBrandCommand);
        return Ok(response);
    }

    [HttpPost("addRange")]
    public async Task<IActionResult> AddRange([FromBody] CreateBrandRangeCommand createBrandRangeCommand)
    {
        var response = await Mediator.Send(createBrandRangeCommand);
        return Ok(response);
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetBrands([FromQuery] PageRequest pageRequest)
    {
        GetListBrandQuery getListBrandQuery = new GetListBrandQuery
        {
            PageRequest = pageRequest
        };
        var response = await Mediator.Send(getListBrandQuery);
        return Ok(response);
    }

    [HttpGet("getById/{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdBrandQuery query = new() { Id = id };
        var response = await Mediator.Send(query);
        return Ok(response);
}
}

﻿namespace Application.Features.Models.Commands.Create;

public class CreatedModelResponse
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }
    public string ImageUrl { get; set; }
    public string Brand { get; set; }
    public string Fuel { get; set; }
    public string Color { get; set; }
    public string Transmission { get; set; }
    public string Type { get; set; }


}
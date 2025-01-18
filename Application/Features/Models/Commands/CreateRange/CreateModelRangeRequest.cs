namespace Application.Features.Models.Commands.CreateRange;

public class CreateModelRangeRequest
{
    public Guid BrandId { get; set; }
    public Guid FuelId { get; set; }
    public Guid ColorId { get; set; }
    public Guid TransmissionId { get; set; }
    public Guid TypeId { get; set; }
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }
    public string ImageUrl { get; set; }
}
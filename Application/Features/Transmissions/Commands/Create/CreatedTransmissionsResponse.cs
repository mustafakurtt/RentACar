namespace Application.Features.Transmissions.Commands.Create;

public class CreatedTransmissionsResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
}
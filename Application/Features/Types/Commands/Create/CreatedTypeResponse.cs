namespace Application.Features.Types.Commands.Create;

public class CreatedTypeResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
}
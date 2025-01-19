namespace Application.Features.Types.Commands.Delete;

public class DeletedTypeResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime DeletedDate { get; set; }
}
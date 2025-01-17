using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Brand : Entity<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Brand()
    {
        
    }

    public Brand(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}
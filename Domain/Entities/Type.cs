using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Type : Entity<Guid>
{
    public string Name { get; set; }
    public virtual ICollection<Model> Models { get; set; }

    public Type()
    {
        
    }

    public Type(Guid id, string name) : this()
    {
        Id = id;
        Name = name;
    }
}
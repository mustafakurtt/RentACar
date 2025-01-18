using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars").HasKey(b => b.Id);
        builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");

        builder.Property(x => x.ModelId).HasColumnName("ModelId");

        builder.Property(x => x.Plate).HasColumnName("Plate");
        builder.Property(x => x.ModelYear).HasColumnName("ModelYear");
        builder.Property(x => x.Kilometer).HasColumnName("Kilometer");
        builder.Property(x => x.CarState).HasColumnName("CarState");
        builder.Property(x => x.MinFindexScore).HasColumnName("MinFindexScore");

        builder.HasIndex(indexExpression: b => b.Plate, name: "UK_Cars_Plate").IsUnique();
        builder.HasOne(c => c.Model);
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}